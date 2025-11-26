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
    public partial class FrmFaturaKalemleri : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmFaturaKalemleri()
        {
            InitializeComponent();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            // TextBox'lardan gelen değerler
            string seriNo = txtSeriNo.Text.Trim();
            string siraNo = txtSıraNo.Text.Trim();
            string faturaIDText = txtFaturaID.Text.Trim();

            int faturaID;
            bool idGirildi = int.TryParse(faturaIDText, out faturaID);

            // Temel sorgu
            var query = from u in db.TBLFATURADETAY
                        select new
                        {
                            u.FATURADETAYID,
                            u.URUN,
                            u.ADET,
                            u.FIYAT,
                            u.TUTAR,
                            u.FATURAID,
                            u.TBLFATURABILGI.SERI,
                            u.TBLFATURABILGI.SIRANO
                        };

            // Dinamik filtreler
            if (idGirildi)
                query = query.Where(x => x.FATURAID == faturaID);

            if (!string.IsNullOrEmpty(seriNo))
                query = query.Where(x => x.SERI.Contains(seriNo));

            if (!string.IsNullOrEmpty(siraNo))
                query = query.Where(x => x.SIRANO.Contains(siraNo));

            // Listeyi gride bas
            gridControl1.DataSource = query.ToList();
        }

    }
}
