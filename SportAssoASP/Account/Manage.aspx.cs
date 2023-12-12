using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using SportAssoASP.Models;

namespace SportAssoASP.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
            GetUserInscritption();

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                // Déterminer les sections à afficher
               
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    ChangePassword.Visible = false;
                }

                // Afficher le message de réussite
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Enlever la chaîne de requête de l'action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Votre mot de passe a été changé."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        protected void GetUserInscritption()
        {
            int userId = Adherent.GetUserID(Context.User.Identity.GetUserName());
            List<InscriptionData> inscriptionDataList = new List<InscriptionData>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryString = "SELECT A.ActiviteID, A.Sport, A.Section, A.Jour, A.Heure, A.Capacite_max, A.Prix " +
                    "FROM Activites A JOIN Inscription I ON A.ActiviteID = I.ActiviteID " +
                    "JOIN Adherents Adh ON I.AdherentID = Adh.AdherentID WHERE Adh.AdherentID = @AdherentID";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@AdherentID", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Ajouter les données à la liste
                            InscriptionData inscriptionData = new InscriptionData
                            {
                                ActiviteID = Convert.ToInt32(reader["ActiviteID"]),
                                Sport = reader["Sport"].ToString(),
                                Section = reader["Section"].ToString(),
                                Jour = reader["Jour"].ToString(),
                                Heure = reader["Heure"].ToString(),
                                Capacite_max = Convert.ToInt32(reader["Capacite_max"]),
                                Prix = Convert.ToDecimal(reader["Prix"])
                            };

                            inscriptionDataList.Add(inscriptionData);
                        }
                    }
                }

                // Fermer la connexion en dehors du bloc using(SqlCommand...)
                connection.Close();
            }

            // Lier la liste au GridView
            MesInscriptions.DataSource = inscriptionDataList;
            MesInscriptions.DataBind();

            // Remplir les autres informations de l'utilisateur
            string[] userInfo = Adherent.GetUserInfo(userId);
            Nom.Text = userInfo[1];
            Prenom.Text = userInfo[2];
            Email.Text = userInfo[3];
            Tel.Text = userInfo[5];
            Adresse.Text = userInfo[6];
        }

    }
}