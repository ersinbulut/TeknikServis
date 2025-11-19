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
    public partial class Frmİstatistik : Form
    {
        DBTeknikServisEntities db=new DBTeknikServisEntities(); 
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            lblurunsayisi.Text = db.TBLURUN.Count().ToString();
            lblkategorisayisi.Text = db.TBLKATEGORI.Count().ToString();
            lblstoksayisi.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
            lblKritikseviye.Text= db.TBLURUN.Count(x => x.STOK <= 20).ToString();
            lblBugunsatilanurunsayisi.Text = db.TBLURUNHAREKET.Count(x => x.TARIH == DateTime.Today).ToString();
            //
            lblEnfazlastokluurun.Text = (from x in db.TBLURUN
                                           orderby x.STOK descending
                                           select x.AD).FirstOrDefault();

            lblEnazstokluurun.Text = (from x in db.TBLURUN 
                                      orderby x.STOK ascending
                                      select x.AD).FirstOrDefault();

            lblEnfazlaurunkategorisi.Text = (from x in db.TBLURUN
                                           orderby x.SATISFIYAT descending
                                           select x.AD).FirstOrDefault();

            lblenyuksekfiyaturn.Text = (from x in db.TBLURUN
                                           orderby x.SATISFIYAT descending
                                           select x.AD).FirstOrDefault();

            lblendusukfyturun.Text = (from x in db.TBLURUN
                                          orderby x.SATISFIYAT ascending
                                          select x.AD).FirstOrDefault();
            //
            lbltoplammarka.Text = db.TBLURUN.Select(x => x.MARKA).Distinct().Count().ToString();
            lblenurunmarka.Text = (from x in db.TBLURUN
                                       group x by x.MARKA into g
                                       orderby g.Count() descending
                                       select g.Key).FirstOrDefault();
            //lblarizaliurun.Text = db.TBLURUNHAREKET.Select(x=>x.TBLURUN.TBLURUNKABUL).Count().ToString();
            //lbltamirurun.Text = db.TBLURUNHAREKET.Count(x => x.dur == true).ToString();

            lblbeyazesya.Text = db.TBLURUN.Count(x => x.KATEGORİ == 4).ToString();

            lblbilgisayar.Text = db.TBLURUN.Count(x => x.KATEGORİ == 1).ToString();

            lblkucukevaleti.Text = db.TBLURUN.Count(x => x.KATEGORİ == 3).ToString();

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit10_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
