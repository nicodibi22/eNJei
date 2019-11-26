using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using UI.Models;
using BIZ;
using System.Data;
using System.Data.SqlClient;

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
                string query = "select * from aspnetusers, UserActivation where email  = '" + Email.Text + "' and id = UserId";

                if(GetData(query).Rows.Count > 0)
                    Response.Redirect("/Account/ActivacionPendiente");

                var result = signinManager.PasswordSignIn(Email.Text, txtPassword.Text, RememberMe.Checked, shouldLockout: false);
                
                switch (result)
                {
                    case SignInStatus.Success:
                        //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);   
                        
                        
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

        private DataTable GetData(string query)
        {
            //string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string conString = BIZUtilites.getConnection();
            //string conString = @"workstation id=haylugardbnew.mssql.somee.com;packet size=4096;user id=sbiondini_SQLLogin_2;pwd=z9j9uo7kaq;data source=haylugardbnew.mssql.somee.com;persist security info=False;initial catalog=haylugardbnew";


            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }
}