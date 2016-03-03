using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
    public class Prizes: GamificationConnectGamification
    {
        public static void Insert(int id_prize, string name_prize, string Images, int points)
        {
            string sql = string.Format("Insert Into Prizes" +
                   "(id_prize, name_prize, Images, points) Values(@id_prize, @name_prize, @Images, @points)");

            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {

                cmd.Parameters.AddWithValue("@id_prize", id_prize);
                cmd.Parameters.AddWithValue("@name_prize", name_prize);
                cmd.Parameters.AddWithValue("@Images", Images);
                cmd.Parameters.AddWithValue("@points", points);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Prizes where id_prize = '{0}'", id);
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
            string sql = string.Format("Update Prizes Set '{0}' = '{1}' Where id_prize = '{2}'",
                   change_colum, change_value, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(int id, string change_colum, int change_value)
        {
            string sql = string.Format("Update Prizes Set '{0}' = '{1}' Where id_prize = '{2}'",
                   change_colum, change_value, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
