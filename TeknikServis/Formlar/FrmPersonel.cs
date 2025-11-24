using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TeknikServis.Formlar
{
    public partial class FrmPersonel : Form
    {
        DBTeknikServisEntities db=new DBTeknikServisEntities();
        public FrmPersonel()
        {
            InitializeComponent();
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAIL,
                               u.TELEFON,
                               u.DEPARTMAN
                           };
            gridControl1.DataSource = degerler.ToList();

            lupDepartman.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                  select new
                                                  {
                                                      x.ID,
                                                      x.AD
                                                  }).ToList();
            var depId = gridView1.GetFocusedRowCellValue("DEPARTMAN");

            string ad1, soyad1,ad2,soyad2,ad3,soyad3,ad4,soyad4;
            //1.Personel
            ad1 = db.TBLPERSONEL.First(x=>x.ID==1).AD;
            soyad1 = db.TBLPERSONEL.First(x => x.ID == 1).SOYAD;
            labelControl5.Text= db.TBLPERSONEL.First(x=>x.ID==1).TBLDEPARTMAN.AD;
            labelControl8.Text= db.TBLPERSONEL.First(x=>x.ID==1).MAIL;
            labelControl3.Text = ad1 + " " + soyad1;
            //2.Personel
            ad2 = db.TBLPERSONEL.First(x => x.ID == 2).AD;
            soyad2 = db.TBLPERSONEL.First(x => x.ID == 2).SOYAD;
            labelControl11.Text = db.TBLPERSONEL.First(x => x.ID == 2).TBLDEPARTMAN.AD;
            labelControl9.Text = db.TBLPERSONEL.First(x => x.ID == 2).MAIL;
            labelControl14.Text = ad2 + " " + soyad2;
            //3.Personel
            ad3 = db.TBLPERSONEL.First(x => x.ID == 3).AD;
            soyad3 = db.TBLPERSONEL.First(x => x.ID == 3).SOYAD;
            labelControl18.Text = db.TBLPERSONEL.First(x => x.ID == 3).TBLDEPARTMAN.AD;
            labelControl16.Text = db.TBLPERSONEL.First(x => x.ID == 3).MAIL;
            labelControl20.Text = ad3 + " " + soyad3;
            //4.Personel
            ad4 = db.TBLPERSONEL.First(x => x.ID == 4).AD;
            soyad4 = db.TBLPERSONEL.First(x => x.ID == 4).SOYAD;
            labelControl24.Text = db.TBLPERSONEL.First(x => x.ID == 4).TBLDEPARTMAN.AD;
            labelControl22.Text = db.TBLPERSONEL.First(x => x.ID == 4).MAIL;
            labelControl26.Text = ad4 + " " + soyad4;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID")?.ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("AD")?.ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD")?.ToString();

            // Departman listeleme
            lupDepartman.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                  select new
                                                  {
                                                      x.ID,
                                                      x.AD
                                                  }).ToList();
            lupDepartman.Properties.DisplayMember = "AD";
            lupDepartman.Properties.ValueMember = "ID";

            // Personelin departmanı
            var depId = gridView1.GetFocusedRowCellValue("DEPARTMAN");

            if (depId != null && depId != DBNull.Value)
                lupDepartman.EditValue = Convert.ToByte(depId);
            else
                lupDepartman.EditValue = null;

            txtFotograf.Text = gridView1.GetFocusedRowCellValue("FOTOGRAF")?.ToString();
            txtMail.Text = gridView1.GetFocusedRowCellValue("MAIL")?.ToString();
            txtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON")?.ToString();
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var personel = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(personel);
            db.SaveChanges();
            XtraMessageBox.Show("Personel Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var personel = db.TBLPERSONEL.Find(id);

            personel.AD = txtAd.Text;
            personel.SOYAD = txtSoyad.Text;

            // Departman güncelleme (byte? türüne çeviriyoruz)
            personel.DEPARTMAN = Convert.ToByte(lupDepartman.EditValue);

            personel.FOTOGRAF = txtFotograf.Text;
            personel.MAIL = txtMail.Text;
            personel.TELEFON = txtTelefon.Text;

            db.SaveChanges();

            XtraMessageBox.Show("Personel Başarıyla Güncellendi",
                                "Bilgi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAIL,
                               u.TELEFON,
                           };
            gridControl1.DataSource = degerler.ToList();

        }
    }
}
