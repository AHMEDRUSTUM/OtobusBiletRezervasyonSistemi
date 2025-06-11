namespace Ntp
{
    partial class MusteriForm
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusteriForm));
            lblWelcome = new Label();
            btnotubussec = new Button();
            pictureBox = new PictureBox();
            rbSehirlerarasi = new RadioButton();
            rbSehirici = new RadioButton();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.MediumSlateBlue;
            lblWelcome.Location = new Point(291, 182);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(178, 40);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Hoşgeldiniz";
            // 
            // btnotubussec
            // 
            btnotubussec.BackColor = Color.MediumSlateBlue;
            btnotubussec.FlatStyle = FlatStyle.Flat;
            btnotubussec.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnotubussec.ForeColor = Color.White;
            btnotubussec.Location = new Point(253, 405);
            btnotubussec.Margin = new Padding(3, 4, 3, 4);
            btnotubussec.Name = "btnotubussec";
            btnotubussec.Size = new Size(206, 51);
            btnotubussec.TabIndex = 10;
            btnotubussec.Text = "Otobüs seçiniz.";
            btnotubussec.UseVisualStyleBackColor = false;
            // 
            // pictureBox
            // 
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(220, 13);
            pictureBox.Margin = new Padding(3, 4, 3, 4);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(326, 147);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // rbSehirlerarasi
            // 
            rbSehirlerarasi.AutoSize = true;
            rbSehirlerarasi.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbSehirlerarasi.Location = new Point(443, 325);
            rbSehirlerarasi.Margin = new Padding(3, 4, 3, 4);
            rbSehirlerarasi.Name = "rbSehirlerarasi";
            rbSehirlerarasi.Size = new Size(139, 29);
            rbSehirlerarasi.TabIndex = 4;
            rbSehirlerarasi.Text = "Şehirlerarası";
            // 
            // rbSehirici
            // 
            rbSehirici.AutoSize = true;
            rbSehirici.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbSehirici.Location = new Point(161, 325);
            rbSehirici.Margin = new Padding(3, 4, 3, 4);
            rbSehirici.Name = "rbSehirici";
            rbSehirici.Size = new Size(94, 29);
            rbSehirici.TabIndex = 3;
            rbSehirici.Text = "Şehiriçi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MediumSlateBlue;
            label1.Location = new Point(161, 244);
            label1.Name = "label1";
            label1.Size = new Size(421, 25);
            label1.TabIndex = 11;
            label1.Text = "Gideceğiniz yolculuk nereye? Lütfen belirtiniz.";
            // 
            // MusteriForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(701, 543);
            Controls.Add(label1);
            Controls.Add(pictureBox);
            Controls.Add(lblWelcome);
            Controls.Add(rbSehirici);
            Controls.Add(rbSehirlerarasi);
            Controls.Add(btnotubussec);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MusteriForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Müşteri Paneli";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnotubussec;
        private System.Windows.Forms.PictureBox pictureBox;
        private RadioButton rbSehirlerarasi;
        private RadioButton rbSehirici;
        private Label label1;
    }
}
