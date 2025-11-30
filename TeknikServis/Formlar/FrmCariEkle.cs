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

       

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TBLCARI t = new TBLCARI();
                t.AD = txtAd.Text;
                t.SOYAD = txtSoyad.Text;
                t.TELEFON = txtTelefon.Text;
                t.MAIL = txtMail.Text;
                t.IL = lupIl.Text;
                t.ILCE = lupIlce.Text;
                t.BANKA = txtBanka.Text;
                t.VERGIDAIRESI = txtVdaire.Text;
                t.VERGINO = txtVno.Text;
                t.STATU = txtStatu.Text;
                t.ADRES = txtAdres.Text;
                db.TBLCARI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Cari Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
               MessageBox.Show("Hata Oluştu Lütfen Tekrar Deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int secilen;
        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
            lupIl.Properties.DataSource = (from x in db.TBLILLER
                                           select new
                                           {
                                               x.ILID,
                                               x.ILADI
                                           }).ToList();
            lupIlce.Properties.DataSource = (from y in db.TBLILCELER
                                             select new
                                             {
                                                 y.ILCEID,
                                                 y.ILCEADI
                                             }).ToList();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit14_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
