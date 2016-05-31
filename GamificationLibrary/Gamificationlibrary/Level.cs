using Gamificationlibrary.DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificationlibrary
{
    public class Level : GamificationConnectGamification, Points
    {
        public int points;
        public string title;
        public int id_level;
        public string note;
        public byte[] blob;
        public int minPoints { get; private set; }
        public int maxPoints { get; private set; }

        /// <summary>
        /// Add new level
        /// </summary>
        /// <param name="title"></param>
        /// <param name="points"></param>
        /// <param name="Images"></param>
        /// <param name="note"></param>
        public void addLevel(string title,  int points, byte[] Images= null, string note = "")
        {

            connect.Open();
            Levels.Insert(title, points, Images, note);
            connect.Close();
        }

        public Level() { }
        public Level(int id_level)
        {
            this.id_level = id_level;
        }
        /// <summary>
        /// return points this level
        /// </summary>
        /// <returns></returns>
        public int getPoints()
        {
            return points;
        }
        /// <summary>
        /// return title this level
        /// </summary>
        /// <returns></returns>
        public string getTitle()
        {
            return title;
        }
        /// <summary>
        /// Search level
        /// </summary>
        /// <param name="title"></param>
        public void searchLevel(string title)
        {
            connect.Close();
            connect.Open();
            string strSQL1 = String.Format("SELECT * FROM Levels Where title = '{0}'", title);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                id_level = (int)dr1[0];
                title = dr1[1].ToString();
                //blob = (byte[])dr1[2];
                points = (int)dr1[3];
                note = dr1[4].ToString();
            }
            connect.Close();
        }

        /// <summary>
        /// Update level user
        /// </summary>
        /// <param name="points"></param>
        public void updateLevelUser(int points)
        {
            connect.Open();
            string strSQL1 = String.Format("SELECT * FROM Levels Where points = '{0}'", points);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                id_level = (int)dr1[0];
                title = dr1[1].ToString();
                blob = (byte[])dr1[2];
                points = (int)dr1[3];
                note = dr1[4].ToString();
            }
            connect.Close();
        }
        /// <summary>
        /// Previous level
        /// </summary>
        public void backLevelUser()
        {
            connect.Open();
            string strSQL1 = String.Format("SELECT * FROM Levels Where id_level < '{0}' ORDER BY `id_level` DESC  LIMIT 1 ", id_level);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                id_level = (int)dr1[0];
                title = dr1[1].ToString();
               // blob = (byte[])dr1[2];
                points = (int)dr1[3];
                note = dr1[4].ToString();
            }
            connect.Close();
        }
        /// <summary>
        /// The next level
        /// </summary>
        public void nextLevelUser()
        {
            connect.Open();
            string strSQL1 = String.Format("SELECT * FROM Levels Where id_level > '{0}' ORDER BY `id_level` ASC LIMIT 1 ", id_level);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                id_level = (int)dr1[0];
                title = dr1[1].ToString();
              //  blob = (byte[])dr1[2];
                points = (int)dr1[3];
                note = dr1[4].ToString();
            }
            connect.Close();
        }

        public void Dispose()
        {
            this.Dispose();
        }
        public void addActivity(string titleActivity) {
            connect.Open();
            Activity.Insert(titleActivity, title, Account.id_user, blob);
            connect.Close();
        }

        public void progressLevel(string title) {
            searchLevel(title);
            minPoints = points;
            nextLevelUser();
            maxPoints = points;
        }
    }
}
