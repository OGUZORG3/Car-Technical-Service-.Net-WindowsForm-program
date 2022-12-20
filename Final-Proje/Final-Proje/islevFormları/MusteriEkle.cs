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
    public partial class MusteriEkle : Form
    {
        Formlar.Musteriler anaEkran;
        MysqlBaglantı veri = new MysqlBaglantı();
        
        public MusteriEkle(Formlar.Musteriler Parametre)
        {
            InitializeComponent();
            anaEkran = Parametre;
            veri.BaglantıAc();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            MusteriEkleSınıf ekle = new MusteriEkleSınıf();
            ekle.musteriEkle(txtAd.Text,txtSoyad.Text,txtTc.Text,TxtAdres.Text,txtTel.Text,Convert.ToInt32(cmbAracid.Text), Convert.ToInt32(cmbSigortaid.Text), Convert.ToInt32(cmbFiloid.Text));
            
            anaEkran.yenile();
            this.Close();
            
        }

        private void MusteriEkle_Load(object sender, EventArgs e)
        {
            arac();
            sigorta();
            Filo();
        }
        private void arac()
        {
            
            cmbAracid.Items.Clear();
            string sql = "SELECT arac_id FROM araclar";
            veri.komut = new MySqlCommand(sql, veri.mysqlbaglan);
            veri.oku = veri.komut.ExecuteReader();
            while (veri.oku.Read())
            {
                cmbAracid.Items.Add(veri.oku[0]);
            }
            veri.oku.Close();

            anaEkran.yenile();
        }
        private void Filo()
        {
            
            cmbFiloid.Items.Clear();
            string sql = "SELECT arac_id FROM araclar";
            veri.komut = new MySqlCommand(sql, veri.mysqlbaglan);
            veri.oku = veri.komut.ExecuteReader();
            while (veri.oku.Read())
            {
                cmbFiloid.Items.Add(veri.oku[0]);
            }
            veri.oku.Close();

            anaEkran.yenile();
        }
        private void sigorta()
        {
          
            cmbSigortaid.Items.Clear();
            string sql = "SELECT arac_id FROM araclar";
            veri.komut = new MySqlCommand(sql, veri.mysqlbaglan);
            veri.oku = veri.komut.ExecuteReader();
            while (veri.oku.Read())
            {
                cmbSigortaid.Items.Add(veri.oku[0]);
            }
            veri.oku.Close();

            anaEkran.yenile();
        }
    }
}
