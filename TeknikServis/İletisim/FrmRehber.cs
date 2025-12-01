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
    public partial class FrmRehber : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmRehber()
        {
            InitializeComponent();
        }

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource= db.TBLCARI.Select(x=> new
            {
                x.ID,
                x.AD,
                x.SOYAD,
                x.TELEFON,
                x.MAIL
            }).ToList();
        }
    }
}
