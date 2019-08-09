using BIZ;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Account
{
    public partial class CS_Activation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string constr = BIZUtilites.getConnection();
                bool activo = false;
                string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM UserActivation WHERE ActivationCode = @ActivationCode"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                            cmd.Connection = con;
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            con.Close();
                            if (rowsAffected == 1)
                            {

                                

                                ltMessage.Text = "Felicitaciones! La activación de la cuenta se hizo satisfactoriamente. \r\nAhora ya podes iniciar sesión.";
                            }
                            else
                            {
                                ltMessage.Text = "No se pudo activar la cuenta. El código no es correcto. Escribinos a administracion@haylugar.com";
                            }
                        }
                    }
                }
                if (activo)
                {
                    BIZAspNetUsers.AspNetUsersUpdateEmailConfirmed(User.Identity.GetUserId());
                }
            }
        }
    }
}