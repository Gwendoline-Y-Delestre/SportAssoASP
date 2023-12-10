using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SportAssoASP.Models;
using WebGrease.Activities;

namespace SportAssoASP.Account
{
    public partial class Register : Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (!chkAccepterConditions.Checked)
            {
                lblError.Text = "Vous devez accepter les conditions d'utilisation.";
                return;
            }
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                InsertUserIntoDatabase();

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }


        private void InsertUserIntoDatabase()
        {

            string email = Email.Text;
            string lastname = Nom.Text;
            string firstname = Prenom.Text;
            string birthdate = BirthDate.Text;
            string password = Password.Text;
            string adresse = Adresse.Text;
            int tel;
            // Vérifiez si le numéro de téléphone est valide
            if (!int.TryParse(Tel.Text, out tel))
            {
                lblError.Text = "Veuillez entrer un numéro de téléphone valide.";
                return;
            }
            // Vous devez utiliser des paramètres pour éviter les attaques par injection SQL
            string insertQuery = "INSERT INTO Adherents (Nom, Prenom, Date_naissance, Email, Tel, Adresse, Contact_urgenceID, Mot_de_passe) " +
                "VALUES (@Nom, @Prenom, @Date_naissance, @Email, @Tel, @Adresse, @Contact_urgenceID, @Mot_de_passe)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Paramètres
                    command.Parameters.AddWithValue("@Nom", lastname);
                    command.Parameters.AddWithValue("@Prenom", firstname);
                    command.Parameters.AddWithValue("@Date_naissance", Convert.ToDateTime(birthdate));
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Tel", tel);
                    command.Parameters.AddWithValue("@Contact_urgenceID", 1);
                    command.Parameters.AddWithValue("@Adresse", adresse);
                    command.Parameters.AddWithValue("@Mot_de_passe", password);

                    // Ouverture de la connexion et exécution de la commande
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        protected void cvAccepterConditions_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Valider manuellement si la case à cocher est cochée
            args.IsValid = chkAccepterConditions.Checked;
        }
    }
}