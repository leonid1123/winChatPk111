using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winChatPk111
{
    //статический класс для хранения информации о пользователе
    //который залогинился
    public static class User
    {
        static string login;//для хранения логина
        static string password;//для хранения пароля
        static string name;//для хранения имени
        static int age;//для хранения возраста
        static int id;//для хранения ID пользователя из таблицы users
        static public int Age//переменная для получения и внесения возраста(age)
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
        static public int Id//переменная пля получения и внесения ID пользователя(id)
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
        //Метод для того, чтобы задать логин и пароль пользователя(login,password)
        static public void UserLogin(string _login, string _password)
        {
            login = _login;
            password = _password;
        }
        //Метод  для того, чтобы задать имя пользователя(name)
        //Метод всегда ставит большую букву в имени пользователя
        static public void SetName(string _name)
        {
            string oldName = _name.Remove(0, 1);
            name = oldName.Insert(0, Char.ToUpper(_name[0]).ToString());
        }
        //Метод для того, чтобы получить логин пользователя
        static public string GetLogin()
        {
            return login;
        }
        //Метод для получения строки, которая содержит логин и пароль пользователя
        //Создан для отладки
        static public string GetInfo()
        {
            return "login: " + login + " password: " + password;
        }
        //Метод для сравнения пароля, который ввел пользователь на форме1
        //с паролем который хранится в БД
        static public bool Comp(string _passInput)
        {
            return password.Equals(_passInput);
        }
    }
}
