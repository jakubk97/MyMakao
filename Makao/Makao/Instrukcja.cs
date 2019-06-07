using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Makao
{
    public partial class Instrukcja : UserControl
    {
        public Instrukcja()
        {
            InitializeComponent();
        }

        #region Events
        public event Action<Gra> StartGame;
        public event Action<Instrukcja> LoadInstruction;
        public event Action<Powitalna> LoadWelcome;
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Powitalna p1 = new Powitalna();
            if (LoadWelcome != null)
                LoadWelcome(p1);
        }
    }
}
