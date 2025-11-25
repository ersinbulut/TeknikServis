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
    public partial class FrmFaturaListesi : Form
    {
        DBTeknikServisEntities db=  new DBTeknikServisEntities();
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
                var degerler = from u in db.TBLFATURABILGI
                           select new
                           {
                               u.ID,
                               u.SERI,
                               u.SIRANO,
                               u.TARIH,
                               u.SAAT,
                               u.VERGIDAIRE,
                              CARİ= u.TBLCARI.AD+" "+ u.TBLCARI.SOYAD,
                               PERSONEL=u.TBLPERSONEL.AD+" "+ u.TBLPERSONEL.SOYAD,
                          
                           };
            gridControl1.DataSource = degerler.ToList();
            lpCari.Properties.DataSource = (from x in db.TBLCARI
                                               select new
                                               {
                                                   x.ID,
                                                   ADSOYAD=x.AD + " " + x.SOYAD
                                               }).ToList();
            lpPersonel.Properties.DataSource = (from x in db.TBLPERSONEL
                                               select new
                                               {
                                                   x.ID,
                                                   ADSOYAD = x.AD + " " + x.SOYAD
                                               }).ToList();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLFATURABILGI
                           select new
                           {
                               u.ID,
                               u.SERI,
                               u.SIRANO,
                               u.TARIH,
                               u.SAAT,
                               u.VERGIDAIRE,
                               CARİ = u.TBLCARI.AD+" "+u.TBLCARI.SOYAD,
                               PERSONEL = u.TBLPERSONEL.AD+" "+u.TBLPERSONEL.SOYAD,

                           };
            gridControl1.DataSource = degerler.ToList();
            lpCari.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     ADSOYAD = x.AD + " " + x.SOYAD
                                                 }).ToList();
            lpPersonel.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     ADSOYAD = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURABILGI t = new TBLFATURABILGI();
            t.SERI = txtSeri.Text;
            t.SIRANO = txtSırano.Text;
            t.TARIH = Convert.ToDateTime(txtTarih.Text);
            t.SAAT = txtSaat.Text;
            t.VERGIDAIRE = txtVergiDairesi.Text;
            t.CARI = int.Parse(lpCari.EditValue.ToString());
            t.PERSEONEL = short.Parse(lpPersonel.EditValue.ToString());
            db.TBLFATURABILGI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
