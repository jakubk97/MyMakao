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
            powitalna1.LoadInstruction += Powitalna1_LoadInstruction;
            powitalna1.LoadWelcome += Powitalna1_LoadWelcome;
        }

        private void Powitalna1_LoadWelcome(Powitalna p1)
        {
            this.Controls.Remove(powitalna1);
            this.Controls.Add(p1);
        }

        private void Powitalna1_LoadInstruction(Instrukcja i1)
        {
            this.Controls.Remove(powitalna1);
            this.Controls.Add(i1);
        }


        #region Events
        public event Action<Gra> StartGame;
        public event Action<Instrukcja> LoadInstruction;
        public event Action<Powitalna> LoadWelcome;
        #endregion
    }
}
