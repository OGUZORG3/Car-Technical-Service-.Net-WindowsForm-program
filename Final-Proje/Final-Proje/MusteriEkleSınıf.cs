using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Final_Proje
{
    
    class MusteriEkleSınıf
    {
        MysqlBaglantı veri = new MysqlBaglantı();
        public DataTable Listele()
        {
            try
            {
                veri.dataset = new DataTable();
                veri.BaglantıAc();
                // veri.komut = new MySqlCommand("SELECT * FROM t_musteri ", veri.baglandtı);
                // veri.adapter = new MySqlDataAdapter("SELECT * FROM ('"+tablo+"')", veri.mysqlbaglan);
                veri.adapter = new MySqlDataAdapter("SELECT * FROM musteriler ", veri.mysqlbaglan);
                veri.adapter.Fill(veri.dataset);
                // veri.oku = veri.komut.ExecuteReader();
                // DataTable Tablo = new DataTable();
                // Tablo.Load(veri.oku);
                veri.mysqlbaglan.Close();
                return veri.dataset;
            }
            catch (Exception hata)
            {
                System.Windows.Forms.MessageBox.Show("" + hata);
                throw;
            }
        }
        public void musteriEkle(string ad, string soyad, string tc,string adres,string tel,int aracid,int sigortaid,int filoid)
        {
            try
            {
                veri.BaglantıAc();
                veri.komut = new MySqlCommand("INSERT INTO musteriler(ad,soyad,tc,adres,tel,arac_id,sigorta_id,filo_id)values(@ad,@soyad,@tc,@adres,@tel,@arac_id,@sigorta_id,@filo_id)", veri.mysqlbaglan);
                veri.komut.Parameters.AddWithValue("@ad", ad);
                veri.komut.Parameters.AddWithValue("@soyad", soyad);
                veri.komut.Parameters.AddWithValue("@tc", tc);
                veri.komut.Parameters.AddWithValue("@adres", adres);
                veri.komut.Parameters.AddWithValue("@tel", tel);
                veri.komut.Parameters.AddWithValue("@arac_id", aracid);
                veri.komut.Parameters.AddWithValue("@sigorta_id", sigortaid);
                veri.komut.Parameters.AddWithValue("@filo_id", filoid);
                veri.komut.ExecuteNonQuery();
                veri.BaglantıKapat();
            }
            catch (Exception hata)
            {
                System.Windows.Forms.MessageBox.Show("" + hata);
                throw;
            }
            finally
            {
                System.Windows.Forms.MessageBox.Show("Kayıt İşlemi Başarılı");
            }
        }
        public void musteriSil(int id)
        {
            try
            {
                veri.BaglantıAc();
                veri.komut = new MySqlCommand("DELETE FROM Musteri WHERE Musteri_Ad=@Musteri_Ad", veri.mysqlbaglan);
                veri.komut.Parameters.AddWithValue("@musteri_id", id);
                veri.komut.ExecuteNonQuery();

                veri.BaglantıKapat();
            }
            catch (Exception hata)
            {
                System.Windows.Forms.MessageBox.Show("" + hata);
                throw;
            }
            finally
            {
                System.Windows.Forms.MessageBox.Show("Silme İşlemi Başarılı");
            }

        }
        public void musteriGuncelle(string adsoyad, string tel, string adres, string id)
        {
            try
            {
                veri.BaglantıAc();
                veri.komut = new MySqlCommand("UPDATE Musteri set musteri_adsoyad=@musteri_adsoyad,musteri_tel=@musteri_tel,musteri_adres=@musteri_adres Where musteri_id=@musteri_id", veri.mysqlbaglan);
                veri.komut.Parameters.AddWithValue("@musteri_adsoyad", adsoyad);
                veri.komut.Parameters.AddWithValue("@musteri_tel", tel);
                veri.komut.Parameters.AddWithValue("@musteri_adres", adres);
                veri.komut.Parameters.AddWithValue("@musteri_id", id);
                veri.komut.ExecuteNonQuery();

                veri.BaglantıKapat();
            }
            catch (Exception hata)
            {
                System.Windows.Forms.MessageBox.Show("" + hata);
                throw;
            }
            finally
            {
                System.Windows.Forms.MessageBox.Show("Güncelleme İşlemi Başarılı");
            }

        }
    }
}
