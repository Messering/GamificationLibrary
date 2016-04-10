using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
    public class Profile: GamificationConnectGamification
    {
        public static void Insert(int id_user, int points, int level, int rank)
        {
            string sql = string.Format("Insert Into Profiles" +
                   "(id_user, points, level, rank) Values(@id_user, @points, @level, @rank)");

            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@id_user", id_user);
                cmd.Parameters.AddWithValue("@points", points);
                cmd.Parameters.AddWithValue("@level", level);
                cmd.Parameters.AddWithValue("@rank", rank);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error creating user!", ex);
                    throw error;
                }
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Profiles where id_user = '{0}'", id);
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error can not be removed user!", ex);
                    throw error;
                }
            }
        }

        public static void Update(int id, string change_colum, int change_value)
        {
            string sql = string.Format("Update Profiles Set '{0}' = '{1}' Where id_user = '{2}'",
                   change_colum, change_value, id);
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error updating profile!", ex);
                    throw error;
                }
            }
        }
    }
}
