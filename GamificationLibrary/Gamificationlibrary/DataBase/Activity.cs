using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
    public class Activity: GamificationConnectGamification
    {
        public static void Insert(int id_activity, string title, string content, string Images, int id_user)
        {
            string sql = string.Format("Insert Into Activity" +
                   "(id_activity, title, content, Images, id_user) Values(@id_rank, @title, @content, @Images, @id_user)");

            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@id_activity", id_activity);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@content", content);
                cmd.Parameters.AddWithValue("@Images", Images);
                cmd.Parameters.AddWithValue("@id_user", id_user);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Activity where id_activity = '{0}'", id);
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
            string sql = string.Format("Update Activity Set '{0}' = '{1}' Where id_activity = '{2}'",
                   change_colum, change_value, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(int id, string change_colum, int change_value)
        {
            string sql = string.Format("Update Activity Set '{0}' = '{1}' Where id_activity = '{2}'",
                   change_colum, change_value, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
