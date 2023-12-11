using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using SportAssoASP.Models;
using Stripe;
using Stripe.Terminal;

namespace SportAssoASP
{
    public partial class Inscription : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string assurancePath = null;
        string certificatpath = null;
        string accordPath = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            InfoInscription();

        }
        protected void InfoInscription()
        {
            // Récupérer le paramètre "sport" de l'URL
            if (int.TryParse(Request.QueryString["activiteID"], out int activiteID))
            {
                // Créer une connexion à la base de données
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Ouvrir la connexion
                    connection.Open();

                    // Créer une commande SQL avec le paramètre
                    string queryString = "SELECT ActiviteID, Section, Jour, Heure, Prix  FROM Activites WHERE ActiviteID = @ActiviteID";
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        // Ajouter le paramètre
                        command.Parameters.AddWithValue("@ActiviteID", activiteID);


                        // Vérifier si des données ont été renvoyées
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Accéder aux colonnes des résultats
                                string jour = reader["Jour"].ToString();
                                string heure = reader["Heure"].ToString();
                                string section = reader["Section"].ToString();
                                string prix = reader["Prix"].ToString();

                                RecapJour.Text = jour;
                                RecapHeure.Text = heure;
                                RecapSection.Text = section;
                                RecapPrix.Text = prix;

                            }

                        }
                    }
                    connection.Close();
                }
            }
            //StripeConfiguration.ApiKey = "sk_test_51OLUOYCrIsytqVYwpw2EYjy9ZXe1q21AfqMHkwKazlLKX3E1lubC9xgX3ptyI7XCpHtvoDRH63TfZkGd5t1K3KqR00YIl5ZUbI";
        }

        protected void Afficher_Paiement(object sender, EventArgs e)
        {
            HandleFileUpload(Assurance, StatusLabel1, "assurance");
            HandleFileUpload(Certificat, StatusLabel2, "certificat");
            HandleFileUpload(Accord, StatusLabel3, "accord");
            paiement.Visible = true;
        }

        // Attention plus d'exension (mais ça s'affiche quand meme sur mozilla"
        protected string HandleFileUpload(FileUpload fileUploadControl, Label StatusLabel, string filetype)
        {
            if (fileUploadControl.HasFile)
            {
                try
                {
                    string extension = Path.GetExtension(fileUploadControl.FileName).ToLower();

                    // Vérifiez le type de fichier
                    if (extension == ".pdf" || IsImage(extension))
                    {
                        // Vérifiez la taille du fichier (en octets)
                        int maxSizeInBytes = 5 * 1024 * 1024; // 4 Mo par exemple
                        if (fileUploadControl.FileBytes.Length <= maxSizeInBytes)
                        {
                            // Obtenez le chemin du dossier où vous souhaitez sauvegarder les fichiers
                            string uploadFolder = Server.MapPath("~/Uploads/");

                            // Créez le dossier s'il n'existe pas
                            if (!Directory.Exists(uploadFolder))
                            {
                                Directory.CreateDirectory(uploadFolder);
                            }

                            // Obtenez le nom du fichier
                            //string fileName = Path.GetFileName(fileUploadControl.FileName);
                            
                            // Construisez le chemin complet du fichier sur le serveur
                            string userid = Adherent.GetUserID(Context.User.Identity.GetUserName()).ToString();
                            string actId = Request.QueryString["activiteID"];

                            string NameBD = $"{filetype}_{userid}_{actId}{extension}";
                            string filePath = Path.Combine(uploadFolder, NameBD);

                            // Sauvegardez le fichier
                            fileUploadControl.SaveAs(filePath);

                            if (filetype == "assurance")
                            {
                                Session["AssurancePath"] = assurancePath = filePath;
                            }
                            else if (filetype == "certificat")
                            {
                                Session["CertificatPath"] = certificatpath = filePath;
                            }
                            else
                            {
                                Session["AccordPath"] = accordPath = filePath;
                            }

                            // Affichez un message de réussite
                            return StatusLabel.Text = "Upload réussi ! ";

                        }
                        else
                        {
                            return StatusLabel.Text = "La taille du fichier dépasse la limite autorisée. ";
                        }
                    }
                    else
                    {
                        return StatusLabel.Text = " Format incorrect. Veuillez télécharger un fichier PDF ou une image. ";
                    }
                }
                catch (Exception ex)
                {
                    return StatusLabel.Text = $"Erreur lors de l'upload du fichier . Message d'erreur : {ex.Message}. ";
                }
            }
            else
            {
                return InformationFichier.Text = "Vous n'avez pas fourni tout les documents, veillez à les déposer pour examination sur votre espace personnel avant votre 1ère participation";
            }
        }
        private bool IsImage(string extension)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            return imageExtensions.Contains(extension);
        }
        protected void Payer_Click(object sender, EventArgs e)
        {
            try
            {
                if (long.TryParse(NumeroCarte.Text, out long result1) && NumeroCarte.Text.Length == 16 && int.TryParse(CVC.Text, out int result2) && CVC.Text.Length == 3)
                {
                    // Vérifiez que les champs contiennent des valeurs non vides
                    if (!string.IsNullOrEmpty(MoisExpiration.SelectedValue) && !string.IsNullOrEmpty(AnneeExpiration.SelectedValue))
                    {

                        // Enregistrez les informations dans la base de données
                        EnregistrerDansLaBaseDeDonnees();

                        // Affichez un message de réussite
                        Message.Text = "Inscription effectuée avec avec succès! Veillez à fournir les documents nécessaire si ce n'est pas fait";
                    }
                    else
                    {
                        // Les valeurs ne sont pas valides, affichez un message d'erreur
                        Message.Text = "Veuillez remplir tous les champs du formulaire.";
                    }
                }
                else
                {
                    Message.Text = "Informations de carte incorrect";
                }
                    
            }
            catch (Exception ex)
            {
                // Affichez le message d'erreur détaillé pour le débogage
                Message.Text = "Erreur: " + ex.Message;
            }

            // REVOIR SI ON A LE TEMPS POUR FAIRE UN TRUC DE PAYEMENT
            //try
            //{
            //    // Vérifiez que les champs contiennent des valeurs non vides
            //    if (int.TryParse(MoisExpiration.Text, out int mois) && int.TryParse(AnneeExpiration.Text, out int annee))
            //    {
            //        // Les valeurs sont valides, vous pouvez les utiliser
            //        var tokenOptions = new TokenCreateOptions
            //        {
            //            Card = new TokenCardOptions
            //            {
            //                Number = NumeroCarte.Text,
            //                ExpMonth = mois.ToString(),
            //                ExpYear = annee.ToString(),
            //                Cvc = CVC.Text
            //            }
            //        };

            //        var tokenService = new TokenService();
            //        Token stripeToken = tokenService.Create(tokenOptions);

            //        // Utilisez le token pour effectuer des opérations côté serveur
            //        // Dans un scénario réel, vous stockeriez généralement le token dans la base de données et l'utiliseriez ultérieurement

            //        // Affichez un message de réussite
            //        Message.Text = "Paiement réussi! Token: " + stripeToken.Id;
            //    }
            //    else
            //    {
            //        // Les valeurs ne sont pas valides, affichez un message d'erreur
            //        Message.Text = "Veuillez saisir des valeurs valides pour le mois et l'année d'expiration.";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Affichez le message d'erreur détaillé pour le débogage
            //    Message.Text = "Erreur: " + ex.Message;
            //}
        }


        protected void EnregistrerDansLaBaseDeDonnees()
        {

            int adherent = Adherent.GetUserID(Context.User.Identity.GetUserName());

            int.TryParse(Request.QueryString["activiteID"], out int activite);


            // Code pour insérer les informations dans la base de données
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryString = "INSERT INTO Inscription (AdherentID, ActiviteID, Date_inscription, AssurancePath, CertificatPath, AccordParentalPath) " +
                    "VALUES (@AdherentID, @ActiviteID, @Date_inscription, @AssurancePath, @CertificatPath, @AccordParentalPath)";

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@AdherentID", adherent);
                    command.Parameters.AddWithValue("@ActiviteID", activite);
                    command.Parameters.AddWithValue("@Date_inscription", DateTime.Today);
                    command.Parameters.AddWithValue("@AssurancePath", Session["AssurancePath"] ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CertificatPath", Session["CertificatPath"] ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@AccordParentalPath", Session["AccordPath"] ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();

                }
                connection.Close();
                // Affichez un message de réussite
                Message.Text = "Informations de carte enregistrées avec succès!";
            }
        }

    }
}