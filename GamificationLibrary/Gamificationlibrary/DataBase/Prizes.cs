using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
    public class Prizes: GamificationConnectGamification
    {
        public static void Insert(string name_prize, string Images, int points)
        {
            string sql = string.Format("Insert Into Prizes" +
                   "(name_prize, Images, points) Values(@name_prize, @Images, @points)");

            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@name_prize", name_prize);
                cmd.Parameters.AddWithValue("@Images", Images);
                cmd.Parameters.AddWithValue("@points", points);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error adding prize!", ex);
                    throw error;
                }
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Prizes where id_prize = '{0}'", id);
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error can not be removed from the list of prizes!", ex);
                    throw error;
                }
            }
        }

        public static void Update(int id, string change_colum, string change_value)
        {           
            string sql = string.Format("Update Prizes Set '{0}' = '{1}' Where id_prize = '{2}'",
                   change_colum, change_value, id);
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Updating error not occurred!", ex);
                    throw error;
                }
            }
        }

        public static void Update(int id, string change_colum, int change_value)
        {
            string sql = string.Format("Update Prizes Set '{0}' = '{1}' Where id_prize = '{2}'",
                   change_colum, change_value, id);
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Updating error not occurred!", ex);
                    throw error;
                }
            }
        }
    }
}
