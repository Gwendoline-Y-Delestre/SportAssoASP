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
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection MyConnexion = null;
            try
            {
                MyConnexion = new SqlConnection(connectionString);
                SqlCommand AllActivite = new SqlCommand("SELECT * FROM Activites ORDER BY Heure, CASE WHEN jour = 'Lundi' THEN 1 WHEN jour = 'Mardi' THEN 2 " +
                    "WHEN jour = 'Mercredi' THEN 3 WHEN jour = 'Jeudi' THEN 4 WHEN jour = 'Vendredi' THEN 5 WHEN jour = 'Samedi' THEN 6 " +
                    "WHEN jour = 'Dimanche' THEN 7 END; ", MyConnexion);
                MyConnexion.Open();
                using (SqlDataReader reader = AllActivite.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DataGrid.DataSource = reader;
                        DataGrid.DataBind();
                    }
                }

                SqlDataReader MyReader = AllActivite.ExecuteReader();
                DataGrid.DataSource = MyReader;
                DataGrid.DataBind();
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
    }
}