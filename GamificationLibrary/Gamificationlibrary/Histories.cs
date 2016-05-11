using Gamificationlibrary.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificationlibrary
{
    public class Histories
    {
        public void addHistory(int changepoint, DateTime date)
        {
            History.Insert(Account.id_user, changepoint, date);
        }
    }
}
