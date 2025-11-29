namespace TeknikServis.Formlar
{
    partial class FrmArizaDetaylar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmArizaDetaylar));
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.richArizaDetay = new System.Windows.Forms.RichTextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSeriNo = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTarih = new DevExpress.XtraEditors.TextEdit();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeriNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarih.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(26, 375);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(143, 35);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "GÜNCELLE";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(26, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(335, 30);
            this.labelControl1.TabIndex = 44;
            this.labelControl1.Text = "ARIZALI ÜRÜN KAYDI AÇIKLAMA";
            // 
            // richArizaDetay
            // 
            this.richArizaDetay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.richArizaDetay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richArizaDetay.ForeColor = System.Drawing.Color.White;
            this.richArizaDetay.Location = new System.Drawing.Point(26, 262);
            this.richArizaDetay.Name = "richArizaDetay";
            this.richArizaDetay.Size = new System.Drawing.Size(323, 96);
            this.richArizaDetay.TabIndex = 3;
            this.richArizaDetay.Text = "ARIZA DETAYLARI";
            this.richArizaDetay.Click += new System.EventHandler(this.richArizaDetay_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(26, 284);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(0, 17);
            this.labelControl4.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(26, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 3);
            this.panel2.TabIndex = 52;
            // 
            // txtSeriNo
            // 
            this.txtSeriNo.EditValue = "Seri No";
            this.txtSeriNo.Location = new System.Drawing.Point(26, 101);
            this.txtSeriNo.Name = "txtSeriNo";
            this.txtSeriNo.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtSeriNo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSeriNo.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtSeriNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtSeriNo.Properties.Appearance.Options.UseFont = true;
            this.txtSeriNo.Properties.Appearance.Options.UseForeColor = true;
            this.txtSeriNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSeriNo.Size = new System.Drawing.Size(320, 26);
            this.txtSeriNo.TabIndex = 50;
            this.txtSeriNo.Click += new System.EventHandler(this.txtSeriNo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(26, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 3);
            this.panel1.TabIndex = 54;
            // 
            // txtTarih
            // 
            this.txtTarih.EditValue = "Tarih";
            this.txtTarih.Location = new System.Drawing.Point(26, 152);
            this.txtTarih.Name = "txtTarih";
            this.txtTarih.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtTarih.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTarih.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtTarih.Properties.Appearance.Options.UseBackColor = true;
            this.txtTarih.Properties.Appearance.Options.UseFont = true;
            this.txtTarih.Properties.Appearance.Options.UseForeColor = true;
            this.txtTarih.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtTarih.Size = new System.Drawing.Size(320, 26);
            this.txtTarih.TabIndex = 53;
            this.txtTarih.Click += new System.EventHandler(this.txtTarih_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ürün Kaydoldu",
            "Parça Bekliyor",
            "Mesaj Bekliyor",
            "İptal Edildi",
            "Fiyat Verildi"});
            this.comboBox1.Location = new System.Drawing.Point(26, 203);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(323, 29);
            this.comboBox1.TabIndex = 57;
            // 
            // btnVazgec
            // 
            this.btnVazgec.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVazgec.ImageOptions.Image")));
            this.btnVazgec.Location = new System.Drawing.Point(206, 375);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(143, 35);
            this.btnVazgec.TabIndex = 58;
            this.btnVazgec.Text = "VAZGEÇ";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // FrmArizaDetaylar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(393, 457);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtTarih);
            this.Controls.Add(this.txtSeriNo);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.richArizaDetay);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnKaydet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmArizaDetaylar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmArizaDetaylar";
            this.Load += new System.EventHandler(this.FrmArizaDetaylar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSeriNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarih.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RichTextBox richArizaDetay;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit txtSeriNo;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit txtTarih;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
    }
}