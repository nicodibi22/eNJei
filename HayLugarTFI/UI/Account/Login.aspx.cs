﻿using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using UI.Models;
using BIZ;

namespace UI.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register";
            // Habilite esta opción una vez tenga la confirmación de la cuenta habilitada para la funcionalidad de restablecimiento de contraseña
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}
            if (HttpContext.Current.User.Identity.IsAuthenticated == true)
            {
                Response.Redirect("~/default.aspx");
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validar la contraseña del usuario
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // Esto no cuenta los errores de inicio de sesión hacia el bloqueo de cuenta
                // Para habilitar los errores de contraseña para desencadenar el bloqueo, cambie a shouldLockout: true
                
                var result = signinManager.PasswordSignIn(Email.Text, txtPassword.Text, RememberMe.Checked, shouldLockout: false);
                
                switch (result)
                {
                    case SignInStatus.Success:
                        //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);   
                        BIZBitacora.Insert(DateTime.Now, Context.User.Identity.GetUserId(), "INGRESO", "Login");
                        Response.Redirect("~/default.aspx");                        
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:

                        var res = manager.FindByEmail(Email.Text);
                        string mensaje = string.Empty;
                        if (res == null) 
                        {
                            mensaje = "No existe un usuario con el correo electrónico ingresado.";
                        }
                        else
                        {
                            mensaje = "La contraseña ingresada no es correcta.";
                        }
                        
                        FailureText.Text = mensaje;
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
        

    }
}