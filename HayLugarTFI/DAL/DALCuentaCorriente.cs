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
	/// Class	 : CuentaCorriente
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla CuentaCorriente.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	25/11/2017 12:24:36
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALCuentaCorriente
	{

		/// <summary>
		/// Inserta registros dentro de la tabla CuentaCorriente.
		/// </summary>
		/// <param name="idUsr"></param>
		/// <param name="saldo"></param>
		/// <param name="fechaUltimaOperacion"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	25/11/2017 12:24:36
		/// </history>
		public static int Insert(string idUsr, decimal saldo, DateTime fechaUltimaOperacion)
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("CuentaCorrienteInsert");

			myDatabase.AddInParameter(myCommand,"@idUsr", DbType.String, idUsr);
			myDatabase.AddInParameter(myCommand,"@saldo", DbType.Decimal, saldo);
			myDatabase.AddInParameter(myCommand,"@fechaUltimaOperacion", DbType.DateTime, fechaUltimaOperacion);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla CuentaCorriente.
		/// </summary>
		/// <param name="nroCuenta"></param>
		/// <param name="idUsr"></param>
		/// <param name="saldo"></param>
		/// <param name="fechaUltimaOperacion"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	25/11/2017 12:24:36
		/// </history>
		public static void Update(int nroCuenta, string idUsr, decimal saldo, DateTime fechaUltimaOperacion)
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("CuentaCorrienteUpdate");

			myDatabase.AddInParameter(myCommand,"@nroCuenta", DbType.Int32, nroCuenta);
			myDatabase.AddInParameter(myCommand,"@idUsr", DbType.String, idUsr);
			myDatabase.AddInParameter(myCommand,"@saldo", DbType.Decimal, saldo);
			myDatabase.AddInParameter(myCommand,"@fechaUltimaOperacion", DbType.DateTime, fechaUltimaOperacion);

			myDatabase.ExecuteNonQuery(myCommand);
		}

        public static void UpdateSaldo(int nroCuenta, decimal saldo)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("CuentaCorrienteUpdateSaldo");

            myDatabase.AddInParameter(myCommand, "@nroCuenta", DbType.Int32, nroCuenta);
            myDatabase.AddInParameter(myCommand, "@saldo", DbType.Decimal, saldo);
            myDatabase.ExecuteNonQuery(myCommand);
        }


        /// <summary>
        /// Selecciona un registro desde la tabla CuentaCorriente.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	25/11/2017 12:24:36
        /// </history>
        public static DataSet  Select(string idUsr) 
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("CuentaCorrienteSelect");

			myDatabase.AddInParameter(myCommand, "@idUsr", DbType.String, idUsr);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla CuentaCorriente.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	25/11/2017 12:24:36
		/// </history>
		public static DataSet  SelectAll()
		{
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("CuentaCorrienteSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

        public static DataSet SelectUsersSinCtaCte()
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("SelectUsersSinCtaCte");

            return myDatabase.ExecuteDataSet(myCommand);
        }

    }
}
