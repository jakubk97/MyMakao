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

        private static Instrukcja instancja;

        public static Instrukcja Instancja
        {
            get
            {
                if (instancja == null)
                    instancja = new Instrukcja();
                return instancja;
            }
        }



        public Instrukcja()
        {
            InitializeComponent();
        }

        #region Events
        public event Action StartGame;
        public event Action LoadInstruction;
        public event Action LoadWelcome;


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoadWelcome != null)
                LoadWelcome();
        }


    }
}
