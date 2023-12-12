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
    public partial class NewEmploye : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void CreateNewEmploye(object sender, EventArgs e)
        {
            string email = Email.Text;
            string lastname = Nom.Text;
            string firstname = Prenom.Text;
            string birthdate = BirthDate.Text;

            string insertQuery = "INSERT INTO Employes (Nom, Prenom, Date_naissance, Email) " +
            "VALUES (@Nom, @Prenom, @Date_naissance, @Email)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Paramètres
                        command.Parameters.AddWithValue("@Nom", lastname);
                        command.Parameters.AddWithValue("@Prenom", firstname);
                        command.Parameters.AddWithValue("@Date_naissance", Convert.ToDateTime(birthdate));
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                    }
                }
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                Response.Redirect("~/Employes.aspx");

            }
            catch (Exception ex)
            {
                lblErreur.Text = ex.Message;
            }
        }
    }
}