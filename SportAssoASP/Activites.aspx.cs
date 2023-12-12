using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportAssoASP
{
    public partial class Activites : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection MyConnexion = null;
            try
            {
                MyConnexion = new SqlConnection(connectionString);
                SqlCommand AllActivite = new SqlCommand("SELECT A.*, CONCAT(E.Nom, ' ', E.Prenom) AS NomPrenom FROM Activites A " +
                    "Inner Join Employes E ON A.EmployeID = E.EmployeID ORDER BY Sport, Heure; ", MyConnexion);
                MyConnexion.Open();
                using (SqlDataReader reader = AllActivite.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        GridActivites.DataSource = reader;
                        GridActivites.DataBind();
                    }
                }

                SqlDataReader MyReader = AllActivite.ExecuteReader();
                GridActivites.DataSource = MyReader;
                GridActivites.DataBind();
            }
            catch (Exception MyException)
            {
                string message = MyException.Message;
                ErreurMessage.Text = message;
            }
            finally
            {
                if (MyConnexion != null)
                {
                    if (MyConnexion.State == ConnectionState.Open)
                    {
                        MyConnexion.Close();
                    }
                }
            }
        }

        //protected void ModifActivite_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Modification")
        //    {
        //        // Récupérer l'identifiant de l'activité sélectionnée
        //        int activiteID;
        //        if (int.TryParse(e.CommandArgument.ToString(), out activiteID))
        //        {
        //            // Rediriger vers la page de téléchargement de documents avec l'identifiant de l'activité
        //            Response.Redirect($"EditActivites.aspx?activiteID={activiteID}");
        //        }
        //    }
        //}


        //protected void BindDataGridInActivites(GridView grid)
        //{
        //    // Connexion à la base de données et liaison des données à la GridView
        //    // Assurez-vous d'ajuster cela en fonction de votre logique actuelle
        //    // ...

        //    // Exemple (à adapter selon votre structure et logique)
        //    string selectQuery = "SELECT ActiviteID, Sport, Section, Jour, Heure, Prix, Capacite_max, EmployeID FROM Activites";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(selectQuery, connection))
        //        {
        //            connection.Open();
        //            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
        //            {
        //                DataTable dataTable = new DataTable();
        //                dataAdapter.Fill(dataTable);
        //                grid.DataSource = dataTable;
        //                grid.DataBind();
        //            }
        //        }
        //    }
        //}

    }
}