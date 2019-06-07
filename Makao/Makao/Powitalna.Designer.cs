namespace Makao
{
    partial class Powitalna
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Powitalna));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BT_Wyjdz = new Quiz.RoundButton();
            this.BT_Instrukcja = new Quiz.RoundButton();
            this.BT_Graj = new Quiz.RoundButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(93, 220);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(721, 220);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(254, 173);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // BT_Wyjdz
            // 
            this.BT_Wyjdz.BackColor = System.Drawing.Color.Transparent;
            this.BT_Wyjdz.FlatAppearance.BorderSize = 0;
            this.BT_Wyjdz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_Wyjdz.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BT_Wyjdz.ForeColor = System.Drawing.Color.Transparent;
            this.BT_Wyjdz.Location = new System.Drawing.Point(426, 381);
            this.BT_Wyjdz.Name = "BT_Wyjdz";
            this.BT_Wyjdz.Size = new System.Drawing.Size(197, 98);
            this.BT_Wyjdz.TabIndex = 2;
            this.BT_Wyjdz.Text = "Wyjdź";
            this.BT_Wyjdz.UseVisualStyleBackColor = false;
            this.BT_Wyjdz.Click += new System.EventHandler(this.BT_Wyjdz_Click);
            // 
            // BT_Instrukcja
            // 
            this.BT_Instrukcja.BackColor = System.Drawing.Color.Transparent;
            this.BT_Instrukcja.FlatAppearance.BorderSize = 0;
            this.BT_Instrukcja.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_Instrukcja.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BT_Instrukcja.ForeColor = System.Drawing.Color.Transparent;
            this.BT_Instrukcja.Location = new System.Drawing.Point(426, 243);
            this.BT_Instrukcja.Name = "BT_Instrukcja";
            this.BT_Instrukcja.Size = new System.Drawing.Size(197, 98);
            this.BT_Instrukcja.TabIndex = 1;
            this.BT_Instrukcja.Text = "Instrukcja";
            this.BT_Instrukcja.UseVisualStyleBackColor = false;
            this.BT_Instrukcja.Click += new System.EventHandler(this.BT_Instrukcja_Click);
            // 
            // BT_Graj
            // 
            this.BT_Graj.BackColor = System.Drawing.Color.Transparent;
            this.BT_Graj.FlatAppearance.BorderSize = 0;
            this.BT_Graj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_Graj.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BT_Graj.ForeColor = System.Drawing.Color.Transparent;
            this.BT_Graj.Location = new System.Drawing.Point(426, 107);
            this.BT_Graj.Name = "BT_Graj";
            this.BT_Graj.Size = new System.Drawing.Size(197, 98);
            this.BT_Graj.TabIndex = 0;
            this.BT_Graj.Text = "Graj";
            this.BT_Graj.UseVisualStyleBackColor = false;
            this.BT_Graj.Click += new System.EventHandler(this.BT_Graj_Click);
            // 
            // Powitalna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BT_Wyjdz);
            this.Controls.Add(this.BT_Instrukcja);
            this.Controls.Add(this.BT_Graj);
            this.Name = "Powitalna";
            this.Size = new System.Drawing.Size(1050, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Quiz.RoundButton BT_Graj;
        private Quiz.RoundButton BT_Instrukcja;
        private Quiz.RoundButton BT_Wyjdz;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
