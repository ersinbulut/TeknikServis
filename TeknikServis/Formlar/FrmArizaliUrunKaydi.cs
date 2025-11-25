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
            t.CARI = int.Parse(txtID.Text);
            t.GELISTARIH = DateTime.Parse(txtTarih.Text);
            t.PERSONEL = short.Parse(txtPersonel.Text);
            t.URUNSERINO = txtSerino.Text;
            db.TBLURUNKABUL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Arızalı Ürün Kaydı Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
