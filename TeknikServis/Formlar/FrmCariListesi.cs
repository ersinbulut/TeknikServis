using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.DirectXPaint;

namespace TeknikServis.Formlar
{
    public partial class FrmCariListesi : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();

        public FrmCariListesi()
        {
            InitializeComponent();
        }
        void liste()
        {
            var degerler = from x in db.TBLCARI
                           select new
                           {
                               x.ID,
                               x.AD,
                               x.SOYAD,
                               x.IL,
                               x.ILCE,
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        int secilen;
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            liste();
            lblToplamCariSayisi.Text = db.TBLCARI.Count().ToString();

            lupIl.Properties.DataSource = (from x in db.TBLILLER
                                           select new
                                           {
                                               x.ILID,
                                               x.ILADI
                                           }).ToList();
            lblToplamİlSayisi.Text = db.TBLCARI.Select(x=>x.IL).Distinct().Count().ToString();
            lblToplamİlceSayisi.Text = db.TBLCARI.Select(x => x.ILCE).Distinct().Count().ToString();
        }

        private void lupIl_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lupIl.EditValue.ToString());
            lupIlce.Properties.DataSource = (from y in db.TBLILCELER
                                             where y.ILID == secilen
                                             select new
                                             {
                                                 y.ILCEID,
                                                 y.ILCEADI,
                                             }).ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text !="" & txtSoyad.Text!="" & txtAd.Text.Length<=20)
            {
                TBLCARI t = new TBLCARI();
                t.AD = txtAd.Text;
                t.SOYAD = txtSoyad.Text;
                t.TELEFON = txtTelefon.Text;
                t.IL = lupIl.Text;
                t.ILCE = lupIlce.Text;
                db.TBLCARI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Cari Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                liste();
            }
            else
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
    }
}
