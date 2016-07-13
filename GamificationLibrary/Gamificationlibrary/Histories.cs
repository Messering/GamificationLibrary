using Gamificationlibrary.DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificationlibrary
{
    public class Histories : GamificationConnectGamification
    {

        public static KeyValuePair<string, int>[] gKeyValue;
        public static Point[] pointCoord;
        public void addHistory(int changepoint, DateTime date)
        {
            History.Insert(Account.id_user, changepoint, date);
        }

        public static KeyValuePair<string, int>[] getProgressUser(int countday, DateTime nowDate)
        {

            TimeSpan dateDiff = new TimeSpan(countday, 0, 0, 0, 0); ;
            DateTime endDate = nowDate - dateDiff;
            connect.Open();

            //string strSQL1 = "SELECT points, record_date FROM History Where id_user = '1' AND record_date>= '2016-06-04' AND record_date<= '2016-06-04' ORDER BY record_date ";
            string strSQL1 = " SELECT points, record_date FROM History Where id_user = '"+Account.id_user+"' AND record_date>= '"+endDate.Date.ToString("yyyy-MM-dd")+"' AND record_date<= '2016-07-20' ORDER BY record_date";
            MySqlCommand myCommand1 = new MySqlCommand(strSQL1, connect);
            
            MySqlDataReader dr1 = myCommand1.ExecuteReader();
            pointCoord = new Point[5];
            gKeyValue = new KeyValuePair<string, int>[5];
            int i = 0;
            while (dr1.Read())
            {
                gKeyValue[i] = new KeyValuePair<string, int>(((DateTime)dr1[1]).Date.ToString("yyyy-MM-dd"), (int)dr1[0]);
                pointCoord[i].X = i;
                pointCoord[i].Y = (int)dr1[0];
                i++;
            }
                connect.Close();
                return gKeyValue;
            
        }
    }
}
