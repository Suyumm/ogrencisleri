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
    public partial class sinif_islemleri : Form
    {
        public sinif_islemleri()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\ogrenci.accdb");
        private void kayit()
        {
            try
            {
                bag.Open();
                OleDbDataAdapter list = new OleDbDataAdapter("select * from sinif", bag);
                DataSet dsBilgi = new DataSet();
                list.Fill(dsBilgi);
                dataGridView1.DataSource = dsBilgi.Tables[0];
                bag.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                bag.Close();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

            Form2 menu = new Form2();
            menu.Show();
            this.Hide();
        }

        private void sinif_islemleri_Load(object sender, EventArgs e)
        {
            kayit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bag.Open();

            OleDbCommand ekle = new OleDbCommand("insert into sinif (sube,bolum_id,sinif_id)values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", bag);
            ekle.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("bilgi kaydedildi ");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            kayit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand guncelle = new OleDbCommand("update sinif set sinif_id='" + textBox3.Text + "', bolum_id='" + textBox2.Text + "' where sube ='" + textBox1.Text + "'", bag);
            guncelle.ExecuteNonQuery();
            bag.Close();

            kayit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand sil = new OleDbCommand("delete * from sinif where sube='" + textBox1.Text + "'", bag);
            sil.ExecuteNonQuery();
            bag.Close();
            kayit();
            MessageBox.Show("bilgi silindi");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                OleDbDataAdapter ara = new OleDbDataAdapter("select * from sinif where sube='" + textBox1.Text + "'", bag);
                DataSet ds = new DataSet();
                ara.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                bag.Close();
                textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                bag.Close();
            }
        }
    }
}
