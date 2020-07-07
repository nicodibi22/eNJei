using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using Microsoft.AspNet.Identity;

namespace UI
{
    public partial class PagoReserva : System.Web.UI.Page
    {

        private decimal ImporteCompra
        {
            set { ViewState["_ImporteCompra"] = value; }
            get { return ViewState["_ImporteCompra"] != null ? (decimal)ViewState["_ImporteCompra"] : 0; }
        }

        private decimal SaldoCuentaCorriente
        {
            set { ViewState["_SaldoCuentaCorriente"] = value; }
            get { return ViewState["_SaldoCuentaCorriente"] != null ? (decimal)ViewState["_SaldoCuentaCorriente"] : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {

                    DataSet dataset = BIZCuentaCorriente.Select(User.Identity.GetUserId());

                    if (dataset != null && dataset.Tables.Count > 0
                        && dataset.Tables[0].Rows.Count > 0)
                    {

                        SaldoCuentaCorriente = decimal.Parse(dataset.Tables[0].Rows[0].ItemArray[1].ToString());
                        lblCCNro.Text = dataset.Tables[0].Rows[0].ItemArray[0].ToString();
                        lblTotalSaldo.Text = dataset.Tables[0].Rows[0].ItemArray[1].ToString();
                        /*if (SaldoCuentaCorriente > 180)
                        {
                            ddlFormaPago.Items.Add(new ListItem("Cuenta Corriente", "ddlCC"));

                            lblCCNro.Text = dataset.Tables[0].Rows[0].ItemArray[0].ToString();
                            lblTotalSaldo.Text = dataset.Tables[0].Rows[0].ItemArray[1].ToString();
                        }*/

                    }

                    lblAvisoPago2.Text = Session["Importe_Reserva"].ToString();
                    ImporteCompra = decimal.Parse(lblAvisoPago2.Text);

                }
                catch (Exception)
                {

                }
            }

        }

        protected void ddlFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFormaPago.SelectedValue == "0")
            {
                string message = "Debe seleccionar una forma de pago.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                panelTC.Visible = false;
                panelCC.Visible = false;
                panelAviso.Visible = false;
            }

            if (ddlFormaPago.SelectedValue == "ddlTC")
            {
                panelTC.Visible = true; panelCC.Visible = false;
                panelAviso.Visible = true;
            }
            if (ddlFormaPago.SelectedValue == "ddlCC")
            {
                panelCC.Visible = true; panelTC.Visible = false;
                panelAviso.Visible = true;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MisReservas.aspx");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            lblErrorMensaje.Visible = false;
            try
            {
                bool pagoReserva = false;
                if (ddlFormaPago.SelectedValue == "0")
                {
                    string message = "Debe seleccionar una forma de pago.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);

                    lblErrorMensaje.Text = message;
                    lblErrorMensaje.Visible = true;
                    panelTC.Visible = false;
                    panelCC.Visible = false;
                }
                else
                {

                    if (ddlFormaPago.SelectedValue == "ddlTC")
                    {
                        btnConfirmar.ValidationGroup = "ValTarjetaCredito";
                        //consumir servicio
                        if(TarjetaValida())
                        {
                            BIZOperacionesTC.Insert(txtNroTarjeta.Text, Convert.ToDateTime("01/" + txtMes.Text + "/" + txtAnio.Text), Convert.ToInt32(txtCodSeg.Text), Convert.ToInt32(Session["Nro_Reserva"].ToString()), DateTime.Now, "", User.Identity.GetUserId());
                            pagoReserva = true;
                        }
                        else
                        {
                            string message = "Verifique los datos de la tarjeta ingresada";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                            lblErrorMensaje.Text = message;
                            lblErrorMensaje.Visible = true;
                        }
                        
                    }
                    else
                    {
                        btnConfirmar.ValidationGroup = "ValCuentaCorriente";
                        try
                        {
                            if (Convert.ToDecimal(Session["Importe_Reserva"].ToString()) < SaldoCuentaCorriente)
                            {
                                BIZCuentaCorriente.UpdateSaldo(Convert.ToInt32(lblCCNro.Text), Convert.ToDecimal(Session["Importe_Reserva"].ToString()));
                                BIZOperacionesCtaCte.Insert(Convert.ToInt32(lblCCNro.Text), Convert.ToDecimal(Session["Importe_Reserva"].ToString()), Utils.GetDateTimeLocal(), "Pago de la reserva Nro: " + Session["Nro_Reserva"].ToString(), "DEBITO");
                                pagoReserva = true;
                            }
                            else
                            {
                                //string message = "El saldo de su cuenta no es suficiente para pagar la reserva.";
                                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);

                                lblSaldoInsuficiente.Visible = true;

                            }

                        }
                        catch (Exception ex)
                        {
                            lblPyEconfirmado.Text = ex.Message;
                        }
                    }
                }
                if (pagoReserva)
                {
                    
                    //BIZReserva.PlazaUpdateStatePayment(Convert.ToInt32(Session["Nro_Reserva"].ToString()), true);
                    BIZReserva.ReservaUpdateStatePayment(Convert.ToInt32(Session["Nro_Reserva"].ToString()), Utils.GetDateTimeLocal(), true);
                    panelTotal.Visible = false;
                    lblPyEconfirmado.Visible = true;
                    btnContinuar.Visible = true;
                    btnMisReservas.Visible = true;
                }
                
            }
            catch (Exception)
            {
                string message = "Se ha producido un error en la operatoria. Volvé a ingresar a Mis Reservas e intentalo nuevamente";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                Response.Redirect("MisReservas.aspx");
            }

        }

        private bool TarjetaValida()
        {

            
            try
            {
                if (int.Parse(txtAnio.Text) < Utils.GetDateTimeLocal().Year)
                    return false;
                if (int.Parse(txtAnio.Text) == Utils.GetDateTimeLocal().Year && int.Parse(txtMes.Text) > Utils.GetDateTimeLocal().Month)
                    return false;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MisReservas.aspx");
        }

        protected void btnMisReservas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MisReservas.aspx");
        }
    }
}