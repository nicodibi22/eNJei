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
	/// Class	 : Multa
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Multa.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALMulta
	{

		/// <summary>
		/// Inserta registros dentro de la tabla Multa.
		/// </summary>
		/// <param name="idTipoInfraccion"></param>
		/// <param name="idTarifa"></param>
		/// <param name="idUsuario"></param>
		/// <param name="rutaFotoMulta"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static int Insert(int idTipoInfraccion, int idTarifa, string idUsuario, string rutaFotoMulta)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("MultaInsert");

			myDatabase.AddInParameter(myCommand,"@idTipoInfraccion", DbType.Int32, idTipoInfraccion);
			myDatabase.AddInParameter(myCommand,"@idTarifa", DbType.Int32, idTarifa);
			myDatabase.AddInParameter(myCommand,"@idUsuario", DbType.String, idUsuario);
			myDatabase.AddInParameter(myCommand,"@rutaFotoMulta", DbType.String, rutaFotoMulta);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla Multa.
		/// </summary>
		/// <param name="idMulta"></param>
		/// <param name="idTipoInfraccion"></param>
		/// <param name="idTarifa"></param>
		/// <param name="idUsuario"></param>
		/// <param name="rutaFotoMulta"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Update(int idMulta, int idTipoInfraccion, int idTarifa, string idUsuario, string rutaFotoMulta)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("MultaUpdate");

			myDatabase.AddInParameter(myCommand,"@idMulta", DbType.Int32, idMulta);
			myDatabase.AddInParameter(myCommand,"@idTipoInfraccion", DbType.Int32, idTipoInfraccion);
			myDatabase.AddInParameter(myCommand,"@idTarifa", DbType.Int32, idTarifa);
			myDatabase.AddInParameter(myCommand,"@idUsuario", DbType.String, idUsuario);
			myDatabase.AddInParameter(myCommand,"@rutaFotoMulta", DbType.String, rutaFotoMulta);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla Multa por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Delete(int idMulta)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("MultaDelete");

			myDatabase.AddInParameter(myCommand,"@idMulta", DbType.Int32, idMulta);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla Multa a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByIdTarifa(int idTarifa)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("MultaDeleteByIdTarifa");

			myDatabase.AddInParameter(myCommand,"@idTarifa", DbType.Int32, idTarifa);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla Multa.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  Select(int idMulta) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("MultaSelect");

			myDatabase.AddInParameter(myCommand,"@idMulta", DbType.Int32, idMulta);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Multa.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("MultaSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Multa a través de una foreign key.
		/// </summary>
		/// <param name="idTarifa"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectByIdTarifa(int idTarifa) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("MultaSelectByIdTarifa");

			myDatabase.AddInParameter(myCommand,"@idTarifa", DbType.Int32, idTarifa);

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
