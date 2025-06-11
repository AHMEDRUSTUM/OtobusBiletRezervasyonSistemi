using System.Windows.Forms;

namespace Ntp
{
    public partial class MusteriForm : Form
    {
        public MusteriForm()
        {
            InitializeComponent();
            // Otobüs seçiniz butonuna tıklanınca OtobusForm açılsın
            btnotubussec.Click += (s, e) => {
                if (rbSehirlerarasi.Checked)
                {
                    var otobusForm = new OtobusForm();
                    otobusForm.ShowDialog();
                }
                else if (rbSehirici.Checked)
                {
                    var otobusForm = new OtobusForm();
                    otobusForm.ShowDialog();
                }
                else
              {
                MessageBox.Show("Lütfen gitmek istediğiniz yeri seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              }
            };
        }

        
    }
}
