using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.IO;

namespace Gamificationlibrary.DataBase
{
    public class Badges: GamificationConnectGamification
    {

        public static void Insert(string title, int points, byte[] Images=null, string note = "", string descriptions = "")
        {
            string sql = string.Format("Insert Into Badges" +
                   "(title, Images, points, note, descriptions) Values(@title, @Images, @points, @note, @descriptions)");

            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@Images", Images);
                cmd.Parameters.AddWithValue("@points", points);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@descriptions", descriptions);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error adding badge!", ex);
                    throw error;
                }
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Badges where id_badge = '{0}'", id);
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error can not be removed from the list of badges!", ex);
                    throw error;
                }
            }
        }

        public static void Update(int id, string change_colum, string change_value)
        {
            string sql = string.Format("Update Badges Set '{0}' = '{1}' Where id_badge = '{2}'",
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

            string sql = string.Format("Update Users Set Images = @FILE Where id_badge = '{0}'", id);



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
            string sql = string.Format("Update Badges Set '{0}' = '{1}' Where id_badge = '{2}'",
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
