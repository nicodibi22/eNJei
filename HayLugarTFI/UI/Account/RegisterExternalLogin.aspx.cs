using System;
using System.Web;
using BIZ;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using UI.Models;

namespace UI.Account
{
    public partial class RegisterExternalLogin : System.Web.UI.Page
    {
        protected string ProviderName
        {
            get { return (string)ViewState["ProviderName"] ?? String.Empty; }
            private set { ViewState["ProviderName"] = value; }
        }

        protected string ProviderAccountKey
        {
            get { return (string)ViewState["ProviderAccountKey"] ?? String.Empty; }
            private set { ViewState["ProviderAccountKey"] = value; }
        }

        private void RedirectOnFail()
        {
            Response.Redirect((User.Identity.IsAuthenticated) ? "~/Account/Manage" : "~/Account/Login");
        }

        protected void Page_Load()
        {
            // Procesar el resultado de un proveedor de autenticación en la solicitud
            ProviderName = IdentityHelper.GetProviderNameFromRequest(Request);
            if (String.IsNullOrEmpty(ProviderName))
            {
                RedirectOnFail();
                return;
            }
            if (!IsPostBack)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
                if (loginInfo == null)
                {
                    RedirectOnFail();
                    return;
                }
                var user = manager.Find(loginInfo.Login);
                if (user != null)
                {
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    Context.Session["loginGoogle"] = true;
                    IdentityHelper.RedirectToReturnUrl("~/default.aspx", Response);
                    
                }
                else if (User.Identity.IsAuthenticated)
                {
                    // Aplicar comprobación de Xsrf durante la vinculación
                    var verifiedloginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo(IdentityHelper.XsrfKey, User.Identity.GetUserId());
                    if (verifiedloginInfo == null)
                    {
                        RedirectOnFail();
                        return;
                    }

                    var result = manager.AddLogin(User.Identity.GetUserId(), verifiedloginInfo.Login);
                    if (result.Succeeded)
                    {
                        Context.Session["loginGoogle"] = true;
                        IdentityHelper.RedirectToReturnUrl("~/default.aspx", Response);
                    }
                    else
                    {
                        AddErrors(result);
                        return;
                    }
                }
                else
                {
                    email.Text = loginInfo.Email;
                }
            }
        }        
        
        protected void LogIn_Click(object sender, EventArgs e)
        {
            CreateAndLoginUser();
        }

        private void CreateAndLoginUser()
        {
            if (!IsValid)
            {
                return;
            }
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = email.Text, Email = email.Text };
            IdentityResult result = manager.Create(user);
            if (result.Succeeded)
            {

                var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
                if (loginInfo == null)
                {
                    RedirectOnFail();
                    return;
                }
                result = manager.AddLogin(user.Id, loginInfo.Login);
                if (result.Succeeded)
                {

                    //inserto el ROL para el usuario
                    BIZAspNetUserRoles.Insert(user.Id, "2");

                    //agregado para crear cuenta corriente cuando se registra
                    AltaCuentaCorriente(user.Id);

                    AltaDatosPersonales(user.Id, email.Text);

                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                    // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                    // var code = manager.GenerateEmailConfirmationToken(user.Id);
                    // Enviar este vínculo por correo electrónico: IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id)
                    Context.Session["loginGoogle"] = true;
                    IdentityHelper.RedirectToReturnUrl("~/default.aspx", Response);
                    return;
                }
            }
            AddErrors(result);
        }

        private void AddErrors(IdentityResult result) 
        {
            foreach (var error in result.Errors) 
            {
                ModelState.AddModelError("", error);
            }
        }

        private void AltaDatosPersonales(string id, string email)
        {
            try
            {
                BIZDatosPersonales.Insert(id, "DNI", "00000000", email, "9999999999", "MOVIL", "Nombre Apellido", string.Empty, string.Empty, string.Empty, string.Empty);
                BIZVehiculo.Insert(id, "MARCA", "MODELO", "XXX XXX");
            }
            catch (Exception)
            {
                return;
            }
        }

        private void AltaCuentaCorriente(string id)
        {
            try
            {
                BIZCuentaCorriente.Insert(id, 100, Utils.GetDateTimeLocal());
            }
            catch (Exception)
            {
                return;
            }

        }
    }
}