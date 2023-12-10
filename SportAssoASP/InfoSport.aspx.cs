using Microsoft.AspNet.Identity;
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
                // Chaîne de connexion à votre base de données externe
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


                // Créer une connexion à la base de données
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Ouvrir la connexion
                    connection.Open();

                    // Créer une commande SQL avec le paramètre
                    string queryString = "SELECT ActiviteID, Section, Jour, Heure, Prix  FROM Activites WHERE Sport = @Sport";
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

    }
}