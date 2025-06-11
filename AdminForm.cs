using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Ntp
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            this.Load += AdminForm_Load;
        }

        private void AdminForm_Load(object? sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-15EI2H8\SQLEXPRESS;Initial Catalog=OtobusBileti2;Integrated Security=True;Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT OtobusId, SirketAdi, Plaka, KoltukSayisi FROM Otobus";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    lstOtobusler.Items.Clear();

                    while (dr.Read())
                    {
                        int otobusId = dr["OtobusId"] != DBNull.Value ? Convert.ToInt32(dr["OtobusId"]) : 0;
                        string sirketAdi = dr["SirketAdi"]?.ToString() ?? "";
                        string plaka = dr["Plaka"]?.ToString() ?? "";
                        int koltukSayisi = dr["KoltukSayisi"] != DBNull.Value ? Convert.ToInt32(dr["KoltukSayisi"]) : 0;

                        string itemText = $"{sirketAdi} - {plaka} - Koltuk: {koltukSayisi}";
                        lstOtobusler.Items.Add(new ListBoxItemWithId(itemText, otobusId));
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Otobüs verileri yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public class ListBoxItemWithId
        {
            public string Display { get; set; }
            public int OtobusId { get; set; }
            public ListBoxItemWithId(string display, int otobusId)
            {
                Display = display;
                OtobusId = otobusId;
            }
            public override string ToString() => Display;
        }

        private void btnOtobusEkle_Click(object sender, System.EventArgs e)
        {
            // Küçük bir form ile otobüs bilgisi al
            Form frm = new Form();
            frm.Text = "Otobüs Ekle";
            frm.Size = new System.Drawing.Size(320, 300);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Otobüs Ekle dialog tasarımı
            frm.BackColor = System.Drawing.Color.WhiteSmoke;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Font = new System.Drawing.Font("Segoe UI", 10F);

            Label lblTitle = new Label
            {
                Text = "Otobüs Bilgileri",
                Location = new System.Drawing.Point(0, 10),
                AutoSize = false,
                Width = 320,
                Height = 30,
                Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                ForeColor = System.Drawing.Color.MediumSlateBlue
            };
            frm.Controls.Add(lblTitle);

            Label lblOtobusId = new Label { Text = "Otobüs ID:", Location = new System.Drawing.Point(30, 55), AutoSize = true };
            TextBox txtOtobusId = new TextBox { Location = new System.Drawing.Point(120, 50), Width = 150 };
            Label lblPlaka = new Label { Text = "Plaka:", Location = new System.Drawing.Point(30, 90), AutoSize = true };
            TextBox txtPlaka = new TextBox { Location = new System.Drawing.Point(120, 85), Width = 150 };
            Label lblKoltuk = new Label { Text = "Koltuk Sayısı:", Location = new System.Drawing.Point(30, 125), AutoSize = true };
            NumericUpDown nudKoltuk = new NumericUpDown { Location = new System.Drawing.Point(120, 120), Width = 80, Minimum = 10, Maximum = 60, Value = 30 };
            Label lblSirket = new Label { Text = "Şirket Adı:", Location = new System.Drawing.Point(30, 160), AutoSize = true };
            TextBox txtSirket = new TextBox { Location = new System.Drawing.Point(120, 155), Width = 150 };
            Button btnEkle = new Button { Text = "Ekle", Location = new System.Drawing.Point(120, 195), Width = 100, Height = 36, BackColor = System.Drawing.Color.MediumSlateBlue, ForeColor = System.Drawing.Color.White };
            btnEkle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.FlatAppearance.BorderSize = 0;
            btnEkle.Cursor = Cursors.Hand;

            frm.Controls.Add(lblOtobusId);
            frm.Controls.Add(txtOtobusId);
            frm.Controls.Add(lblPlaka);
            frm.Controls.Add(txtPlaka);
            frm.Controls.Add(lblKoltuk);
            frm.Controls.Add(nudKoltuk);
            frm.Controls.Add(lblSirket);
            frm.Controls.Add(txtSirket);
            frm.Controls.Add(btnEkle);

            btnEkle.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtOtobusId.Text) || !int.TryParse(txtOtobusId.Text, out int girilenOtobusId))
                {
                    MessageBox.Show("Geçerli bir Otobüs ID girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPlaka.Text))
                {
                    MessageBox.Show("Plaka boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtSirket.Text))
                {
                    MessageBox.Show("Şirket adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string connectionString = @"Data Source=DESKTOP-15EI2H8\SQLEXPRESS;Initial Catalog=OtobusBileti2;Integrated Security=True;Trust Server Certificate=True";

                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        string insertOtobusQuery = "INSERT INTO Otobus (OtobusId, Plaka, KoltukSayisi, SirketAdi) VALUES (@otobusId, @plaka, @koltuk, @sirket)";
                        using (var cmd = new SqlCommand(insertOtobusQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@otobusId", girilenOtobusId);
                            cmd.Parameters.AddWithValue("@plaka", txtPlaka.Text.Trim());
                            cmd.Parameters.AddWithValue("@koltuk", nudKoltuk.Value);
                            cmd.Parameters.AddWithValue("@sirket", txtSirket.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        // Otobüs eklendikten sonra koltukları ekle
                        int koltukSayisi = (int)nudKoltuk.Value;
                        for (int i = 1; i <= koltukSayisi; i++)
                        {
                            using (var cmd = new SqlCommand("INSERT INTO Koltuk (OtobusId, KoltukNo, DoluMu) VALUES (@otobusId, @koltukNo, 0)", conn))
                            {
                                cmd.Parameters.AddWithValue("@otobusId", girilenOtobusId);
                                cmd.Parameters.AddWithValue("@koltukNo", i);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show($"Otobüs ve koltuklar başarıyla eklendi. OtobusId: {girilenOtobusId}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Otobüs eklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                frm.DialogResult = DialogResult.OK;
                frm.Close();
                AdminForm_Load(this, EventArgs.Empty);
            };

            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstOtobusler.SelectedItem is ListBoxItemWithId selected)
            {
                var result = MessageBox.Show(
                    $"Seçili otobüsü silmek istediğinize emin misiniz?\n\n{selected.Display}",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connectionString = @"Data Source=DESKTOP-15EI2H8\SQLEXPRESS;Initial Catalog=OtobusBileti2;Integrated Security=True;Trust Server Certificate=True";

                    using (var conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();

                            // Koltuk tablosundan önce ilgili OtobusId'ye ait tüm koltukları sil
                            using (var cmd = new SqlCommand("DELETE FROM Koltuk WHERE OtobusId = @id", conn))
                            {
                                cmd.Parameters.AddWithValue("@id", selected.OtobusId);
                                cmd.ExecuteNonQuery();
                            }

                            // Sonra Otobus tablosundan ilgili otobüsü sil
                            using (var cmd = new SqlCommand("DELETE FROM Otobus WHERE OtobusId = @id", conn))
                            {
                                cmd.Parameters.AddWithValue("@id", selected.OtobusId);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Otobüs başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Otobüs listesini yeniden yükle
                            AdminForm_Load(this, EventArgs.Empty);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Otobüs silinirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir otobüs seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBiletleriGor_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-15EI2H8\SQLEXPRESS;Initial Catalog=OtobusBileti2;Integrated Security=True;Trust Server Certificate=True";

            // ListView başlıklarını sadece bir kez ekleyelim
            if (lvwBiletler.Columns.Count == 0)
            {
                lvwBiletler.View = View.Details;
                lvwBiletler.Columns.Add("Bilet ID", 70);
                lvwBiletler.Columns.Add("Yolcu Adı Soyadı", 140);
                lvwBiletler.Columns.Add("OtobusPlaka", 100);
                lvwBiletler.Columns.Add("Koltuk", 60);
                lvwBiletler.Columns.Add("Tarih", 130);
                lvwBiletler.Columns.Add("Nereden", 100);
                lvwBiletler.Columns.Add("Nereye", 100);
            }

            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    s.Nereye, 
                    s.Nereden, 
                    s.Tarih, 
                    o.Plaka AS OtobusPlaka, 
                    k.KoltukNo, 
                    b.YolcuAdSoyad, 
                    b.BiletId
                FROM 
                    Bilet b
                INNER JOIN 
                    Sefer s ON b.SeferId = s.SeferId
                INNER JOIN 
                    Otobus o ON s.OtobusId = o.OtobusId
                INNER JOIN
                    Koltuk k ON b.KoltukId = k.KoltukId
                ORDER BY 
                    s.Tarih DESC";

                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        lvwBiletler.Items.Clear();
                        while (reader.Read())
                        {
                            string biletId = reader["BiletId"]?.ToString() ?? "";
                            string yolcu = reader["YolcuAdSoyad"]?.ToString() ?? "";
                            string otobus = reader["OtobusPlaka"]?.ToString() ?? "";
                            string koltuk = reader["KoltukNo"]?.ToString() ?? "";
                            DateTime tarih = reader["Tarih"] != DBNull.Value ? Convert.ToDateTime(reader["Tarih"]) : DateTime.MinValue;
                            string nereden = reader["Nereden"]?.ToString() ?? "";
                            string nereye = reader["Nereye"]?.ToString() ?? "";

                            ListViewItem item = new ListViewItem(biletId);
                            item.SubItems.Add(yolcu);
                            item.SubItems.Add(otobus);
                            item.SubItems.Add(koltuk);
                            item.SubItems.Add(tarih != DateTime.MinValue ? tarih.ToString("dd.MM.yyyy HH:mm") : "");
                            item.SubItems.Add(nereden);
                            item.SubItems.Add(nereye);

                            lvwBiletler.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Biletler yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBiletIptal_Click(object sender, EventArgs e)
        {
            Form frm = new Form
            {
                Text = "Bilet İptal",
                Size = new System.Drawing.Size(320, 220),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            Label lblTitle = new Label
            {
                Text = "Bilet İptal Bilgileri",
                Location = new System.Drawing.Point(0, 10),
                AutoSize = false,
                Width = 320,
                Height = 30,
                Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                ForeColor = System.Drawing.Color.Crimson
            };
            frm.Controls.Add(lblTitle);

            Label lblBiletId = new Label { Text = "Bilet ID:", Location = new System.Drawing.Point(30, 55), AutoSize = true };
            TextBox txtBiletId = new TextBox { Location = new System.Drawing.Point(120, 50), Width = 150 };
            Label lblYolcu = new Label { Text = "Yolcu Adı Soyadı:", Location = new System.Drawing.Point(5, 90), AutoSize = true };
            TextBox txtYolcu = new TextBox { Location = new System.Drawing.Point(120, 85), Width = 150 };
            Button btnIptal = new Button
            {
                Text = "İptal Et",
                Location = new System.Drawing.Point(120, 130),
                Width = 100,
                Height = 36,
                BackColor = System.Drawing.Color.Crimson,
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnIptal.FlatAppearance.BorderSize = 0;

            frm.Controls.Add(lblBiletId);
            frm.Controls.Add(txtBiletId);
            frm.Controls.Add(lblYolcu);
            frm.Controls.Add(txtYolcu);
            frm.Controls.Add(btnIptal);

            // Eğer ListView'de seçim varsa otomatik doldur
            if (lvwBiletler.SelectedItems.Count > 0)
            {
                txtBiletId.Text = lvwBiletler.SelectedItems[0].SubItems[6].Text; // BiletId kolonuna göre index
                txtYolcu.Text = lvwBiletler.SelectedItems[0].SubItems[5].Text;   // Yolcu Adı Soyadı kolonuna göre index
            }

            btnIptal.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtBiletId.Text) || !int.TryParse(txtBiletId.Text, out int biletId))
                {
                    MessageBox.Show("Geçerli bir Bilet ID girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtYolcu.Text))
                {
                    MessageBox.Show("Yolcu adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string connectionString = @"Data Source=DESKTOP-15EI2H8\SQLEXPRESS;Initial Catalog=OtobusBileti2;Integrated Security=True;Trust Server Certificate=True";
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM Bilet WHERE BiletId = @biletId AND YolcuAdSoyad = @yolcu";
                        using (var cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@biletId", biletId);
                            cmd.Parameters.AddWithValue("@yolcu", txtYolcu.Text.Trim());
                            int affected = cmd.ExecuteNonQuery();
                            if (affected > 0)
                                MessageBox.Show("Bilet başarıyla iptal edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Böyle bir bilet bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bilet iptal edilirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                frm.DialogResult = DialogResult.OK;
                frm.Close();
                btnBiletleriGor_Click(this, EventArgs.Empty); // Listeyi güncelle
            };

            frm.ShowDialog();
        }

        private void butseferekle_Click(object sender, EventArgs e)
        {
            // Dialog oluştur
            Form frm = new Form();
            frm.Text = "Sefer Ekle";
            frm.Size = new System.Drawing.Size(370, 370);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Font = new System.Drawing.Font("Segoe UI", 10F);
            frm.BackColor = System.Drawing.Color.WhiteSmoke;

            Label lblTitle = new Label
            {
                Text = "Sefer Bilgileri",
                Location = new System.Drawing.Point(0, 10),
                AutoSize = false,
                Width = 370,
                Height = 30,
                Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                ForeColor = System.Drawing.Color.MediumSlateBlue
            };
            frm.Controls.Add(lblTitle);

            int y = 55;
            Label lblSeferId = new Label { Text = "Sefer ID:", Location = new System.Drawing.Point(30, y), AutoSize = true };
            TextBox txtSeferId = new TextBox { Location = new System.Drawing.Point(140, y - 5), Width = 180 };
            y += 35;
            Label lblOtobusId = new Label { Text = "Otobüs:", Location = new System.Drawing.Point(30, y), AutoSize = true };
            ComboBox cmbOtobus = new ComboBox { Location = new System.Drawing.Point(140, y - 5), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            y += 35;
            Label lblNereden = new Label { Text = "Nereden:", Location = new System.Drawing.Point(30, y), AutoSize = true };
            TextBox txtNereden = new TextBox { Location = new System.Drawing.Point(140, y - 5), Width = 180 };
            y += 35;
            Label lblNereye = new Label { Text = "Nereye:", Location = new System.Drawing.Point(30, y), AutoSize = true };
            TextBox txtNereye = new TextBox { Location = new System.Drawing.Point(140, y - 5), Width = 180 };
            y += 35;
            Label lblTarih = new Label { Text = "Tarih:", Location = new System.Drawing.Point(30, y), AutoSize = true };
            DateTimePicker dtpTarih = new DateTimePicker { Location = new System.Drawing.Point(140, y - 5), Width = 180, Format = DateTimePickerFormat.Short };
            y += 35;
            Label lblSaat = new Label { Text = "Saat:", Location = new System.Drawing.Point(30, y), AutoSize = true };
            MaskedTextBox txtSaat = new MaskedTextBox { Location = new System.Drawing.Point(140, y - 5), Width = 180, Mask = "00:00" };
            y += 45;
            Button btnEkle = new Button { Text = "Sefer Ekle", Location = new System.Drawing.Point(140, y), Width = 120, Height = 36, BackColor = System.Drawing.Color.MediumSlateBlue, ForeColor = System.Drawing.Color.White };
            btnEkle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.FlatAppearance.BorderSize = 0;
            btnEkle.Cursor = Cursors.Hand;

            frm.Controls.Add(lblSeferId); frm.Controls.Add(txtSeferId);
            frm.Controls.Add(lblOtobusId); frm.Controls.Add(cmbOtobus);
            frm.Controls.Add(lblNereden); frm.Controls.Add(txtNereden);
            frm.Controls.Add(lblNereye); frm.Controls.Add(txtNereye);
            frm.Controls.Add(lblTarih); frm.Controls.Add(dtpTarih);
            frm.Controls.Add(lblSaat); frm.Controls.Add(txtSaat);
            frm.Controls.Add(btnEkle);

            // Otobüsleri ComboBox'a yükle
            string connectionString = @"Data Source=DESKTOP-15EI2H8\SQLEXPRESS;Initial Catalog=OtobusBileti2;Integrated Security=True;Trust Server Certificate=True";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT OtobusId, Plaka, SirketAdi FROM Otobus", conn))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int otobusId = Convert.ToInt32(dr["OtobusId"]);
                        string plaka = dr["Plaka"]?.ToString() ?? "";
                        string sirket = dr["SirketAdi"]?.ToString() ?? "";
                        cmbOtobus.Items.Add(new ComboBoxItemWithId($"{sirket} - {plaka}", otobusId));
                    }
                }
            }

            btnEkle.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtSeferId.Text) || !int.TryParse(txtSeferId.Text, out int seferId))
                {
                    MessageBox.Show("Geçerli bir Sefer ID girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbOtobus.SelectedItem is not ComboBoxItemWithId otobusItem)
                {
                    MessageBox.Show("Lütfen bir otobüs seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNereden.Text) || string.IsNullOrWhiteSpace(txtNereye.Text))
                {
                    MessageBox.Show("Nereden ve Nereye alanları boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!TimeSpan.TryParse(txtSaat.Text, out TimeSpan saat))
                {
                    MessageBox.Show("Saat formatı hatalı (örn: 14:30)", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime tarih = dtpTarih.Value.Date;
                int otobusId = otobusItem.Id;

                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string insertQuery = "INSERT INTO Sefer (SeferId, OtobusId, Nereden, Nereye, Tarih, Saat) VALUES (@seferId, @otobusId, @nereden, @nereye, @tarih, @saat)";
                        using (var cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@seferId", seferId);
                            cmd.Parameters.AddWithValue("@otobusId", otobusId);
                            cmd.Parameters.AddWithValue("@nereden", txtNereden.Text.Trim());
                            cmd.Parameters.AddWithValue("@nereye", txtNereye.Text.Trim());
                            cmd.Parameters.AddWithValue("@tarih", tarih);
                            cmd.Parameters.AddWithValue("@saat", txtSaat.Text);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show($"Sefer başarıyla eklendi. SeferId: {seferId}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm.DialogResult = DialogResult.OK;
                        frm.Close();
                        AdminForm_Load(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sefer eklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            frm.ShowDialog();
        }

        // ComboBox için yardımcı sınıf
        private class ComboBoxItemWithId
        {
            public string Display { get; set; }
            public int Id { get; set; }
            public ComboBoxItemWithId(string display, int id)
            {
                Display = display;
                Id = id;
            }
            public override string ToString() => Display;
        }

        private void butsefersil_Click(object sender, EventArgs e)
        {
            // Dialog oluştur
            Form frm = new Form();
            frm.Text = "Sefer Sil";
            frm.Size = new System.Drawing.Size(370, 320);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Font = new System.Drawing.Font("Segoe UI", 10F);
            frm.BackColor = System.Drawing.Color.WhiteSmoke;

            Label lblTitle = new Label
            {
                Text = "Sefer Silme Bilgileri",
                Location = new System.Drawing.Point(0, 10),
                AutoSize = false,
                Width = 370,
                Height = 30,
                Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                ForeColor = System.Drawing.Color.Crimson
            };
            frm.Controls.Add(lblTitle);

            int y = 55;
            Label lblSeferId = new Label { Text = "Sefer ID:", Location = new System.Drawing.Point(30, y), AutoSize = true };
            TextBox txtSeferId = new TextBox { Location = new System.Drawing.Point(140, y-5), Width = 180 };
            y += 35;
            Label lblOtobus = new Label { Text = "Otobüs:", Location = new System.Drawing.Point(30, y), AutoSize = true };
            ComboBox cmbOtobus = new ComboBox { Location = new System.Drawing.Point(140, y-5), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            y += 35;
            Label lblNereden = new Label { Text = "Nereden:", Location = new System.Drawing.Point(30, y), AutoSize = true };
            TextBox txtNereden = new TextBox { Location = new System.Drawing.Point(140, y-5), Width = 180 };
            y += 35;
            Label lblNereye = new Label { Text = "Nereye:", Location = new System.Drawing.Point(30, y), AutoSize = true };
            TextBox txtNereye = new TextBox { Location = new System.Drawing.Point(140, y-5), Width = 180 };
            y += 45;
            Button btnSil = new Button { Text = "Sefer Sil", Location = new System.Drawing.Point(140, y), Width = 120, Height = 36, BackColor = System.Drawing.Color.Crimson, ForeColor = System.Drawing.Color.White };
            btnSil.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.Cursor = Cursors.Hand;

            frm.Controls.Add(lblSeferId); frm.Controls.Add(txtSeferId);
            frm.Controls.Add(lblOtobus); frm.Controls.Add(cmbOtobus);
            frm.Controls.Add(lblNereden); frm.Controls.Add(txtNereden);
            frm.Controls.Add(lblNereye); frm.Controls.Add(txtNereye);
            frm.Controls.Add(btnSil);

            // Otobüsleri ComboBox'a yükle
            string connectionString = @"Data Source=DESKTOP-15EI2H8\SQLEXPRESS;Initial Catalog=OtobusBileti2;Integrated Security=True;Trust Server Certificate=True";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT OtobusId, Plaka, SirketAdi FROM Otobus", conn))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int otobusId = Convert.ToInt32(dr["OtobusId"]);
                        string plaka = dr["Plaka"]?.ToString() ?? "";
                        string sirket = dr["SirketAdi"]?.ToString() ?? "";
                        cmbOtobus.Items.Add(new ComboBoxItemWithId($"{sirket} - {plaka}", otobusId));
                    }
                }
            }

            btnSil.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtSeferId.Text) || !int.TryParse(txtSeferId.Text, out int seferId))
                {
                    MessageBox.Show("Geçerli bir Sefer ID girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbOtobus.SelectedItem is not ComboBoxItemWithId otobusItem)
                {
                    MessageBox.Show("Lütfen bir otobüs seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int otobusId = otobusItem.Id;
                string nereden = txtNereden.Text.Trim();
                string nereye = txtNereye.Text.Trim();
                if (string.IsNullOrWhiteSpace(nereden) || string.IsNullOrWhiteSpace(nereye))
                {
                    MessageBox.Show("Nereden ve Nereye alanları boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM Sefer WHERE SeferId = @seferId AND OtobusId = @otobusId AND Nereden = @nereden AND Nereye = @nereye";
                        using (var cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@seferId", seferId);
                            cmd.Parameters.AddWithValue("@otobusId", otobusId);
                            cmd.Parameters.AddWithValue("@nereden", nereden);
                            cmd.Parameters.AddWithValue("@nereye", nereye);
                            int affected = cmd.ExecuteNonQuery();
                            if (affected > 0)
                                MessageBox.Show("Sefer başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Böyle bir sefer bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        frm.DialogResult = DialogResult.OK;
                        frm.Close();
                        AdminForm_Load(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sefer silinirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            frm.ShowDialog();
        }
    }
}
