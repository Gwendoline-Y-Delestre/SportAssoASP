using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportAssoASP
{
    public partial class Contact : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string userEmail = Context.User.Identity.GetUserName();
            ErrorMessage.Text = userEmail;

        }
    }
}