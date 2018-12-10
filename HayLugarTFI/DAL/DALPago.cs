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
	/// Class	 : Pago
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Pago.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALPago
	{

		/// <summary>
		/// Inserta registros dentro de la tabla Pago.
		/// </summary>
		/// <param name="fechaPago"></param>
		/// <param name="importe"></param>
		/// <param name="idMulta"></param>
		/// <param name="idReserva"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static int Insert(DateTime fechaPago, decimal importe, int idMulta, int idReserva)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PagoInsert");

			myDatabase.AddInParameter(myCommand,"@fechaPago", DbType.DateTime, fechaPago);
			myDatabase.AddInParameter(myCommand,"@importe", DbType.Decimal, importe);
			myDatabase.AddInParameter(myCommand,"@idMulta", DbType.Int32, idMulta);
			myDatabase.AddInParameter(myCommand,"@idReserva", DbType.Int32, idReserva);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla Pago.
		/// </summary>
		/// <param name="idPago"></param>
		/// <param name="fechaPago"></param>
		/// <param name="importe"></param>
		/// <param name="idMulta"></param>
		/// <param name="idReserva"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Update(int idPago, DateTime fechaPago, decimal importe, int idMulta, int idReserva)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PagoUpdate");

			myDatabase.AddInParameter(myCommand,"@idPago", DbType.Int32, idPago);
			myDatabase.AddInParameter(myCommand,"@fechaPago", DbType.DateTime, fechaPago);
			myDatabase.AddInParameter(myCommand,"@importe", DbType.Decimal, importe);
			myDatabase.AddInParameter(myCommand,"@idMulta", DbType.Int32, idMulta);
			myDatabase.AddInParameter(myCommand,"@idReserva", DbType.Int32, idReserva);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla Pago por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Delete(int idPago)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PagoDelete");

			myDatabase.AddInParameter(myCommand,"@idPago", DbType.Int32, idPago);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla Pago a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByIdMulta(int idMulta)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PagoDeleteByIdMulta");

			myDatabase.AddInParameter(myCommand,"@idMulta", DbType.Int32, idMulta);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla Pago a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByIdReserva(int idReserva)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PagoDeleteByIdReserva");

			myDatabase.AddInParameter(myCommand,"@idReserva", DbType.Int32, idReserva);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla Pago.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  Select(int idPago) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PagoSelect");

			myDatabase.AddInParameter(myCommand,"@idPago", DbType.Int32, idPago);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Pago.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectAll()
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PagoSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Pago a través de una foreign key.
		/// </summary>
		/// <param name="idMulta"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectByIdMulta(int idMulta) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PagoSelectByIdMulta");

			myDatabase.AddInParameter(myCommand,"@idMulta", DbType.Int32, idMulta);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Pago a través de una foreign key.
		/// </summary>
		/// <param name="idReserva"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectByIdReserva(int idReserva) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PagoSelectByIdReserva");

			myDatabase.AddInParameter(myCommand,"@idReserva", DbType.Int32, idReserva);

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
