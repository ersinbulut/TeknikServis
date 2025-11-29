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
    public partial class FrmArizaDetaylar : Form
    {
        DBTeknikServisEntities db=new DBTeknikServisEntities();
        public FrmArizaDetaylar()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNTAKIP t = new TBLURUNTAKIP();
            t.ACIKLAMA = richArizaDetay.Text;
            t.SERINO = txtSeriNo.Text;
            t.TARIH = DateTime.Parse(txtTarih.Text);
            db.TBLURUNTAKIP.Add(t);

            //2.güncelleme
            TBLURUNKABUL tb = new TBLURUNKABUL();
           int urunid = int.Parse(id.ToString());
            var deger = db.TBLURUNKABUL.Find(urunid);
            deger.URUNDURUMDETAY = comboBox1.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Arıza Detayı Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void richArizaDetay_Click(object sender, EventArgs e)
        {
            richArizaDetay.Text = "";
        }

        private void txtSeriNo_Click(object sender, EventArgs e)
        {
            txtSeriNo.Text = "";
        }

        private void txtTarih_Click(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string id,serino;
        private void FrmArizaDetaylar_Load(object sender, EventArgs e)
        {
           txtSeriNo.Text = serino;
        }
    }
}
