namespace Makao
{
    partial class Gra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gra));
            this.panel1 = new System.Windows.Forms.Panel();
            this.karta = new System.Windows.Forms.Label();
            this.BT_Stop = new Quiz.RoundButtonBlue();
            this.BT_Pull = new Quiz.RoundButtonBlue();
            this.button1 = new Quiz.RoundButton();
            this.BT_End = new Quiz.RoundButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BT_Stop);
            this.panel1.Controls.Add(this.BT_Pull);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.BT_End);
            this.panel1.Controls.Add(this.karta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 561);
            this.panel1.TabIndex = 0;
            // 
            // karta
            // 
            this.karta.AutoSize = true;
            this.karta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.karta.Location = new System.Drawing.Point(12, 536);
            this.karta.Name = "karta";
            this.karta.Size = new System.Drawing.Size(0, 16);
            this.karta.TabIndex = 7;
            // 
            // BT_Stop
            // 
            this.BT_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_Stop.Location = new System.Drawing.Point(914, 311);
            this.BT_Stop.Name = "BT_Stop";
            this.BT_Stop.Size = new System.Drawing.Size(110, 46);
            this.BT_Stop.TabIndex = 12;
            this.BT_Stop.Text = "Stoję";
            this.BT_Stop.UseVisualStyleBackColor = true;
            this.BT_Stop.Visible = false;
            this.BT_Stop.Click += new System.EventHandler(this.BT_Stop_Click);
            // 
            // BT_Pull
            // 
            this.BT_Pull.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_Pull.Location = new System.Drawing.Point(914, 234);
            this.BT_Pull.Name = "BT_Pull";
            this.BT_Pull.Size = new System.Drawing.Size(110, 46);
            this.BT_Pull.TabIndex = 11;
            this.BT_Pull.Text = "Ciągnij";
            this.BT_Pull.UseVisualStyleBackColor = true;
            this.BT_Pull.Click += new System.EventHandler(this.BT_Pull_Click_1);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(949, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Wyjdź z gry";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // BT_End
            // 
            this.BT_End.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BT_End.Location = new System.Drawing.Point(440, 220);
            this.BT_End.Name = "BT_End";
            this.BT_End.Size = new System.Drawing.Size(160, 84);
            this.BT_End.TabIndex = 9;
            this.BT_End.Text = "ZAKOŃCZ";
            this.BT_End.UseVisualStyleBackColor = true;
            this.BT_End.Visible = false;
            this.BT_End.Click += new System.EventHandler(this.BT_End_Click);
            // 
            // Gra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Name = "Gra";
            this.Size = new System.Drawing.Size(1044, 561);
            this.Load += new System.EventHandler(this.Gra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label karta;
        private Quiz.RoundButton button1;
        private Quiz.RoundButton BT_End;
        private Quiz.RoundButtonBlue BT_Pull;
        private Quiz.RoundButtonBlue BT_Stop;
    }
}
