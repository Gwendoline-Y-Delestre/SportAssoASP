using SportAssoASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Activities;
using static System.Collections.Specialized.BitVector32;

namespace SportAssoASP
{
    public partial class NewActivite : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Récupérer la liste d'employés depuis la base de données externe
                List<Employe> employes = GetEmployesFromDatabase();

                // Remplir le DropDownList avec les données des employés
                NewEmploye.DataSource = employes;
                NewEmploye.DataTextField = "NomPrenom"; // Champ affiché (nom de l'employé)
                NewEmploye.DataValueField = "EmployeID"; // Champ valeur (id de l'employé)
                NewEmploye.DataBind();
            }
        }
        public List<Employe> GetEmployesFromDatabase()
        {
            // Logique pour récupérer les données des employés depuis la base de données externe
            // Retournez une liste d'objets Employe
            List<Employe> employes = new List<Employe>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Remplacez "VotreTable" par le nom réel de votre table des employés
                string query = "SELECT EmployeID, CONCAT(Nom, ' ', Prenom) AS NomPrenom FROM Employes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employe employe = new Employe
                            {
                                EmployeID = Convert.ToInt32(reader["EmployeID"]),
                                //Nom = reader["Nom"].ToString(),
                                //Prenom = reader["Prenom"].ToString(),
                                NomPrenom = reader["NomPrenom"].ToString(),
                            };

                            employes.Add(employe);
                        }
                    }
                }
            }

            return employes;
        }

        public void CreateNewActivite(object sender, EventArgs e)
        {
            string sport = NewSport.SelectedValue;
            string section = NewSection.SelectedValue;
            string jour = NewJour.SelectedValue;
            string heure = NewHeure.SelectedValue;
            float prix = float.Parse(Prix.Text);
            int capMax = Convert.ToInt32(CapaciteMax.Text);
            int employeid = Convert.ToInt32(NewEmploye.SelectedValue);

            string insertQuery = "INSERT INTO Activites (Sport, Section, Jour, Heure, Capacite_max, Prix, EmployeID) " +
            "VALUES (@Sport, @Section, @Jour, @Heure, @Capacite_max, @Prix, @EmployeID)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Paramètres
                        command.Parameters.AddWithValue("@Sport", sport);
                        command.Parameters.AddWithValue("@Section", section);
                        command.Parameters.AddWithValue("@Jour", jour);
                        command.Parameters.AddWithValue("@Heure", heure);
                        command.Parameters.AddWithValue("@Capacite_max", capMax);
                        command.Parameters.AddWithValue("@Prix", prix);
                        command.Parameters.AddWithValue("@EmployeID", employeid);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                    }
                }
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                Response.Redirect("~/Activites.aspx");

            }
            catch (Exception ex)
            {
                lblErreur.Text =  ex.Message;
            }
        }
    }
    

}