using MySqlConnector;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace winChatPk111
{
    public partial class Form1 : Form
    {
        //для закрытия формы
        public bool isLoggedIn = false;

        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User.UserLogin(loginInput.Text, passwordInput.Text);
            string info = User.GetInfo();
            Debug.WriteLine(info);

            string loginString = "SELECT password, id FROM users WHERE nikname=@param ";
            MySqlCommand loginComm = new MySqlCommand(loginString, MySqlConn.GetConn());

            loginComm.Parameters.AddWithValue("param",User.GetLogin());
            loginComm.ExecuteNonQuery();

            MySqlDataReader loginDataReader = loginComm.ExecuteReader();
            loginDataReader.Read();
            //Debug.WriteLine(user.GetLogin());

            if (loginDataReader.HasRows && User.Comp(loginDataReader.GetString(0)))
            {
                User.Id = loginDataReader.GetInt32(1);
                MySqlConn.CloseConn();
                label3.Text = "Пароли совпадают";
                string onlineStr = "UPDATE `users` SET `online`=true WHERE id=@id";
                MySqlCommand onlineCmd = new MySqlCommand(onlineStr, MySqlConn.GetConn());
                onlineCmd.Parameters.AddWithValue("id",User.Id);
                onlineCmd.ExecuteNonQuery(); 
                MySqlConn.CloseConn();
                //для закрытия формы
                this.Close();
                isLoggedIn= true;
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
    
    
}
