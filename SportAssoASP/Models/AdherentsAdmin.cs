using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SportAssoASP.Models
{
    public class AdherentsAdmin
    {
        static string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static string[] GetInscriptionInfo()
        {
            string[] inscriptions = new string[16];

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
                            // Vous pouvez accéder aux colonnes de la table Adherents ici
                            inscriptions[0] = reader["AdherentNom"].ToString();
                            inscriptions[1] = reader["AdherentPrenom"].ToString();
                            inscriptions[2] = reader["AdherentDateNaissance"].ToString();
                            inscriptions[3] = reader["AdherentEmail"].ToString();
                            inscriptions[4] = reader["ContactUrgenceNom"].ToString();
                            inscriptions[5] = reader["ContactUrgencePrenom"].ToString();
                            inscriptions[6] = reader["ContactUrgenceEmail"].ToString();
                            inscriptions[7] = reader["ContactUrgenceTel"].ToString();
                            inscriptions[8] = reader["ActiviteSport"].ToString();
                            inscriptions[9] = reader["ActiviteSection"].ToString();
                            inscriptions[10] = reader["ActiviteJour"].ToString();
                            inscriptions[11] = reader["ActiviteHeure"].ToString();
                            inscriptions[12] = reader["InscriptionDateInscription"].ToString();
                            inscriptions[13] = reader["AssurancePath"].ToString();
                            inscriptions[14] = reader["CertificatPath"].ToString();
                            inscriptions[15] = reader["AccordParentalPath"].ToString();
                        }
                    }
                }

                // Fermer la connexion en dehors du bloc using(SqlCommand...)
                connection.Close();
            }
            return inscriptions;
        }
    }
}