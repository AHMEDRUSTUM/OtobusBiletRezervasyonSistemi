using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Ntp
{
    public partial class OtobusForm : Form
    {
        public OtobusForm()
        {
            InitializeComponent();
            Load += OtobusForm_Load;
            lstOtobusler.SelectedIndexChanged += LstOtobusler_SelectedIndexChanged;
            btnBiletAl.Click += BtnBiletAl_Click;
        }

        private readonly string connectionString = @"Data Source=DESKTOP-15EI2H8\SQLEXPRESS;Initial Catalog=OtobusBileti2;Integrated Security=True;Trust Server Certificate=True";

        private void OtobusForm_Load(object sender, EventArgs e)
        {
            using SqlConnection conn = new(connectionString);
            try
            {
                conn.Open();
                string query = @"
                    SELECT o.SirketAdi, s.Nereden, s.Nereye, s.Tarih, s.Saat, s.SeferId
                    FROM Sefer s
                    INNER JOIN Otobus o ON s.OtobusId = o.OtobusId";

                using SqlCommand cmd = new(query, conn);
                using SqlDataReader dr = cmd.ExecuteReader();
                lstOtobusler.Items.Clear();

                while (dr.Read())
                {
                    string item = $"{dr["SirketAdi"]} - {dr["Nereden"]} → {dr["Nereye"]} - {Convert.ToDateTime(dr["Tarih"]).ToString("dd.MM.yyyy")} - {dr["Saat"]}";
                    int seferId = Convert.ToInt32(dr["SeferId"]);
                    lstOtobusler.Items.Add(new ListBoxItemWithId(item, seferId));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Otobüsler yüklenirken hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LstOtobusler_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlKoltuklar.Controls.Clear();

            if (lstOtobusler.SelectedItem is not ListBoxItemWithId selectedItem)
                return;

            int seferId = selectedItem.SeferId;
            int otobusId = 0;
            List<(int KoltukNo, int DoluMu)> tumKoltuklar = new();

            using SqlConnection conn = new(connectionString);
            conn.Open();

            using (SqlCommand cmd = new("SELECT OtobusId FROM Sefer WHERE SeferId = @seferId", conn))
            {
                cmd.Parameters.AddWithValue("@seferId", seferId);
                otobusId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            using (SqlCommand cmd = new("SELECT KoltukNo, DoluMu FROM Koltuk WHERE OtobusId = @otobusId ORDER BY KoltukNo", conn))
            {
                cmd.Parameters.AddWithValue("@otobusId", otobusId);
                using SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tumKoltuklar.Add((Convert.ToInt32(dr["KoltukNo"]), Convert.ToInt32(dr["DoluMu"])));
                }
            }

            int rows = 6, cols = 5, index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (index >= tumKoltuklar.Count)
                        return;

                    var (koltukNo, doluMu) = tumKoltuklar[index++];
                    var btn = new Button
                    {
                        Text = koltukNo.ToString(),
                        Width = 50,
                        Height = 40,
                        Margin = new Padding(5),
                        BackColor = doluMu == 1 ? Color.Gray : Color.White,
                        ForeColor = doluMu == 1 ? Color.White : Color.Black,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        Tag = false,
                        Enabled = doluMu == 0
                    };
                    if (btn.Enabled)
                        btn.Click += Koltuk_Click;

                    pnlKoltuklar.Controls.Add(btn);
                }
            }
        }

        private void Koltuk_Click(object sender, EventArgs e)
        {
            if (sender is not Button b) return;

            foreach (Button btn in pnlKoltuklar.Controls.OfType<Button>().Where(btn => btn.Enabled))
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.Tag = false;
            }

            b.BackColor = Color.MediumSlateBlue;
            b.ForeColor = Color.White;
            b.Tag = true;
        }

        private void BtnBiletAl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtTC.Text) || string.IsNullOrWhiteSpace(txtTel.Text))
            {
                MessageBox.Show("Lütfen tüm kişi bilgilerini doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var seciliKoltuklar = pnlKoltuklar.Controls
                .OfType<Button>()
                .Where(b => b.Tag is bool tag && tag)
                .Select(b => int.Parse(b.Text))
                .ToList();

            if (!seciliKoltuklar.Any())
            {
                MessageBox.Show("Lütfen en az bir koltuk seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstOtobusler.SelectedItem is not ListBoxItemWithId selectedSefer)
            {
                MessageBox.Show("Lütfen bir otobüs seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int seferId = selectedSefer.SeferId, otobusId = 0;
            List<int> biletIdList = new();

            using SqlConnection conn = new(connectionString);
            conn.Open();

            using (SqlCommand cmd = new("SELECT OtobusId FROM Sefer WHERE SeferId = @seferId", conn))
            {
                cmd.Parameters.AddWithValue("@seferId", seferId);
                otobusId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            foreach (int koltukNo in seciliKoltuklar)
            {
                int koltukId = 0;

                using (SqlCommand cmd = new("SELECT KoltukId FROM Koltuk WHERE OtobusId = @otobusId AND KoltukNo = @koltukNo", conn))
                {
                    cmd.Parameters.AddWithValue("@otobusId", otobusId);
                    cmd.Parameters.AddWithValue("@koltukNo", koltukNo);
                    koltukId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (SqlCommand cmd = new(@"INSERT INTO Bilet (SeferId, KoltukId, YolcuAdSoyad, KimlikNo, TelNo, SatinAlmaTarihi, SatinAlanKullaniciId) 
                                              VALUES (@seferId, @koltukId, @adsoyad, @tc, @tel, @tarih, @kullanici); 
                                              SELECT SCOPE_IDENTITY();", conn))
                {
                    cmd.Parameters.AddWithValue("@seferId", seferId);
                    cmd.Parameters.AddWithValue("@koltukId", koltukId);
                    cmd.Parameters.AddWithValue("@adsoyad", $"{txtAd.Text.Trim()} {txtSoyad.Text.Trim()}");
                    cmd.Parameters.AddWithValue("@tc", txtTC.Text.Trim());
                    cmd.Parameters.AddWithValue("@tel", txtTel.Text.Trim());
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
                    cmd.Parameters.AddWithValue("@kullanici", 2);

                    var result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int biletId))
                        biletIdList.Add(biletId);
                }

                using (SqlCommand cmd = new("UPDATE Koltuk SET DoluMu = 1 WHERE KoltukId = @koltukId", conn))
                {
                    cmd.Parameters.AddWithValue("@koltukId", koltukId);
                    cmd.ExecuteNonQuery();
                }
            }

            ShowBiletDialog(txtAd.Text, txtSoyad.Text, biletIdList, seciliKoltuklar);

            txtAd.Clear();
            txtSoyad.Clear();
            txtTC.Clear();
            txtTel.Clear();
            pnlKoltuklar.Controls.Clear();
        }

        private void ShowBiletDialog(string ad, string soyad, List<int> biletIds, List<int> koltuklar)
        {
            Form frm = new()
            {
                Text = "Bilet Alındı",
                Size = new Size(350, 260),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.WhiteSmoke
            };

            frm.Controls.Add(new Label
            {
                Text = "Biletiniz Başarıyla Alındı!",
                Location = new Point(0, 20),
                AutoSize = false,
                Width = 350,
                Height = 30,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.MediumSlateBlue
            });

            frm.Controls.Add(new Label
            {
                Text = $"Sayın {ad} {soyad},\nBiletiniz başarıyla alınmıştır!\n\nBilet ID(ler): {string.Join(", ", biletIds)}\nKoltuk: {string.Join(", ", koltuklar)}\n\nLütfen Bilet ID'nizi not ediniz.",
                Location = new Point(30, 60),
                AutoSize = false,
                Width = 290,
                Height = 110,
                Font = new Font("Segoe UI", 11F)
            });

            var btnKapat = new Button
            {
                Text = "Kapat",
                Location = new Point(120, 180),
                Width = 100,
                Height = 36,
                BackColor = Color.MediumSlateBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnKapat.FlatAppearance.BorderSize = 0;
            btnKapat.Click += (s, e) => frm.Close();
            frm.Controls.Add(btnKapat);

            frm.ShowDialog();
        }

        public class ListBoxItemWithId
        {
            public string Display { get; set; }
            public int SeferId { get; set; }

            public ListBoxItemWithId(string display, int seferId)
            {
                Display = display;
                SeferId = seferId;
            }

            public override string ToString() => Display;
        }
    }
}
