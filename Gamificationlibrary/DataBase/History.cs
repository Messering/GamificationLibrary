using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
  public class History: GamificationConnectGamification
    {
        public static void Insert(int id_history, int id_user, int points, DateTime record_date, int id_level)
        {
            string sql = string.Format("Insert Into History" +
                   "(id_history, id_user, points, record_date, id_level) Values(@id_history, @id_user, @points, @record_date, @id_level)");

            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {

                cmd.Parameters.AddWithValue("@id_history", id_history);
                cmd.Parameters.AddWithValue("@id_user", id_user);
                cmd.Parameters.AddWithValue("@points", points);
                cmd.Parameters.AddWithValue("@record_date", record_date);
                cmd.Parameters.AddWithValue("@id_level", id_level);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from History where id_history = '{0}'", id);
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
            string sql = string.Format("Update History Set '{0}' = '{1}' Where id_history = '{2}'",
                   change_colum, change_value, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(int id, string change_colum, int change_value)
        {
            string sql = string.Format("Update History Set '{0}' = '{1}' Where id_history = '{2}'",
                   change_colum, change_value, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }

    }
}
