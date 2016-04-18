using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.IO;

namespace Gamificationlibrary.DataBase
{
    public class Users : GamificationConnectGamification
    {
        public static void Insert(string name, string nickname, string passwords, byte[] image=null, string email="")
        {
            string sql = string.Format("Insert Into Users" +
                   "(name, nickname, passwords, email, image) Values(@name, @nickname, @passwords, @email, @image)");

            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
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
                catch (MySqlException ex)
                {
                    Exception error = new Exception("Error creating user!", ex);
                    throw error;
                }
            }
        }

        public static void Delete(int id)
        {
            string sql = string.Format("Delete from Users where id_user = '{0}'", id);
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

        public static void UpdatePassword(int id, string newPasswords)
        {
            string sql = string.Format("Update Users Set passwords = '{0}' Where id_user = '{1}'",
                   newPasswords, id);
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

        public static void Update(int id, string change_colum, string change_value)
        {
            string sql = string.Format("Update Users Set {0} = '{1}' Where id_user = '{2}'",
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

            string sql = string.Format("Update Users Set image = @FILE Where id_user = '{0}'", id);



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
    }
}
