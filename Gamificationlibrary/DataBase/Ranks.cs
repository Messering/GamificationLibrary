﻿using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
   public class Ranks: GamificationConnectGamification
    {
        public static void Insert(int id_rank, string title, string Images, int points, string note="")
        {
            string sql = string.Format("Insert Into Ranks" +
                   "(id_rank, title, Images, points, note) Values(@id_rank, @title, @Images, @points, @note)");

            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@id_rank", id_rank);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@Images", Images);
                cmd.Parameters.AddWithValue("@points", points);
                cmd.Parameters.AddWithValue("@note", note);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Ranks where id_rank = '{0}'", id);
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
            string sql = string.Format("Update Ranks Set '{0}' = '{1}' Where id_rank = '{2}'",
                   change_colum, change_value, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(int id, string change_colum, int change_value)
        {
            string sql = string.Format("Update Ranks Set '{0}' = '{1}' Where id_rank = '{2}'",
                   change_colum, change_value, id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
