using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace loginform
{
    public partial class login_form : Form
    {
        public login_form()
        {
            InitializeComponent();
            txtusername.Focus();
            
        }
        private async void ShakeForm()
        {
            var original = this.Location;
            var rnd = new Random();
            const int shake_amplitude = 10;
            const int shake_count = 10;

            for (int i = 0; i < shake_count; i++)
            {
                this.Location = new Point(
                    original.X + rnd.Next(-shake_amplitude, shake_amplitude),
                    original.Y + rnd.Next(-shake_amplitude, shake_amplitude)
                );
                await Task.Delay(20);
            }

            this.Location = original;
        }



        SqlConnection connect = new SqlConnection(" \"Data Source=YOUR_SERVER\\\\SQLEXPRESS;Initial Catalog=YOUR_DATABASE;Integrated Security=True;\";");
        private void btnlogin_Click(object sender, EventArgs e)
        {
            string kullanici = txtusername.Text.Trim();
            string sifre = txtpsswd.Text.Trim();

            if (string.IsNullOrEmpty(kullanici))
            {
                MessageBox.Show("Lütfen kullanıcı adınızı girin!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kullanici.All(char.IsDigit))
            {
                MessageBox.Show("Kullanıcı adı tamamen sayısal olamaz!", "Geçersiz Kullanıcı Adı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen şifrenizi girin!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            connect.Open();
            SqlCommand cmd = new SqlCommand("Select * From users where kullaniciad=@p1 and sifre=@p2", connect);
            cmd.Parameters.AddWithValue("@p1",txtusername.Text);
            cmd.Parameters.AddWithValue("@p2",txtpsswd.Text);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                mainfrm frm = new mainfrm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre Girdiniz!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShakeForm();

            }
            connect.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtpsswd.UseSystemPasswordChar = !cbshow.Checked;

        }

        private void txtpsswd_KeyDown(object sender, KeyEventArgs e)
        {

            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                lblcapslock.Visible = true;
            }
            else
            {
                lblcapslock.Visible = false;
            }

            if (e.KeyCode == Keys.Enter)
            {
                btnlogin.PerformClick();
                e.Handled = true;
            }

        }
    }
}
