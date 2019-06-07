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




        #endregion

        #region Functions


        #endregion

        private void Gra_Load(object sender, EventArgs e)
        {
            if (LoadCards != null)
                LoadCards(panel1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(Properties.Resources.cards,new Point(0,0));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz wyjść z gry?", "Wyjście z gry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (LoadWelcome != null)
                    LoadWelcome();
            }
        }
    }
}
