namespace loginform
{
    partial class Frm_barkodekle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_barkodekle));
            this.msktxtbox_barkod1 = new System.Windows.Forms.MaskedTextBox();
            this.lbl_barkodserino = new System.Windows.Forms.Label();
            this.msktxtbox_barkod2 = new System.Windows.Forms.MaskedTextBox();
            this.label1lbl_barkodserino2 = new System.Windows.Forms.Label();
            this.txtgonderilenkurum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpgonderilentarih = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtb_aciklama = new System.Windows.Forms.RichTextBox();
            this.btn_barkodkayit = new System.Windows.Forms.Button();
            this.link_geri1 = new System.Windows.Forms.LinkLabel();
            this.chckbx_yici = new System.Windows.Forms.CheckBox();
            this.chckbx_ydisi = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpsonkullanma = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // msktxtbox_barkod1
            // 
            this.msktxtbox_barkod1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msktxtbox_barkod1.Location = new System.Drawing.Point(253, 50);
            this.msktxtbox_barkod1.Mask = "0000000";
            this.msktxtbox_barkod1.Name = "msktxtbox_barkod1";
            this.msktxtbox_barkod1.Size = new System.Drawing.Size(70, 27);
            this.msktxtbox_barkod1.TabIndex = 0;
            this.msktxtbox_barkod1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.msktxtbox_barkod1_KeyPress);
            // 
            // lbl_barkodserino
            // 
            this.lbl_barkodserino.AutoSize = true;
            this.lbl_barkodserino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_barkodserino.ForeColor = System.Drawing.Color.White;
            this.lbl_barkodserino.Location = new System.Drawing.Point(12, 53);
            this.lbl_barkodserino.Name = "lbl_barkodserino";
            this.lbl_barkodserino.Size = new System.Drawing.Size(200, 20);
            this.lbl_barkodserino.TabIndex = 1;
            this.lbl_barkodserino.Text = "Barkod Seri Numarası:";
            // 
            // msktxtbox_barkod2
            // 
            this.msktxtbox_barkod2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msktxtbox_barkod2.Location = new System.Drawing.Point(253, 86);
            this.msktxtbox_barkod2.Mask = "0000000";
            this.msktxtbox_barkod2.Name = "msktxtbox_barkod2";
            this.msktxtbox_barkod2.Size = new System.Drawing.Size(70, 27);
            this.msktxtbox_barkod2.TabIndex = 1;
            this.msktxtbox_barkod2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.msktxtbox_barkod2_KeyPress);
            // 
            // label1lbl_barkodserino2
            // 
            this.label1lbl_barkodserino2.AutoSize = true;
            this.label1lbl_barkodserino2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1lbl_barkodserino2.ForeColor = System.Drawing.Color.White;
            this.label1lbl_barkodserino2.Location = new System.Drawing.Point(11, 96);
            this.label1lbl_barkodserino2.Name = "label1lbl_barkodserino2";
            this.label1lbl_barkodserino2.Size = new System.Drawing.Size(200, 20);
            this.label1lbl_barkodserino2.TabIndex = 3;
            this.label1lbl_barkodserino2.Text = "Barkod Seri Numarası:";
            // 
            // txtgonderilenkurum
            // 
            this.txtgonderilenkurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtgonderilenkurum.Location = new System.Drawing.Point(253, 119);
            this.txtgonderilenkurum.Name = "txtgonderilenkurum";
            this.txtgonderilenkurum.Size = new System.Drawing.Size(264, 27);
            this.txtgonderilenkurum.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gönderilen Kurum:";
            // 
            // dtpgonderilentarih
            // 
            this.dtpgonderilentarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpgonderilentarih.Location = new System.Drawing.Point(253, 159);
            this.dtpgonderilentarih.Name = "dtpgonderilentarih";
            this.dtpgonderilentarih.Size = new System.Drawing.Size(264, 27);
            this.dtpgonderilentarih.TabIndex = 3;
            this.dtpgonderilentarih.ValueChanged += new System.EventHandler(this.dtpgonderilentarih_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gönderilen Tarih:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Açıklama (Opsiyonel):";
            // 
            // rtb_aciklama
            // 
            this.rtb_aciklama.Location = new System.Drawing.Point(253, 320);
            this.rtb_aciklama.Name = "rtb_aciklama";
            this.rtb_aciklama.Size = new System.Drawing.Size(264, 118);
            this.rtb_aciklama.TabIndex = 7;
            this.rtb_aciklama.Text = "";
            // 
            // btn_barkodkayit
            // 
            this.btn_barkodkayit.Location = new System.Drawing.Point(319, 454);
            this.btn_barkodkayit.Name = "btn_barkodkayit";
            this.btn_barkodkayit.Size = new System.Drawing.Size(122, 37);
            this.btn_barkodkayit.TabIndex = 8;
            this.btn_barkodkayit.Text = "Kaydet";
            this.btn_barkodkayit.UseVisualStyleBackColor = true;
            this.btn_barkodkayit.Click += new System.EventHandler(this.button1_Click);
            // 
            // link_geri1
            // 
            this.link_geri1.AutoSize = true;
            this.link_geri1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.link_geri1.LinkColor = System.Drawing.Color.White;
            this.link_geri1.Location = new System.Drawing.Point(12, 9);
            this.link_geri1.Name = "link_geri1";
            this.link_geri1.Size = new System.Drawing.Size(61, 23);
            this.link_geri1.TabIndex = 9;
            this.link_geri1.TabStop = true;
            this.link_geri1.Text = "◀ Geri";
            this.link_geri1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_geri1_LinkClicked);
            // 
            // chckbx_yici
            // 
            this.chckbx_yici.AutoSize = true;
            this.chckbx_yici.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chckbx_yici.ForeColor = System.Drawing.Color.White;
            this.chckbx_yici.Location = new System.Drawing.Point(256, 248);
            this.chckbx_yici.Name = "chckbx_yici";
            this.chckbx_yici.Size = new System.Drawing.Size(175, 24);
            this.chckbx_yici.TabIndex = 5;
            this.chckbx_yici.Text = "Yurtiçi (1 Ay Skt)";
            this.chckbx_yici.UseVisualStyleBackColor = true;
            this.chckbx_yici.CheckedChanged += new System.EventHandler(this.chckbx_yici_CheckedChanged);
            // 
            // chckbx_ydisi
            // 
            this.chckbx_ydisi.AutoSize = true;
            this.chckbx_ydisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chckbx_ydisi.ForeColor = System.Drawing.Color.White;
            this.chckbx_ydisi.Location = new System.Drawing.Point(256, 278);
            this.chckbx_ydisi.Name = "chckbx_ydisi";
            this.chckbx_ydisi.Size = new System.Drawing.Size(185, 24);
            this.chckbx_ydisi.TabIndex = 6;
            this.chckbx_ydisi.Text = "Yurtdışı (2 Ay Skt)";
            this.chckbx_ydisi.UseVisualStyleBackColor = true;
            this.chckbx_ydisi.CheckedChanged += new System.EventHandler(this.chckbx_ydisi_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Gönderim Tipi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Son Kullanma Tarihi:";
            // 
            // dtpsonkullanma
            // 
            this.dtpsonkullanma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpsonkullanma.Location = new System.Drawing.Point(253, 204);
            this.dtpsonkullanma.Name = "dtpsonkullanma";
            this.dtpsonkullanma.Size = new System.Drawing.Size(264, 27);
            this.dtpsonkullanma.TabIndex = 4;
            this.dtpsonkullanma.ValueChanged += new System.EventHandler(this.dtpsonkullanma_ValueChanged);
            // 
            // Frm_barkodekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(662, 503);
            this.Controls.Add(this.dtpsonkullanma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chckbx_ydisi);
            this.Controls.Add(this.chckbx_yici);
            this.Controls.Add(this.link_geri1);
            this.Controls.Add(this.btn_barkodkayit);
            this.Controls.Add(this.rtb_aciklama);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpgonderilentarih);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtgonderilenkurum);
            this.Controls.Add(this.label1lbl_barkodserino2);
            this.Controls.Add(this.msktxtbox_barkod2);
            this.Controls.Add(this.lbl_barkodserino);
            this.Controls.Add(this.msktxtbox_barkod1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_barkodekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barkod Ekle";
            this.Load += new System.EventHandler(this.Frm_barkodekle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox msktxtbox_barkod1;
        private System.Windows.Forms.Label lbl_barkodserino;
        private System.Windows.Forms.MaskedTextBox msktxtbox_barkod2;
        private System.Windows.Forms.Label label1lbl_barkodserino2;
        private System.Windows.Forms.TextBox txtgonderilenkurum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpgonderilentarih;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtb_aciklama;
        private System.Windows.Forms.Button btn_barkodkayit;
        private System.Windows.Forms.LinkLabel link_geri1;
        private System.Windows.Forms.CheckBox chckbx_yici;
        private System.Windows.Forms.CheckBox chckbx_ydisi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpsonkullanma;
    }
}