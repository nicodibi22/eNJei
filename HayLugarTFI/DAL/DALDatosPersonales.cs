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
	/// Class	 : DatosPersonales
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla DatosPersonales.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALDatosPersonales
	{

		/// <summary>
		/// Inserta registros dentro de la tabla DatosPersonales.
		/// </summary>
		/// <param name="idUsr"></param>
		/// <param name="tipoDoc"></param>
		/// <param name="nroDoc"></param>
		/// <param name="email"></param>
		/// <param name="telefono"></param>
		/// <param name="tipoTelefono"></param>
		/// <param name="aliasEmp"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static int Insert(string idUsr, string tipoDoc, string nroDoc, string email, string telefono, string tipoTelefono, string aliasEmp,
            string nombre, string apellido, string direccion, string cuil)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("DatosPersonalesInsert");

			myDatabase.AddInParameter(myCommand,"@idUsr", DbType.String, idUsr);
			myDatabase.AddInParameter(myCommand,"@tipoDoc", DbType.String, tipoDoc);
			myDatabase.AddInParameter(myCommand,"@nroDoc", DbType.String, nroDoc);
			myDatabase.AddInParameter(myCommand,"@email", DbType.String, email);
			myDatabase.AddInParameter(myCommand,"@telefono", DbType.String, telefono);
			myDatabase.AddInParameter(myCommand,"@tipoTelefono", DbType.String, tipoTelefono);
			myDatabase.AddInParameter(myCommand,"@aliasEmp", DbType.String, aliasEmp);
            myDatabase.AddInParameter(myCommand, "@nombre", DbType.String, nombre);
            myDatabase.AddInParameter(myCommand, "@apellido", DbType.String, apellido);
            myDatabase.AddInParameter(myCommand, "@direccion", DbType.String, direccion);
            myDatabase.AddInParameter(myCommand, "@cuil", DbType.String, cuil);
			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla DatosPersonales.
		/// </summary>
		/// <param name="nroReg"></param>
		/// <param name="idUsr"></param>
		/// <param name="tipoDoc"></param>
		/// <param name="nroDoc"></param>
		/// <param name="email"></param>
		/// <param name="telefono"></param>
		/// <param name="tipoTelefono"></param>
		/// <param name="aliasEmp"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Update(int nroReg, string idUsr, string tipoDoc, string nroDoc, string email, string telefono, string tipoTelefono, string aliasEmp)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("DatosPersonalesUpdate");

			myDatabase.AddInParameter(myCommand,"@nroReg", DbType.Int32, nroReg);
			myDatabase.AddInParameter(myCommand,"@idUsr", DbType.String, idUsr);
			myDatabase.AddInParameter(myCommand,"@tipoDoc", DbType.String, tipoDoc);
			myDatabase.AddInParameter(myCommand,"@nroDoc", DbType.String, nroDoc);
			myDatabase.AddInParameter(myCommand,"@email", DbType.String, email);
			myDatabase.AddInParameter(myCommand,"@telefono", DbType.String, telefono);
			myDatabase.AddInParameter(myCommand,"@tipoTelefono", DbType.String, tipoTelefono);
			myDatabase.AddInParameter(myCommand,"@aliasEmp", DbType.String, aliasEmp);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla DatosPersonales por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Delete(int nroReg)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("DatosPersonalesDelete");

			myDatabase.AddInParameter(myCommand,"@nroReg", DbType.Int32, nroReg);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla DatosPersonales a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByIdUsr(string idUsr)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("DatosPersonalesDeleteByIdUsr");

			myDatabase.AddInParameter(myCommand,"@idUsr", DbType.String, idUsr);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla DatosPersonales.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  Select(int nroReg) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("DatosPersonalesSelect");

			myDatabase.AddInParameter(myCommand,"@nroReg", DbType.Int32, nroReg);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla DatosPersonales.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("DatosPersonalesSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla DatosPersonales a través de una foreign key.
		/// </summary>
		/// <param name="idUsr"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectByIdUsr(string idUsr) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("DatosPersonalesSelectByIdUsr");

			myDatabase.AddInParameter(myCommand,"@idUsr", DbType.String, idUsr);

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
