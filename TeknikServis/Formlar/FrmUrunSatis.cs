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
    public partial class FrmUrunSatis : Form
    {
        DBTeknikServisEntities db=new DBTeknikServisEntities();
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
           TBLURUNHAREKET t = new TBLURUNHAREKET();
            t.URUN = int.Parse(lupUrun.EditValue.ToString());
            t.MUSTERI = int.Parse(lupMusteri.EditValue.ToString());
            t.PERSONEL = short.Parse(lupPersonel.EditValue.ToString());
            t.TARIH = DateTime.Parse(txtTarih.Text);
            t.ADET = short.Parse(txtAdet.Text);
            t.FIYAT = decimal.Parse(txtFiyat.Text);
            t.URUNSERINO = txtSerino.Text;
            db.TBLURUNHAREKET.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Satışı Gerçekleşti","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {
            lupUrun.Properties.DataSource = (from x in db.TBLURUN
                                         select new
                                         {
                                             x.ID,
                                             x.AD
                                         }).ToList();
            lupMusteri.Properties.DataSource = (from x in db.TBLCARI
                                               select new
                                               {
                                                   x.ID,
                                                   ADSOYAD = x.AD + " " + x.SOYAD
                                               }).ToList();

            lupPersonel.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     ADSOYAD = x.AD + " " + x.SOYAD
                                                 }).ToList();

        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
