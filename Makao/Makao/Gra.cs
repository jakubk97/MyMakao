﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Makao
{
    public partial class Gra : UserControl
    {
        public Gra()
        {
            InitializeComponent();
        }

        #region Events
        public event Action<Gra> StartGame;
        public event Action<Instrukcja> LoadInstruction;
        public event Action<Powitalna> LoadWelcome;

        #endregion

        #region Functions


        #endregion



    }
}
