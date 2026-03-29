namespace loginform
{
    partial class login_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login_form));
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpsswd = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.lbl_login = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.cbshow = new System.Windows.Forms.CheckBox();
            this.lblcapslock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtusername
            // 
            this.txtusername.BackColor = System.Drawing.Color.White;
            this.txtusername.Location = new System.Drawing.Point(206, 148);
            this.txtusername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(158, 20);
            this.txtusername.TabIndex = 0;
            // 
            // txtpsswd
            // 
            this.txtpsswd.BackColor = System.Drawing.Color.White;
            this.txtpsswd.Location = new System.Drawing.Point(206, 175);
            this.txtpsswd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtpsswd.Name = "txtpsswd";
            this.txtpsswd.Size = new System.Drawing.Size(158, 20);
            this.txtpsswd.TabIndex = 1;
            this.txtpsswd.UseSystemPasswordChar = true;
            this.txtpsswd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpsswd_KeyDown);
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(241, 197);
            this.btnlogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(68, 27);
            this.btnlogin.TabIndex = 2;
            this.btnlogin.Text = "Giriş Yap";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.ForeColor = System.Drawing.Color.White;
            this.lbl_login.Location = new System.Drawing.Point(140, 152);
            this.lbl_login.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(67, 13);
            this.lbl_login.TabIndex = 4;
            this.lbl_login.Text = "Kullanıcı Adı:";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.ForeColor = System.Drawing.Color.White;
            this.lbl_password.Location = new System.Drawing.Point(168, 177);
            this.lbl_password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(31, 13);
            this.lbl_password.TabIndex = 5;
            this.lbl_password.Text = "Şifre:";
            // 
            // cbshow
            // 
            this.cbshow.AutoSize = true;
            this.cbshow.ForeColor = System.Drawing.Color.White;
            this.cbshow.Location = new System.Drawing.Point(314, 204);
            this.cbshow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbshow.Name = "cbshow";
            this.cbshow.Size = new System.Drawing.Size(88, 17);
            this.cbshow.TabIndex = 3;
            this.cbshow.Text = "Şifreyi Göster";
            this.cbshow.UseVisualStyleBackColor = true;
            this.cbshow.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblcapslock
            // 
            this.lblcapslock.AutoSize = true;
            this.lblcapslock.Location = new System.Drawing.Point(168, 193);
            this.lblcapslock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcapslock.Name = "lblcapslock";
            this.lblcapslock.Size = new System.Drawing.Size(0, 13);
            this.lblcapslock.TabIndex = 7;
            // 
            // login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(554, 303);
            this.Controls.Add(this.lblcapslock);
            this.Controls.Add(this.cbshow);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_login);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtpsswd);
            this.Controls.Add(this.txtusername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "login_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Ekranı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpsswd;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.CheckBox cbshow;
        private System.Windows.Forms.Label lblcapslock;
    }
}

