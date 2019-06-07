using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Makao
{
    class Model
    {
        private const int NumSuits = 4;
        private const int NumRanks = 13;
        private int CardWidth, CardHeight;
        private PictureBox[,] Pics = null;

        private enum Kolory
        {
            Kier, Karo, Trefl, Pik
        }
        private enum Figury
        {
            As, _2 = 1, _3 = 2, _4 = 3, _5 = 4, _6 = 5, _7 = 6, _8 = 7, _9 = 8, _10 = 9, J, D, K
        }

        #region Functions



        public void WczytajKarty(Panel pan)
        {
            pan.Visible = false;
            CardWidth = Properties.Resources.cards.Width / NumRanks;
            CardHeight = Properties.Resources.cards.Height / NumSuits;
            int dx = CardWidth;
            int dy = CardHeight;
            Pics = new PictureBox[NumRanks, NumSuits];
            int y = 0;
            for (int color = 0; color < NumSuits; color++)
            {
                int x = 0;
                for (int numer = 0; numer < NumRanks; numer++)
                {
                    Pics[numer, color] = WczytajKarte(numer, color, x, y, pan);
                    x += dx;
                }
                y += dy;
            }
            //for (int i = pan.Controls.Count-1; i >= 1; i--)
            //{
            //    pan.Controls.RemoveAt(i);
            //}
            pan.Visible = true;
            Tasowanie(pan);
        }

        public PictureBox WczytajKarte(int number, int color, int x, int y, Panel pan)
        {
            PictureBox pic = new PictureBox();
            Bitmap bm = LoadCardImage(number, color, x, y);
            pic.Image = bm;
            pic.SizeMode = PictureBoxSizeMode.AutoSize;
            pic.BorderStyle = BorderStyle.Fixed3D;
            pic.Parent = pan;
            pic.Click += Pic_Click;
            pic.Tag = new Karty(number, color, bm);
            pic.Visible = false;
            return pic;
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            //sprawdzenie czy karta się nadaje
            //rzucenie karty +/ akcja
            //sprawdzenie wygranej
            PictureBox pic = sender as PictureBox;
            Karty card = pic.Tag as Karty;
            Kolory suit = (Kolory)card.Color;
            Figury rank = (Figury)card.Number;
            MessageBox.Show(rank.ToString().Replace("_","") + " " + suit.ToString());

        }

        public void Tasowanie(Panel pan)
        {
            int x = pan.Width / 2;
            int y = pan.Height - Pics[0, 0].Height;
            Pics[0, 0].Location = new Point(x, y);
            x += Pics[0, 0].Width / 2;
            Pics[0, 1].Location = new Point(x, y);
            x += Pics[0, 0].Width / 2;
            Pics[0, 2].Location = new Point(x, y);
            Pics[0, 0].Visible = true;
        }


        private Bitmap LoadCardImage(int rank, int suit, int x, int y)
        {
            Bitmap bm = new Bitmap(CardWidth, CardHeight);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                Rectangle dest_rect = new Rectangle(0, 0, CardWidth, CardHeight);
                Rectangle src_rect = new Rectangle(x, y, CardWidth, CardHeight);
                gr.DrawImage(Properties.Resources.cards, dest_rect, src_rect, GraphicsUnit.Pixel);
            }

            return bm;
        }

        #endregion
    }
}
