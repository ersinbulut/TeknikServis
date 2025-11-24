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
    public partial class FrmYeniDepartman : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();
            if (txtAd.Text.Length <= 50 && txtAd.Text != "")
            {
                t.AD = txtAd.Text;
                //t.ACIKLAMA = richTextBox1.Text;
                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt yapılamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
