using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ogrenciIsleri
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            okul_islem okul = new okul_islem();
            okul.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ogrenci_islemleri ogr = new ogrenci_islemleri();
            ogr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sinif_islemleri sinif = new sinif_islemleri();
            sinif.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bolum_islem bolum = new bolum_islem();
            bolum.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ders_islem ders = new ders_islem();
            ders.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ogretmen_islemleri ogrt = new ogretmen_islemleri();
            ogrt.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bilgiler saat = new bilgiler();
            saat.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
