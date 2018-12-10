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
	/// Class	 : Tarifa
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Tarifa.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALTarifa
	{

		/// <summary>
		/// Inserta registros dentro de la tabla Tarifa.
		/// </summary>
		/// <param name="idTipoEstadia"></param>
		/// <param name="idMedioPago"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static int Insert(int idTipoEstadia, int idMedioPago)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TarifaInsert");

			myDatabase.AddInParameter(myCommand,"@idTipoEstadia", DbType.Int32, idTipoEstadia);
			myDatabase.AddInParameter(myCommand,"@idMedioPago", DbType.Int32, idMedioPago);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla Tarifa.
		/// </summary>
		/// <param name="idTarifa"></param>
		/// <param name="idTipoEstadia"></param>
		/// <param name="idMedioPago"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Update(int idTarifa, int idTipoEstadia, int idMedioPago)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TarifaUpdate");

			myDatabase.AddInParameter(myCommand,"@idTarifa", DbType.Int32, idTarifa);
			myDatabase.AddInParameter(myCommand,"@idTipoEstadia", DbType.Int32, idTipoEstadia);
			myDatabase.AddInParameter(myCommand,"@idMedioPago", DbType.Int32, idMedioPago);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla Tarifa por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Delete(int idTarifa)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TarifaDelete");

			myDatabase.AddInParameter(myCommand,"@idTarifa", DbType.Int32, idTarifa);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla Tarifa a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByIdTipoEstadia(int idTipoEstadia)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TarifaDeleteByIdTipoEstadia");

			myDatabase.AddInParameter(myCommand,"@idTipoEstadia", DbType.Int32, idTipoEstadia);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla Tarifa a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByIdMedioPago(int idMedioPago)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TarifaDeleteByIdMedioPago");

			myDatabase.AddInParameter(myCommand,"@idMedioPago", DbType.Int32, idMedioPago);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla Tarifa.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  Select(int idTarifa) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TarifaSelect");

			myDatabase.AddInParameter(myCommand,"@idTarifa", DbType.Int32, idTarifa);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Tarifa.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TarifaSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Tarifa a través de una foreign key.
		/// </summary>
		/// <param name="idTipoEstadia"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectByIdTipoEstadia(int idTipoEstadia) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TarifaSelectByIdTipoEstadia");

			myDatabase.AddInParameter(myCommand,"@idTipoEstadia", DbType.Int32, idTipoEstadia);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Tarifa a través de una foreign key.
		/// </summary>
		/// <param name="idMedioPago"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectByIdMedioPago(int idMedioPago) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TarifaSelectByIdMedioPago");

			myDatabase.AddInParameter(myCommand,"@idMedioPago", DbType.Int32, idMedioPago);

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
