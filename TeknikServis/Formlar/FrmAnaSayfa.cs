using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmAnaSayfa : Form
    {
        DBTeknikServisEntities db=new DBTeknikServisEntities();
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            gridControl4.DataSource = (from x in db.TBLURUN 
                                       select new
                                       {
                                           x.AD,
                                           x.STOK
                                       }).Where(x=>x.STOK <30).ToList();

            gridControl2.DataSource = (from x in db.TBLCARI
                                       select new
                                       {
                                           x.AD,
                                           x.SOYAD,
                                           x.IL
                                       }).ToList();

            gridControl1.DataSource = db.urunkategori().ToList();

            DateTime bugun = DateTime.Today;
            var deger=(from x in db.TBLNOTLARIM.OrderBy(y=>y.ID).Where(z=>z.TARIH==bugun)
                       select new
                       {
                           x.BASLIK,
                           x.ICERIK
                       });

            gridControl3.DataSource = deger.ToList();

            string konu1,ad1,konu2,ad2,konu3,ad3,konu4,ad4,konu5,ad5;
            konu1 = db.TBLILETISIM.First(x => x.ID == 1).KONU;
            ad1 = db.TBLILETISIM.First(x => x.ID == 1).ADSOYAD;
            labelControl1.Text = konu1 + " - " + ad1;

            konu2 = db.TBLILETISIM.First(x => x.ID == 2).KONU;
            ad2 = db.TBLILETISIM.First(x => x.ID == 2).ADSOYAD;
            labelControl2.Text = konu2 + " - " + ad2;

            konu3 = db.TBLILETISIM.First(x => x.ID == 3).KONU;
            ad3 = db.TBLILETISIM.First(x => x.ID == 3).ADSOYAD;
            labelControl3.Text = konu3 + " - " + ad3;

            konu4 = db.TBLILETISIM.First(x => x.ID == 4).KONU;
            ad4 = db.TBLILETISIM.First(x => x.ID == 4).ADSOYAD;
            labelControl4.Text = konu4 + " - " + ad4;

            konu5 = db.TBLILETISIM.First(x => x.ID == 5).KONU;
            ad5 = db.TBLILETISIM.First(x => x.ID == 5).ADSOYAD;
            labelControl5.Text = konu5 + " - " + ad5;





        }
    }
}
