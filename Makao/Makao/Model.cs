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
        //private Karty kartaNaSrodku;
        List<Player> PlaList;
        Player p1, p2;
        List<Point> punkty;

        private enum Kolory
        {
            Kier, Karo, Trefl, Pik
        }
        private enum Figury
        {
            As, _2 = 1, _3 = 2, _4 = 3, _5 = 4, _6 = 5, _7 = 6, _8 = 7, _9 = 8, _10 = 9, J, D, K
        }

        #region Functions



        public void Tasowanie(Panel pan)
        {
            try
            {
                pan.Visible = false;
                CardWidth = Properties.Resources.cards.Width / NumRanks;
                CardHeight = Properties.Resources.cards.Height / NumSuits;
                int dx = CardWidth;
                int dy = CardHeight;
                Pics = new PictureBox[NumRanks + 1, NumSuits];
                int y = 0;
                for (int color = 0; color < NumSuits; color++)
                {
                    int x = 0;
                    for (int numer = 0; numer < NumRanks; numer++)
                    {
                        Pics[numer, color] = WczytajKarte(numer, color, x, y, pan, Properties.Resources.cards);
                        x += dx;
                    }
                    y += dy;
                }
                Pics[NumRanks, NumSuits - 1] = WczytajKarte(NumRanks + 1, NumSuits, 0, 0, pan, Properties.Resources.back);
                pan.Visible = true;
                pan.Paint += Pan_Paint;
            }
            catch (Exception)
            {
            }

        }

        public void DodajGraczy(int liczba, Panel pan)
        {
            PlaList = new List<Player>();
            for (int i = 0; i < liczba; i++)
            {
                if (i == 0)
                {
                    p1 = new Player("player1", pan.Width / 2, pan.Height - 110);
                    PlaList.Add(p1);
                }
                else if (i == 1)
                {
                    p2 = new Player("player2", pan.Width / 2, 0 + 10);
                    PlaList.Add(p2);
                }
            }
        }


        private void Pan_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in punkty)
            {
                Bitmap btm = new Bitmap(Properties.Resources.back);
                Graphics g = Graphics.FromImage(btm);
                e.Graphics.DrawImage(btm, item);
                btm.Dispose();
            }
        }

        public PictureBox WczytajKarte(int number, int color, int x, int y, Panel pan, Image image)
        {
            PictureBox pic = new PictureBox();
            Bitmap bm = LoadCardImage(number, color, x, y, image);
            pic.Image = bm;
            pic.SizeMode = PictureBoxSizeMode.AutoSize;
            pic.BorderStyle = BorderStyle.Fixed3D;
            pic.Parent = pan;
            pic.DoubleClick += Pic_DoubleClick;
            pic.Tag = new Karty(number, color, bm);
            pic.Visible = false;
            return pic;
        }

        private void Pic_DoubleClick(object sender, EventArgs e)
        {
            //sprawdzenie czy karta się nadaje
            //rzucenie karty +/ akcja
            //sprawdzenie wygranej

            PictureBox pic = sender as PictureBox;
            Karty card = pic.Tag as Karty;
            Kolory suit = (Kolory)card.Color;
            Figury rank = (Figury)card.Number;

            Pics[card.Number, card.Color].Location = new Point(pic.Parent.Width / 2, pic.Parent.Height / 2);
        }

        public void RozpocznijGre(Panel pan)
        {
            try
            {
                foreach (Player player in PlaList)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        DodajKarte(pan, player);
                    }
                    if (player.Name1() == "player1")
                    {
                        UstawKartyGracza(pan, player);
                    }
                    else
                    {
                        UstawKartyKomputera(pan, player);
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        public void UstawKartyKomputera(Panel pan, Player player)
        {
            try
            {
                int x0 = 0;
                punkty = new List<Point>();
                foreach (var karty in player.CardsList())
                {
                    int x = player.X1();
                    int y = player.Y1();
                    punkty.Add(new Point(x0 + x - ((Pics[karty.Number, karty.Color].Width / 2) * player.CardsList().Count), y));
                    x0 += Pics[karty.Number, karty.Color].Width + 5;
                }
            }
            catch (Exception)
            {
            }
        }
        public void UstawKartyGracza(Panel pan, Player player)
        {
            try
            {
                int x0 = 0;
                foreach (var karty in player.CardsList())
                {
                    int x = player.X1();
                    int y = player.Y1();
                    Pics[karty.Number, karty.Color].Location = new Point(x0 + x - ((Pics[karty.Number, karty.Color].Width / 2) * player.CardsList().Count), y);
                    Pics[karty.Number, karty.Color].Visible = true;
                    x0 += Pics[karty.Number, karty.Color].Width + 5;
                }
            }
            catch (Exception)
            {
            }
        }

        public void DodajKarte(Panel pan, Player player)
        {
            try
            {
                bool dod = true;
                while (dod)
                {
                    Random rnd = new Random(DateTime.Now.Millisecond);
                    int a = rnd.Next(0, 12);
                    int b = rnd.Next(0, 3);
                    Karty karta = Pics[a, b].Tag as Karty;

                    if (karta.OnTable == false)
                    {
                        player.AddCard(Pics[a, b].Tag as Karty);
                        karta.OnTable = true;
                        dod = false;
                    }
                }
            }
            catch (Exception)
            {

            }
        }


        private Bitmap LoadCardImage(int rank, int suit, int x, int y, Image image)
        {
            Bitmap bm = new Bitmap(CardWidth, CardHeight);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                Rectangle dest_rect = new Rectangle(0, 0, CardWidth, CardHeight);
                Rectangle src_rect = new Rectangle(x, y, CardWidth, CardHeight);
                gr.DrawImage(image, dest_rect, src_rect, GraphicsUnit.Pixel);
            }

            return bm;
        }

        #endregion
    }
}
