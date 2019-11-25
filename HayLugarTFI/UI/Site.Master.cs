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
using System.Data;
using BIZ;

namespace UI
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        public enum WarningType
        {
            Success,
            Info,
            Warning,
            Danger
        }

        public void ShowMessage(string mensaje, WarningType type)
        {
            //gets the controls from the page
            //Panel PanelMessage = Master.FindControl("Message") as Panel;
            //Label labelMessage = PanelMessage.FindControl("labelMessage") as Label;

            //sets the message and the type of alert, than displays the message
            labelMessage.Text = mensaje;
            Message.CssClass = string.Format("alert alert-{0} alert-dismissable", type.ToString().ToLower());
            Message.Attributes.Add("role", "alert");
            Message.Visible = true;
        }

        public void HiddenMessage()
        {
            Message.Visible = false;
        }

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
            Request.Browser.Adapters.Clear();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            /*if (HttpContext.Current.User.Identity.IsAuthenticated == true && 
                !manager.IsEmailConfirmed(HttpContext.Current.User.Identity.GetUserId()))
            {
                if (this.Page.AppRelativeVirtualPath.Contains("CS_Activation") && !string.IsNullOrEmpty(this.Page.ClientQueryString))
                    return;
                if (!this.Page.AppRelativeVirtualPath.Contains("ActivacionPendiente"))
                    Response.Redirect("~/Account/ActivacionPendiente.aspx");
                else
                    return;
            }*/
            

            if (HttpContext.Current.User.Identity.IsAuthenticated == true)
            {

                pestaniaMisViajes.Visible = true;
                pestaniaPlazasDisponibles.Visible = true;

                DataSet dsUsuario = BIZ.BIZDatosPersonales.SelectByIdUsr(Context.User.Identity.GetUserId());
                if (dsUsuario != null && dsUsuario.Tables.Count > 0 && dsUsuario.Tables[0].Rows.Count > 0
                    && dsUsuario.Tables[0].Rows[0]["nombre"] != null && dsUsuario.Tables[0].Rows[0]["nombre"].ToString() != string.Empty)
                {
                    string nombre = dsUsuario.Tables[0].Rows[0]["nombre"].ToString();                    
                    (this.loginView.FindControl("lblNombre") as Label).Text = nombre;
                }
                else
                {
                    (this.loginView.FindControl("lblNombre") as Label).Text = Context.User.Identity.GetUserName().Split('@')[0];
                }

                DataSet dsCuentaCorriente = BIZ.BIZCuentaCorriente.Select(Context.User.Identity.GetUserId());

                if (dsCuentaCorriente != null && dsCuentaCorriente.Tables != null && dsCuentaCorriente.Tables.Count > 0 && dsCuentaCorriente.Tables[0].Rows.Count > 0)
                {
                    (this.loginView.FindControl("lblCuentaCorriente") as Label).Text = "$" + dsCuentaCorriente.Tables[0].Rows[0]["saldo"].ToString();
                }
                else
                {
                    (this.loginView.FindControl("lblCuentaCorriente") as Label).Text = "$0,00";
                }
                                

                if (Context.User.IsInRole("Administrador"))
                {
                    pestaniaMiCuenta.Visible = true;
                    pestaniaAdm.Visible = true;
                    
                    (this.loginView.FindControl("imgStar") as Image).Visible = true;
                }
                else
                {
                    pestaniaMiCuenta.Visible = true;
                }
                
                if (Context.User.IsInRole("Propietario") || Context.User.IsInRole("Cond_Prop"))
                {
                    pestaniaRendimiento.Visible = true;
                    
                    (this.loginView.FindControl("imgKey") as Image).Visible = true;
                    
                    
                }

                if (Context.User.IsInRole("Propietario") || Context.User.IsInRole("Cond_Prop"))
                {
                    pestaniaEstacionamiento.Visible = true;
                }

                if (Context.User.IsInRole("Conductor") || Context.User.IsInRole("Cond_Prop"))
                {
                    (this.loginView.FindControl("imgCar") as Image).Visible = true;
                }
                
                
            }

        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            BIZBitacora.Insert(DateTime.Now, Context.User.Identity.GetUserId(), "FIN SESIÓN", "Logout");
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void ddlAdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAdm.SelectedValue == "1")
            { Response.Redirect("~/Zona.aspx"); }

            if (ddlAdm.SelectedValue == "2")
            { Response.Redirect("~/GestionCtaCte.aspx"); }

            if (ddlAdm.SelectedValue == "3")
            { Response.Redirect("~/Estacionamiento.aspx"); }

            if (ddlAdm.SelectedValue == "4")
            { Response.Redirect("~/MisReservas.aspx"); }

            if (ddlAdm.SelectedValue == "5")
            { Response.Redirect("~/Usuario.aspx"); }

            if (ddlAdm.SelectedValue == "6")
            { Response.Redirect("~/LiberarPlazas.aspx"); }

            if (ddlAdm.SelectedValue == "7")
            { Response.Redirect("~/Bitacora.aspx"); }
        }

        protected void ddlMiCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMiCuenta.SelectedValue == "1")
            { Response.Redirect("~/MisReservas.aspx"); }

            if (ddlMiCuenta.SelectedValue == "2")
            { Response.Redirect("~/CtaCte.aspx"); }

            if (ddlMiCuenta.SelectedValue == "3")
            { Response.Redirect("~/Reclamo.aspx"); }

            if (ddlMiCuenta.SelectedValue == "4")
            { Response.Redirect("~/MisDatosPersonales.aspx"); }

        }

        protected void ddlMisViajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMisViajes.SelectedValue == "1")
            { Response.Redirect("~/CalcularDistanciaMapa.aspx"); }

            if (ddlMisViajes.SelectedValue == "2")
            { Response.Redirect("~/CalculoEnvio.aspx"); }
        }
    }

}