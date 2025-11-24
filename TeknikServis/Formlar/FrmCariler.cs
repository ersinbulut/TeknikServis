using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
 
namespace TeknikServis.Formlar
{
    public partial class FrmCariler : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmCariler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DEV;Initial Catalog=DBTeknikServis;Integrated Security=True;");
        private void FrmCariler_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 25);
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 18);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 15);
            //chartControl1.Series["Series 1"].Points.AddPoint("Antalya", 22);

            gridControl1.DataSource=db.TBLCARI.OrderBy(x=>x.IL).GroupBy(y=>y.IL).Select(z=>new
            {
                İL=z.Key,
                Toplam=z.Count()
            }).ToList();
            baglanti.Open();
            SqlCommand komut=new SqlCommand("SELECT IL, COUNT(*) FROM TBLCARI GROUP BY IL", baglanti);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),Convert.ToInt32(dr[1]));
            }
            baglanti.Close();

        }
    }
}
