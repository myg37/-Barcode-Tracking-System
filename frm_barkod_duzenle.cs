using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginform
{
    public partial class frm_barkod_duzenle : Form
    {
        private int selectedRowIndex = -1;

        public frm_barkod_duzenle()
        {
            InitializeComponent();
        }

        private void frm_barkod_duzenle_Load(object sender, EventArgs e)
        {
            LoadBarcodes();

            // ContextMenuStrip Opening event'ini bağla
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;

            // CellEndEdit event'ini bağla (ENTER tuşunda kaydetmek için)
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }

        private void LoadBarcodes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(" \"Data Source=YOUR_SERVER\\\\SQLEXPRESS;Initial Catalog=YOUR_DATABASE;Integrated Security=True;\";"))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT gonderilenkurum, gonderilentarih, uretimtarihi, sonkullanmatarihi, batchid, serialnumber, aciklama FROM barcodes ORDER BY id ASC", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // Kolon başlıklarını ayarla
                    if (dataGridView1.Columns["gonderilenkurum"] != null)
                        dataGridView1.Columns["gonderilenkurum"].HeaderText = "Gönderilen Kurum";
                    if (dataGridView1.Columns["gonderilentarih"] != null)
                        dataGridView1.Columns["gonderilentarih"].HeaderText = "Gönderilen Tarih";
                    if (dataGridView1.Columns["uretimtarihi"] != null)
                        dataGridView1.Columns["uretimtarihi"].HeaderText = "Üretim Tarihi";
                    if (dataGridView1.Columns["sonkullanmatarihi"] != null)
                        dataGridView1.Columns["sonkullanmatarihi"].HeaderText = "Son Kullanma Tarihi";
                    if (dataGridView1.Columns["batchid"] != null)
                        dataGridView1.Columns["batchid"].HeaderText = "Batch ID";
                    if (dataGridView1.Columns["serialnumber"] != null)
                        dataGridView1.Columns["serialnumber"].HeaderText = "Seri Numarası";
                    if (dataGridView1.Columns["aciklama"] != null)
                        dataGridView1.Columns["aciklama"].HeaderText = "Açıklama";

                    // Tarih formatlarını ayarla
                    if (dataGridView1.Columns["gonderilentarih"] != null)
                        dataGridView1.Columns["gonderilentarih"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    if (dataGridView1.Columns["uretimtarihi"] != null)
                        dataGridView1.Columns["uretimtarihi"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    if (dataGridView1.Columns["sonkullanmatarihi"] != null)
                        dataGridView1.Columns["sonkullanmatarihi"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    // ContextMenuStrip'i bağla
                    dataGridView1.ContextMenuStrip = contextMenuStrip1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // Mouse pozisyonunu al
            Point mousePos = dataGridView1.PointToClient(Cursor.Position);
            DataGridView.HitTestInfo hitTest = dataGridView1.HitTest(mousePos.X, mousePos.Y);

            if (hitTest.RowIndex >= 0)
            {
                selectedRowIndex = hitTest.RowIndex;
                dataGridView1.Rows[hitTest.RowIndex].Selected = true;
            }
            else
            {
                e.Cancel = true; // Satır dışında tıklanmışsa menüyü gösterme
            }
        }

        private void duzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                // DataGridView'i tamamen düzenlenebilir yap
                dataGridView1.ReadOnly = false;

                // Tüm kolonları düzenlenebilir yap
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.ReadOnly = false; // Hepsini düzenlenebilir yap
                }

                // Seçili satırı aktif et
                dataGridView1.CurrentCell = dataGridView1.Rows[selectedRowIndex].Cells[0];

                MessageBox.Show("Düzenleme modu aktif! Tüm hücreleri düzenleyebilirsiniz. Değişiklik yaptıktan sonra ENTER tuşuna basın veya başka hücreye geçin.",
                    "Düzenleme Modu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen önce düzenlemek istediğiniz satıra sağ tıklayın!");
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                // Onay sor
                var result = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?",
                    "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Seçili satırdan serial number'ı al
                        string serialNumber = dataGridView1.Rows[selectedRowIndex].Cells["serialnumber"].Value.ToString();

                        // Veritabanından sil
                        DeleteBarcode(serialNumber);

                        // DataGridView'den satırı kaldır
                        dataGridView1.Rows.RemoveAt(selectedRowIndex);

                        MessageBox.Show("Kayıt başarıyla silindi!", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        selectedRowIndex = -1; // Seçimi temizle
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Silme işlemi sırasında hata: {ex.Message}",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce silmek istediğiniz satıra sağ tıklayın!");
            }
        }

        private void DeleteBarcode(string serialNumber)
        {
            using (SqlConnection conn = new SqlConnection(" \"Data Source=YOUR_SERVER\\\\SQLEXPRESS;Initial Catalog=YOUR_DATABASE;Integrated Security=True;\";"))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM barcodes WHERE serialnumber = @serial";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@serial", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ENTER tuşuna basıldığında çalışır
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                SaveCurrentRow();
            }
        }

        private void SaveCurrentRow()
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];

                // Basit veri alma
                string serialNumber = row.Cells["serialnumber"].Value?.ToString() ?? "";
                string kurum = row.Cells["gonderilenkurum"].Value?.ToString() ?? "";
                string batchid = row.Cells["batchid"].Value?.ToString() ?? "";
                string aciklama = row.Cells["aciklama"].Value?.ToString() ?? "";

                // Basit tarih alma
                DateTime gonderilentarih = DateTime.Now;
                DateTime.TryParse(row.Cells["gonderilentarih"].Value?.ToString(), out gonderilentarih);

                DateTime? uretimtarihi = null;
                if (DateTime.TryParse(row.Cells["uretimtarihi"].Value?.ToString(), out DateTime ut))
                    uretimtarihi = ut;

                DateTime? sonkullanma = null;
                if (DateTime.TryParse(row.Cells["sonkullanmatarihi"].Value?.ToString(), out DateTime sk))
                    sonkullanma = sk;

                UpdateAllFields(serialNumber, kurum, batchid, aciklama, gonderilentarih, uretimtarihi, sonkullanma);

                MessageBox.Show("Satır güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }

        }


        private void UpdateAllFields(string serialNumber, string kurum, string batchid, string aciklama,
            DateTime gonderilentarih, DateTime? uretimtarihi, DateTime? sonkullanma)
        {
            using (SqlConnection conn = new SqlConnection(" \"Data Source=YOUR_SERVER\\\\SQLEXPRESS;Initial Catalog=YOUR_DATABASE;Integrated Security=True;\";"))
            {
                conn.Open();
                string updateQuery = @"UPDATE barcodes SET 
                              gonderilenkurum = @kurum,
                              gonderilentarih = @gonderilentarih,
                              uretimtarihi = @uretimtarihi,
                              sonkullanmatarihi = @sonkullanma,
                              batchid = @batchid,
                              aciklama = @aciklama
                              WHERE serialnumber = @serial";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@serial", serialNumber);
                    cmd.Parameters.AddWithValue("@kurum", kurum);
                    cmd.Parameters.AddWithValue("@gonderilentarih", gonderilentarih);
                    cmd.Parameters.AddWithValue("@uretimtarihi", uretimtarihi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@sonkullanma", sonkullanma ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@batchid", batchid);
                    cmd.Parameters.AddWithValue("@aciklama", aciklama);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "mainfrm") //  <- gidilecek formun adı ben ana form'a gitmek istediğim için mainfrm yazdım
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