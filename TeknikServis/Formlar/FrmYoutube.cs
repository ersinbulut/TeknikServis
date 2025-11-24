using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using Microsoft.Web.WebView2.WinForms;

namespace TeknikServis.Formlar
{
    public partial class FrmYoutube : Form
    {
        public FrmYoutube()
        {
            InitializeComponent();
        }

        private async void FrmYoutube_Load(object sender, EventArgs e)
        {
            var webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.Navigate("https://www.youtube.com/watch?v=fOzBVy-sDbM");

            this.Controls.Add(webView);
        }
    }
}
