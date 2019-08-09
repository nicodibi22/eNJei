using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;

namespace UI
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // El código siguiente ayuda a proteger frente a ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Utilizar el token Anti-XSRF de la cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validar el token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (HttpContext.Current.User.Identity.IsAuthenticated == true &&
                !manager.IsEmailConfirmed(HttpContext.Current.User.Identity.GetUserId()))
            {
                if (this.Page.AppRelativeVirtualPath.Contains("CS_Activation") && !string.IsNullOrEmpty(this.Page.ClientQueryString))
                    return;
                if (!this.Page.AppRelativeVirtualPath.Contains("ActivacionPendiente"))
                    Response.Redirect("~/Account/ActivacionPendiente.aspx");
                else
                    return;
            }


            /*if (HttpContext.Current.User.Identity.IsAuthenticated == true)
            {
                pestaniaCalcDistancia.Visible = true;
                pestaniaPlazasDisponibles.Visible = true;

                if (Context.User.IsInRole("Administrador"))
                {
                    pestaniaMiCuenta.Visible = true;
                    pestaniaAdm.Visible = true;
                }
                else
                {
                    pestaniaMiCuenta.Visible = true;
                }

                if (Context.User.IsInRole("Propietario") || Context.User.IsInRole("Cond_Prop"))
                {
                    pestaniaRendimiento.Visible = true;
                }

                if (Context.User.IsInRole("Propietario") || Context.User.IsInRole("Cond_Prop"))
                {
                    pestaniaEstacionamiento.Visible = true;
                }
            }*/

        }
    }
}