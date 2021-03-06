﻿using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
  public class History: GamificationConnectGamification
    {
        public static void Insert(int id_user, int points, DateTime record_date)
        {
            string sql = string.Format("Insert Into History" +
                   "(id_user, points, record_date, id_level) Values(@id_user, @points, @record_date");

            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@id_user", id_user);
                cmd.Parameters.AddWithValue("@points", points);
                cmd.Parameters.AddWithValue("@record_date", record_date);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Failed to write session!", ex);
                    throw error;
                }
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from History where id_history = '{0}'", id);
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Failed to clean session!", ex);
                    throw error;
                }
            }
        }

        public static void Update(int id, string change_colum, string change_value)
        {
            string sql = string.Format("Update History Set '{0}' = '{1}' Where id_history = '{2}'",
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
            string sql = string.Format("Update History Set '{0}' = '{1}' Where id_history = '{2}'",
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
