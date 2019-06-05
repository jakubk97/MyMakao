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
    public partial class Powitalna : UserControl
    {
        public Powitalna()
        {
            InitializeComponent();
        }

        #region Events
        public event Action StartGame;
        public event Action LoadInstruction;

        #endregion

        #region Functions
        private void BT_Graj_Click(object sender, EventArgs e)
        {
            if (StartGame != null)
                StartGame();
        }

        private void BT_Instrukcja_Click(object sender, EventArgs e)
        {
            if (LoadInstruction != null)
                LoadInstruction();
        }

        private void BT_Wyjdz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion



    }
}
