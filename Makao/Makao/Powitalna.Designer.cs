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
            this.BT_Graj = new Quiz.RoundButton();
            this.BT_Instrukcja = new Quiz.RoundButton();
            this.BT_Wyjdz = new Quiz.RoundButton();
            this.SuspendLayout();
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
            // 
            // Powitalna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.BT_Wyjdz);
            this.Controls.Add(this.BT_Instrukcja);
            this.Controls.Add(this.BT_Graj);
            this.Name = "Powitalna";
            this.Size = new System.Drawing.Size(1049, 584);
            this.ResumeLayout(false);

        }

        #endregion

        private Quiz.RoundButton BT_Graj;
        private Quiz.RoundButton BT_Instrukcja;
        private Quiz.RoundButton BT_Wyjdz;
    }
}
