using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamificationlibrary.DataBase;

namespace TestDb
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder connect =
            new SqlConnectionStringBuilder();

            connect.InitialCatalog = "Gamefication";
            connect.DataSource = @"(local)\SQLEXPRESS";
            connect.ConnectTimeout = 30;
            connect.IntegratedSecurity = true;

            Users.OpenConnection(connect.ConnectionString);
            Users.Insert(12, "BlaBla12", "Sofa", "pardon");                      

        }
    }
}
    
