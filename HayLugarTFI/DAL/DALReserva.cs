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
	/// Class	 : Reserva
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Reserva.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALReserva
	{

		/// <summary>
		/// Inserta registros dentro de la tabla Reserva.
		/// </summary>
		/// <param name="fechaDesde"></param>
		/// <param name="fechaHasta"></param>
		/// <param name="horaDesde"></param>
		/// <param name="horaHasta"></param>
		/// <param name="idPlaza"></param>
		/// <param name="idUsuario"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static int Insert(DateTime fechaDesde, DateTime fechaHasta, string horaDesde, string horaHasta, int idPlaza, string idUsuario)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ReservaInsert");

			myDatabase.AddInParameter(myCommand,"@fechaDesde", DbType.DateTime, fechaDesde);
			myDatabase.AddInParameter(myCommand,"@fechaHasta", DbType.DateTime, fechaHasta);
			myDatabase.AddInParameter(myCommand,"@horaDesde", DbType.String, horaDesde);
			myDatabase.AddInParameter(myCommand,"@horaHasta", DbType.String, horaHasta);
			myDatabase.AddInParameter(myCommand,"@idPlaza", DbType.Int32, idPlaza);
			myDatabase.AddInParameter(myCommand,"@idUsuario", DbType.String, idUsuario);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla Reserva.
		/// </summary>
		/// <param name="idReserva"></param>
		/// <param name="fechaDesde"></param>
		/// <param name="fechaHasta"></param>
		/// <param name="horaDesde"></param>
		/// <param name="horaHasta"></param>
		/// <param name="idPlaza"></param>
		/// <param name="idUsuario"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Update(int idReserva, DateTime fechaDesde, DateTime fechaHasta, string horaDesde, string horaHasta, int idPlaza, string idUsuario)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ReservaUpdate");

			myDatabase.AddInParameter(myCommand,"@idReserva", DbType.Int32, idReserva);
			myDatabase.AddInParameter(myCommand,"@fechaDesde", DbType.DateTime, fechaDesde);
			myDatabase.AddInParameter(myCommand,"@fechaHasta", DbType.DateTime, fechaHasta);
			myDatabase.AddInParameter(myCommand,"@horaDesde", DbType.String, horaDesde);
			myDatabase.AddInParameter(myCommand,"@horaHasta", DbType.String, horaHasta);
			myDatabase.AddInParameter(myCommand,"@idPlaza", DbType.Int32, idPlaza);
			myDatabase.AddInParameter(myCommand,"@idUsuario", DbType.String, idUsuario);

			myDatabase.ExecuteNonQuery(myCommand);
		}

        public static void PlazaUpdateStatePayment(int idPlaza, bool pago)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("PlazaUpdateStatePayment");

            myDatabase.AddInParameter(myCommand, "@idPlaza", DbType.Int32, idPlaza);
            myDatabase.AddInParameter(myCommand, "@pago", DbType.Boolean, pago);

            myDatabase.ExecuteNonQuery(myCommand);
        }


        /// <summary>
        /// Suprime un registro de la tabla Reserva por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idReserva)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ReservaDelete");

			myDatabase.AddInParameter(myCommand,"@idReserva", DbType.Int32, idReserva);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla Reserva a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByIdPlaza(int idPlaza)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ReservaDeleteByIdPlaza");

			myDatabase.AddInParameter(myCommand,"@idPlaza", DbType.Int32, idPlaza);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla Reserva.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  Select(int idReserva) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ReservaSelect");

			myDatabase.AddInParameter(myCommand,"@idReserva", DbType.Int32, idReserva);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Reserva.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ReservaSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

        /// <summary>
        /// Selecciona todos los registros de la tabla Reserva a través de una foreign key.
        /// </summary>
        /// <param name="idPlaza"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet MisReservasSelectByIdUser(string id)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("MisReservasSelectByIdUser");
            myDatabase.AddInParameter(myCommand, "@UserId", DbType.String, id);
            return myDatabase.ExecuteDataSet(myCommand);
        }

        public static DataSet MisReservasSelectByIdReserva(int idReserva)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("MisReservasSelectByIdReserva");
            myDatabase.AddInParameter(myCommand, "@idReserva", DbType.Int32, idReserva);
            return myDatabase.ExecuteDataSet(myCommand);
        }


        /// <summary>
        /// Selecciona todos los registros de la tabla Reserva.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet MisReservasSelectAll()
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("MisReservasSelectAll");

            return myDatabase.ExecuteDataSet(myCommand);
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Reserva a través de una foreign key.
        /// </summary>
        /// <param name="idPlaza"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet  SelectByIdPlaza(int idPlaza) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("ReservaSelectByIdPlaza");

			myDatabase.AddInParameter(myCommand,"@idPlaza", DbType.Int32, idPlaza);

			return myDatabase.ExecuteDataSet(myCommand);
		}

        public static DataSet MisReservasSelectAllByEstadoPago(bool pago, DateTime? fechaDesde, DateTime? fechaHasta, string usuario)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("MisReservasSelectAllByEstadoPago");

            myDatabase.AddInParameter(myCommand, "@pago", DbType.Boolean, pago);
            myDatabase.AddInParameter(myCommand, "@fechaDesde", DbType.DateTime, fechaDesde);
            myDatabase.AddInParameter(myCommand, "@fechaHasta", DbType.DateTime, fechaHasta);
            myDatabase.AddInParameter(myCommand, "@usuario", DbType.String, usuario);

            return myDatabase.ExecuteDataSet(myCommand);
        }


        public static DataSet MisReservasSelectByPagoStateAndUserId(bool pago, string userId)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("MisReservasSelectByPagoStateAndUserId");

            myDatabase.AddInParameter(myCommand, "@pago", DbType.Boolean, pago);
            myDatabase.AddInParameter(myCommand, "@userId", DbType.String, userId);

            return myDatabase.ExecuteDataSet(myCommand);
        }


        public static DataSet MisReservasCancelar(int idReserva)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("MisReservasCancelar");

            myDatabase.AddInParameter(myCommand, "@idReserva", DbType.Int32, idReserva);            

            return myDatabase.ExecuteDataSet(myCommand);
        }

        public static void ReservaUpdateStatePayment(int idReserva, bool pago)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("ReservaUpdateStatePayment");

            myDatabase.AddInParameter(myCommand, "@idReserva", DbType.Int32, idReserva);
            myDatabase.AddInParameter(myCommand, "@pago", DbType.Boolean, pago);

            myDatabase.ExecuteNonQuery(myCommand);
        }
    }
}
