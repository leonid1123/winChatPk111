using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winChatPk111
{
    public static class User
    {
        static string login;
        static string password;
        static string name;
        static int age;
        static int id;
        static public int Age
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
        static public int Id
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
        static public void UserLogin(string _login, string _password)
        {
            login = _login;
            password = _password;
        }
        static public void SetName(string _name)
        {
            string oldName = _name.Remove(0, 1);
            name = oldName.Insert(0, Char.ToUpper(_name[0]).ToString());
        }
        static public string GetLogin()
        {
            return login;
        }
        static public string GetInfo()
        {
            return "login: " + login + " password: " + password;
        }
        static public bool Comp(string _passInput)
        {
            return password.Equals(_passInput);
        }

    }
}
