namespace Makao
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.powitalna1 = new Makao.Powitalna();
            this.SuspendLayout();
            // 
            // powitalna1
            // 
            this.powitalna1.BackColor = System.Drawing.Color.Transparent;
            this.powitalna1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("powitalna1.BackgroundImage")));
            this.powitalna1.Location = new System.Drawing.Point(0, 0);
            this.powitalna1.Name = "powitalna1";
            this.powitalna1.Size = new System.Drawing.Size(1066, 608);
            this.powitalna1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1065, 610);
            this.Controls.Add(this.powitalna1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Makao";
            this.ResumeLayout(false);

        }

        #endregion
        private Powitalna powitalna1;
    }
}

