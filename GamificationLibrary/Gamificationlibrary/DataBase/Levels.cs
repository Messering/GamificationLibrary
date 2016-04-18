using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.IO;

namespace Gamificationlibrary.DataBase
{
    public class Levels: GamificationConnectGamification
    {
        public static void Insert(string title, int points, byte[] Images = null, string note = "")
        {
            string sql = string.Format("Insert Into Levels" +
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
                    Exception error = new Exception("Failed to add level!", ex);
                    throw error;
                }
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Levels where id_level = '{0}'", id);
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Failed to delete level!", ex);
                    throw error;
                }
            }
        }

        public static void Update(int id, string change_colum, string change_value)
        {
            string sql = string.Format("Update Levels Set '{0}' = '{1}' Where id_level = '{2}'",
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

        public static void UpdateImage(int id, String FileName)

        {

            string sql = string.Format("Update Users Set Images = @FILE Where id_level = '{0}'", id);



            using (MySqlCommand cmd = new MySqlCommand(sql, connect))

            {

                try

                {

                    cmd.Parameters.AddWithValue("@FILE", File.ReadAllBytes(FileName));

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
            string sql = string.Format("Update Level Set '{0}' = '{1}' Where id_level = '{2}'",
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
