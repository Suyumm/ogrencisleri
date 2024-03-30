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

namespace ogrenciIsleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\ogrenci.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            hakkinda hakkinda = new hakkinda();
            hakkinda.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş yer bırakmayınız!");
            }
            else
            {
                bag.Open();
                OleDbCommand komut = new OleDbCommand("select * from kullanici where k_ad='" + textBox1.Text + "'", bag);
                OleDbDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read() == true)
                {
                    if (textBox1.Text == okuyucu["k_ad"].ToString() && textBox2.Text == okuyucu["sifre"].ToString())
                    {
                        MessageBox.Show("HİÇ Hoş Gelmediniz'" + okuyucu["k_ad"].ToString() + "'");
                        Form2 menu = new Form2();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Yanlış Giriş Yaptın");
                    }

                }
                else
                {
                    MessageBox.Show("Yanlış Hareketler Yaptığını Görüyorum");
                }
                bag.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
