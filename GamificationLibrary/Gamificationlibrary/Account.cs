using System;
using Gamificationlibrary.DataBase;
using MySql.Data.MySqlClient;

namespace Gamificationlibrary
{
    public class Account : GamificationConnectGamification
    {

        public static string nickname_user { get; set; }
        public static int id_user;
        /// <summary>
        /// The method for registration
        /// </summary>
        /// <param name="connect"></param>
        /// <param name="name"></param>
        /// <param name="nickname"></param>
        /// <param name="passwords"></param>
        /// <param name="confirm_passwords"></param>
        /// <param name="email"></param>
        /// <returns>true or false is registration</returns>
        public static bool Registration(MySqlConnection connect, string name, string nickname, string passwords, string confirm_passwords, byte[] image, string email = "") {
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                Exception error = new Exception("Error with the databse connection!", ex);
                throw error;
            }
            string qry = "Select * from Users where nickname=@nickname";
            MySqlCommand com = new MySqlCommand(qry, connect);
            com.Parameters.AddWithValue("@nickname", nickname);
            MySqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    return false;
                }               
          }
            if (dr.HasRows == false)
            {
                Users.Insert(name, nickname, passwords,image, email);
                connect.Close();
                nickname_user = nickname;
                CreateProfile(nickname, connect);
                return true;
            }
            
            connect.Close();
            return false;
        }


        /// <summary>
        /// The method for login
        /// </summary>
        /// <param name="connect"></param>
        /// <param name="nickname"></param>
        /// <param name="passwords"></param>
        /// <returns>true or false is login</returns>
        public static bool Login(MySqlConnection connect, string nickname, string passwords) {
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                Exception error = new Exception("Error with the databse connection!", ex);
                throw error;
            }
            string qry = "Select * from Users where passwords=@passwords and nickname=@nickname";
            MySqlCommand com = new MySqlCommand(qry, connect);
            com.Parameters.AddWithValue("@nickname", nickname);
            com.Parameters.AddWithValue("@passwords", passwords);
            MySqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    id_user = Convert.ToInt32(dr[0]);
                    nickname_user = nickname;
                    return true;                  
                }
            }
            if (dr.HasRows == false)
            {
                return false;
            }
            connect.Close();
            return false;
        }

        /// <summary>
        /// Create a profile after registration
        /// </summary>
        /// <param name="nickname"></param>
        /// <param name="connect"></param>
        public static void CreateProfile(string nickname, MySqlConnection connect)
        {
            connect.Open();
            string strSQL = String.Format("SELECT id_user FROM Users Where nickname = '{0}'", nickname);
            MySqlCommand myCommand = new MySqlCommand(strSQL, connect);
            MySqlDataReader dr = myCommand.ExecuteReader();
            while (dr.Read())
                id_user = Convert.ToInt32(dr[0]);
                Profile.Insert(id_user, 0, 100, 200);               
            connect.Close();
        }
    }
}

