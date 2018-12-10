using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace DAL
{
	/// -----------------------------------------------------------------------------
	/// Project	 : DAL
	/// Class	 : Zona
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Zona.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALZona
	{

		/// <summary>
		/// Inserta registros dentro de la tabla Zona.
		/// </summary>
		/// <param name="descripcion"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static int Insert(string descripcion, string direccion, decimal precioKm)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ZonaInsert");

			myDatabase.AddInParameter(myCommand,"@descripcion", DbType.String, descripcion);
            myDatabase.AddInParameter(myCommand, "@direccion", DbType.String, direccion);
            myDatabase.AddInParameter(myCommand, "@precioKm", DbType.Decimal, precioKm);

            //Ejecuta la consulta y retorna el nuevo identity.
            int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla Zona.
		/// </summary>
		/// <param name="idZona"></param>
		/// <param name="descripcion"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Update(int idZona, string descripcion, string direccion, decimal precioKm)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ZonaUpdate");

			myDatabase.AddInParameter(myCommand,"@idZona", DbType.Int32, idZona);
			myDatabase.AddInParameter(myCommand,"@descripcion", DbType.String, descripcion);
            myDatabase.AddInParameter(myCommand, "@direccion", DbType.String, direccion);
            myDatabase.AddInParameter(myCommand, "@precioKm", DbType.Decimal, precioKm);
            myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla Zona por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Delete(int idZona)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ZonaDelete");

			myDatabase.AddInParameter(myCommand,"@idZona", DbType.Int32, idZona);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla Zona.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  Select(int idZona) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ZonaSelect");

			myDatabase.AddInParameter(myCommand,"@idZona", DbType.Int32, idZona);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Zona.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ZonaSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
