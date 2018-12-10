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
	/// Project	 : DAL.TDG
	/// Class	 : OperacionesTC
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla OperacionesTC.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	27/11/2017 23:27:18
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALOperacionesTC
	{

		/// <summary>
		/// Inserta registros dentro de la tabla OperacionesTC.
		/// </summary>
		/// <param name="nroTarjeta"></param>
		/// <param name="fechaVenc"></param>
		/// <param name="codSeg"></param>
		/// <param name="nroReserva"></param>
		/// <param name="fechaOperacion"></param>
		/// <param name="detalle"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	27/11/2017 23:27:18
		/// </history>
		public static int Insert(string nroTarjeta, DateTime fechaVenc, int codSeg, int nroReserva, DateTime fechaOperacion, string detalle, string UserId)
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("OperacionesTCInsert");

			myDatabase.AddInParameter(myCommand,"@nroTarjeta", DbType.String, nroTarjeta);
			myDatabase.AddInParameter(myCommand,"@fechaVenc", DbType.DateTime, fechaVenc);
			myDatabase.AddInParameter(myCommand,"@codSeg", DbType.Int32, codSeg);
			myDatabase.AddInParameter(myCommand,"@nroReserva", DbType.Int32, nroReserva);
			myDatabase.AddInParameter(myCommand,"@fechaOperacion", DbType.DateTime, fechaOperacion);
			myDatabase.AddInParameter(myCommand,"@detalle", DbType.String, detalle);
            myDatabase.AddInParameter(myCommand, "@UserId", DbType.String, UserId);

            //Ejecuta la consulta y retorna el nuevo identity.
            int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla OperacionesTC.
		/// </summary>
		/// <param name="idOperacion"></param>
		/// <param name="nroTarjeta"></param>
		/// <param name="fechaVenc"></param>
		/// <param name="codSeg"></param>
		/// <param name="nroReserva"></param>
		/// <param name="fechaOperacion"></param>
		/// <param name="detalle"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	27/11/2017 23:27:18
		/// </history>
		public static void Update(int idOperacion, string nroTarjeta, DateTime fechaVenc, int codSeg, int nroReserva, DateTime fechaOperacion, string detalle, string UserId)
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("OperacionesTCUpdate");

			myDatabase.AddInParameter(myCommand,"@IdOperacion", DbType.Int32, idOperacion);
			myDatabase.AddInParameter(myCommand,"@nroTarjeta", DbType.String, nroTarjeta);
			myDatabase.AddInParameter(myCommand,"@fechaVenc", DbType.DateTime, fechaVenc);
			myDatabase.AddInParameter(myCommand,"@codSeg", DbType.Int32, codSeg);
			myDatabase.AddInParameter(myCommand,"@nroReserva", DbType.Int32, nroReserva);
			myDatabase.AddInParameter(myCommand,"@fechaOperacion", DbType.DateTime, fechaOperacion);
			myDatabase.AddInParameter(myCommand,"@detalle", DbType.String, detalle);
            myDatabase.AddInParameter(myCommand, "@UserId", DbType.String, UserId);


            myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla OperacionesTC.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	27/11/2017 23:27:18
		/// </history>
		public static DataSet  Select(int idOperacion) 
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("OperacionesTCSelect");

			myDatabase.AddInParameter(myCommand,"@IdOperacion", DbType.Int32, idOperacion);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla OperacionesTC.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	27/11/2017 23:27:18
		/// </history>
		public static DataSet  SelectAll()
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("OperacionesTCSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
