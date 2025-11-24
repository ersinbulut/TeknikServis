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
    public partial class FrmCariEkle : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmCariEkle()
        {
            InitializeComponent();
        }

        private void pictureEdit14_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();
            t.AD = txtAd.Text;
            t.SOYAD = txtSoyad.Text;
            t.TELEFON = txtTelefon.Text;
            t.MAIL = txtMail.Text;
            t.IL = txtİl.Text;
            t.ILCE = txtİlce.Text;
            t.BANKA = txtBanka.Text;
            t.VERGIDAIRESI = txtVdaire.Text;
            t.VERGINO = txtVno.Text;
            t.STATU = txtStatu.Text;
            t.ADRES = txtAdres.Text;
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Cari Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
