using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winChatPk111
{
    static public class MySqlConn
    {
        static string connStr = "Server=localhost;User ID=pk111;Password=123456;Database=pk111";
        static MySqlConnection conn = null;
        public static MySqlConnection GetConn()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            Debug.WriteLine(conn.State);
            return conn;
            //TODO
            //добавить проверки на подключение к БД
        }
        public static void CloseConn()
        {
            conn.Close();
        }
    }
}
