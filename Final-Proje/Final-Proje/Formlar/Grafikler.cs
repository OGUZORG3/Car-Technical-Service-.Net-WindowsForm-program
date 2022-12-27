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
    public partial class Grafikler : Form
    {
        MysqlBaglantı baglan = new MysqlBaglantı();
        public Grafikler()
        {
            InitializeComponent();
        }

        private void Grafikler_Load(object sender, EventArgs e)
        {
            baglan.BaglantıAc();
            baglan.komut = new MySqlCommand("SELECT sigorta_id, COUNT(sigorta_id),	marka FROM araclar GROUP BY sigorta_id,marka; ", baglan.mysqlbaglan);
            baglan.oku = baglan.komut.ExecuteReader();
            while (baglan.oku.Read())
            {
                chart1.Series["Yedek parcalar"].Points.AddXY(baglan.oku[2].ToString()+"("+ baglan.oku[0].ToString() + ")", baglan.oku[1].ToString());
            }
            baglan.BaglantıKapat();

        }
    }
}
