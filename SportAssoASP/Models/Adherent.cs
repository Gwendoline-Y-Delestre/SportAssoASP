using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;


namespace SportAssoASP.Models
{
    public class Adherent
    {
        static string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public  static int GetUserID(string userName)
        {
            
            int adherentID = 0;
            string readIdAsString = string.Empty;


            // Code pour insérer les informations dans la base de données
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Ouvrir la connexion
                connection.Open();

                // Créer une commande SQL avec le paramètre
                string queryString = "SELECT AdherentID From Adherents WHERE Adherents.Email = @Email";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    // Ajouter le paramètre
                    command.Parameters.AddWithValue("@Email", userName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Vous pouvez accéder aux colonnes de la table Adherents ici
                            readIdAsString = reader["AdherentID"].ToString();
                        }
                    }
                }

                // Fermer la connexion en dehors du bloc using(SqlCommand...)
                connection.Close();
            }
            int.TryParse(readIdAsString, out adherentID);
            return adherentID;
        }

        public static string[] GetUserInfo(int userID)
        {
            string[] userInfo = new string[7];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Ouvrir la connexion
                connection.Open();

                // Créer une commande SQL avec le paramètre
                string queryString = "SELECT AdherentID, Nom, Prenom, Email, Date_Naissance, Tel, Adresse From Adherents WHERE AdherentID = @ID";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    // Ajouter le paramètre
                    command.Parameters.AddWithValue("@ID", userID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Vous pouvez accéder aux colonnes de la table Adherents ici
                            userInfo[0] = reader["AdherentID"].ToString();
                            userInfo[1] = reader["Nom"].ToString();
                            userInfo[2] = reader["Prenom"].ToString();
                            userInfo[3] = reader["Email"].ToString();
                            userInfo[4] = reader["Date_naissance"].ToString();
                            userInfo[5] = reader["Tel"].ToString();
                            userInfo[6] = reader["Adresse"].ToString();
                        }
                    }
                }

                // Fermer la connexion en dehors du bloc using(SqlCommand...)
                connection.Close();
            }
            return userInfo;
        }

        public static GridView GetUserInscription(int userID)
        {
            GridView userInscription = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Ouvrir la connexion
                connection.Open();

                // Créer une commande SQL avec le paramètre
                string queryString = "SELECT A.ActiviteID, A.Sport, A.Section, A.Jour, A.Heure, A.Capacite_max, A.Prix " +
                    "FROM Activites A JOIN Inscription I ON A.ActiviteID = I.ActiviteID " +
                    "JOIN Adherents Adh ON I.AdherentID = Adh.AdherentID WHERE Adh.AdherentID = @AdherentID";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    // Ajouter le paramètre
                    command.Parameters.AddWithValue("@AdherentID", userID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userInscription = new GridView();
                            userInscription.DataSource = reader;
                            userInscription.DataBind();
                        }
                    }
                }

                // Fermer la connexion en dehors du bloc using(SqlCommand...)
                connection.Close();
            }

            // Convertir la liste en tableau avant de retourner
            
            return userInscription;
        }
    }
}