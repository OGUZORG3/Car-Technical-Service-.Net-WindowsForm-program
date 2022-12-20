using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Proje
{
   
    public class Musteri
    {
        public string Ad;
        public string SoyAd;
        public int Telefon;
        public string Marka;
        public string Model;
        public int Sase;
        public Musteri(string ad, string Soyad,int Tel,string marka,string model,int sase)
        {
            Ad = ad;
            SoyAd = Soyad;
            Telefon = Tel;
            Marka = marka;
            Model = model;
            Sase = sase;
        }

    }
}
