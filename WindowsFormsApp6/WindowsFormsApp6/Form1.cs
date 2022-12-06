using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int saat = 0, dakika = 0, saniye = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        
            Random red = new Random();
            Random gren = new Random();
            Random blue = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            label3.Text = ":"+saniye;
            if (saniye==60)
            {
                saniye = 0;
                this.BackColor = Color.BlueViolet;
                dakika++;
                label2.Text = ":"+dakika;
                if (dakika==60)
                {
                    dakika = 0;
                    saat++;
                    if (saat>24)
                    {
                        saniye = 0;
                        dakika = 0;
                        saat = 0;
                    }
                }
            }
        }
    }
}
