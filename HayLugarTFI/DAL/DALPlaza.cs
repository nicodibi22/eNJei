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
	/// Class	 : Plaza
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Plaza.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALPlaza
	{

		/// <summary>
		/// Inserta registros dentro de la tabla Plaza.
		/// </summary>
		/// <param name="idEstacionamiento"></param>
		/// <param name="idUsuario"></param>
		/// <param name="idTarifa"></param>
		/// <param name="disponible"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static int Insert(int idEstacionamiento, string idUsuario, int idTarifa, bool disponible, bool pago)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaInsert");

			myDatabase.AddInParameter(myCommand,"@idEstacionamiento", DbType.Int32, idEstacionamiento);
			myDatabase.AddInParameter(myCommand,"@idUsuario", DbType.String, idUsuario);
			myDatabase.AddInParameter(myCommand,"@idTarifa", DbType.Int32, idTarifa);
			myDatabase.AddInParameter(myCommand,"@disponible", DbType.Boolean, disponible);
            //myDatabase.AddInParameter(myCommand, "@pago", DbType.Boolean, pago);

            //Ejecuta la consulta y retorna el nuevo identity.
            int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
            return returnValue;
		}

        /// <summary>
        /// Actualiza registros de la tabla Plaza.
        /// </summary>
        /// <param name="idPlaza"></param>
        /// <param name="idEstacionamiento"></param>
        /// <param name="idUsuario"></param>
        /// <param name="idTarifa"></param>
        /// <param name="disponible"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void UpdateAvailable(int idPlaza, string idUsuario)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaUpdateAvailable");
            myDatabase.AddInParameter(myCommand, "@idPlaza", DbType.Int32, idPlaza);
            myDatabase.AddInParameter(myCommand, "@idUsuario", DbType.String, idUsuario);

            myDatabase.ExecuteNonQuery(myCommand);
        }

        /// Actualiza registros de la tabla Plaza.
        /// </summary>
        /// <param name="idPlaza"></param>
        /// <param name="idEstacionamiento"></param>
        /// <param name="idUsuario"></param>
        /// <param name="idTarifa"></param>
        /// <param name="disponible"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void UpdateNOAvailable(int idPlaza, string idUsuario)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaUpdateNOAvailable");
            myDatabase.AddInParameter(myCommand, "@idPlaza", DbType.Int32, idPlaza);
            myDatabase.AddInParameter(myCommand, "@idUsuario", DbType.String, idUsuario);

            myDatabase.ExecuteNonQuery(myCommand);
        }


        /// <summary>
        /// Actualiza registros de la tabla Plaza.
        /// </summary>
        /// <param name="idPlaza"></param>
        /// <param name="idEstacionamiento"></param>
        /// <param name="idUsuario"></param>
        /// <param name="idTarifa"></param>
        /// <param name="disponible"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idPlaza, int idEstacionamiento, string idUsuario, int idTarifa, bool disponible, bool pago)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaUpdate");

			myDatabase.AddInParameter(myCommand,"@idPlaza", DbType.Int32, idPlaza);
			myDatabase.AddInParameter(myCommand,"@idEstacionamiento", DbType.Int32, idEstacionamiento);
			myDatabase.AddInParameter(myCommand,"@idUsuario", DbType.String, idUsuario);
			myDatabase.AddInParameter(myCommand,"@idTarifa", DbType.Int32, idTarifa);
			myDatabase.AddInParameter(myCommand,"@disponible", DbType.Boolean, disponible);
            myDatabase.AddInParameter(myCommand, "@pago", DbType.Boolean, pago);

            myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla Plaza por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Delete(int idPlaza)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaDelete");

			myDatabase.AddInParameter(myCommand,"@idPlaza", DbType.Int32, idPlaza);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla Plaza a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByIdEstacionamiento(int idEstacionamiento)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaDeleteByIdEstacionamiento");

			myDatabase.AddInParameter(myCommand,"@idEstacionamiento", DbType.Int32, idEstacionamiento);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla Plaza a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByIdTarifa(int idTarifa)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaDeleteByIdTarifa");

			myDatabase.AddInParameter(myCommand,"@idTarifa", DbType.Int32, idTarifa);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla Plaza.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  Select(int idPlaza) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaSelect");

			myDatabase.AddInParameter(myCommand,"@idPlaza", DbType.Int32, idPlaza);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Plaza.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectAll(int? idTipoEstadia, int? idZona, DateTime? fechaDesde, DateTime? fechaHasta)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            //DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaSelectAll");
            DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaSelectAllAvailable");

            myDatabase.AddInParameter(myCommand, "@idTipoEstadia", DbType.Int32, idTipoEstadia);
            myDatabase.AddInParameter(myCommand, "@idZona", DbType.Int32, idZona);
            myDatabase.AddInParameter(myCommand, "@fechaDesde", DbType.Date, fechaDesde);
            myDatabase.AddInParameter(myCommand, "@fechaHasta", DbType.Date, fechaHasta);

            return myDatabase.ExecuteDataSet(myCommand);
		}

        public static DataSet SelectDisponibilidadByPlaza(int? idPlaza, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            //DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaSelectAll");
            DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaSelectAvailableByPlaza");

            myDatabase.AddInParameter(myCommand, "@idPlaza", DbType.Int32, idPlaza);
            myDatabase.AddInParameter(myCommand, "@fechaDesde", DbType.Date, fechaDesde);
            myDatabase.AddInParameter(myCommand, "@fechaHasta", DbType.Date, fechaHasta);

            return myDatabase.ExecuteDataSet(myCommand);
        }

		/// <summary>
		/// Selecciona todos los registros de la tabla Plaza a través de una foreign key.
		/// </summary>
		/// <param name="idEstacionamiento"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectByIdEstacionamiento(int idEstacionamiento) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaSelectByIdEstacionamiento");

			myDatabase.AddInParameter(myCommand,"@idEstacionamiento", DbType.Int32, idEstacionamiento);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Plaza a través de una foreign key.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaSelectByIdTarifa");

			myDatabase.AddInParameter(myCommand,"@idTarifa", DbType.Int32, idTarifa);

			return myDatabase.ExecuteDataSet(myCommand);
		}

        public static DataSet SelectDisponibilidadHora(DateTime fecha, string hora)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaSelectAllHoraAvailable");

            myDatabase.AddInParameter(myCommand, "@fecha", DbType.Date, fecha);
            myDatabase.AddInParameter(myCommand, "@hora", DbType.String, hora);
			return myDatabase.ExecuteDataSet(myCommand);
            
        }

        public static DataSet SelectDisponibilidadDiario(DateTime fecha)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaSelectAllDiarioAvailable");

            myDatabase.AddInParameter(myCommand, "@fecha", DbType.Date, fecha);
            return myDatabase.ExecuteDataSet(myCommand);

        }
    }
}
