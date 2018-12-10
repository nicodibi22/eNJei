using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZAspNetUserRoles
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
        /// 	[JeiSolo]	11/09/2016 20:05:16
        /// </history>
        public static void Insert(string userId, string roleId)
        {
            try
            {
                DALAspNetUserRoles.Insert(userId, roleId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
