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
        public event Action<Gra> StartGame;
        public event Action<Instrukcja> LoadInstruction;
        public event Action<Powitalna> LoadWelcome;

        #endregion

        #region Functions
        private void BT_Graj_Click(object sender, EventArgs e)
        {
            Gra g1 = new Gra();
            if (StartGame != null)
                StartGame(g1);
        }

        private void BT_Instrukcja_Click(object sender, EventArgs e)
        {
            Instrukcja i1 = new Instrukcja();
            if (LoadInstruction != null)
                LoadInstruction(i1);
        }

        private void BT_Wyjdz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion



    }
}
