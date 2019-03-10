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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            SqlConnection con1 = new SqlConnection(Conn);

            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Clienti", con1);

            SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
            DataTable dtbl2 = new DataTable();
            da2.Fill(dtbl2);
            dataGridView1.DataSource = dtbl2;
            con1.Close();
        }

        //cream o variabila care contine numele serverului si numele bazei de date
        string Conn = ("Data Source = WINDOWSDEPOZITU\\SQLEXPRESS;Initial Catalog = Sistem de rezervare bilete;Integrated Security = true");

        private void button1_Click(object sender, EventArgs e)
        {
                //conexiunea este posibila
                SqlConnection con = new SqlConnection(Conn);

            //deschidem conexiunea
            con.Open();

            //comanda pe care o transmit
            SqlCommand cmd = new SqlCommand("UPDATE Clienti SET Nume = @Nume,Prenume = @Prenume,email = @email,telefon = @telefon,data_nasterii = @data_nasterii WHERE Nume = @Num and Prenume = @Pren ", con);
            //transmitem parametrii
            cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
            cmd.Parameters.AddWithValue("@Prenume", textBox2.Text);
            cmd.Parameters.AddWithValue("@email", textBox3.Text);
            cmd.Parameters.AddWithValue("@telefon", textBox4.Text);
            cmd.Parameters.AddWithValue("@data_nasterii", textBox5.Text);
            cmd.Parameters.AddWithValue("@Num", textBox7.Text);
            cmd.Parameters.AddWithValue("@Pren", textBox6.Text);
            
            cmd.ExecuteNonQuery();
            
            MessageBox.Show("Succesfully update");

            SqlCommand cmd2 = new SqlCommand("select * from Clienti", con);

            SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
            DataTable dtbl1 = new DataTable();
            da1.Fill(dtbl1);
            dataGridView1.DataSource = dtbl1;
            //inchidem conexiunea
            con.Close();
            }       
    }
}
