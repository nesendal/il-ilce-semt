using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace il_ilce_semt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti;
        SqlCommand komut;
      

        private void Doldur()
        {
            comboBox1.Items.Clear();
            baglanti = new SqlConnection("Data Source=DESKTOP-KG64S0D;Database=AdresDB;Integrated Security=true");
            komut = new SqlCommand("select id, adi from iller", baglanti);
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["adi"]);
            }
        }

     
        private void Form1_Load_1(object sender, EventArgs e)
        {
            label1.Text = "il";
            label2.Text = "ilce";
            Doldur();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            baglanti = new SqlConnection("Data Source=DESKTOP-KG64S0D;Database=AdresDB;Integrated Security=true");
            komut = new SqlCommand("select id from iller where adi=@ad", baglanti);
            komut.Parameters.AddWithValue("@ad", comboBox1.SelectedItem.ToString());
            baglanti.Open();
            int id = (int)komut.ExecuteScalar();
            baglanti.Close();

            komut = new SqlCommand("select id, adi from ilceler where il_id=@ilid", baglanti); // Komut belirtiyoruz. İller tablosundaki verilerin id sini ve adını istiyoruz.
            komut.Parameters.AddWithValue("@ilid", id);
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["adi"]);
            }
        }
    }
}
