using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
    public class Helpers : GamificationConnectGamification
    {
        public static void Insert(string title, string message="Help")
        {
            string sql = string.Format("Insert Into Helpers" +
                   "(title, message) Values(@title, @message)");

            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@message", message);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error adding informative message!", ex);
                    throw error;
                }
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Helpers where id_helper = '{0}'", id);
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error can not be removed from the list of help-messages!", ex);
                    throw error;
                }
            }
        }

        public static void Update(int id, string change_colum, string change_value)
        {
            string sql = string.Format("Update Helpers Set '{0}' = '{1}' Where id_helper = '{2}'",
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

