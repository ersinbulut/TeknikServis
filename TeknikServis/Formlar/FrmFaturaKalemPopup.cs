using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmFaturaKalemPopup : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmFaturaKalemPopup()
        {
            InitializeComponent();
        }
        public int id;
        private void FrmFaturaKalemPopup_Load(object sender, EventArgs e)
        {
            //label1.Text = id.ToString();
            gridControl1.DataSource= (from x in db.TBLFATURADETAY
                                       where x.FATURAID == id
                                       select new
                                       {
                                           x.FATURADETAYID,
                                           x.URUN,
                                           x.ADET,
                                           x.FIYAT,
                                           x.TUTAR
                                       }).ToList();

            gridControl2.DataSource = db.TBLFATURABILGI.Where(x => x.ID == id).ToList();

        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            string path = "Dosya1.Pff";
            gridControl1.ExportToPdf(path);
            Process.Start(path);
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            string path = "Dosya1.xls";
            gridControl1.ExportToXls(path);
            Process.Start(path);
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
