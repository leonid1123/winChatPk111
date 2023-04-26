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
        int x = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            strings.Add("element1");
            strings.Add("element2");
            strings.Add("element3");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int y = 0;
            foreach (String s in strings)
            {
                Label label = new Label();
                label.Location = new Point(0, y += 25);
                label.Text = s;
                panel1.Controls.Add(label);

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            strings.Add(textBox1.Text);
            textBox1.Text = "";
        }
    }
}
