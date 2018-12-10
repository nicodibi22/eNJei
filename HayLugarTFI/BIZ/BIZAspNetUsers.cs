using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZAspNetUsers
    {
        public static void AspNetUsersUpdateEmailConfirmed(string id)
        {
            try
            {
                DALAspNetUsers.AspNetUsersUpdateEmailConfirmed(id);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
