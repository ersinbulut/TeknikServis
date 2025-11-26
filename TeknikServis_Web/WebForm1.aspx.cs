using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeknikServis_Web.Entity;

namespace TeknikServis_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            ////var degerler= db.TBLURUNTAKIP.ToList();
            ////Repeater1.DataSource = degerler;
            ////Repeater1.DataBind();
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            var degerler = db.TBLURUNTAKIP.Where(x => x.SERINO == txtSeriNo.Text);
            Repeater1.DataSource = degerler.ToList();
            Repeater1.DataBind();
        }
    }
}