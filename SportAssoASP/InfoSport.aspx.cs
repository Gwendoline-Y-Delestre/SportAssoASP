using Microsoft.AspNet.Identity;
using SportAssoASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportAssoASP
{
    public partial class InfoSport : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                              
                if (Context.User.Identity.IsAuthenticated)
                {
                    UnAuth.Visible = false;
                    Auth.Visible = true;
                }
                else
                {
                    UnAuth.Visible = true;
                    Auth.Visible = false;
                }
                Afficher();

            }

        }
        protected void Afficher()
        {
            // Récupérer le paramètre "sport" de l'URL
            string sportName = Request.QueryString["sport"];

            if (!string.IsNullOrEmpty(sportName))
            {
                // Créer une connexion à la base de données
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Ouvrir la connexion
                    connection.Open();

                    // Créer une commande SQL avec le paramètre
                    string queryString = "SELECT ActiviteID, Section, Jour, Heure, Prix, CONCAT(Nom, ' ', Prenom) AS NomPrenom  " +
                        "FROM Activites A Inner Join Employes E ON A.EmployeID = E.EmployeID " +
                        "WHERE Sport = @Sport";
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        // Ajouter le paramètre
                        command.Parameters.AddWithValue("@Sport", sportName);


                        // Vérifier si des données ont été renvoyées
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (Context.User.Identity.IsAuthenticated)
                            {
                                GridViewActivitesAuth.DataSource = reader;
                                GridViewActivitesAuth.DataBind();
                            }
                            else
                            {
                                GridViewActivites.DataSource = reader;
                                GridViewActivites.DataBind();
                            }
                        }


                    }
                    connection.Close();
                }
            }
        }

        protected void GridViewActivitesAuth_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Inscription")
            {
                // Récupérer l'identifiant de l'activité sélectionnée
                int activiteID;
                if (int.TryParse(e.CommandArgument.ToString(), out activiteID))
                {
                    // Rediriger vers la page de téléchargement de documents avec l'identifiant de l'activité
                    Response.Redirect($"Inscription.aspx?activiteID={activiteID}");
                }
            }
        }
        protected void Inscription_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Récupérer la valeur de IsInscrit
                int adhID = Adherent.GetUserID(Context.User.Identity.GetUserName());
                bool isInscrit = GetInscription(adhID);
                
                // Trouver le bouton "S'inscrire" dans la ligne actuelle
                Button btnSInscrire = e.Row.FindControl("btnSInscrire") as Button;

                // Masquer le bouton si l'adhérent est déjà inscrit
                if (isInscrit)
                {
                    btnSInscrire.Visible = false;
                }
               
            }
        }

        protected bool GetInscription(int adhId)
        {
            string sportName = Request.QueryString["sport"];

            string query = "SELECT I.InscriptionID FROM Activites A " +
                "LEFT JOIN Inscription I ON A.ActiviteID = I.ActiviteID "+
                " WHERE A.Sport = @Sport AND I.AdherentID = @AdherentID ";

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connexion))
                {
                    cmd.Parameters.AddWithValue("@AdherentID", adhId);
                    cmd.Parameters.AddWithValue("@Sport", sportName);

                    connexion.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        connexion.Close();

                        return false;
                    }
                }
            }
        }

    }
}