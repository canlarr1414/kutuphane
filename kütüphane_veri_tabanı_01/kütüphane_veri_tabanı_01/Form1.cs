using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace kütüphane_veri_tabanı_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbDataAdapter data;
        OleDbCommand komut;

        void listele()
        {
            //açma
            baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0;Data source=kutuphane.mdb");
            baglanti.Open();
            data = new OleDbDataAdapter("Select * From kitaplar",baglanti);
            DataTable sorgu = new DataTable();
            data.Fill(sorgu);
            dataGridView1.DataSource = sorgu;
            baglanti.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ekleme
            string sorgu = "INSERT INTO kitaplar(adi,yazar,tur,raf,sayfa_sayisi,kimlik_no) VALUES ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"')";
            OleDbCommand komut = new OleDbCommand(sorgu,baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //güncelleme
            string sorgu = "UPDATE kitaplar SET adi= '" + textBox1.Text + "',yazar='" + textBox2.Text + "',tur='" + textBox3.Text + "',raf='" + textBox4.Text + "',sayfa_sayisi='" + textBox5.Text + "' WHERE kimlik_no='" + textBox6.Text + "'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //silme
            string sorgu = "DELETE FROM kitaplar WHERE adi='" + textBox1.Text + "' AND kimlik_no='" + textBox6.Text + "'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
