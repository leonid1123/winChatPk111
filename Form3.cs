using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winChatPk111
{
    public partial class Form3 : Form
    {
        List<String> strings = new List<String>();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            strings.Add("element1");
            strings.Add("element2");
            strings.Add("element3");
         
            listBox1.DataSource = strings;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            strings.Add("element_new");
            listBox1.BeginUpdate();
            listBox1.DataSource = null;
            listBox1.DataSource = strings;
            listBox1.EndUpdate();
            Console.WriteLine(strings.Count);
        }
    }
}
