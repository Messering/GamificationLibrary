using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificationlibrary.DataBase
{
   public class ListBadges : GamificationConnectGamification
    {
        public static void Insert(int id_user,int id_badge)
        {
            string sql = string.Format("Insert Into badgesuser" +
                   "(id_user, id_badge) Values(@id_user, @id_badge)");

            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@id_user", id_user);
                cmd.Parameters.AddWithValue("@id_badge", id_badge);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error adding badge user!", ex);
                    throw error;
                }
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from badgesuser where id_badgesUser = '{0}'", id);
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error can not be removed from the list of badges user!", ex);
                    throw error;
                }
            }
        }
    }
}
