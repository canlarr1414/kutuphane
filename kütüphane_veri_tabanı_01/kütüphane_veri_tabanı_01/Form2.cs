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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbDataAdapter data;
        OleDbCommand sorgu;

        void listele()
        {
            baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0;Data source=kutuphane.mdb");
            baglanti.Open();
            data = new OleDbDataAdapter("Select * from kullanıcı",baglanti);
            DataTable sorgu = new DataTable();
            data.Fill(sorgu);
            dataGridView1.DataSource = sorgu;
            baglanti.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * FROM kitaplar";
            OleDbCommand komut = new OleDbCommand(sorgu,baglanti);
            baglanti.Open();

            OleDbDataReader okuma = komut.ExecuteReader();
            okuma.Read();

            if (okuma.GetValue(1).ToString() == textBox1.Text && okuma.GetValue(2).ToString() == textBox2.Text)
            {
                Form1 frm = new Form1();
                frm.Show();
            }
            else
            {
                MessageBox.Show("kullanıcı ve parola yanlış");
            }
            baglanti.Close();
        }
    
        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
