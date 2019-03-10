using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//ne conectam la baza de date
using System.Data.SqlClient;


namespace Login
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        Form12 ob = new Form12();
        Form13 ob1 = new Form13();
        Form14 ob2 = new Form14();

        private void button1_Click(object sender, EventArgs e)
        {
            ob.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ob1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ob2.Show();
        }
    }
}
