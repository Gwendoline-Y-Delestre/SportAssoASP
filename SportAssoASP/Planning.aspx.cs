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
    public partial class Planning : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            //SqlConnection MyConnexion = null;
            //try
            //{
            //    MyConnexion = new SqlConnection(connectionString);
            //    SqlCommand AllActivite = new SqlCommand("SELECT *, CONCAT(E.Nom, ' ', E.Prenom) AS NomPrenom " +
            //        "FROM Activites A INNER JOIN Employes E ON A.EmployeID = E.EmployeID O" +
            //        "RDER BY" +
            //        " CASE WHEN A.Jour = 'Lundi' THEN 1" +
            //        " WHEN A.Jour = 'Mardi' THEN 2 " +
            //        " WHEN A.Jour = 'Mercredi' THEN 3 " +
            //        "  WHEN A.Jour = 'Jeudi' THEN 4 " +
            //        " WHEN A.Jour = 'Vendredi' THEN 5 " +
            //        " WHEN A.Jour = 'Samedi' THEN 6 " +
            //        " WHEN A.Jour = 'Dimanche' THEN 7 " +
            //        " END,  A.Heure;", MyConnexion);
            //    MyConnexion.Open();
            //    using (SqlDataReader reader = AllActivite.ExecuteReader())
            //    {
            //        if (reader.HasRows)
            //        {
            //            DataGrid.DataSource = reader;
            //            DataGrid.DataBind();
            //        }
            //    }

            //    SqlDataReader MyReader = AllActivite.ExecuteReader();
            //    DataGrid.DataSource = MyReader;
            //    DataGrid.DataBind();
            //}
            //catch (Exception MyException)
            //{
            //    string message = MyException.Message;
            //    ErreurMessage.Text = message;
            //}
            //finally
            //{
            //    if (MyConnexion != null)
            //    {
            //        if (MyConnexion.State == ConnectionState.Open)
            //        {
            //            MyConnexion.Close();
            //        }
            //    }
            //}

            //Lundi();
            //Mardi();
            //Mercredi();
            //Jeudi();
            //Vendredi();
            //Samedi();
            //Dimanche();
            ChargerActivitesParJour("Mardi", GridLundi);

            ChargerActivitesParJour("Mardi", GridMardi);
            ChargerActivitesParJour("Mercredi", GridMercredi);
            ChargerActivitesParJour("Jeudi", GridJeudi);
            ChargerActivitesParJour("Vendredi", GridVendredi);
            ChargerActivitesParJour("Samedi", GridSamedi);
            ChargerActivitesParJour("Dimanche", GridDimanche);



        }
        public void Lundi()
        {
            SqlConnection MyConnexion = null;
            try
            {
                MyConnexion = new SqlConnection(connectionString);
                MyConnexion.Open();

                
                string query = "SELECT A.Sport, A.Heure, A.Section, CONCAT(E.Nom, ' ', E.Prenom) AS NomPrenom FROM Activites A " +
                    "INNER JOIN Employes E ON A.EmployeID = E.EmployeID WHERE A.Jour = 'Lundi' ORDER BY A.Heure";

                using (SqlCommand command = new SqlCommand(query, MyConnexion))
                {
                   using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            GridLundi.DataSource = reader;
                            GridLundi.DataBind();
                        }
                    }
                }
                
            }
            catch (Exception MyException)
            {
                string message = MyException.Message;
                ErreurMessage.Text = message;
            }
            finally
            {
                if (MyConnexion != null && MyConnexion.State == ConnectionState.Open)
                {
                    MyConnexion.Close();
                }
            }
        }

        public void Mardi()
        {
            SqlConnection MyConnexion = null;
            try
            {
                MyConnexion = new SqlConnection(connectionString);
                MyConnexion.Open();


                string query = "SELECT A.Sport, A.Heure, A.Section, CONCAT(E.Nom, ' ', E.Prenom) AS NomPrenom FROM Activites A " +
                    "INNER JOIN Employes E ON A.EmployeID = E.EmployeID WHERE A.Jour = 'Mardi' ORDER BY A.Heure";

                using (SqlCommand command = new SqlCommand(query, MyConnexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            GridMardi.DataSource = reader;
                            GridMardi.DataBind();
                        }
                    }
                }

            }
            catch (Exception MyException)
            {
                string message = MyException.Message;
                ErreurMessage.Text = message;
            }
            finally
            {
                if (MyConnexion != null && MyConnexion.State == ConnectionState.Open)
                {
                    MyConnexion.Close();
                }
            }
        }

        public void Mercredi()
        {
            SqlConnection MyConnexion = null;
            try
            {
                MyConnexion = new SqlConnection(connectionString);
                MyConnexion.Open();


                string query = "SELECT A.Sport, A.Heure, A.Section, CONCAT(E.Nom, ' ', E.Prenom) AS NomPrenom FROM Activites A " +
                    "INNER JOIN Employes E ON A.EmployeID = E.EmployeID WHERE A.Jour = 'Mercredi' ORDER BY A.Heure";

                using (SqlCommand command = new SqlCommand(query, MyConnexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            GridMercredi.DataSource = reader;
                            GridMercredi.DataBind();
                        }
                    }
                }

            }
            catch (Exception MyException)
            {
                string message = MyException.Message;
                ErreurMessage.Text = message;
            }
            finally
            {
                if (MyConnexion != null && MyConnexion.State == ConnectionState.Open)
                {
                    MyConnexion.Close();
                }
            }
        }

        public void Jeudi()
        {
            SqlConnection MyConnexion = null;
            try
            {
                MyConnexion = new SqlConnection(connectionString);
                MyConnexion.Open();


                string query = "SELECT A.Sport, A.Heure, A.Section, CONCAT(E.Nom, ' ', E.Prenom) AS NomPrenom FROM Activites A " +
                    "INNER JOIN Employes E ON A.EmployeID = E.EmployeID WHERE A.Jour = 'Lundi' ORDER BY A.Heure";

                using (SqlCommand command = new SqlCommand(query, MyConnexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            GridJeudi.DataSource = reader;
                            GridJeudi.DataBind();
                        }
                    }
                }

            }
            catch (Exception MyException)
            {
                string message = MyException.Message;
                ErreurMessage.Text = message;
            }
            finally
            {
                if (MyConnexion != null && MyConnexion.State == ConnectionState.Open)
                {
                    MyConnexion.Close();
                }
            }
        }


        public void Vendredi()
        {
            SqlConnection MyConnexion = null;
            try
            {
                MyConnexion = new SqlConnection(connectionString);
                MyConnexion.Open();


                string query = "SELECT A.Sport, A.Heure, A.Section, CONCAT(E.Nom, ' ', E.Prenom) AS NomPrenom FROM Activites A " +
                    "INNER JOIN Employes E ON A.EmployeID = E.EmployeID WHERE A.Jour = 'Vendredi' ORDER BY A.Heure";

                using (SqlCommand command = new SqlCommand(query, MyConnexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            GridVendredi.DataSource = reader;
                            GridVendredi.DataBind();
                        }
                    }
                }

            }
            catch (Exception MyException)
            {
                string message = MyException.Message;
                ErreurMessage.Text = message;
            }
            finally
            {
                if (MyConnexion != null && MyConnexion.State == ConnectionState.Open)
                {
                    MyConnexion.Close();
                }
            }
        }


        public void Samedi()
        {
            SqlConnection MyConnexion = null;
            try
            {
                MyConnexion = new SqlConnection(connectionString);
                MyConnexion.Open();


                string query = "SELECT A.Sport, A.Heure, A.Section, CONCAT(E.Nom, ' ', E.Prenom) AS NomPrenom FROM Activites A " +
                    "INNER JOIN Employes E ON A.EmployeID = E.EmployeID WHERE A.Jour = 'Samedi' ORDER BY A.Heure";

                using (SqlCommand command = new SqlCommand(query, MyConnexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            GridSamedi.DataSource = reader;
                            GridSamedi.DataBind();
                        }
                    }
                }

            }
            catch (Exception MyException)
            {
                string message = MyException.Message;
                ErreurMessage.Text = message;
            }
            finally
            {
                if (MyConnexion != null && MyConnexion.State == ConnectionState.Open)
                {
                    MyConnexion.Close();
                }
            }
        }
        public void Dimanche()
        {
            SqlConnection MyConnexion = null;
            try
            {
                MyConnexion = new SqlConnection(connectionString);
                MyConnexion.Open();


                string query = "SELECT A.Sport, A.Heure, A.Section, CONCAT(E.Nom, ' ', E.Prenom) AS NomPrenom FROM Activites A " +
                    "INNER JOIN Employes E ON A.EmployeID = E.EmployeID WHERE A.Jour = 'Dimanche' ORDER BY A.Heure";

                using (SqlCommand command = new SqlCommand(query, MyConnexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            GridDimanche.DataSource = reader;
                            GridDimanche.DataBind();
                        }
                    }
                }

            }
            catch (Exception MyException)
            {
                string message = MyException.Message;
                ErreurMessage.Text = message;
            }
            finally
            {
                if (MyConnexion != null && MyConnexion.State == ConnectionState.Open)
                {
                    MyConnexion.Close();
                }
            }
        }


        public void ChargerActivitesParJour(string jour, DataGrid grid)
        {
            SqlConnection MyConnexion = null;

            try
            {
                MyConnexion = new SqlConnection(connectionString);
                MyConnexion.Open();

                string query = "SELECT A.Sport, A.Heure, A.Section, CONCAT(E.Nom, ' ', E.Prenom) AS NomPrenom FROM Activites A " +
                    "INNER JOIN Employes E ON A.EmployeID = E.EmployeID WHERE A.Jour = @Jour ORDER BY A.Heure";

                using (SqlCommand command = new SqlCommand(query, MyConnexion))
                {
                    command.Parameters.AddWithValue("@Jour", jour);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            grid.DataSource = reader;
                            grid.DataBind();
                        }
                    }
                }
            }
            catch (Exception MyException)
            {
                string message = MyException.Message;
                ErreurMessage.Text = message;
            }
            finally
            {
                if (MyConnexion != null && MyConnexion.State == ConnectionState.Open)
                {
                    MyConnexion.Close();
                }
            }
        }

    }
}