using System.Data.SqlClient;

namespace Gamificationlibrary.DataBase
{
    public class GamificationConnectGamification
    {
        protected static SqlConnection connect = null;

        public static void OpenConnection(string connectionString)
        {
            connect = new SqlConnection(connectionString);
            connect.Open();
        }

        public static void CloseConnection()
        {
            connect.Close();
        }
    }
}
