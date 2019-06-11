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
        private Instrukcja i1;
        private Powitalna p1;
        private Gra g1;

        public Form1()
        {
            InitializeComponent();

            panel.Controls.Clear();

            p1 = new Powitalna();
            panel.Controls.Add(p1);

            p1.LoadInstruction += Powitalna1_LoadInstruction;
            p1.LoadWelcome += Powitalna1_LoadWelcome;
            p1.StartGame += Powitalna1_StartGame;
        }

        #region Events
        public event Action StartGame;
        public event Action LoadInstruction;
        public event Action LoadWelcome;
        public event Action<Panel> LoadCards;
        public event Action<Panel> PullCard;
        public event Action<Panel> Stop;
        #endregion


        private void G1_LoadCards(Panel pan)
        {
            if (LoadCards != null)
                LoadCards(pan);
        }

        private void G1_PullCard(Panel pan)
        {
            if (PullCard != null)
                PullCard(pan);
        }
        private void G1_Stop(Panel pan)
        {
            if (Stop != null)
                Stop(pan);
        }

        private void Powitalna1_StartGame()
        {
            panel.Controls.Clear();
            g1 = new Gra();
            g1.LoadWelcome += Powitalna1_LoadWelcome;
            g1.LoadCards += G1_LoadCards;
            g1.PullCard += G1_PullCard;
            g1.Stop += G1_Stop;
            panel.Controls.Add(g1);

            if (!panel.Controls.Contains(g1))
            {
                panel.Controls.Add(g1);
                g1.Dock = DockStyle.Fill;
                g1.BringToFront();
            }
            else
            {
                Gra.Instancja.BringToFront();
            }
        }

     

        private void Powitalna1_LoadWelcome()
        {
            panel.Controls.Clear();
            panel.Controls.Add(p1);
            if (!panel.Controls.Contains(p1))
            {
                panel.Controls.Add(p1);
                Powitalna.Instancja.Dock = DockStyle.Fill;
                Powitalna.Instancja.BringToFront();
            }
            else
            {
                Powitalna.Instancja.BringToFront();
            }
        }

        private void Powitalna1_LoadInstruction()
        {
            i1 = new Instrukcja();
            panel.Controls.Add(i1);

            i1.LoadInstruction += Powitalna1_LoadInstruction;
            i1.LoadWelcome += Powitalna1_LoadWelcome;
            i1.StartGame += Powitalna1_StartGame;

            panel.Controls.Clear();
            panel.Controls.Add(i1);
            if (!panel.Controls.Contains(i1))
            {
                panel.Controls.Add(i1);
                Instrukcja.Instancja.Controls.Add(i1);
                Instrukcja.Instancja.Dock = DockStyle.Fill;
                Instrukcja.Instancja.BringToFront();
            }
            else
            {
                Instrukcja.Instancja.BringToFront();
            }
        }

    }
}
