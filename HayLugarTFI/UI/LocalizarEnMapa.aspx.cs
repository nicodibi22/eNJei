using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCargarMapa_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "http://maps.google.com/maps/api/geocode/xml?address=" + txtDomicilio.Text + " " + txtLocalidad.Text + "&sensor=false";
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
    }
}