using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace loginform
{
    public partial class frm_barkodliste : Form
    {
        public frm_barkodliste()
        {
            InitializeComponent();
        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_barkodliste_Load_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("\"Data Source=YOUR_SERVER\\\\SQLEXPRESS;Initial Catalog=YOUR_DATABASE;Integrated Security=True;\";"))
                {
                    conn.Open();
                   
                    SqlDataAdapter da = new SqlDataAdapter("SELECT gonderilenkurum, gonderilentarih, uretimtarihi, sonkullanmatarihi, batchid, serialnumber, aciklama FROM barcodes ORDER BY id ASC", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Kolon başlıklarını buraya ekleyeceğim sonradan değişiklik olursa 
                    dataGridView1.Columns["gonderilenkurum"].HeaderText = "Gönderilen Kurum";
                    dataGridView1.Columns["gonderilentarih"].HeaderText = "Gönderilen Tarih";
                    dataGridView1.Columns["uretimtarihi"].HeaderText = "Üretim Tarihi";
                    dataGridView1.Columns["sonkullanmatarihi"].HeaderText = "Son Kullanma Tarihi";
                    dataGridView1.Columns["batchid"].HeaderText = "Batch ID";
                    dataGridView1.Columns["serialnumber"].HeaderText = "Seri Numarası";
                    dataGridView1.Columns["aciklama"].HeaderText = "Açıklama";

                    // Tarih formatlarının ayarlandığı kısım
                    dataGridView1.Columns["gonderilentarih"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dataGridView1.Columns["uretimtarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dataGridView1.Columns["sonkullanmatarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void link_geri2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            link_geri2.LinkBehavior = LinkBehavior.HoverUnderline;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "mainfrm") // <- gösterilmek istenilen form girelecek buraya ben ana formu göstermek istedim
                {
                    form.Show();
                    form.BringToFront();
                    break;
                }
            }
            this.Hide();
        }
    }
}
