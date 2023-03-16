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
        string login;
        string password;
        public Form1()
        {
    
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login = loginInput.Text;
            password = passwordInput.Text;

            Debug.WriteLine(login);
            Debug.WriteLine(password);

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
        User(string _login, string _password)
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
    }
}
