using SportAssoASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportAssoASP
{
    public partial class Adherents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Ouvrir la connexion
                connection.Open();

                // Créer une commande SQL avec le paramètre
                string queryString = "SELECT I.InscriptionID AS InscriptionID, A.Nom AS AdherentNom, A.Prenom AS AdherentPrenom, A.Date_naissance AS AdherentDateNaissance," +
                " A.Email AS AdherentEmail, AC.Nom AS ContactUrgenceNom, AC.Prenom AS ContactUrgencePrenom, AC.Email AS ContactUrgenceEmail," +
                " AC.Tel AS ContactUrgenceTel, AC.Relation AS ContactUrgenceRelation, Act.Sport AS ActiviteSport, Act.Section AS ActiviteSection," +
                " Act.Jour AS ActiviteJour, Act.Heure AS ActiviteHeure, Act.Capacite_max AS ActiviteCapaciteMax, Act.Prix AS ActivitePrix," +
                " I.Date_inscription AS InscriptionDateInscription, AssurancePath, CertificatPath, AccordParentalPath" +
                " FROM Inscription I INNER JOIN Adherents A ON I.AdherentID = A.AdherentID " +
                " INNER JOIN Contact_Urgence AC ON A.Contact_urgenceID = AC.ContactID " +
                " INNER JOIN Activites Act ON I.ActiviteID = Act.ActiviteID;";

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            GridViewAdherentsInscriptions.DataSource = reader;
                            GridViewAdherentsInscriptions.DataBind();
                        }
                    }
                }

                // Fermer la connexion en dehors du bloc using(SqlCommand...)
                connection.Close();
            }

            //GridViewAdherentsInscriptions.RowCommand += GridViewAdherentsInscriptions_RowCommand;

        }
        protected void DocView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AssuranceView")
            {
                // Récupérer l'identifiant de l'activité sélectionnée
                string AssurancePath = e.CommandArgument.ToString();
                    // Rediriger vers la page de téléchargement de documents avec l'identifiant de l'activité
                Response.Redirect("file:///"+AssurancePath);
                
            }
        }
        protected string GetDocumentPathFromDatabase(int documentID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string documentPath = null;

            // Remplacez "VotreRequeteSQL" par la requête SQL appropriée pour récupérer le chemin d'accès du document
            string query = "SELECT AssurancePath FROM Inscription WHERE InscriptionID = @InscriptionID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InscriptionID", documentID);

                    connection.Open();
                    documentPath = (string)command.ExecuteScalar();
                }
            }

            return documentPath;
        }

        protected string GetEncodedDocumentPathFromDatabase(int documentID)
        {
            string documentPath = GetDocumentPathFromDatabase(documentID);

            // Assurez-vous que le chemin d'accès est non null avant de l'encoder
            if (!string.IsNullOrEmpty(documentPath))
            {
                return Server.UrlEncode(documentPath);
            }

            return string.Empty;
        }
    }
}