using System;
using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
    public class Users : GamificationConnectGamification
    {
        public static void Insert(string name, string nickname, string passwords, string email="", string image="")
        {
            string sql = string.Format("Insert Into Users" +
                   "(name, nickname, passwords, email, image) Values(@name, @nickname, @passwords, @email, @image)");

            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@nickname", nickname);
                cmd.Parameters.AddWithValue("@passwords", passwords);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@image", image);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Error creating user!", ex);
                    throw error;
                }
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Users where id_user = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Error can not be removed user!", ex);
                    throw error;
                }
            }
        }

        public static void UpdatePassword(int id, string newPasswords)
        {
            string sql = string.Format("Update Users Set passwords = '{0}' Where id_user = '{1}'",
                   newPasswords, id);
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

        public static void UpdateImage(int id, string newImage)
        {
            string sql = string.Format("Update Users Set image = '{0}' Where id_user = '{1}'",
                   newImage, id);
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
