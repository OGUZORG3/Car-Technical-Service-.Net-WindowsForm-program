﻿using System;
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
    public partial class Filolar : Form
    {
        MysqlBaglantı baglantı = new MysqlBaglantı();
        public Filolar()
        {
            InitializeComponent();
        }
        private void btnFiloekle_Click(object sender, EventArgs e)
        {
            islevFormları.FiloEkle filoEkle = new islevFormları.FiloEkle(this);
            filoEkle.Show();
        }
        İslemler islemYap = new İslemler();
        private void Filolar_Load(object sender, EventArgs e)
        {
            FiloTablo.DataSource = islemYap.Listele("filolar");
        }
       public void yenile()
        {
            FiloTablo.DataSource = islemYap.Listele("filolar");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            islemYap.musteriSil(index, "filolar", "filo_id");
            yenile();
        }
        public string index;
        private void FiloTablo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = FiloTablo.Rows[e.RowIndex].Cells[0].Value.ToString();
                filoid = Convert.ToInt32(FiloTablo.Rows[e.RowIndex].Cells[0].Value);
                filoadi = FiloTablo.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
            }
        }
        public string filoadi;
        public int filoid;
        private void FiloGuncelle_Click(object sender, EventArgs e)
        {
            if (index!= null)
            {

            Filo filo = new Filo(filoid,filoadi);
            islevFormları.FiloDuzenle filoDuzenle = new islevFormları.FiloDuzenle(this,filo);
            filoDuzenle.Show();
            }
            else
            {
                MessageBox.Show("Filo secmediniz");
            }
        }
        public void filoGuncelle(Filo filo)
        {
            try
            {
            baglantı.BaglantıAc();
            baglantı.komut = new MySqlCommand("UPDATE filolar set filo_adi=@filo_adi,filo_id=@filo_id Where filo_id=" + index + "", baglantı.mysqlbaglan);
            baglantı.komut.Parameters.AddWithValue("@filo_id", filo.filoid);
            baglantı.komut.Parameters.AddWithValue("@filo_adi", filo.filoadi);
            yenile();

            baglantı.BaglantıKapat();

            }
            catch (Exception hata)
            {
                MessageBox.Show(""+ hata);
                throw;
            }
            finally
            {
                MessageBox.Show("başarılı");
            }
        }
    }
}
