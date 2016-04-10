using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
   public class Ranks: GamificationConnectGamification
    {
        public static void Insert(string title,  int points, byte[] Images = null, string note="")
        {
            string sql = string.Format("Insert Into Ranks" +
                   "(title, Images, points, note) Values(@title, @Images, @points, @note)");

            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@Images", Images);
                cmd.Parameters.AddWithValue("@points", points);
                cmd.Parameters.AddWithValue("@note", note);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error adding rank!", ex);
                    throw error;
                }
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Ranks where id_rank = '{0}'", id);
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error can not be removed from the list of ranks!", ex);
                    throw error;
                }
            }
        }

        public static void Update(int id, string change_colum, string change_value)
        {
            string sql = string.Format("Update Ranks Set '{0}' = '{1}' Where id_rank = '{2}'",
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

        public static void UpdateImage(int id, byte[] newImage)
        {
            string sql = string.Format("Update Ranks Set Images = '{0}' Where id_rank = '{1}'",
                   newImage, id);
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
            string sql = string.Format("Update Ranks Set '{0}' = '{1}' Where id_rank = '{2}'",
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
