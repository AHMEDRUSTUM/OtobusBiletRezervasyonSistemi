namespace Ntp
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private Button btnOtobusEkle;
        private Button btnBiletleriGor;
        private Button btnBiletIptal;
        private ListView lvwBiletler;
        private Label lblAdminPanel;
        private Label lblOtobusler;
        private ListBox lstOtobusler;
        private void InitializeComponent()
        {
            btnOtobusEkle = new Button();
            btnBiletleriGor = new Button();
            btnBiletIptal = new Button();
            lvwBiletler = new ListView();
            lblAdminPanel = new Label();
            lblOtobusler = new Label();
            lstOtobusler = new ListBox();
            button1 = new Button();
            butsefersil = new Button();
            butseferekle = new Button();
            SuspendLayout();
            // 
            // btnOtobusEkle
            // 
            btnOtobusEkle.BackColor = Color.MediumSlateBlue;
            btnOtobusEkle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOtobusEkle.ForeColor = Color.White;
            btnOtobusEkle.Location = new Point(30, 228);
            btnOtobusEkle.Name = "btnOtobusEkle";
            btnOtobusEkle.Size = new Size(259, 44);
            btnOtobusEkle.TabIndex = 3;
            btnOtobusEkle.Text = "Otobüs Ekle";
            btnOtobusEkle.UseVisualStyleBackColor = false;
            btnOtobusEkle.Click += btnOtobusEkle_Click;
            // 
            // btnBiletleriGor
            // 
            btnBiletleriGor.BackColor = Color.MediumSlateBlue;
            btnBiletleriGor.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBiletleriGor.ForeColor = Color.White;
            btnBiletleriGor.Location = new Point(30, 452);
            btnBiletleriGor.Name = "btnBiletleriGor";
            btnBiletleriGor.Size = new Size(259, 42);
            btnBiletleriGor.TabIndex = 4;
            btnBiletleriGor.Text = "Biletleri Gör";
            btnBiletleriGor.UseVisualStyleBackColor = false;
            btnBiletleriGor.Click += btnBiletleriGor_Click;
            // 
            // btnBiletIptal
            // 
            btnBiletIptal.BackColor = Color.IndianRed;
            btnBiletIptal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBiletIptal.ForeColor = Color.White;
            btnBiletIptal.Location = new Point(30, 506);
            btnBiletIptal.Name = "btnBiletIptal";
            btnBiletIptal.Size = new Size(259, 44);
            btnBiletIptal.TabIndex = 5;
            btnBiletIptal.Text = "Bilet İptal Et";
            btnBiletIptal.UseVisualStyleBackColor = false;
            btnBiletIptal.Click += btnBiletIptal_Click;
            // 
            // lvwBiletler
            // 
            lvwBiletler.FullRowSelect = true;
            lvwBiletler.GridLines = true;
            lvwBiletler.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvwBiletler.Location = new Point(432, 101);
            lvwBiletler.Name = "lvwBiletler";
            lvwBiletler.Size = new Size(422, 410);
            lvwBiletler.TabIndex = 6;
            lvwBiletler.UseCompatibleStateImageBehavior = false;
            lvwBiletler.View = View.Details;
            // 
            // lblAdminPanel
            // 
            lblAdminPanel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAdminPanel.ForeColor = Color.MediumSlateBlue;
            lblAdminPanel.Location = new Point(12, 9);
            lblAdminPanel.Name = "lblAdminPanel";
            lblAdminPanel.Size = new Size(250, 40);
            lblAdminPanel.TabIndex = 0;
            lblAdminPanel.Text = "Admin Paneli";
            // 
            // lblOtobusler
            // 
            lblOtobusler.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOtobusler.Location = new Point(30, 56);
            lblOtobusler.Name = "lblOtobusler";
            lblOtobusler.Size = new Size(100, 25);
            lblOtobusler.TabIndex = 1;
            lblOtobusler.Text = "Otobüsler";
            // 
            // lstOtobusler
            // 
            lstOtobusler.Font = new Font("Segoe UI", 11F);
            lstOtobusler.Location = new Point(30, 101);
            lstOtobusler.Name = "lstOtobusler";
            lstOtobusler.Size = new Size(376, 104);
            lstOtobusler.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(30, 284);
            button1.Name = "button1";
            button1.Size = new Size(259, 44);
            button1.TabIndex = 7;
            button1.Text = "Otobüs Sil";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // butsefersil
            // 
            butsefersil.BackColor = Color.IndianRed;
            butsefersil.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            butsefersil.ForeColor = Color.White;
            butsefersil.Location = new Point(30, 396);
            butsefersil.Name = "butsefersil";
            butsefersil.Size = new Size(259, 44);
            butsefersil.TabIndex = 8;
            butsefersil.Text = "Sefer Sil";
            butsefersil.UseVisualStyleBackColor = false;
            butsefersil.Click += butsefersil_Click;
            // 
            // butseferekle
            // 
            butseferekle.BackColor = Color.MediumSlateBlue;
            butseferekle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            butseferekle.ForeColor = Color.White;
            butseferekle.Location = new Point(30, 340);
            butseferekle.Name = "butseferekle";
            butseferekle.Size = new Size(259, 44);
            butseferekle.TabIndex = 9;
            butseferekle.Text = "Sefer Ekle";
            butseferekle.UseVisualStyleBackColor = false;
            butseferekle.Click += butseferekle_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(882, 583);
            Controls.Add(butseferekle);
            Controls.Add(butsefersil);
            Controls.Add(button1);
            Controls.Add(lblAdminPanel);
            Controls.Add(lblOtobusler);
            Controls.Add(lstOtobusler);
            Controls.Add(btnOtobusEkle);
            Controls.Add(btnBiletleriGor);
            Controls.Add(btnBiletIptal);
            Controls.Add(lvwBiletler);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Paneli";
            ResumeLayout(false);
        }
        private Button button1;
        private Button butsefersil;
        private Button butseferekle;
    }
}
