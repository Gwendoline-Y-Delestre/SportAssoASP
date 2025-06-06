﻿using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SportAssoASP.Models;

namespace SportAssoASP.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            
           
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Valider le mot de passe de l'utilisateur
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // Ceci ne compte pas les échecs de connexion pour le verrouillage du compte
                // Pour que les échecs de mot passe déclenchent le verrouillage, utilisez shouldLockout: true
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                if (Email.Text == "admin@sport-asso.fr")
                {
                    switch (result)
                    {
                        case SignInStatus.Success:
                            IdentityHelper.RedirectToReturnUrl("~/Planning", Response);
                            break;
                        //case SignInStatus.LockedOut:
                        //    Response.Redirect("/Account/Lockout");
                        //    break;
                        case SignInStatus.Failure:
                        default:
                            FailureText.Text = "Tentative de connexion non valide";
                            ErrorMessage.Visible = true;
                            break;
                    }
                }
                else
                {
                    switch (result)
                    {
                        case SignInStatus.Success:
                            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                            break;
                        case SignInStatus.LockedOut:
                            Response.Redirect("/Account/Lockout");
                            break;
                        case SignInStatus.Failure:
                        default:
                            FailureText.Text = "Tentative de connexion non valide";
                            ErrorMessage.Visible = true;
                            break;
                    }
                }
                
            }
        }
    }
}