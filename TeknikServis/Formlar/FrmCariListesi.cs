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
    public partial class FrmCariListesi : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();

        public FrmCariListesi()
        {
            InitializeComponent();
        }

        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource= db.TBLCARI.ToList();
        }
    }
}
