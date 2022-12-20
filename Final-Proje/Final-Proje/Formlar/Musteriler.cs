using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Final_Proje.Formlar
{
    public partial class Musteriler : Form
    {   
        MysqlBaglantı veri = new MysqlBaglantı();

        public Musteriler()
        {
            InitializeComponent();
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            islevFormları.MusteriEkle me = new islevFormları.MusteriEkle(this);
            me.Show();
        }

        private void Musteriler_Load(object sender, EventArgs e)
        {

           veri.dataset = new DataTable();
            veri.BaglantıAc();
            /*  veri.adapter = new MySqlDataAdapter("SELECT * FROM t_musteri",veri.mysqlbaglan);
             veri.adapter.Fill(veri.dataset);
             dataGridView1.DataSource = veri.dataset;
             veri.mysqlbaglan.Close();*/
            dataGridView1.DataSource = ekle.Listele();
        }
            MusteriEkleSınıf ekle = new MusteriEkleSınıf();
        public void yenile ()
        {
            dataGridView1.DataSource = ekle.Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
