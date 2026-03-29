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
using System.Data.Sql;

namespace loginform
{
    public partial class Frm_barkodekle : Form
    {
        private readonly string connectionString = "Data Source=YOUR_SERVER\\SQLEXPRESS;Initial Catalog=YOUR_DATABASE;Integrated Security=True;";

        public Frm_barkodekle()
        {
            InitializeComponent();
        }

        private void msktxtbox_barkod1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Lütfen sadece rakam girin!", "Hatalı Giriş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void msktxtbox_barkod2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Lütfen sadece rakam girin!", "Hatalı Giriş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // UI'yi disable et
                btn_barkodkayit.Enabled = false;
                Cursor = Cursors.WaitCursor;

                string startBarkod = msktxtbox_barkod1.Text.Trim();
                string endBarkod = msktxtbox_barkod2.Text.Trim();
                string gonderilenKurum = txtgonderilenkurum.Text.Trim();
                DateTime gonderilenTarih = dtpgonderilentarih.Value;
                string aciklama = rtb_aciklama.Text.Trim();

                // DateTimePicker değerlerini al
                DateTime? uretimTarihi = dtpgonderilentarih.Value; // Üretim tarihi gönderilen tarih ile aynı
                DateTime? sonKullanmaTarihi = dtpsonkullanma.Value; // Form üzerindeki son kullanma tarihi DateTimePicker

                // Input validation
                if (!ValidateInputs(startBarkod, endBarkod, gonderilenKurum))
                    return;

                // Barkod aralığını hesapla
                long start = long.Parse(startBarkod);
                long end = string.IsNullOrEmpty(endBarkod) ? start : long.Parse(endBarkod);

                // Aralık kontrolü
                if (end < start)
                {
                    MessageBox.Show("Bitiş barkodu başlangıç barkodundan küçük olamaz!", "Hatalı Aralık", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Aynı barkod kontrolü
                if (end == start && !string.IsNullOrEmpty(endBarkod))
                {
                    MessageBox.Show("Başlangıç ve bitiş barkodu aynı olamaz! Tek barkod eklemek için bitiş kutusunu boş bırakın.",
                        "Aynı Barkod", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Çok büyük aralık kontrolü (performans için)
                if (end - start > 10000)
                {
                    var result = MessageBox.Show($"Çok büyük bir aralık ({end - start + 1} barkod). Devam etmek istiyor musunuz?",
                        "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }

                // Barkodları kaydet - DateTimePicker değerlerini gönder
                var result_operation = await SaveBarcodes(start, end, gonderilenKurum, gonderilenTarih,
                    aciklama, uretimTarihi, sonKullanmaTarihi);

                MessageBox.Show($"İşlem tamamlandı!\n" +
                               $"Toplam: {result_operation.Total}\n" +
                               $"Eklenen: {result_operation.Added}\n" +
                               $"Atlanan (Mevcut): {result_operation.Skipped}",
                               "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Formu temizle
                ClearForm();

                // AutoComplete listesini yenile (yeni kurum eklendiyse)
                RefreshAutoComplete();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // UI'yi tekrar enable et
                btn_barkodkayit.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private bool ValidateInputs(string startBarkod, string endBarkod, string gonderilenKurum)
        {
            // Zorunlu alan kontrolleri
            if (string.IsNullOrEmpty(startBarkod))
            {
                MessageBox.Show("Başlangıç barkodunu girin!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msktxtbox_barkod1.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(gonderilenKurum))
            {
                MessageBox.Show("Gönderilen kurumu girin!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgonderilenkurum.Focus();
                return false;
            }

            // Barkod format kontrolü (7 haneli sayısal)
            if (!long.TryParse(startBarkod, out long start) || startBarkod.Length != 7)
            {
                MessageBox.Show("Başlangıç barkodu 7 haneli sayısal olmalıdır!", "Hatalı Barkod", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msktxtbox_barkod1.Focus();
                msktxtbox_barkod1.SelectAll();
                return false;
            }

            // Bitiş barkodu kontrolü (eğer girilmişse)
            if (!string.IsNullOrEmpty(endBarkod))
            {
                if (!long.TryParse(endBarkod, out long end) || endBarkod.Length != 7)
                {
                    MessageBox.Show("Bitiş barkodu 7 haneli sayısal olmalıdır!", "Hatalı Barkod", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    msktxtbox_barkod2.Focus();
                    msktxtbox_barkod2.SelectAll();
                    return false;
                }
            }

            return true;
        }

        private async Task<(int Total, int Added, int Skipped)> SaveBarcodes(long start, long end,
            string gonderilenKurum, DateTime gonderilenTarih, string aciklama,
            DateTime? uretimTarihi = null, DateTime? sonKullanmaTarihi = null)
        {
            int totalCount = (int)(end - start + 1);
            int addedCount = 0;
            int skippedCount = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();

                // Transaction kullan - ya hepsi kaydet ya hiçbiri
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Batch olarak mevcut barkodları kontrol et (performans için)
                        List<string> existingBarcodes = await GetExistingBarcodes(conn, transaction, start, end);

                        for (long i = start; i <= end; i++)
                        {
                            string serialNumber = i.ToString();

                            // Eğer barkod mevcutsa atla
                            if (existingBarcodes.Contains(serialNumber))
                            {
                                skippedCount++;
                                continue;
                            }

                            // Yeni barkod ekle - TÜM PARAMETRELERİ GÖNDER
                            await InsertBarcode(conn, transaction, serialNumber, gonderilenKurum,
                                gonderilenTarih, aciklama, uretimTarihi, sonKullanmaTarihi);
                            addedCount++;
                        }

                        // Transaction'ı commit et
                        transaction.Commit();
                    }
                    catch
                    {
                        // Hata durumunda rollback
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return (totalCount, addedCount, skippedCount);
        }

        private async Task<List<string>> GetExistingBarcodes(SqlConnection conn, SqlTransaction transaction, long start, long end)
        {
            List<string> existingBarcodes = new List<string>();

            string query = "SELECT serialnumber FROM barcodes WHERE serialnumber BETWEEN @start AND @end";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@start", start.ToString());
                cmd.Parameters.AddWithValue("@end", end.ToString());

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        existingBarcodes.Add(reader["serialnumber"].ToString());
                    }
                }
            }

            return existingBarcodes;
        }

        private async Task InsertBarcode(SqlConnection conn, SqlTransaction transaction, string serialNumber,
            string gonderilenKurum, DateTime gonderilenTarih, string aciklama,
            DateTime? uretimTarihi = null, DateTime? sonKullanmaTarihi = null)
        {
            string insertQuery = @"INSERT INTO barcodes (serialnumber, gonderilentarih, gonderenisim, gonderilenkurum, 
                          batchid, aciklama, uretimtarihi, sonkullanmatarihi) 
                          VALUES (@serial, @tarih, @gonderen, @kurum, @batchid, @aciklama, 
                          @uretimtarihi, @sonkullanmatarihi)";

            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction))
            {
                insertCmd.Parameters.AddWithValue("@serial", serialNumber);
                insertCmd.Parameters.AddWithValue("@tarih", gonderilenTarih);
                insertCmd.Parameters.AddWithValue("@gonderen", Environment.UserName);
                insertCmd.Parameters.AddWithValue("@kurum", gonderilenKurum);
                insertCmd.Parameters.AddWithValue("@batchid", 100006);
                insertCmd.Parameters.AddWithValue("@aciklama", string.IsNullOrEmpty(aciklama) ? (object)DBNull.Value : aciklama);
                insertCmd.Parameters.AddWithValue("@uretimtarihi", uretimTarihi ?? (object)DBNull.Value);
                insertCmd.Parameters.AddWithValue("@sonkullanmatarihi", sonKullanmaTarihi ?? (object)DBNull.Value);

                await insertCmd.ExecuteNonQueryAsync();
            }
        }

        private void ClearForm()
        {
            msktxtbox_barkod1.Clear();
            msktxtbox_barkod2.Clear();
            txtgonderilenkurum.Clear();
            rtb_aciklama.Clear();
            dtpgonderilentarih.Value = DateTime.Now;
            dtpsonkullanma.Value = DateTime.Now; // Son kullanma tarihini de sıfırla

            // Checkbox'ları temizle
            chckbx_yici.Checked = false;
            chckbx_ydisi.Checked = false;

            msktxtbox_barkod1.Focus();
        }

        private void link_geri1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            link_geri1.LinkBehavior = LinkBehavior.HoverUnderline;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "mainfrm") // Ana formun adı ne ise
                {
                    form.Show();
                    form.BringToFront();
                    break;
                }
            }
            this.Hide();
        }

        private void Frm_barkodekle_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde varsayılan değerleri ayarla
            dtpgonderilentarih.Value = DateTime.Now;
            dtpsonkullanma.Value = DateTime.Now;

            // AutoComplete'i ayarla
            SetupAutoComplete();
        }

        // YENİ METOT: AutoComplete ayarlama
        private void SetupAutoComplete()
        {
            try
            {
                // Veritabanından benzersiz kurum isimlerini çek
                AutoCompleteStringCollection kurumlar = new AutoCompleteStringCollection();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT gonderilenkurum FROM barcodes WHERE gonderilenkurum IS NOT NULL AND gonderilenkurum != '' ORDER BY gonderilenkurum";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string kurum = reader["gonderilenkurum"].ToString();
                                if (!string.IsNullOrEmpty(kurum))
                                {
                                    kurumlar.Add(kurum);
                                }
                            }
                        }
                    }
                }

                // TextBox'a AutoComplete ayarla
                txtgonderilenkurum.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtgonderilenkurum.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtgonderilenkurum.AutoCompleteCustomSource = kurumlar;
            }
            catch (Exception ex)
            {
                // Hata durumunda sadece log, program devam etsin
                Console.WriteLine($"AutoComplete ayarlanırken hata: {ex.Message}");
            }
        }

        // YENİ METOT: AutoComplete listesini yenileme
        private void RefreshAutoComplete()
        {
            SetupAutoComplete(); // AutoComplete listesini yenile
        }

        private void HesaplaSonKullanmaTarihi(object sender = null)
        {
            DateTime uretimTarihi = dtpgonderilentarih.Value;

            // 1 yıl önceki tarihi hesapla
            DateTime birYilOnce = DateTime.Now.AddYears(-1);

            // Tarih kontrolü - 1 yıl ve önceki tarihleri kabul etme
            if (uretimTarihi.Date <= birYilOnce.Date)
            {
                MessageBox.Show("1 yıl ve önceki tarihler kabul edilmez! Lütfen daha güncel bir tarih seçin.",
                    "Geçersiz Tarih", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Tarihi bugüne ayarla (opsiyonel)
                dtpgonderilentarih.Value = DateTime.Now;
                return;
            }

            // Geçerli tarih kontrolü - ayın maksimum gün sayısını kontrol et
            int ayinMaxGunu = DateTime.DaysInMonth(uretimTarihi.Year, uretimTarihi.Month);
            if (uretimTarihi.Day > ayinMaxGunu)
            {
                MessageBox.Show($"Seçilen ay ({uretimTarihi.Month}/{uretimTarihi.Year}) için geçersiz gün! " +
                               $"Bu ay maksimum {ayinMaxGunu} gün içerir.",
                    "Geçersiz Gün", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Tarihi o ayın son günü olarak ayarla
                dtpgonderilentarih.Value = new DateTime(uretimTarihi.Year, uretimTarihi.Month, ayinMaxGunu);
                return;
            }

            // Her ikisi de seçili
            if (chckbx_yici.Checked && chckbx_ydisi.Checked)
            {
                MessageBox.Show("Lütfen sadece bir barkod tipi seçin! (Yurtiçi VEYA Yurtdışı)",
                    "Hatalı Seçim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Son seçileni iptal et (bu event'i tetikleyen checkbox'u kapat)
                if (sender is CheckBox currentCheckbox)
                {
                    currentCheckbox.Checked = false;
                }
                return;
            }

            // Hiçbiri seçili değil - varsayılan değeri koru
            if (!chckbx_yici.Checked && !chckbx_ydisi.Checked)
            {
                return;
            }

            // SON KULLANMA TARİHİNİ hesapla
            if (chckbx_yici.Checked)
                dtpsonkullanma.Value = uretimTarihi.AddMonths(1); // +1 ay
            else if (chckbx_ydisi.Checked)
                dtpsonkullanma.Value = uretimTarihi.AddMonths(2); // +2 ay
        }

        private void dtpgonderilentarih_ValueChanged(object sender, EventArgs e)
        {
            HesaplaSonKullanmaTarihi();
        }

        private void chckbx_yici_CheckedChanged(object sender, EventArgs e)
        {

            HesaplaSonKullanmaTarihi(sender);
        }

        private void chckbx_ydisi_CheckedChanged(object sender, EventArgs e)
        {

            HesaplaSonKullanmaTarihi(sender);
        }

        private void dtpsonkullanma_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}