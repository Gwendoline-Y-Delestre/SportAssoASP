using SportAssoASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportAssoASP
{
    public partial class Employes : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Créer une liste pour stocker les données des employés
            List<Employe> employes = new List<Employe>();

            // Créer une connexion à la base de données
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Ouvrir la connexion
                connection.Open();

                // Créer une commande SQL avec le paramètre
                string queryString = "SELECT Nom, Prenom, Date_naissance, Email FROM Employes";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    // Vérifier si des données ont été renvoyées
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Créer un objet Employe avec les données actuelles
                            Employe employe = new Employe
                            {
                                Nom = reader["Nom"].ToString(),
                                Prenom = reader["Prenom"].ToString(),
                                Datedenaissane = reader["Date_naissance"].ToString(),
                                Email = reader["Email"].ToString()
                            };

                            // Ajouter l'employé à la liste
                            employes.Add(employe);
                        }
                    }
                }

                // Fermer la connexion
                connection.Close();
            }

            // Lier la liste des employés au GridView
            GridViewEmploye.DataSource = employes;
            GridViewEmploye.DataBind();
        }
    }
    
}