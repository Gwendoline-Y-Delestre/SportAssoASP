using SportAssoASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            //// Créer une connexion à la base de données
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    // Ouvrir la connexion
            //    connection.Open();

            //    // Créer une commande SQL avec le paramètre
            //    string queryString = "SELECT Nom, Prenom, Date_naissance, Email, Tel, Adresse  FROM Adherents";
            //    using (SqlCommand command = new SqlCommand(queryString, connection))
            //    {
            //        // Vérifier si des données ont été renvoyées
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                GridViewAdherents.DataSource = reader;
            //                GridViewAdherents.DataBind();
            //            }
            //        }


            //    }
            //    connection.Close();

            // Appeler la méthode pour récupérer les informations
            //string[] inscriptions = AdherentsAdmin.GetInscriptionInfo();

            //// Vérifier si des données ont été récupérées
            //if (inscriptions != null && inscriptions.Length > 0)
            //{
            //    // Lier les données au GridView
            //    GridViewAdherentsInscriptions.DataSource = new string[][] { inscriptions };
            //    GridViewAdherentsInscriptions.DataBind();
            //}

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Ouvrir la connexion
                connection.Open();

                // Créer une commande SQL avec le paramètre
                string queryString = "SELECT I.InscriptionID, A.Nom AS AdherentNom, A.Prenom AS AdherentPrenom, A.Date_naissance AS AdherentDateNaissance," +
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

        }
    }
}