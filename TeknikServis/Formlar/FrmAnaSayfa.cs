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
    public partial class FrmAnaSayfa : Form
    {
        DBTeknikServisEntities db=new DBTeknikServisEntities();
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            gridControl4.DataSource = (from x in db.TBLURUN 
                                       select new
                                       {
                                           x.AD,
                                           x.STOK
                                       }).Where(x=>x.STOK <30).ToList();

            gridControl2.DataSource = (from x in db.TBLCARI
                                       select new
                                       {
                                           x.AD,
                                           x.SOYAD,
                                           x.IL
                                       }).ToList();
        }
    }
}
