using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;

namespace DAL
{
    public static class DALUtilities
    {
        public static object ConfigurationManager { get; private set; }

        //static
        public static string GenerarIdMje()
        {
            String fecha = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("d2") + DateTime.Now.Day.ToString("d2") + DateTime.Now.Hour.ToString("d2") + DateTime.Now.Minute.ToString("d2") + DateTime.Now.Second.ToString("d3") + DateTime.Now.Millisecond.ToString("d3"); ;
            String id = fecha;
            return id;
        }
        public static string getConnection() {

            //string p1 = @"Data Source=JEISOLO-PC\SQLEXPRESS;Initial Catalog=hayLugarDB;Integrated Security=True";

            string p1 = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
            return p1;
        }
    }
}
