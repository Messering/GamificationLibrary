using Gamificationlibrary.DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificationlibrary
{
    public class Rank : GamificationConnectGamification, Points
    {
        public int points;
        public string title;
        public int id_rank;
        public string note;
        public byte[] blob;

        public int minPoints { get; private set; }
        public int maxPoints { get; private set; }

        /// <summary>
        /// Add new rank
        /// </summary>
        /// <param name="title"></param>
        /// <param name="points"></param>
        /// <param name="Images"></param>
        /// <param name="note"></param>
        public void addRank(string title,  int points, byte[] Images=null, string note = "")
        {

            connect.Open();
            Ranks.Insert(title, points, Images, note);
            connect.Close();
        }

        public Rank() { }
        public Rank(int id_rank)
        {
            this.id_rank = id_rank;
        }
        /// <summary>
        /// Return point this level
        /// </summary>
        /// <returns></returns>
        public int getPoints()
        {
            return points;
        }
        /// <summary>
        /// Return title this level
        /// </summary>
        /// <returns></returns>
        public string getTitle()
        {
            return title;
        }

        /// <summary>
        /// Search rank
        /// </summary>
        /// <param name="title"></param>
        public void searchRank(string title)
        {
            connect.Open();
            string strSQL1 = String.Format("SELECT * FROM Ranks Where title = '{0}'", title);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                id_rank = (int)dr1[0];
                title = dr1[1].ToString();
                blob = (byte[])dr1[2];
                points = (int)dr1[3];
                note = dr1[4].ToString();
            }
            connect.Close();
        }

        /// <summary>
        /// Update rank user
        /// </summary>
        /// <param name="points"></param>
        public void updateRankUser(int points)
        {
            connect.Open();
            string strSQL1 = String.Format("SELECT * FROM Ranks Where points = '{0}'", points);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                id_rank = (int)dr1[0];
                title = dr1[1].ToString();
                blob = (byte[])dr1[2];
                points = (int)dr1[3];
                note = dr1[4].ToString();
            }
            connect.Close();
        }
        public void Dispose()
        {
            this.Dispose();
        }

        /// <summary>
        /// Previous rank user
        /// </summary>
        public void backRankUser()
        {
            connect.Open();
            string strSQL1 = String.Format("SELECT * FROM Ranks Where id_rank < '{0}' ORDER BY `id_rank` DESC  LIMIT 1 ", id_rank);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                id_rank = (int)dr1[0];
                title = dr1[1].ToString();
                blob = (byte[])dr1[2];
                points = (int)dr1[3];
                note = dr1[4].ToString();
            }
            connect.Close();
        }
        /// <summary>
        /// The next rank user
        /// </summary>
        public void nextRankUser()
        {
            connect.Open();
            string strSQL1 = String.Format("SELECT * FROM Ranks Where id_rank > '{0}' ORDER BY `id_rank` ASC LIMIT 1 ", id_rank);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                id_rank = (int)dr1[0];
                title = dr1[1].ToString();
                blob = (byte[])dr1[2];
                points = (int)dr1[3];
                note = dr1[4].ToString();
            }
            connect.Close();
        }

        public void progressRank(string title)
        {
            searchRank(title);
            minPoints = points;
            nextRankUser();
            maxPoints = points;
        }
        public void addActivity(string titleActivity) {
            connect.Open();
            Activity.Insert(titleActivity, title, Account.id_user, blob);
            connect.Close();
        }
        
    }
}
