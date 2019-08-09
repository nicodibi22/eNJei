using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using Microsoft.AspNet.Identity;
using System.Data;

namespace UI
{
    public partial class Rendimiento : System.Web.UI.Page
    {
        decimal SaldoTotal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrillaCC();
        }

        private void cargarGrillaCC()
        {
            try
            {
                gv_DatosCocheras.DataSource = BIZReserva.SelectByPropietario(User.Identity.GetUserId());
                gv_DatosCocheras.DataBind();

                if (gv_DatosCocheras.Rows.Count > 0)
                {

                    //Attribute to show the Plus Minus Button.
                    gv_DatosCocheras.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gv_DatosCocheras.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gv_DatosCocheras.HeaderRow.TableSection = TableRowSection.TableHeader;

                    pnlTabcc.Visible = true;
                }
                else
                {
                    //pnlTabcc.Visible = false;
                    btnVerMovCC.Visible = false;
                }
            }
            catch (Exception)
            {
                Response.Redirect("ErrorDB.aspx");
            }
        }


        protected void btnVerMovCC_Click(object sender, EventArgs e)
        {
            BIZReserva.ReservaUpdateCerrado(Context.User.Identity.GetUserId());
            DataSet dsCuentaCorriente = BIZCuentaCorriente.Select(Context.User.Identity.GetUserId());

            int nroCuenta = Convert.ToInt32( dsCuentaCorriente.Tables[0].Rows[0]["nroCuenta"]);

            BIZCuentaCorriente.UpdateSaldo(nroCuenta, SaldoTotal*(-1));
            cargarGrillaCC();
        }

        protected void gv_DatosCocheras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblTotal = (Label)e.Row.FindControl("lblTarifa");
                SaldoTotal += Decimal.Parse(lblTotal.Text);
                
            }
        }
    }
}