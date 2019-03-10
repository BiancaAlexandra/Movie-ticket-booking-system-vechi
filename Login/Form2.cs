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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //cream o variabila care contine numele serverului si numele bazei de date
        //string Conn = ("Data Source = WINDOWSDEPOZITU\\SQLEXPRESS;Initial Catalog = Sistem de rezervare bilete;Integrated Security = true");

        Form3 ob = new Form3();
        Form7 ob1 = new Form7();
        Form11 ob2 = new Form11();
        Form15 ob3 = new Form15();

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

        private void button4_Click(object sender, EventArgs e)
        {
            ob3.Show();
        }
    }
}

