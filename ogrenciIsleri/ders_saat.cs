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
    public partial class bilgiler : Form
    {
        public bilgiler()
        {
            InitializeComponent();
        }

        private void bilgiler_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form2 menu = new Form2();
            menu.Show();
            this.Hide();
        }
    }
}
