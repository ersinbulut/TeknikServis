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
    public partial class FrmArizaliUrunKaydi : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNKABUL t = new TBLURUNKABUL();
            t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            t.GELISTARIH = DateTime.Parse(txtTarih.Text);
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            t.URUNSERINO = txtSerino.Text;
            t.URUNDURUMDETAY = "Ürün Kaydoldu";
            db.TBLURUNKABUL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Arızalı Ürün Kaydı Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            //MÜŞTERİ 
            lookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     ADSOYAD = x.AD + " " + x.SOYAD
                                                 }).ToList();
            //PERSONEL
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
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

        private void txtTarih_Click(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
