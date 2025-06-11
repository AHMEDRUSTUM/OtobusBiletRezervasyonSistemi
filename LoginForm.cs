using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Ntp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

      private void btnLogin_Click(object sender, EventArgs e)
{
    // 1. Kullanıcıdan alınan giriş bilgileri
    string kullaniciAdi = txtUsername.Text.Trim();
    string sifre = txtPassword.Text.Trim();

    // 2. Veritabanı bağlantı dizesi
    string connectionString = @"Data Source=DESKTOP-15EI2H8\SQLEXPRESS;Initial Catalog=OtobusBileti2;Integrated Security=True;Trust Server Certificate=True";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        try
        {
            conn.Open();

            // 3. SQL sorgusu – Kullanıcıyı ve RolId'sini al
            string query = "SELECT RolId FROM Kullanici WHERE KullaniciAdi=@kullaniciAdi AND Sifre=@sifre";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
            cmd.Parameters.AddWithValue("@sifre", sifre);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int rolId = Convert.ToInt32(dr["RolId"]);

                // 4. RolId’ye göre uygun formu aç
                if (rolId == 1) // Admin
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else if (rolId == 2) // Müşteri
                {
                    MusteriForm musteriForm = new MusteriForm();
                    musteriForm.Show();
                }
                else
                {
                    MessageBox.Show("Tanımsız rol!", "Rol Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.Hide(); // LoginForm'u gizle
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dr.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Veritabanı bağlantısında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

    }
}
