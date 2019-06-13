using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.IO;
using System.Text;
using Microsoft.AspNet.Identity;
using System.Drawing;
using System.Globalization;

namespace UI
{
    public partial class Estacionamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == true)
            {
                if (Context.User.IsInRole("Administrador"))
                {
                    cargarEstacionamientos();
                }
                else
                {
                    Response.Redirect("~/ErrorAcceso.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }

        private void cargarMapa()
        {
            try
            {
                string url = "https://maps.google.com/maps/api/geocode/xml?address=" + txtCalle.Text + " " + txtAltura.Text + "&sensor=false&key=AIzaSyBCJHG-OM17NkmG9kteZWkaMY2mvbY34rQ";
                WebRequest request = WebRequest.Create(url);
                using (WebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        DataSet dsResult = new DataSet();
                        dsResult.ReadXml(reader);
                        DataTable dtCoordinates = new DataTable();
                        dtCoordinates.Columns.AddRange(new DataColumn[4] { new DataColumn("Id", typeof(int)),
                        new DataColumn("Address", typeof(string)),
                        new DataColumn("Latitude",typeof(string)),
                        new DataColumn("Longitude",typeof(string)) });
                        foreach (DataRow row in dsResult.Tables["result"].Rows)
                        {
                            string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();
                            DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];
                            dtCoordinates.Rows.Add(row["result_id"], row["formatted_address"], location["lat"], location["lng"]);
                        }
                        GridView1.DataSource = dtCoordinates;
                        GridView1.DataBind();

                        string mapDireccion = "", mapDLatitud = "", mapLongitud = "", mapDescripcion = "";

                        for (int i = 0; i < GridView1.Rows.Count; i++)
                        {
                            mapDireccion = GridView1.Rows[i].Cells[1].Text.ToString();
                            mapDLatitud = GridView1.Rows[i].Cells[2].Text.ToString();
                            mapLongitud = GridView1.Rows[i].Cells[3].Text.ToString();
                            mapDescripcion = GridView1.Rows[i].Cells[0].Text.ToString() + "LALALALA";
                        }

                        DataTable table = new DataTable("Table1");
                        table.Columns.Add(new DataColumn("Name", typeof(string)));
                        table.Columns.Add(new DataColumn("Latitude", typeof(string)));
                        table.Columns.Add(new DataColumn("Longitude", typeof(string)));
                        table.Columns.Add(new DataColumn("Description", typeof(string)));

                        DataRow rowMap = table.NewRow();
                        rowMap["Name"] = mapDireccion;
                        rowMap["Latitude"] = mapDLatitud;
                        rowMap["Longitude"] = mapLongitud;
                        rowMap["Description"] = mapDescripcion;

                        //txtLatitud.Text = mapDLatitud.Replace('.',',');
                        //txtLongitud.Text = mapLongitud.Replace('.', ',');

                        Session["latitud"] = mapDLatitud;
                        Session["longitud"] = mapLongitud;

                        table.Rows.Add(rowMap);

                        rptMarkers.DataSource = table;
                        //rptMarkers.DataSource = GridView1.DataSource;
                        rptMarkers.DataBind();
                        GridView1.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                rptMarkers.DataSource = null;
                lblErrorMapa.Visible = true;
            }
        }

        private void cargarEstacionamientos()
        {

            ddlBarrios.DataSource = BIZBarrio.SelectAll();
            ddlBarrios.DataValueField = "idBarrio";
            ddlBarrios.DataTextField = "descripcion";
            ddlBarrios.DataBind();

            try
            {
                CultureInfo us = new CultureInfo("es-ES");
                gvEstacionamiento.DataSource = BIZEstacionamiento.SelectAll();
                gvEstacionamiento.DataBind();

                if (gvEstacionamiento.Rows.Count > 0)
                {
                    //Attribute to show the Plus Minus Button.
                    gvEstacionamiento.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gvEstacionamiento.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gvEstacionamiento.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            catch (Exception)
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargaMasiva.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            titleProdAccion.InnerText = "Agregar Estacionamiento";

            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            txtIdEstac.Visible = false;
            lblIdEstac.Visible = false;

            txtDescripcion.Enabled = true;
            txtCalle.Enabled = true;
            txtAltura.Enabled = true;
            txtDatosAdicionales.Enabled = true;
            //txtIdBarrio.Enabled = true;
            ddlBarrios.Enabled = true;
            lblLatitud.Visible = false;
            lblLongitud.Visible = false;

            txtLatitud.Visible = false;
            txtLongitud.Visible = false;

            //txtLatitud.Enabled = true;
            //txtLongitud.Enabled = true;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);


        }

        protected void gvEstacionamiento_RowEditing(object sender, GridViewEditEventArgs e)
        {
            cargarMapa();

            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            txtIdEstac.Text = gvEstacionamiento.Rows[e.NewEditIndex].Cells[0].Text.ToString();
            //txtDescripcion.Text = gvEstacionamiento.Rows[e.NewEditIndex].Cells[1].Text.ToString();
            txtDescripcion.Text = ((Label)gvEstacionamiento.Rows[e.NewEditIndex].FindControl("lblDescripcion")).Text.Substring(1).Replace(".", "").Replace(",", ".");

            txtCalle.Text = gvEstacionamiento.Rows[e.NewEditIndex].Cells[2].Text.ToString();
            txtAltura.Text = gvEstacionamiento.Rows[e.NewEditIndex].Cells[3].Text.ToString();
            txtDatosAdicionales.Text = gvEstacionamiento.Rows[e.NewEditIndex].Cells[4].Text.ToString();
            ddlBarrios.SelectedValue = gvEstacionamiento.Rows[e.NewEditIndex].Cells[8].Text.ToString();
            txtLatitud.Text = gvEstacionamiento.Rows[e.NewEditIndex].Cells[6].Text.ToString();
            txtLongitud.Text = gvEstacionamiento.Rows[e.NewEditIndex].Cells[7].Text.ToString();


            e.Cancel = true;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);

        }

        protected void gvEstacionamiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEstacionamiento.PageIndex = e.NewPageIndex;
            cargarEstacionamientos();

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estacionamiento.aspx");

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            cargarMapa();

            try
            {
                lblMensaje.Text = string.Empty;

                //txtLatitud.Text = mapDLatitud.Replace('.',',');
                //txtLongitud.Text = mapLongitud.Replace('.', ',');


                if (txtIdEstac.Text == string.Empty)
                {
                    BIZEstacionamiento.Insert(txtDescripcion.Text, txtCalle.Text, Convert.ToInt32(txtAltura.Text), txtDatosAdicionales.Text, Convert.ToInt32(ddlBarrios.SelectedValue), 
                        Convert.ToDecimal(Session["latitud"].ToString().Replace('.', ',')), Convert.ToDecimal(Session["longitud"].ToString().Replace('.', ',')));

                    //BIZEstacionamiento.Insert(txtDescripcion.Text, txtCalle.Text, Convert.ToInt32(txtAltura.Text), txtDatosAdicionales.Text, Convert.ToInt32(ddlBarrios.SelectedValue),
                    //Convert.ToDecimal(Session["latitud"].ToString().Replace('.', ',')), Convert.ToDecimal(Session["longitud"].ToString().Replace('.', ',')));


                }
                else
                {
                    BIZEstacionamiento.Update(Convert.ToInt32(txtIdEstac.Text), txtDescripcion.Text, txtCalle.Text, 
                        Convert.ToInt32(txtAltura.Text), txtDatosAdicionales.Text, Convert.ToInt32(ddlBarrios.SelectedValue), Convert.ToDecimal(txtLatitud.Text), Convert.ToDecimal(txtLongitud.Text));

                }
                txtIdEstac.Text = "";
                txtDescripcion.Text = "";
                txtCalle.Text = "";
                txtAltura.Text = "";
                txtDatosAdicionales.Text = "";
                txtIdEstac.Text = "";
                txtLatitud.Text = "";
                txtLongitud.Text = "";


                txtIdEstac.Visible = true;
                lblIdEstac.Visible = true;

                pnlTab2.Visible = false;
                pnlTab1.Visible = true;
                //divPrecio.Visible = false;
                lblMensaje.Text = string.Empty;
                cargarEstacionamientos();
            }
            catch (Exception ex)
            {
                string m = ex.Message;

                Response.Redirect("~/ErrorPage.aspx");
            }


        }

        protected void gvEstacionamiento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idEstacionamiento = (int)gvEstacionamiento.DataKeys[e.RowIndex].Value;
                BIZEstacionamiento.Delete(idEstacionamiento);
                cargarEstacionamientos();
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "alert('No se pudo eliminar la zona');", true);
            }

        }

   }
}