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
        MysqlBaglantı veri = new MysqlBaglantı();
        
        public AracEkle()
        {
            InitializeComponent();
            veri.BaglantıAc();
        }

        private void AracEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
