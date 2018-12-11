using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
	/// -----------------------------------------------------------------------------
	/// Project	 : DAL
	/// Class	 : Vehiculo
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Vehiculo.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	10/12/2018 21:34:16
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALVehiculo
	{

		/// <summary>
		/// Inserta registros dentro de la tabla Vehiculo.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="marca"></param>
		/// <param name="modelo"></param>
		/// <param name="patente"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	10/12/2018 21:34:16
		/// </history>
		public static int Insert(string userId, string marca, string modelo, string patente)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("VehiculoInsert");

			myDatabase.AddInParameter(myCommand,"@userId", DbType.String, userId);
			myDatabase.AddInParameter(myCommand,"@marca", DbType.String, marca);
			myDatabase.AddInParameter(myCommand,"@modelo", DbType.String, modelo);
			myDatabase.AddInParameter(myCommand,"@patente", DbType.String, patente);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla Vehiculo.
		/// </summary>
		/// <param name="idVehiculo"></param>
		/// <param name="userId"></param>
		/// <param name="marca"></param>
		/// <param name="modelo"></param>
		/// <param name="patente"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	10/12/2018 21:34:16
		/// </history>
		public static void Update(decimal idVehiculo, string userId, string marca, string modelo, string patente)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("VehiculoUpdate");

			myDatabase.AddInParameter(myCommand,"@idVehiculo", DbType.Decimal, idVehiculo);
			myDatabase.AddInParameter(myCommand,"@userId", DbType.String, userId);
			myDatabase.AddInParameter(myCommand,"@marca", DbType.String, marca);
			myDatabase.AddInParameter(myCommand,"@modelo", DbType.String, modelo);
			myDatabase.AddInParameter(myCommand,"@patente", DbType.String, patente);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla Vehiculo por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	10/12/2018 21:34:16
		/// </history>
		public static void Delete(decimal idVehiculo)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("VehiculoDelete");

			myDatabase.AddInParameter(myCommand,"@idVehiculo", DbType.Decimal, idVehiculo);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla Vehiculo.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	10/12/2018 21:34:17
		/// </history>
		public static DataSet  Select(decimal idVehiculo) 
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("VehiculoSelect");

			myDatabase.AddInParameter(myCommand,"@idVehiculo", DbType.Decimal, idVehiculo);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Vehiculo.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	10/12/2018 21:34:17
		/// </history>
		public static DataSet  SelectAll()
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("VehiculoSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
