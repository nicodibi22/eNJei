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
	/// Class	 : Estacionamiento
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Estacionamiento.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALEstacionamiento
	{

		/// <summary>
		/// Inserta registros dentro de la tabla Estacionamiento.
		/// </summary>
		/// <param name="descripcion"></param>
		/// <param name="calle"></param>
		/// <param name="altura"></param>
		/// <param name="datosAdicionales"></param>
		/// <param name="idBarrio"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static int Insert(string descripcion, string calle, int altura, string datosAdicionales, int idBarrio, decimal latitud, decimal longitud)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("EstacionamientoInsert");

			myDatabase.AddInParameter(myCommand,"@descripcion", DbType.String, descripcion);
			myDatabase.AddInParameter(myCommand,"@calle", DbType.String, calle);
			myDatabase.AddInParameter(myCommand,"@altura", DbType.Int32, altura);
			myDatabase.AddInParameter(myCommand,"@datosAdicionales", DbType.String, datosAdicionales);
			myDatabase.AddInParameter(myCommand,"@idBarrio", DbType.Int32, idBarrio);
            myDatabase.AddInParameter(myCommand, "@latitud", DbType.Decimal, latitud);
            myDatabase.AddInParameter(myCommand, "@longitud", DbType.Decimal, longitud);

            //Ejecuta la consulta y retorna el nuevo identity.
            int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla Estacionamiento.
		/// </summary>
		/// <param name="idEstacionamiento"></param>
		/// <param name="descripcion"></param>
		/// <param name="calle"></param>
		/// <param name="altura"></param>
		/// <param name="datosAdicionales"></param>
		/// <param name="idBarrio"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Update(int idEstacionamiento, string descripcion, string calle, int altura, string datosAdicionales, int idBarrio, decimal latitud, decimal longitud)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("EstacionamientoUpdate");

			myDatabase.AddInParameter(myCommand,"@idEstacionamiento", DbType.Int32, idEstacionamiento);
			myDatabase.AddInParameter(myCommand,"@descripcion", DbType.String, descripcion);
			myDatabase.AddInParameter(myCommand,"@calle", DbType.String, calle);
			myDatabase.AddInParameter(myCommand,"@altura", DbType.Int32, altura);
			myDatabase.AddInParameter(myCommand,"@datosAdicionales", DbType.String, datosAdicionales);
			myDatabase.AddInParameter(myCommand,"@idBarrio", DbType.Int32, idBarrio);
            myDatabase.AddInParameter(myCommand, "@latitud", DbType.Decimal, latitud);
            myDatabase.AddInParameter(myCommand, "@longitud", DbType.Decimal, longitud);


            myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla Estacionamiento por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Delete(int idEstacionamiento)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("EstacionamientoDelete");

			myDatabase.AddInParameter(myCommand,"@idEstacionamiento", DbType.Int32, idEstacionamiento);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla Estacionamiento a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByIdBarrio(int idBarrio)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("EstacionamientoDeleteByIdBarrio");

			myDatabase.AddInParameter(myCommand,"@idBarrio", DbType.Int32, idBarrio);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla Estacionamiento.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  Select(int idEstacionamiento) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("EstacionamientoSelect");

			myDatabase.AddInParameter(myCommand,"@idEstacionamiento", DbType.Int32, idEstacionamiento);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Estacionamiento.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("EstacionamientoSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Estacionamiento a través de una foreign key.
		/// </summary>
		/// <param name="idBarrio"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectByIdBarrio(int idBarrio) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("EstacionamientoSelectByIdBarrio");

			myDatabase.AddInParameter(myCommand,"@idBarrio", DbType.Int32, idBarrio);

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
