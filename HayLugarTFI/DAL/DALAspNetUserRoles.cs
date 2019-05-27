using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace DAL
{
	/// -----------------------------------------------------------------------------
	/// Project	 : DAL
	/// Class	 : AspNetUserRoles
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla AspNetUserRoles.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[JEISOLO]	23/09/2017 22:58:17
	/// </history>
	/// -----------------------------------------------------------------------------
	public static class DALAspNetUserRoles
	{

		/// <summary>
		/// Inserta registros dentro de la tabla AspNetUserRoles.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="roleId"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Insert(string userId, string roleId)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUserRolesInsert");

			myDatabase.AddInParameter(myCommand,"@UserId", DbType.String, userId);
			myDatabase.AddInParameter(myCommand,"@RoleId", DbType.String, roleId);

			myDatabase.ExecuteNonQuery(myCommand);
		}

        /// <summary>
		/// Actualiza registros dentro de la tabla AspNetUserRoles.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="roleId"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Update(string userId, string roleId)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
            DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUserRolesUpdate");

			myDatabase.AddInParameter(myCommand,"@UserId", DbType.String, userId);
			myDatabase.AddInParameter(myCommand,"@RoleId", DbType.String, roleId);

			myDatabase.ExecuteNonQuery(myCommand);
		}

        
		/// <summary>
		/// Suprime un registro de la tabla AspNetUserRoles por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void Delete(string userId, string roleId)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUserRolesDelete");

			myDatabase.AddInParameter(myCommand,"@UserId", DbType.String, userId);
			myDatabase.AddInParameter(myCommand,"@RoleId", DbType.String, roleId);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla AspNetUserRoles a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByUserId(string userId)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUserRolesDeleteByUserId");

			myDatabase.AddInParameter(myCommand,"@UserId", DbType.String, userId);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla AspNetUserRoles a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static void DeleteByRoleId(string roleId)
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUserRolesDeleteByRoleId");

			myDatabase.AddInParameter(myCommand,"@RoleId", DbType.String, roleId);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla AspNetUserRoles a través de una foreign key.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectByUserId(string userId) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUserRolesSelectByUserId");

			myDatabase.AddInParameter(myCommand,"@UserId", DbType.String, userId);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla AspNetUserRoles a través de una foreign key.
		/// </summary>
		/// <param name="roleId"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[JEISOLO]	23/09/2017 22:58:17
		/// </history>
		public static DataSet  SelectByRoleId(string roleId) 
		{
			Database myDatabase = new SqlDatabase(DALUtilities.getConnection());
			DbCommand myCommand = myDatabase.GetStoredProcCommand("AspNetUserRolesSelectByRoleId");

			myDatabase.AddInParameter(myCommand,"@RoleId", DbType.String, roleId);

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
