using System;
using System.Collections.Generic;
using Gamificationlibrary.DataBase;
using System.Data.SqlClient;

namespace Gamificationlibrary
{
    public class Account
    {

        public static string nickname_user { get; set; }
        public static bool Registration(SqlConnection connect,string name, string nickname, string passwords, string confirm_passwords, string email = "") {
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                Exception error = new Exception("Error with the databse connection!", ex);
                throw error;
            }
            string qry = "Select * from dbo.Users where nickname=@nickname";
            SqlCommand com = new SqlCommand(qry, connect);
            com.Parameters.AddWithValue("@nickname", nickname);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    return false;
                }               
          }
            if (dr.HasRows == false)
            {
                Users.Insert(name, nickname, passwords, email);
                nickname_user = nickname;
                return true;
            }
            
            connect.Close();
            return false;
        }                                   

        public static bool Login(SqlConnection connect, string nickname, string passwords) {
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                Exception error = new Exception("Error with the databse connection!", ex);
                throw error;
            }
            string qry = "Select * from dbo.Users where passwords=@passwords and nickname=@nickname";
            SqlCommand com = new SqlCommand(qry, connect);
            com.Parameters.AddWithValue("@nickname", nickname);
            com.Parameters.AddWithValue("@passwords", passwords);
            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    nickname_user = nickname;
                    return true;                  
                }
            }
            if (dr.HasRows == false)
            {
                return false;
            }
            return false;
        }
    }
}

