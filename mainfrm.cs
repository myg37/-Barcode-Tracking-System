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
using ClosedXML.Excel;

namespace loginform
{
    public partial class mainfrm : Form
    {
        public mainfrm()
        {
            InitializeComponent();
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excel Files|*.xlsx;*.xls";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                string excelPath = ofd.FileName;

                using (var workbook = new XLWorkbook(excelPath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RangeUsed().RowsUsed();

                    using (SqlConnection conn = new SqlConnection("Data Source=YOUR_SERVER\\\\SQLEXPRESS;Initial Catalog=YOUR_DATABASE;Integrated Security=True;\";"))
                    {
                        conn.Open();

                        foreach (var row in rows.Skip(1)) // ilk satır başlık
                        {
                            string gonderilenKurum = row.Cell(1).GetString();
                            DateTime gonderilenTarih = row.Cell(2).GetDateTime();
                            string batchId = row.Cell(3).GetString();
                            string serialNumber = row.Cell(4).GetString();
                            string aciklama = row.Cell(5).GetString();
                            string gonderenIsim = ""; // boş bırak

                            // DB’de var mı kontrol
                            using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM barcodes WHERE serialnumber = @serial", conn))
                            {
                                checkCmd.Parameters.AddWithValue("@serial", serialNumber);
                                int count = (int)checkCmd.ExecuteScalar();

                                if (count == 0)
                                {
                                    using (SqlCommand insertCmd = new SqlCommand(
                                        "INSERT INTO barcodes (serialnumber, gonderilentarih, gonderenisim, gonderilenkurum, batchid, aciklama) " +
                                        "VALUES (@serial, @tarih, @isim, @kurum, @batch, @aciklama)", conn))
                                    {
                                        insertCmd.Parameters.AddWithValue("@serial", serialNumber);
                                        insertCmd.Parameters.AddWithValue("@tarih", gonderilenTarih);
                                        insertCmd.Parameters.AddWithValue("@isim", gonderenIsim);
                                        insertCmd.Parameters.AddWithValue("@kurum", gonderilenKurum);
                                        insertCmd.Parameters.AddWithValue("@batch", batchId);
                                        insertCmd.Parameters.AddWithValue("@aciklama", aciklama);
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Excel verileri başarıyla aktarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_barkodekle_Click(object sender, EventArgs e)
        {
            Frm_barkodekle frm_Barkodekle = new Frm_barkodekle();
            frm_Barkodekle.Show();
            this.Hide();
        }

        private void btn_barkodgor_Click(object sender, EventArgs e)
        {
            frm_barkodliste frm = new frm_barkodliste();
            frm.Show();
            this.Hide();
        }

      
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "login_form") //  <- gidilecek formun adı 
                {
                    form.Show();
                    form.BringToFront();
                    break;
                }
            }
            this.Hide();
        }

        private void mainfrm_Load(object sender, EventArgs e)
        {

        }

        private void btn_barkod_duzenle_Click(object sender, EventArgs e)
        {
            frm_barkod_duzenle form2 = new frm_barkod_duzenle();
            form2.Show();
            this.Hide();
        }
    }
}
