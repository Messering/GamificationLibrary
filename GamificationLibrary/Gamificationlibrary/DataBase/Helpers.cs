using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
    public class Helpers : GamificationConnectGamification
    {
        public static void Insert(int id_helper, string title, string message="Help")
        {
            string sql = string.Format("Insert Into Helpers" +
                   "(id_helper, title, message) Values(@id_helper, @title, @message)");

            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {

                cmd.Parameters.AddWithValue("@id_helper", id_helper);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@message", message);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Helpers where id_helper = '{0}'", id);
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

        public static void Update(int id, string change_colum, string change_value)
        {
            string sql = string.Format("Update Helpers Set '{0}' = '{1}' Where id_helper = '{2}'",
                   change_colum, change_value, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}

