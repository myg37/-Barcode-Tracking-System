namespace loginform
{
    partial class mainfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainfrm));
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_barkodekle = new System.Windows.Forms.Button();
            this.btn_barkodgor = new System.Windows.Forms.Button();
            this.btn_barkod_duzenle = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.Color.White;
            this.btn_import.Location = new System.Drawing.Point(80, 34);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(240, 70);
            this.btn_import.TabIndex = 0;
            this.btn_import.Text = "Excel\'den Veri Aktar";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_barkodekle
            // 
            this.btn_barkodekle.BackColor = System.Drawing.Color.White;
            this.btn_barkodekle.Location = new System.Drawing.Point(80, 110);
            this.btn_barkodekle.Name = "btn_barkodekle";
            this.btn_barkodekle.Size = new System.Drawing.Size(240, 70);
            this.btn_barkodekle.TabIndex = 1;
            this.btn_barkodekle.Text = "Barkod Ekle";
            this.btn_barkodekle.UseVisualStyleBackColor = false;
            this.btn_barkodekle.Click += new System.EventHandler(this.btn_barkodekle_Click);
            // 
            // btn_barkodgor
            // 
            this.btn_barkodgor.BackColor = System.Drawing.Color.White;
            this.btn_barkodgor.Location = new System.Drawing.Point(80, 186);
            this.btn_barkodgor.Name = "btn_barkodgor";
            this.btn_barkodgor.Size = new System.Drawing.Size(240, 70);
            this.btn_barkodgor.TabIndex = 2;
            this.btn_barkodgor.Text = "Barkodları Görüntüle";
            this.btn_barkodgor.UseVisualStyleBackColor = false;
            this.btn_barkodgor.Click += new System.EventHandler(this.btn_barkodgor_Click);
            // 
            // btn_barkod_duzenle
            // 
            this.btn_barkod_duzenle.BackColor = System.Drawing.Color.White;
            this.btn_barkod_duzenle.Location = new System.Drawing.Point(80, 262);
            this.btn_barkod_duzenle.Name = "btn_barkod_duzenle";
            this.btn_barkod_duzenle.Size = new System.Drawing.Size(240, 70);
            this.btn_barkod_duzenle.TabIndex = 3;
            this.btn_barkod_duzenle.Text = "Barkod Düzenle";
            this.btn_barkod_duzenle.UseVisualStyleBackColor = false;
            this.btn_barkod_duzenle.Click += new System.EventHandler(this.btn_barkod_duzenle_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(4, 4);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(64, 23);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "◀ Geri";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(392, 343);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btn_barkod_duzenle);
            this.Controls.Add(this.btn_barkodgor);
            this.Controls.Add(this.btn_barkodekle);
            this.Controls.Add(this.btn_import);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İşlem Ekranı";
            this.Load += new System.EventHandler(this.mainfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_barkodekle;
        private System.Windows.Forms.Button btn_barkodgor;
        private System.Windows.Forms.Button btn_barkod_duzenle;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}