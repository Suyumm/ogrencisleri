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
    public partial class okul_islem : Form
    {
        public okul_islem()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\ogrenci.accdb");

        private void kayit()
        {
            try
            {
                bag.Open();
                OleDbDataAdapter list = new OleDbDataAdapter("select * from okul", bag);
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
        private void okul_islem_Load(object sender, EventArgs e)
        {
            kayit();
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

            OleDbCommand ekle = new OleDbCommand("insert into okul(adi,sinif_id)values ('" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "')", bag);
            ekle.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("bilgi kaydedildi ");
            textBox1.Clear();
            comboBox1.Items.Clear();
            kayit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand guncelle = new OleDbCommand("update okul set okul_id='" + textBox3.Text + "', sinif_id='" + comboBox1.SelectedItem.ToString() + "' where adi ='" + textBox1.Text + "'", bag);
            guncelle.ExecuteNonQuery();
            bag.Close();

            kayit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand sil = new OleDbCommand("delete from okul where okul_id='" + textBox3.Text + "'", bag);
            sil.ExecuteNonQuery();
            bag.Close();
            kayit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                OleDbDataAdapter ara = new OleDbDataAdapter("select * from okul where adi='" + textBox2.Text + "'", bag);
                DataSet ds = new DataSet();
                ara.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                bag.Close();
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
                bag.Close();
            }
        }
    }
}
