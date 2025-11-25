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
            t.SERINO = txtSerino.Text;
            t.TARIH = DateTime.Parse(txtTarih.Text);
            db.TBLURUNTAKIP.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Arıza Detayı Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
