using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
}
