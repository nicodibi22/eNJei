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
	public static class DALBitacora
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
		public static int Insert(DateTime fechaHora, string idUsuario, string  accion, string detalle)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("BitacoraInsert");

            myDatabase.AddInParameter(myCommand, "@fechaHora", DbType.DateTime, fechaHora);
            myDatabase.AddInParameter(myCommand, "@idUsuario", DbType.String, idUsuario);
			myDatabase.AddInParameter(myCommand, "@accion", DbType.String, accion);
            myDatabase.AddInParameter(myCommand, "@detalle", DbType.String, detalle);
			
			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
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
        public static DataSet Select(DateTime fechaDesde, DateTime fechaHasta, string idUsuario, int idPerfil) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("BitacoraSelect");

            myDatabase.AddInParameter(myCommand, "@fechaDesde", DbType.DateTime, fechaDesde);
            myDatabase.AddInParameter(myCommand, "@fechaHasta", DbType.DateTime, fechaHasta);
            myDatabase.AddInParameter(myCommand, "@idUsuario", DbType.String, idUsuario);
            myDatabase.AddInParameter(myCommand, "@idPerfil", DbType.Int32, idPerfil);

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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("BitacoraSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

    }
}
