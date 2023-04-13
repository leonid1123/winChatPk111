using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace winChatPk111
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //метод при закгрузке form2
        //вывод приветствия в верхнюю часть окна
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Добро пожаловать: " + User.GetLogin();
        }
        //обработка события tick таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            //запрос к БД на получение ников пользователей у которых в поле online написано true
            //очистка listbox2, добавление всех данных из запроса
            listBox2.Items.Clear();
            string allUsers = "SELECT `nikname` FROM `users` WHERE `online`= true";
            MySqlCommand onlineUsers = new MySqlCommand(allUsers, MySqlConn.GetConn());
            onlineUsers.ExecuteNonQuery();
            MySqlDataReader onlineUsersReader = onlineUsers.ExecuteReader();
            while (onlineUsersReader.Read())
            {
                listBox2.Items.Add(onlineUsersReader.GetString(0));
            }
            MySqlConn.CloseConn();

            //Делаем запрос в БД на получение всех сообщений из таблицы msg
            //чистим listbox1, добавляем все данные из запроса
            //SELECT `msg`.`text`, `msg`.`time`,`users`.`nikname` FROM `msg` JOIN `users` ON `msg`.`user`=`users`.`id` ORDER BY `msg`.`time` DESC;
            listBox1.Items.Clear();
            string allMsg = "SELECT `msg`.`text`, `msg`.`time`,`users`.`nikname` FROM `msg` JOIN `users` ON `msg`.`user`=`users`.`id` ORDER BY `msg`.`time` DESC;";
            MySqlCommand allMessages = new MySqlCommand(allMsg, MySqlConn.GetConn());
            allMessages.ExecuteNonQuery();
            MySqlDataReader allMsgReader = allMessages.ExecuteReader();
            while (allMsgReader.Read())
            {
                listBox1.Items.Add(allMsgReader.GetString(2) + ":" + allMsgReader.GetDateTime(1));
                listBox1.Items.Add(allMsgReader.GetString(0));
            }
            MySqlConn.CloseConn();
        }

        private void button1_Click(object sender, EventArgs e) //отправить сообщение
        {
            //INSERT INTO `msg`(`text`, `user`) VALUES ("Текст который мы напишем", 1)
            string msg = "INSERT INTO `msg`(`text`, `user`) VALUES (@msgText,@userID)";
            MySqlCommand msgSend = new MySqlCommand(msg, MySqlConn.GetConn());
            msgSend.Parameters.AddWithValue("@msgText", msgBox.Text.Trim());
            msgSend.Parameters.AddWithValue("@userID",User.Id);
            msgSend.ExecuteNonQuery();
        }
    }
}
