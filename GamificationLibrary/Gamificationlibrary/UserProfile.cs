using Gamificationlibrary.DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificationlibrary
{
    public class UserProfile: GamificationConnectGamification
    {
        protected int id_user { get; set; }
        protected int level { get; set; }
        protected int rank { get; set; }
        public int points { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public byte[] imageUser { get; set; }
        public string email { get; set; }
        public string passwords { get; set; }
        public string titleLevel { get; set; }
        public string titleRank { get; set; }
        public string imageRank { get; set; }
        private new MySqlConnection  connect;


        public UserProfile(int id_user, MySqlConnection connect)
        {
            this.id_user = id_user;
            this.connect = connect;
        }

        /// <summary>
        /// Load the user data
        /// </summary>
        public void loadInformation()
        {
            connect.Open();
            string strSQL1 = String.Format("SELECT * FROM Users Where id_user = '{0}'", id_user);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                name = dr1[1].ToString();
                nickname = dr1[2].ToString();
                passwords = dr1[3].ToString();
                email= dr1[4].ToString();
                imageUser= (byte[]) dr1[5];
            }
            connect.Close();
            connect.Open();
            string strSQL2 = String.Format("SELECT * FROM Profiles Where id_user = '{0}'", id_user);
            MySqlCommand myCommand2 = new MySqlCommand(strSQL2, connect);
            MySqlDataReader dr2 = myCommand2.ExecuteReader();
            while (dr2.Read())
            {
                points = Convert.ToInt32(dr2[2]);
                level =Convert.ToInt32(dr2[3]);
                rank = Convert.ToInt32(dr2[4]);
            }
            connect.Close();
            connect.Open();
            string strSQL3 = String.Format("SELECT * FROM Levels Where id_level = '{0}'", level);
            MySqlCommand myCommand3 = new MySqlCommand(strSQL3, connect);
            MySqlDataReader dr3 = myCommand3.ExecuteReader();
            while (dr3.Read())
            {
                for (int i = 1; i < dr3.FieldCount; i++)
                {
                    titleLevel = dr3[1].ToString();
                }
            }
            connect.Close();
            connect.Open();
            string strSQL4 = String.Format("SELECT * FROM Ranks Where id_rank = '{0}'", rank);
            MySqlCommand myCommand4 = new MySqlCommand(strSQL4, connect);
            MySqlDataReader dr4 = myCommand4.ExecuteReader();
            while (dr4.Read())
            {
                for (int i = 1; i < dr4.FieldCount; i++)
                {
                    titleRank = dr4[1].ToString();
                    imageRank = dr4[2].ToString();
                }
            }
            connect.Close();
        }

        public void addPoints(int point)
        {
            connect.Open();
            Profile.Update(id_user, "points",point);
            connect.Close();
        }
    }
}
