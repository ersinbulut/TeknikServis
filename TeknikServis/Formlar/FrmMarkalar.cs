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

            chartControl1.Series["Series 1"].Points.AddPoint("Siemens", 4);
            chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 6);
            chartControl1.Series["Series 1"].Points.AddPoint("Beko", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("Toshiba", 8);
            chartControl1.Series["Series 1"].Points.AddPoint("Lenovo", 5);

            chartControl2.Series["Kategoriler"].Points.AddPoint("Beyaz Eşya", 4);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Bilgisayar", 3);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Telefon", 6);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Küçük Ev Aletleri", 8);
            chartControl2.Series["Kategoriler"].Points.AddPoint("TV", 10);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Diğer", 2);
                

        }
    }
}
