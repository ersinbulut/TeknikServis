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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();


        void metod1()
        {
            var degerler = from u in db.TBLURUN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               KATEGORİ = u.TBLKATEGORI.AD,
                               u.STOK,
                               u.ALISFIYAT,
                               u.SATISFIYAT
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            // Ürün listesini DataGridView'e yükle
            //var degerler= db.TBLURUN.ToList();
         metod1();
            // Kategori verilerini LookUpEdit'e yükle
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORI
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
      

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.AD = txtUrunAd.Text;
            t.MARKA = txtMarka.Text;
            t.STOK = short.Parse(txtStok.Text);
            t.ALISFIYAT = decimal.Parse(txtAlisfiyat.Text);
            t.SATISFIYAT = decimal.Parse(txtSatisfiyat.Text);
            t.DURUM = false;
            t.KATEGORİ = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
           metod1();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                txtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                txtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
                txtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
                txtAlisfiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
                txtSatisfiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("KATEGORİ").ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu Lütfen Tekrar Deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var urun = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var urun = db.TBLURUN.Find(id);
            urun.AD = txtUrunAd.Text;
            urun.MARKA = txtMarka.Text;
            urun.STOK = short.Parse(txtStok.Text);
            urun.ALISFIYAT = decimal.Parse(txtAlisfiyat.Text);
            urun.SATISFIYAT = decimal.Parse(txtSatisfiyat.Text);
            urun.KATEGORİ = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtUrunAd.Text = "";
            txtMarka.Text = "";
            txtStok.Text = "";
            txtAlisfiyat.Text = "";
            txtSatisfiyat.Text = "";
            lookUpEdit1.EditValue = null;
        }
    }
}
