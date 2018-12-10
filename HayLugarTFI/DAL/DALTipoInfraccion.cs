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
	/// Class	 : TipoInfraccion
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla TipoInfraccion.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALTipoInfraccion
	{

		/// <summary>
		/// Inserta registros dentro de la tabla TipoInfraccion.
		/// </summary>
		/// <param name="descripcion"></param>
		/// <param name="porcentaje"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static int Insert(string descripcion, decimal porcentaje)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TipoInfraccionInsert");

			myDatabase.AddInParameter(myCommand,"@descripcion", DbType.String, descripcion);
			myDatabase.AddInParameter(myCommand,"@porcentaje", DbType.Decimal, porcentaje);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla TipoInfraccion.
		/// </summary>
		/// <param name="idTipoInfraccion"></param>
		/// <param name="descripcion"></param>
		/// <param name="porcentaje"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Update(int idTipoInfraccion, string descripcion, decimal porcentaje)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TipoInfraccionUpdate");

			myDatabase.AddInParameter(myCommand,"@idTipoInfraccion", DbType.Int32, idTipoInfraccion);
			myDatabase.AddInParameter(myCommand,"@descripcion", DbType.String, descripcion);
			myDatabase.AddInParameter(myCommand,"@porcentaje", DbType.Decimal, porcentaje);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla TipoInfraccion por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Delete(int idTipoInfraccion)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TipoInfraccionDelete");

			myDatabase.AddInParameter(myCommand,"@idTipoInfraccion", DbType.Int32, idTipoInfraccion);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla TipoInfraccion.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  Select(int idTipoInfraccion) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TipoInfraccionSelect");

			myDatabase.AddInParameter(myCommand,"@idTipoInfraccion", DbType.Int32, idTipoInfraccion);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla TipoInfraccion.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("TipoInfraccionSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
