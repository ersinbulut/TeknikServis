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
    public partial class FrmNotlar : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmNotlar()
        {
            InitializeComponent();
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource =  db.TBLNOTLARIM.Where(x=>x.DURUM == false).ToList();
            gridControl2.DataSource =  db.TBLNOTLARIM.Where(y=>y.DURUM == true).ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLARIM t = new TBLNOTLARIM();
            t.BASLIK = txtBaslik.Text;
            t.ICERIK = txtIcerik.Text;
            t.DURUM = false;
            t.TARIH= DateTime.Parse(txtTarih.Text);
            db.TBLNOTLARIM.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLARIM.Where(y => y.DURUM == true).ToList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                int id = int.Parse(txtID.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Not Durumu Değiştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtBaslik.Text = gridView1.GetFocusedRowCellValue("BASLIK").ToString();
            txtIcerik.Text = gridView1.GetFocusedRowCellValue("ICERIK").ToString();
            checkEdit1.Checked = false;
        }
    }
}
