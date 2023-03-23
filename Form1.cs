using MySqlConnector;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace winChatPk111
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User(loginInput.Text, passwordInput.Text);
            string info = user.GetInfo();
            Debug.WriteLine(info);

            string loginString = "SELECT password FROM users WHERE nikname=@param ";
            MySqlCommand loginComm = new MySqlCommand(loginString, MySqlConn.GetConn());

            loginComm.Parameters.AddWithValue("@param",user.GetLogin());
            loginComm.ExecuteNonQuery();

            MySqlDataReader loginDataReader = loginComm.ExecuteReader();
            loginDataReader.Read();

            if (user.Comp(loginDataReader.GetString(0)))
            {
                MySqlConn.CloseConn();
                label3.Text = "Пароли совпадают";
                string onlineStr = "UPDATE `users` SET `online`=true WHERE id=@id";
                MySqlCommand onlineCmd = new MySqlCommand(onlineStr, MySqlConn.GetConn());
                onlineCmd.Parameters.AddWithValue("@id",);
                //UPDATE `users` SET `online`=true WHERE id=4
            }
            else
            {
                label3.Text = "Пароли НЕ совпадают";
            }
             
        }
        private void Form1_Load(object sender, EventArgs e)
        {
             
        }
    }
    public class User
    {
        string login;
        string password;
        string name;
        int age;
        int id;
        public int Age
        {
            set
            {
                age = value;
            }
            get
            {
                return age;
            }
        }
        public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public User(string _login, string _password)
        {
            login = _login;
            password = _password;
        }
        public void SetName(string _name)
        {
            string oldName = _name.Remove(0, 1);
            name = oldName.Insert(0, Char.ToUpper(_name[0]).ToString());
        }
        public string GetLogin()
        {
            return login;
        }
        public string GetInfo()
        {
            return "login: " + login + " password: " + password;
        }
        public bool Comp(string _passInput)
        {
            return password.Equals(_passInput);
        }
        
    }
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
