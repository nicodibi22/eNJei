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
	/// Class	 : OperacionesCtaCte
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla OperacionesCtaCte.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	25/11/2017 12:24:36
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALOperacionesCtaCte
	{

		/// <summary>
		/// Inserta registros dentro de la tabla OperacionesCtaCte.
		/// </summary>
		/// <param name="idCuenta"></param>
		/// <param name="monto"></param>
		/// <param name="fechaOperacion"></param>
		/// <param name="detalle"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	25/11/2017 12:24:36
		/// </history>
		public static int Insert(int idCuenta, decimal monto, DateTime fechaOperacion, string detalle, string tipoOperacion)
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("OperacionesCtaCteInsert");

			myDatabase.AddInParameter(myCommand,"@idCuenta", DbType.Int32, idCuenta);
			myDatabase.AddInParameter(myCommand,"@monto", DbType.Decimal, monto);
			myDatabase.AddInParameter(myCommand,"@fechaOperacion", DbType.DateTime, fechaOperacion);
			myDatabase.AddInParameter(myCommand,"@detalle", DbType.String, detalle);
            myDatabase.AddInParameter(myCommand, "@tipoOperacion", DbType.String, tipoOperacion);

            //Ejecuta la consulta y retorna el nuevo identity.
            int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla OperacionesCtaCte.
		/// </summary>
		/// <param name="idOperacion"></param>
		/// <param name="idCuenta"></param>
		/// <param name="monto"></param>
		/// <param name="fechaOperacion"></param>
		/// <param name="detalle"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	25/11/2017 12:24:36
		/// </history>
		public static void Update(int idOperacion, int idCuenta, decimal monto, DateTime fechaOperacion, string detalle, string tipoOperacion)
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("OperacionesCtaCteUpdate");

			myDatabase.AddInParameter(myCommand,"@IdOperacion", DbType.Int32, idOperacion);
			myDatabase.AddInParameter(myCommand,"@idCuenta", DbType.Int32, idCuenta);
			myDatabase.AddInParameter(myCommand,"@monto", DbType.Decimal, monto);
			myDatabase.AddInParameter(myCommand,"@fechaOperacion", DbType.DateTime, fechaOperacion);
			myDatabase.AddInParameter(myCommand,"@detalle", DbType.String, detalle);
            myDatabase.AddInParameter(myCommand, "@tipoOperacion", DbType.String, tipoOperacion);

            myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla OperacionesCtaCte.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	25/11/2017 12:24:36
		/// </history>
		public static DataSet  Select(string idUsr) 
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("OperacionesCtaCteSelect");

			myDatabase.AddInParameter(myCommand, "@idUsr", DbType.String, idUsr);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla OperacionesCtaCte.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	25/11/2017 12:24:36
		/// </history>
		public static DataSet  SelectAll()
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("OperacionesCtaCteSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
