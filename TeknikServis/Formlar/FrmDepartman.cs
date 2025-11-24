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
    public partial class FrmDepartman : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmDepartman()
        {
            InitializeComponent();
        }

        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLDEPARTMAN
                           select new
                           {
                               x.ID,
                               x.AD,
                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl12.Text = db.TBLDEPARTMAN.Count().ToString();
            labelControl14.Text = db.TBLPERSONEL.Count().ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();
            if (txtAd.Text.Length <=50 && txtAd.Text!="")
            {
                t.AD = txtAd.Text;
                //t.ACIKLAMA = richTextBox1.Text;
                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt yapılamadı","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
          
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            db.TBLDEPARTMAN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            //richTextBox1.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            deger.AD = txtAd.Text;
            //deger.ACIKLAMA = richTextBox1.Text;
            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLDEPARTMAN
                           select new
                           {
                               x.ID,
                               x.AD,
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
