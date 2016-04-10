using MySql.Data.MySqlClient;

namespace Gamificationlibrary.DataBase
{
    public class GamificationConnectGamification
    {
        protected static MySqlConnection connect = null;

        public static void OpenConnection(string connectionString)
        {
            connect = new MySqlConnection(connectionString);
            connect.Open();
        }

        public static void CloseConnection()
        {
            connect.Close();
        }
    }
}
