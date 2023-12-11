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

            // Créer une connexion à la base de données
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Ouvrir la connexion
                connection.Open();

                // Créer une commande SQL avec le paramètre
                string queryString = "SELECT Nom, Prenom, Date_naissance, Email, Tel, Adresse  FROM Adherents";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    // Vérifier si des données ont été renvoyées
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            GridViewAdherents.DataSource = reader;
                            GridViewAdherents.DataBind();
                        }
                    }


                }
                connection.Close();
            }
        }
    }
}