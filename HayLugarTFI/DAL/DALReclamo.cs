using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;


namespace DAL
{
	/// -----------------------------------------------------------------------------
	/// Project	 : DAL
	/// Class	 : Reserva
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Reserva.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALReclamo
	{

		
		public static int Insert(int idReserva, string patente, string idUsuario)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ReclamoInsert");

			myDatabase.AddInParameter(myCommand,"@idReserva", DbType.Int32, idReserva);
            myDatabase.AddInParameter(myCommand, "@patente", DbType.String, patente);
			myDatabase.AddInParameter(myCommand,"@idUsuario", DbType.String, idUsuario);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

        public static DataSet SelectByIdUser(string idUsuario)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());

            DbCommand myCommand = myDatabase.GetStoredProcCommand("ReclamoSelectByIdUsuario");
            myDatabase.AddInParameter(myCommand, "@idUsuario", DbType.String, idUsuario);

            return myDatabase.ExecuteDataSet(myCommand);
        }

        public static DataSet SelectAll()
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("ReclamoSelectAll");

            return myDatabase.ExecuteDataSet(myCommand);
        }

        public static int Update(int idReclamo, string pathImagen)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("ReclamoUpdate");

            myDatabase.AddInParameter(myCommand, "@idReclamo", DbType.Int32, idReclamo);
            myDatabase.AddInParameter(myCommand, "@pathImagen", DbType.String, pathImagen);

            //Ejecuta la consulta y retorna el nuevo identity.
            int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
            return returnValue;
        }

        public static int UpdateStatus(int idReclamo, int idEstadoReclamo)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("ReclamoUpdateStatus");

            myDatabase.AddInParameter(myCommand, "@idReclamo", DbType.Int32, idReclamo);
            myDatabase.AddInParameter(myCommand, "@idEstado", DbType.Int32, idEstadoReclamo);

            //Ejecuta la consulta y retorna el nuevo identity.
            int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
            return returnValue;
        }
    }
}
