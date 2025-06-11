namespace Ntp
{
    partial class OtobusForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pictureBox;
        private ListBox lstOtobusler;
        private Label lblKoltuklar;
        private FlowLayoutPanel pnlKoltuklar;
        private GroupBox grpKisiBilgi;
        private Label lblAd;
        private TextBox txtAd;
        private Label lblSoyad;
        private TextBox txtSoyad;
        private Label lblTC;
        private TextBox txtTC;
        private Label lblTel;
        private TextBox txtTel;
        private Button btnBiletAl;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            lstOtobusler = new ListBox();
            lblKoltuklar = new Label();
            pnlKoltuklar = new FlowLayoutPanel();
            grpKisiBilgi = new GroupBox();
            lblAd = new Label();
            txtAd = new TextBox();
            lblSoyad = new Label();
            txtSoyad = new TextBox();
            lblTC = new Label();
            txtTC = new TextBox();
            lblTel = new Label();
            txtTel = new TextBox();
            btnBiletAl = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            grpKisiBilgi.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Image = Properties.Resources.electronic_ticket;
            pictureBox.Location = new Point(14, 16);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(91, 101);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // lstOtobusler
            // 
            lstOtobusler.Font = new Font("Segoe UI", 12F);
            lstOtobusler.Location = new Point(240, 16);
            lstOtobusler.Name = "lstOtobusler";
            lstOtobusler.Size = new Size(553, 172);
            lstOtobusler.TabIndex = 1;
            lstOtobusler.SelectedIndexChanged += LstOtobusler_SelectedIndexChanged;
            // 
            // lblKoltuklar
            // 
            lblKoltuklar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblKoltuklar.Location = new Point(14, 256);
            lblKoltuklar.Name = "lblKoltuklar";
            lblKoltuklar.Size = new Size(100, 23);
            lblKoltuklar.TabIndex = 2;
            lblKoltuklar.Text = "Koltuklar";
            // 
            // pnlKoltuklar
            // 
            pnlKoltuklar.BackColor = Color.WhiteSmoke;
            pnlKoltuklar.Location = new Point(14, 293);
            pnlKoltuklar.Name = "pnlKoltuklar";
            pnlKoltuklar.Size = new Size(625, 258);
            pnlKoltuklar.TabIndex = 3;
            // 
            // grpKisiBilgi
            // 
            grpKisiBilgi.Controls.Add(lblAd);
            grpKisiBilgi.Controls.Add(txtAd);
            grpKisiBilgi.Controls.Add(lblSoyad);
            grpKisiBilgi.Controls.Add(txtSoyad);
            grpKisiBilgi.Controls.Add(lblTC);
            grpKisiBilgi.Controls.Add(txtTC);
            grpKisiBilgi.Controls.Add(lblTel);
            grpKisiBilgi.Controls.Add(txtTel);
            grpKisiBilgi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpKisiBilgi.Location = new Point(680, 204);
            grpKisiBilgi.Name = "grpKisiBilgi";
            grpKisiBilgi.Size = new Size(251, 279);
            grpKisiBilgi.TabIndex = 4;
            grpKisiBilgi.TabStop = false;
            grpKisiBilgi.Text = "Kişi Bilgileri";
            // 
            // lblAd
            // 
            lblAd.Location = new Point(11, 45);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(60, 25);
            lblAd.TabIndex = 0;
            lblAd.Text = "Ad:";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(80, 42);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(148, 29);
            txtAd.TabIndex = 1;
            // 
            // lblSoyad
            // 
            lblSoyad.Location = new Point(11, 90);
            lblSoyad.Name = "lblSoyad";
            lblSoyad.Size = new Size(60, 25);
            lblSoyad.TabIndex = 2;
            lblSoyad.Text = "Soyad:";
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(80, 87);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(148, 29);
            txtSoyad.TabIndex = 3;
            // 
            // lblTC
            // 
            lblTC.Location = new Point(11, 135);
            lblTC.Name = "lblTC";
            lblTC.Size = new Size(60, 25);
            lblTC.TabIndex = 4;
            lblTC.Text = "TC:";
            // 
            // txtTC
            // 
            txtTC.Location = new Point(80, 132);
            txtTC.MaxLength = 11;
            txtTC.Name = "txtTC";
            txtTC.Size = new Size(148, 29);
            txtTC.TabIndex = 5;
            // 
            // lblTel
            // 
            lblTel.Location = new Point(11, 180);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(60, 25);
            lblTel.TabIndex = 6;
            lblTel.Text = "Tel:";
            // 
            // txtTel
            // 
            txtTel.Location = new Point(80, 177);
            txtTel.MaxLength = 11;
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(148, 29);
            txtTel.TabIndex = 7;
            // 
            // btnBiletAl
            // 
            btnBiletAl.BackColor = Color.MediumSlateBlue;
            btnBiletAl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBiletAl.ForeColor = Color.White;
            btnBiletAl.Location = new Point(680, 508);
            btnBiletAl.Name = "btnBiletAl";
            btnBiletAl.Size = new Size(251, 57);
            btnBiletAl.TabIndex = 5;
            btnBiletAl.Text = "Bilet Al";
            btnBiletAl.UseVisualStyleBackColor = false;
            btnBiletAl.Click += BtnBiletAl_Click;
            // 
            // OtobusForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 605);
            Controls.Add(pictureBox);
            Controls.Add(lstOtobusler);
            Controls.Add(lblKoltuklar);
            Controls.Add(pnlKoltuklar);
            Controls.Add(grpKisiBilgi);
            Controls.Add(btnBiletAl);
            Name = "OtobusForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Otobüs Bilet Sistemi";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            grpKisiBilgi.ResumeLayout(false);
            grpKisiBilgi.PerformLayout();
            ResumeLayout(false);
        }

    }
}
