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
    public partial class bolum_islem : Form
    {
        public bolum_islem()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\ogrenci.accdb");
        private void kayit()
        {
            try
            {
                bag.Open();
                OleDbDataAdapter list = new OleDbDataAdapter("select * from bolum", bag);
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

        private void button2_Click(object sender, EventArgs e)
        {
            bag.Open();

            OleDbCommand ekle = new OleDbCommand("insert into bolum (adi,sinif,ogrenci_id,ogretmen_id)values ('" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "')", bag);
            ekle.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("bilgi kaydedildi ");
            textBox1.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            kayit();
        }

        private void bolum_islem_Load(object sender, EventArgs e)
        {
            kayit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand guncelle = new OleDbCommand("update bolum set adi='" + textBox1.Text + "', sinif='" + comboBox1.SelectedItem.ToString()+ "'", bag) ;
            guncelle.ExecuteNonQuery();
            bag.Close();

            kayit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand sil = new OleDbCommand("delete * from bolum where adi='" + textBox1.Text + "'", bag);
            sil.ExecuteNonQuery();
            bag.Close();
            kayit();
            MessageBox.Show("bilgi silindi");
            textBox1.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
        }
    }
}
