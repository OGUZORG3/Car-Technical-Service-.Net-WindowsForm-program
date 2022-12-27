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

namespace Final_Proje.islevFormları
{
    public partial class AracEkle : Form
    {
        Formlar.Araclar baglıEkran;
        MysqlBaglantı veri = new MysqlBaglantı();
        İslemler islemYap = new İslemler();
        
        public AracEkle(Formlar.Araclar parametre)
        {
            InitializeComponent();
            veri.BaglantıAc();
            baglıEkran = parametre;
        }

        private void AracEkle_Load(object sender, EventArgs e)
        {
            Filo();
            sigorta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            Arac arac = new Arac(txtMarka.Text, txtModel.Text, txtYıl.Text, txtSaseNo.Text, TxtPlaka.Text, Convert.ToInt32(cmbSigortaİd.Text), Convert.ToInt32(cmbFiloİd.Text));
            islemYap.aracEkle(arac);
            baglıEkran.yenile();

            }
            catch (Exception)
            {
                MessageBox.Show("Boş deger girdiniz");
            }
        }
        private void Filo()
        {

            cmbFiloİd.Items.Clear();
            string sql = "SELECT filo_id FROM filolar";
            veri.komut = new MySqlCommand(sql, veri.mysqlbaglan);
            veri.oku = veri.komut.ExecuteReader();
            while (veri.oku.Read())
            {
                cmbFiloİd.Items.Add(veri.oku[0]);
            }
            veri.oku.Close();

            baglıEkran.yenile();
        }
        private void sigorta()
        {

            cmbSigortaİd.Items.Clear();
            string sql = "SELECT sigorta_id FROM sigorta_sirketleri";
            veri.komut = new MySqlCommand(sql, veri.mysqlbaglan);
            veri.oku = veri.komut.ExecuteReader();
            while (veri.oku.Read())
            {
                cmbSigortaİd.Items.Add(veri.oku[0]);
            }
            veri.oku.Close();

            baglıEkran.yenile();
        }
    }
}
