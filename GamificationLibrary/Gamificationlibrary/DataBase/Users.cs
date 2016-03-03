using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
    public class Users : GamificationConnectGamification
    {
        public static void Insert(int id_user, string name, string nickname, string passwords)
        {
            string sql = string.Format("Insert Into Users" +
                   "(id_user, name, nickname, passwords) Values(@id_user, @name, @nickname, @passwords)");

            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {

                cmd.Parameters.AddWithValue("@id_user", id_user);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@nickname", nickname);
                cmd.Parameters.AddWithValue("@passwords", passwords);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Users where CarID = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Unfortunately, this machine ordered!", ex);
                    throw error;
                }
            }
        }

        public static void UpdatePassword(int id, string newPasswords)
        {
            string sql = string.Format("Update Users Set passwords = '{0}' Where id_user = '{1}'",
                   newPasswords, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
