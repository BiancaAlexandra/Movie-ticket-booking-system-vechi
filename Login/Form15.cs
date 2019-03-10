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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        //cream o variabila care contine numele serverului si numele bazei de date
        string Conn = ("Data Source = WINDOWSDEPOZITU\\SQLEXPRESS;Initial Catalog = Sistem de rezervare bilete;Integrated Security = true");
        //dataGridView1
        private void button1_Click(object sender, EventArgs e)
        {
            //conexiunea este posibila
            SqlConnection con = new SqlConnection(Conn);

            //deschidem conexiunea
            con.Open();
            
            //Numarul de carduri pe care il detine clientul cu ID-ul introdus(Nume + Prenume + numarul de carduri detinute)
            //comanda pe care o transmit
            SqlCommand cmd = new SqlCommand("SELECT C.Nume,C.Prenume,count(C.ID_client) as Numar_carduri FROM Clienti C inner join Carduri Ca on(C.ID_client = Ca.ID_client) WHERE C.Nume = @Nume and C.Prenume = @Prenume GROUP BY C.ID_client, C.Nume, C.Prenume; ", con);           
            //transmitem parametrii
            cmd.Parameters.AddWithValue("@Nume", textBox6.Text);
            cmd.Parameters.AddWithValue("@Prenume", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            //afisam rezultatele comenzii
            dataGridView1.DataSource = dtbl;
            //inchidem conexiunea
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //conexiunea este posibila
            SqlConnection con = new SqlConnection(Conn);

            //deschidem conexiunea
            con.Open();
            //comanda pe care o transmit
            //reduceri de afla pe cardul cu ID introdus
            //SqlCommand cmd = new SqlCommand("select R.Tip_reducere from Carduri_Reduceri Cr inner join Reduceri R on (Cr.ID_reducere = R.ID_reducere) WHERE Cr.ID_card = @ID_card group by Cr.ID_card,R.Tip_reducere  ", con);
            SqlCommand cmd = new SqlCommand("select R.Tip_reducere from Carduri_Reduceri Cr inner join Reduceri R on (Cr.ID_reducere = R.ID_reducere) WHERE Cr.ID_card = @ID_card group by Cr.ID_card,R.Tip_reducere  ", con);
            //transmitem parametrii
            cmd.Parameters.AddWithValue("@ID_card", textBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            //inchidem conexiunea
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //conexiunea este posibila
            SqlConnection con = new SqlConnection(Conn);

            //deschidem conexiunea
            con.Open();
            //comanda pe care o transmit
            //Programul filmului introdus(dupa numele filmului)
            SqlCommand cmd = new SqlCommand("select F.Nume_film , P.Durata , P.Ora_inceput ,P.Minut_inceput, P.Ora_final ,P.Minut_final from Filme F inner join Program P on (F.ID_program = P.ID_program) WHERE F.Nume_film = @Nume_film", con);
            //WHERE Cr.ID_card = @ID_card
            //transmitem parametrii
            cmd.Parameters.AddWithValue("@Nume_film", comboBox1.SelectedItem.ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            //inchidem conexiunea
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //conexiunea este posibila
            SqlConnection con = new SqlConnection(Conn);

            //deschidem conexiunea
            con.Open();
            //comanda pe care o transmit
            //Programul filmului introdus(dupa numele filmului)
            SqlCommand cmd = new SqlCommand("select S.Numar as Numar_sala,S.Cinematograf ,F.Nume_film from Filme_Rezervari Fr inner join Filme F on (Fr.ID_film = F.ID_film) inner join Sala S on (Fr.ID_sala = S.ID_sala)", con);                  
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            //inchidem conexiunea
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //conexiunea este posibila
            SqlConnection con = new SqlConnection(Conn);

            //deschidem conexiunea
            con.Open();
            //comanda pe care o transmit
            //Pentru clientul cu ID-ul introdus sa se afiseze rezervariile si pentru fiecare rezervare numarul de bilete
            SqlCommand cmd = new SqlCommand("select C.Nume ,C.Prenume ,R.ID_rezervare,count(B.ID_rezervare ) as numar_bilete from Clienti C inner join Rezervari R on (C.ID_client = R.ID_client) inner join Bilete B on (R.ID_rezervare = B.ID_rezervare) where C.Nume = @Nume and C.Prenume = @Prenume group by B.ID_rezervare, C.Nume, C.Prenume, R.ID_rezervare", con);
            //transmitem parametrii
            cmd.Parameters.AddWithValue("@Nume", textBox3.Text);
            cmd.Parameters.AddWithValue("@Prenume", textBox4.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            //inchidem conexiunea
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //conexiunea este posibila
            SqlConnection con = new SqlConnection(Conn);

            //deschidem conexiunea
            con.Open();
            //comanda pe care o transmit
            //Suma ce trebuie platita de fiecare client pentru fiecare rezervare
            SqlCommand cmd = new SqlCommand("select C.Nume ,C.Prenume ,R.ID_rezervare ,sum(P.pret) as pret_bilete from Clienti C inner join Rezervari R on (C.ID_client = R.ID_client) inner join Bilete B on (B.ID_rezervare = R.ID_rezervare) inner join Preturi P on (P.Tip_pret = B.Tip_pret) WHERE C.Nume = @Nume and C.Prenume = @Prenume group by C.ID_client, C.Nume, C.Prenume, R.ID_rezervare", con);
            //transmitem parametrii
            //cmd.Parameters.AddWithValue("@ID_client", textBox5.Text);
            cmd.Parameters.AddWithValue("@Nume", textBox7.Text);
            cmd.Parameters.AddWithValue("@Prenume", textBox5.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            //inchidem conexiunea
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //conexiunea este posibila
            SqlConnection con = new SqlConnection(Conn);

            //deschidem conexiunea
            con.Open();
            //comanda pe care o transmit
            //Clientii care au  carduri
            SqlCommand cmd = new SqlCommand("select C.Nume, C.Prenume from Clienti C where C.ID_client IN(select Ca.ID_client from Carduri Ca); ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            //inchidem conexiunea
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //conexiunea este posibila
            SqlConnection con = new SqlConnection(Conn);

            //deschidem conexiunea
            con.Open();
            //comanda pe care o transmit
            //Clientul cu cea mai mare suma de plata per rezervare
            SqlCommand cmd = new SqlCommand("select C.Nume ,C.Prenume ,R.ID_rezervare ,sum(P.pret) as sum from Clienti C inner join Rezervari R on (C.ID_client = R.ID_client) inner join Bilete B on (B.ID_rezervare = R.ID_rezervare) inner join Preturi P on (P.Tip_pret = B.Tip_pret) group by C.ID_client, C.Nume, C.Prenume, R.ID_rezervare having sum(P.pret) > ALL( select sum(P1.pret)  from Clienti C1 inner join Rezervari R1 on (C1.ID_client = R1.ID_client) inner join Bilete B1 on (B1.ID_rezervare = R1.ID_rezervare) inner join Preturi P1 on (P1.Tip_pret = B1.Tip_pret) where C1.ID_client != C.ID_client group by R1.ID_rezervare    ); ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            //inchidem conexiunea
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //conexiunea este posibila
            SqlConnection con = new SqlConnection(Conn);

            //deschidem conexiunea
            con.Open();
            //comanda pe care o transmit
            //Clientii care si-au facut rezervari
            SqlCommand cmd = new SqlCommand("select C.Nume , C.Prenume from Clienti C where C.ID_client in (   select R.ID_client   from Rezervari R); ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            //inchidem conexiunea
            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //conexiunea este posibila
            SqlConnection con = new SqlConnection(Conn);

            //deschidem conexiunea
            con.Open();
            //comanda pe care o transmit
            //Filmul la care s-au facut cele mai multe rezervari
            SqlCommand cmd = new SqlCommand("select F.Nume_film,count(F.ID_film) as Nr_rezervari from Filme F inner join Filme_Rezervari Fr on (F.ID_film = Fr.ID_film) group by F.ID_film, F.Nume_film having count(F.ID_film) >= ALL( select count(Fr1.ID_film)    from Filme_Rezervari Fr1    group by Fr1.ID_film     ); ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            //inchidem conexiunea
            con.Close();
        }
    }
}
