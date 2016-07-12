using Gamificationlibrary.DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificationlibrary
{
   public class Badge: GamificationConnectGamification, IPoints
    {
        public int points;
        public string title;
        public int id_badge;
        public string note;
        public byte[] Images;
        public string descriptions;
        public List<Badge> badgesUser=new List<Badge>();

        /// <summary>
        /// Add new badge
        /// </summary>
        public void addBadge() {
            connect.Open();
            Badges.Insert(title, points, Images=null, note="", descriptions="");
            connect.Close();
        }

        /// <summary>
        /// return points this badge
        /// </summary>
        /// <returns></returns>
        public int getPoints()
        {
            return points;
        }
        /// <summary>
        /// return title this badge
        /// </summary>
        /// <returns></returns>
        public string getTitle()
        {
            return title;
        }

        /// <summary>
        /// Search badge
        /// </summary>
        /// <param name="title"></param>
        public void searchBadge(string title)
        {
            connect.Open();
            string strSQL1 = String.Format("SELECT * FROM Badges Where title = '{0}'", title);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                id_badge = (int)dr1[0];
                title = dr1[1].ToString();
                Images = (byte[])dr1[2];
                points = (int)dr1[3];
                note = dr1[4].ToString();
                descriptions = dr1[5].ToString();
            }
            connect.Close();
        }

        /// <summary>
        /// Add badge in list user badge
        /// </summary>
        /// <param name="title"></param>
        public void addUserBadge(string title) {
            connect.Open();
            ListBadges.Insert(Account.id_user,id_badge);
            connect.Close();
        }

        /// <summary>
        /// return list badge user
        /// </summary>
        public void getListBageUser() {
            connect.Open();
            string strSQL1 = String.Format("SELECT * FROM badgesuser Where id_user = '{0}'", Account.id_user);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                string strSQL2 = String.Format("SELECT * FROM Badges Where id_badge = '{0}'",(int) dr1[2]);
                MySqlCommand myCommand2 = new MySqlCommand(strSQL2, connect);
                MySqlDataReader dr2 = myCommand1.ExecuteReader();
                while (dr2.Read()) {
                    Badge badge = new Badge();
                    badge.id_badge = (int)dr2[0];
                    badge.title = dr2[1].ToString();
                    badge.Images = (byte[])dr2[2];
                    badge.points = (int)dr2[3];
                    badge.note = dr2[4].ToString();
                    badge.descriptions = dr2[5].ToString();
                    badgesUser.Add(badge);
                    badge.Dispose();
                }
            }
            connect.Close();
        }

        public void deleteBadgesUser(int id) {
            ListBadges.Delete(id);
        }
        public void Dispose() {
            this.Dispose();
        }
        public void addActivity(string titleActivity) {
            connect.Open();
            Activity.Insert(titleActivity, title, Account.id_user, Images);
                connect.Close();
        }


    }
}
