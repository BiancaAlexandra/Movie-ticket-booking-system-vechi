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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //cream o variabila care contine numele serverului si numele bazei de date
        string Conn = ("Data Source = WINDOWSDEPOZITU\\SQLEXPRESS;Initial Catalog = Sistem de rezervare bilete;Integrated Security = true");

        Form2 ob = new Form2();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUname.Text == "" && txtPass.Text == "")
                {
                    MessageBox.Show("Please enter your User Name and Password");
                }
                else
                {
                    //conexiunea este posibila
                    SqlConnection con = new SqlConnection(Conn);
                    //comanda pe care o transmit
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username = @UserName and Password = @UserPass", con);

                    //transmitem parametrii
                    cmd.Parameters.AddWithValue("@UserName", txtUname.Text);
                    cmd.Parameters.AddWithValue("@UserPass", txtPass.Text);

                    //deschidem conexiunea
                    con.Open();
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    //introducem obiectul ds in adpt
                    adpt.Fill(ds);
                    //inchidem conexiunea
                    con.Close();

                    int count = ds.Tables[0].Rows.Count;

                    if(count == 1)
                    {
                        MessageBox.Show("Succesfully login");
                        this.Hide();
                        ob.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name or Password");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Form4 ob1 = new Form4();

        private void button2_Click(object sender, EventArgs e)
        {
            ob1.Show();
        }
    }
}
