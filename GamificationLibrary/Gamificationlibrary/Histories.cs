using Gamificationlibrary.DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificationlibrary
{
    public class Histories :GamificationConnectGamification
    {
       public struct Graph
        {
           public DateTime date;
           public int point;
        }
        public void addHistory(int changepoint, DateTime date)
        {
            History.Insert(Account.id_user, changepoint, date);
        }

        public List<Graph> getProgressUser(int countday, DateTime nowDate) {
            List<Graph> g=new List<Graph>();
            TimeSpan dateDiff = new TimeSpan(30, 0, 0, 0, 0); ;
            DateTime endDate =nowDate- dateDiff;
            connect.Open();
            string strSQL1 = String.Format("SELECT points, record_date FROM History Where id_user = '{0}' AND record_date>='{1}' AND record_date<='{2}'", Account.id_user,endDate,nowDate);
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            while (dr1.Read())
            {
                Graph item = new Graph();
                item.point = (int)dr1[0];
                item.date = (DateTime)dr1[1];
                g.Add(item);
            }
                return g;
        }
    }
}
