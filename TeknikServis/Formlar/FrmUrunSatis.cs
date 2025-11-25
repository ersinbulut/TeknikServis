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
            t.URUN = int.Parse(txtID.Text);
            t.MUSTERI = int.Parse(txtMusteri.Text);
            t.PERSONEL = short.Parse(txtPersonel.Text);
            t.TARIH = DateTime.Parse(txtTarih.Text);
            t.ADET = short.Parse(txtAdet.Text);
            t.FIYAT = decimal.Parse(txtFiyat.Text);
            t.URUNSERINO = txtSerino.Text;
            db.TBLURUNHAREKET.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Satışı Gerçekleşti","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
