using System;

namespace SportAssoASP
{
    public partial class Apercu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Récupérez les chemins des fichiers depuis la session
            string assurancePath = Session["AssurancePath"] as string;
            string certificatPath = Session["CertificatPath"] as string;
            string accordPath = Session["AccordPath"] as string;

            // Affichez les images s'il y a des chemins
            if (!string.IsNullOrEmpty(assurancePath))
            {
                imgAssurance.ImageUrl = ResolveUrl(assurancePath);
            }

            if (!string.IsNullOrEmpty(certificatPath))
            {
                imgCertificat.ImageUrl = ResolveUrl(certificatPath);
            }

            if (!string.IsNullOrEmpty(accordPath))
            {
                imgAccord.ImageUrl = ResolveUrl(accordPath);
            }
        }
    }
}
