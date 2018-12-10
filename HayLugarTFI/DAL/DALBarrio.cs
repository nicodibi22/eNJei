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
	/// Class	 : Barrio
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Barrio.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALBarrio
	{

		/// <summary>
		/// Inserta registros dentro de la tabla Barrio.
		/// </summary>
		/// <param name="descripcion"></param>
		/// <param name="idZona"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static int Insert(string descripcion, int idZona)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("BarrioInsert");

			myDatabase.AddInParameter(myCommand,"@descripcion", DbType.String, descripcion);
			myDatabase.AddInParameter(myCommand,"@idZona", DbType.Int32, idZona);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla Barrio.
		/// </summary>
		/// <param name="idBarrio"></param>
		/// <param name="descripcion"></param>
		/// <param name="idZona"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Update(int idBarrio, string descripcion, int idZona)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("BarrioUpdate");

			myDatabase.AddInParameter(myCommand,"@idBarrio", DbType.Int32, idBarrio);
			myDatabase.AddInParameter(myCommand,"@descripcion", DbType.String, descripcion);
			myDatabase.AddInParameter(myCommand,"@idZona", DbType.Int32, idZona);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla Barrio por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Delete(int idBarrio)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("BarrioDelete");

			myDatabase.AddInParameter(myCommand,"@idBarrio", DbType.Int32, idBarrio);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla Barrio a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByIdZona(int idZona)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("BarrioDeleteByIdZona");

			myDatabase.AddInParameter(myCommand,"@idZona", DbType.Int32, idZona);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla Barrio.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  Select(int idBarrio) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("BarrioSelect");

			myDatabase.AddInParameter(myCommand,"@idBarrio", DbType.Int32, idBarrio);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Barrio.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("BarrioSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Barrio a través de una foreign key.
		/// </summary>
		/// <param name="idZona"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectByIdZona(int idZona) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("BarrioSelectByIdZona");

			myDatabase.AddInParameter(myCommand,"@idZona", DbType.Int32, idZona);

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
