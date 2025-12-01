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
    public partial class FrmMarkalar : Form
    {
        DBTeknikServisEntities db=new DBTeknikServisEntities();
        public FrmMarkalar()
        {
            InitializeComponent();
        }

        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.OrderBy(x=>x.MARKA).GroupBy(y=>y.MARKA).Select(z=> new
            {
                Marka=z.Key,
                Toplam=z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            lblurunsayisi.Text= db.TBLURUN.Count().ToString();
            lblEnfazlaurun.Text= (from x in db.TBLURUN
                                 orderby x.SATISFIYAT descending
                                 select x.MARKA).FirstOrDefault();
            lblEnyuksekfiyatliMarka.Text= (from x in db.TBLURUN
                                       orderby x.SATISFIYAT ascending
                                       select x.MARKA).FirstOrDefault();

            //chartControl1.Series["Series 1"].Points.AddPoint("Siemens", 4);
            //chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 6);
            //chartControl1.Series["Series 1"].Points.AddPoint("Beko", 2);
            //chartControl1.Series["Series 1"].Points.AddPoint("Toshiba", 8);
            //chartControl1.Series["Series 1"].Points.AddPoint("Lenovo", 5);

            SqlConnection baglanti = new SqlConnection(@"Data Source=DEV;Initial Catalog=DBTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT MARKA, COUNT(*) AS 'SAYI' FROM TBLURUN GROUP BY MARKA", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

            //2. chart
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT TBLKATEGORI.AD, COUNT(*) FROM TBLURUN INNER JOIN TBLKATEGORI ON TBLKATEGORI.ID=TBLURUN.KATEGORİ GROUP BY TBLKATEGORI.AD", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            baglanti.Close();


        }
    }
}
