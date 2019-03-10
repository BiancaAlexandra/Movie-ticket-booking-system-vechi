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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //cream o variabila care contine numele serverului si numele bazei de date
        //string Conn = ("Data Source = WINDOWSDEPOZITU\\SQLEXPRESS;Initial Catalog = Sistem de rezervare bilete;Integrated Security = true");

        Form5 ob = new Form5();
        Form6 ob1 = new Form6();

        private void button1_Click(object sender, EventArgs e)
        {
            ob.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ob1.Show();
        }
    }
}
