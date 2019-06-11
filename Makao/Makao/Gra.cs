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
    public partial class Gra : UserControl
    {

        private static Gra instancja;

        public static Gra Instancja
        {
            get
            {
                if (instancja == null)
                    instancja = new Gra();
                return instancja;
            }
        }
        public Gra()
        {
            InitializeComponent();
        }


        #region Events
        public event Action StartGame;
        public event Action LoadInstruction;
        public event Action LoadWelcome;
        public event Action<Panel> LoadCards;
        public event Action<Panel> PullCard;
        public event Action<Panel> Stop;
        #endregion



        #region Functions

        private void Gra_Load(object sender, EventArgs e)
        {
            if (LoadCards != null)
                LoadCards(panel1);
        }

        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz wyjść z gry?", "Wyjście z gry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (LoadWelcome != null)
                    LoadWelcome();
            }
        }

        private void BT_Pull_Click_1(object sender, EventArgs e)
        {
            if (PullCard != null)
                PullCard(panel1);
        }

        private void BT_End_Click(object sender, EventArgs e)
        {
            if (LoadWelcome != null)
                LoadWelcome();
        }

        private void BT_Stop_Click(object sender, EventArgs e)
        {
            if (Stop != null)
                Stop(panel1);
        }
    }
}
