using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ebat kucuk = new Ebat { Adi = "küçük", Carpan = 1 }; //Object İnitializer=yapıcı metodu öldürür ve yaptığı işi yapar.
            Ebat orta = new Ebat { Adi = "orta", Carpan = 1.25 };
            Ebat buyuk = new Ebat { Adi = "büyük", Carpan = 1.75 };
            Ebat maxi = new Ebat { Adi = "maxi", Carpan = 2 };
            cmbEbat.Items.Add(kucuk);
            cmbEbat.Items.Add(orta);
            cmbEbat.Items.Add(buyuk);
            cmbEbat.Items.Add(maxi);


            Pizza klasik = new Pizza { Adi = "klasik", Fiyat = 14 };
            Pizza karisik = new Pizza { Adi = "karışık", Fiyat = 17 };
            Pizza turkish = new Pizza { Adi = "turkish", Fiyat = 20 };
            Pizza tuna = new Pizza { Adi = "tuna", Fiyat = 21 };
            Pizza akdeniz = new Pizza { Adi = "akdeniz", Fiyat = 19 };
            Pizza karadeniz = new Pizza { Adi = "karadeniz", Fiyat = 22 };
            listPizzalar.Items.Add(klasik);
            listPizzalar.Items.Add(karisik);
            listPizzalar.Items.Add(turkish);
            listPizzalar.Items.Add(tuna);
            listPizzalar.Items.Add(akdeniz);
            listPizzalar.Items.Add(karadeniz);

            KenarTip ince = new KenarTip { Adi = "İnce Kenar", EkFiyat = 0 };
            rdbInceKenar.Tag = ince;
            KenarTip kalin = new KenarTip { Adi = "Kalın Kenar", EkFiyat = 2 };
            rdbKalinKenar.Tag = kalin;

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Pizza p = (Pizza)listPizzalar.SelectedItem;
            p.Ebati = (Ebat)cmbEbat.SelectedItem;
            p.KenarTipi = rdbInceKenar.Checked ? (KenarTip)rdbInceKenar.Tag : (KenarTip)rdbKalinKenar.Tag;
            p.Malzemeler = new List<string>();
            foreach(CheckBox ctrl in Malzemeler.Controls)
            {
                if (ctrl.Checked)
                {
                    p.Malzemeler.Add(ctrl.Text);
                }
            }
            decimal tutar = nudAdet.Value * p.Tutar;
            txtTutar.Text = tutar.ToString();
            s = new Siparis();
            s.Pizza = p;
            s.Adet = (int)nudAdet.Value;
        }
        Siparis s;
        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (s != null)
            {
                listSepet.Items.Add(s);
            }
           
        }

        private void btnSiparisiOnayla_Click(object sender, EventArgs e)
        {
            decimal toplamtutar = 0;
            int adet = 0;
            foreach(Siparis spr in listSepet.Items)
            {
                toplamtutar += spr.Adet * spr.Pizza.Tutar;
                adet++;
            }
            lblToplamTutar.Text = toplamtutar.ToString();
            MessageBox.Show(string.Format("Toplam Sipariş Adediniz : {0} Toplam Sipariş Tutarınız : {1}", adet, toplamtutar));

        }
    }
}
