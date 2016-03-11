﻿using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
    public class Levels: GamificationConnectGamification
    {
        public static void Insert(string title, int rank, int points)
        {
            string sql = string.Format("Insert Into Levels" +
                   "(title, rank, points) Values(@title, @rank, @points)");

            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@rank", rank);
                cmd.Parameters.AddWithValue("@points", points);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Failed to add level!", ex);
                    throw error;
                }
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Levels where id_level = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
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
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
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
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Updating error not occurred!", ex);
                    throw error;
                }
            }
        }
    }
}
