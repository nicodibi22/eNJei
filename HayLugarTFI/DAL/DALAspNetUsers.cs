using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace DAL
{
	/// -----------------------------------------------------------------------------
	/// Project	 : DAL
	/// Class	 : AspNetUsers
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla AspNetUsers.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALAspNetUsers
	{

		/// <summary>
		/// Inserta registros dentro de la tabla AspNetUsers.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="email"></param>
		/// <param name="emailConfirmed"></param>
		/// <param name="passwordHash"></param>
		/// <param name="securityStamp"></param>
		/// <param name="phoneNumber"></param>
		/// <param name="phoneNumberConfirmed"></param>
		/// <param name="twoFactorEnabled"></param>
		/// <param name="lockoutEndDateUtc"></param>
		/// <param name="lockoutEnabled"></param>
		/// <param name="accessFailedCount"></param>
		/// <param name="userName"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Insert(string id, string email, bool emailConfirmed, string passwordHash, string securityStamp, string phoneNumber, bool phoneNumberConfirmed, bool twoFactorEnabled, DateTime lockoutEndDateUtc, bool lockoutEnabled, int accessFailedCount, string userName)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUsersInsert");

			myDatabase.AddInParameter(myCommand,"@Id", DbType.String, id);
			myDatabase.AddInParameter(myCommand,"@Email", DbType.String, email);
			myDatabase.AddInParameter(myCommand,"@EmailConfirmed", DbType.Boolean, emailConfirmed);
			myDatabase.AddInParameter(myCommand,"@PasswordHash", DbType.String, passwordHash);
			myDatabase.AddInParameter(myCommand,"@SecurityStamp", DbType.String, securityStamp);
			myDatabase.AddInParameter(myCommand,"@PhoneNumber", DbType.String, phoneNumber);
			myDatabase.AddInParameter(myCommand,"@PhoneNumberConfirmed", DbType.Boolean, phoneNumberConfirmed);
			myDatabase.AddInParameter(myCommand,"@TwoFactorEnabled", DbType.Boolean, twoFactorEnabled);
			myDatabase.AddInParameter(myCommand,"@LockoutEndDateUtc", DbType.DateTime, lockoutEndDateUtc);
			myDatabase.AddInParameter(myCommand,"@LockoutEnabled", DbType.Boolean, lockoutEnabled);
			myDatabase.AddInParameter(myCommand,"@AccessFailedCount", DbType.Int32, accessFailedCount);
			myDatabase.AddInParameter(myCommand,"@UserName", DbType.String, userName);

			myDatabase.ExecuteNonQuery(myCommand);
		}

        /// <summary>
        /// Actualiza registros de la tabla AspNetUsers.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="emailConfirmed"></param>
        /// <param name="passwordHash"></param>
        /// <param name="securityStamp"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="phoneNumberConfirmed"></param>
        /// <param name="twoFactorEnabled"></param>
        /// <param name="lockoutEndDateUtc"></param>
        /// <param name="lockoutEnabled"></param>
        /// <param name="accessFailedCount"></param>
        /// <param name="userName"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        /// 
        

        public static void AspNetUsersUpdateEmailConfirmed(string id)
        {
            Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUsersUpdateEmailConfirmed");

            myDatabase.AddInParameter(myCommand, "@Id", DbType.String, id);
            myDatabase.ExecuteNonQuery(myCommand);
        }


        public static void Update(string id, string email, bool emailConfirmed, string passwordHash, string securityStamp, string phoneNumber, bool phoneNumberConfirmed, bool twoFactorEnabled, DateTime lockoutEndDateUtc, bool lockoutEnabled, int accessFailedCount, string userName)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUsersUpdate");

			myDatabase.AddInParameter(myCommand,"@Id", DbType.String, id);
			myDatabase.AddInParameter(myCommand,"@Email", DbType.String, email);
			myDatabase.AddInParameter(myCommand,"@EmailConfirmed", DbType.Boolean, emailConfirmed);
			myDatabase.AddInParameter(myCommand,"@PasswordHash", DbType.String, passwordHash);
			myDatabase.AddInParameter(myCommand,"@SecurityStamp", DbType.String, securityStamp);
			myDatabase.AddInParameter(myCommand,"@PhoneNumber", DbType.String, phoneNumber);
			myDatabase.AddInParameter(myCommand,"@PhoneNumberConfirmed", DbType.Boolean, phoneNumberConfirmed);
			myDatabase.AddInParameter(myCommand,"@TwoFactorEnabled", DbType.Boolean, twoFactorEnabled);
			myDatabase.AddInParameter(myCommand,"@LockoutEndDateUtc", DbType.DateTime, lockoutEndDateUtc);
			myDatabase.AddInParameter(myCommand,"@LockoutEnabled", DbType.Boolean, lockoutEnabled);
			myDatabase.AddInParameter(myCommand,"@AccessFailedCount", DbType.Int32, accessFailedCount);
			myDatabase.AddInParameter(myCommand,"@UserName", DbType.String, userName);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla AspNetUsers por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Delete(string id)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUsersDelete");

			myDatabase.AddInParameter(myCommand,"@Id", DbType.String, id);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla AspNetUsers.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  Select(string id) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUsersSelect");

			myDatabase.AddInParameter(myCommand,"@Id", DbType.String, id);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla AspNetUsers.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUsersSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
