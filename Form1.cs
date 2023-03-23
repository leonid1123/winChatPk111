using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

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
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string connection = "Server=localhost;User ID=pk111;Password=123456;Database=pk111";
            MySqlConnection conn = new MySqlConnection(connection);
            try
            {
                conn.Open();
            } catch(MySqlException ex)
            {

            }
            Debug.WriteLine(conn.State);
            if (conn.State != ConnectionState.Open)
            {
                button1.Enabled = false;
            }
        }
    }
    public class User
    {
        string login;
        string password;
        string name;
        int age;
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
        public string GetName()
        {
            return name;
        }
        public string GetInfo()
        {
            return "login: " + login + " password: " + password;
        }
    }
}
