using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
    public class Badges: GamificationConnectGamification
    {

        public static void Insert(int id_badge, string title, string Images, int points, string note = "", string descriptions = "")
        {
            string sql = string.Format("Insert Into Badges" +
                   "(id_badge, title, Images, points, note, descriptions) Values(@id_rank, @title, @Images, @points, @note, @descriptions)");

            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@id_badge", id_badge);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@Images", Images);
                cmd.Parameters.AddWithValue("@points", points);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@descriptions", descriptions);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Badges where id_badge = '{0}'", id);
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
            string sql = string.Format("Update Badges Set '{0}' = '{1}' Where id_badge = '{2}'",
                   change_colum, change_value, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(int id, string change_colum, int change_value)
        {
            string sql = string.Format("Update Badges Set '{0}' = '{1}' Where id_badge = '{2}'",
                   change_colum, change_value, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
