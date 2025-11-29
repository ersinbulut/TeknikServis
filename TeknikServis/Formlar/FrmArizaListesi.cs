using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();

        public FrmArizaListesi()
        {
            InitializeComponent();
        }

        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLURUNKABUL
                            select new
                            {
                                x.ISLEMID,
                                CARI = x.TBLCARI.AD + x.TBLCARI.SOYAD,
                                PERSONEL = x.TBLPERSONEL.AD + x.TBLPERSONEL.SOYAD,
                                x.GELISTARIH,
                                x.CIKISTARIHI,
                                x.URUNSERINO,
                                x.URUNDURUMDETAY,

                            };
            gridControl1.DataSource = degerler.ToList();
            lblMevcutArizaliUrunSayisi.Text = db.TBLURUNKABUL.Count(x=>x.URUNDURUM == true).ToString();
            lblTadilatibitmisUrunSayisi.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUM == false).ToString();
            lblToplamUrunSayisi.Text = db.TBLURUN.Count().ToString();
            lblParcaBekleyenUrunSayisi.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY=="Parça Bekliyor" ).ToString();
            lblMesajBeklenenMusteriler.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY=="Mesaj Bekliyor" ).ToString();
            lblİptalEdilenİslemler.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY=="İptal Bekliyor" ).ToString();

            SqlConnection baglanti = new SqlConnection(@"Data Source=BULUTS;Initial Catalog=DBTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT URUNDURUMDETAY, COUNT(*) AS 'SAYI' FROM TBLURUNKABUL GROUP BY URUNDURUMDETAY", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArizaDetaylar fr = new FrmArizaDetaylar();
            fr.id = gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.serino = gridView1.GetFocusedRowCellValue("URUNSERINO").ToString();
            fr.Show();
        }
    }
}
