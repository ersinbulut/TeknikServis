using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.İletisim
{
    public partial class FrmGelenMesajlar : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }

        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            lblToplamMesajSayisi.Text = db.TBLILETISIM.Count().ToString();
            lblTesekkurMesajSayisi.Text = db.TBLILETISIM.Where(x => x.KONU == "Teşekkür").Count().ToString();
            lblSikayetMesajSayisi.Text = db.TBLILETISIM.Where(x => x.KONU == "Şikayet").Count().ToString();
            lblRicaMesajSayisi.Text = db.TBLILETISIM.Where(x => x.KONU == "Rica").Count().ToString();
            labelControl1.Text=db.TBLPERSONEL.Count().ToString();
            labelControl3.Text=db.TBLCARI.Count().ToString();
            labelControl5.Text=db.TBLKATEGORI.Count().ToString();
            labelControl7.Text=db.TBLURUN.Count().ToString();

            gridControl1.DataSource = (from x in db.TBLILETISIM
                                       select new
                                       {
                                           x.ID,
                                           x.ADSOYAD,
                                           x.MAIL,
                                           x.KONU,
                                           x.MESAJ
                                       }).ToList();

        }
    }
}
