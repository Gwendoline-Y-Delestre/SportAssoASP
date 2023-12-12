using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportAssoASP
{
    public partial class VisualiserDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string filePath = Request.QueryString["path"];

                if (!string.IsNullOrEmpty(filePath))
                {
                    if (IsImageFile(filePath))
                    {
                        ImageViewer.ImageUrl = filePath;
                        PdfViewer.Visible = false;
                    }
                    else if (IsPdfFile(filePath))
                    {
                        ImageViewer.Visible = false;
                        PdfViewer.Src = filePath;
                    }
                }
            }
        }

        private bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return !string.IsNullOrEmpty(extension) &&
                   (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                    extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                    extension.Equals(".gif", StringComparison.OrdinalIgnoreCase));
        }

        private bool IsPdfFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return !string.IsNullOrEmpty(extension) && extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase);
        }
    }
}