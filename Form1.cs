using MySqlConnector;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace winChatPk111
{
    //пофиксить:
    //1. прокрутка сообщений
    //2. чистить поле для отправки сообщений
    //3. Отправка сообщение по "Enter"
    //4. Сделать регистрацию
    //5. 
    public partial class Form1 : Form
    {
        //переменная для того, чтобы закрыть form1 и открыть form2
        public bool isLoggedIn = false;
        public Form1()
        {
            InitializeComponent();
        }
        //Обработка события "Нажатие на кнопку 'Вход'
        private void button1_Click(object sender, EventArgs e)
        {
            //Вносим в класс User логин и пароль, которые
            //пользователь написал в соответствующих полях
            User.UserLogin(loginInput.Text, passwordInput.Text);
            //выводим информацио о пользователе для проверки
            string info = User.GetInfo();
            Debug.WriteLine(info);
            //Готовим и выполняем запрос в БД, для получения пароля и id по введенному имени пользователя
            string loginString = "SELECT password, id FROM users WHERE nikname=@param ";
            MySqlCommand loginComm = new MySqlCommand(loginString, MySqlConn.GetConn());

            loginComm.Parameters.AddWithValue("param",User.GetLogin());
            loginComm.ExecuteNonQuery();

            MySqlDataReader loginDataReader = loginComm.ExecuteReader();
            loginDataReader.Read();
            //Debug.WriteLine(user.GetLogin());
            //Если в ответе на запрос есть записи и введенный пароль совпадает
            //с паролем из БД, то пользователю в БД в поле online пишем true
            //закрываем form1, открываем form2
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
            else //если ответ не содержит записей или пароли не совпадают, то выводим сообщение
            {
                label3.Text = "Пароли НЕ совпадают";
            }
             
        }
        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3= new Form3();
            form3.Show();
        }
    }
    
    
}
