using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Makao
{
    public partial class Form1 : Form, IView
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red);
            Graphics g = panel1.CreateGraphics();
            g.DrawRectangle(pen, 10, 10, 300, 300);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Red);
            Graphics g = panel1.CreateGraphics();
            g.DrawRectangle(pen, e.Location.X , e.Location.Y , 30, 30);
        }
    }
}
