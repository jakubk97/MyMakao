using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private PictureBox[,] PicsBacks = null;
        //private Cards kartaNaSrodku;
        private int MustColor, MustNumber;
        List<Player> PlaList;
        List<PictureBox> OnTableList;
        Player p1, p2;
        //List<Point> punkty;

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
                        Pics[numer, color] = WczytajKarte(numer, color, x, y, pan, Properties.Resources.cards, null);
                        x += dx;
                    }
                    y += dy;
                }

                Pics[NumRanks, NumSuits - 1] = WczytajKarte(NumRanks + 1, NumSuits, 0, 0, pan, Properties.Resources.back, null);
                PicsBacks = new PictureBox[NumRanks, NumSuits];
                for (int color = 0; color < NumSuits; color++)
                {
                    for (int numer = 0; numer < NumRanks; numer++)
                    {
                        //PicsBacks[numer, color] = Pics[NumRanks, NumSuits - 1];
                        PicsBacks[numer, color] = WczytajKarte(NumRanks + 1, NumSuits, 0, 0, pan, Properties.Resources.back, null);
                    }
                }
                OnTableList = new List<PictureBox>();
                pan.Visible = true;
                RzucPierwsza(pan);
                //pan.Paint += Pan_Paint;
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

        public PictureBox WczytajKarte(int number, int color, int x, int y, Panel pan, Image image, Player player)
        {
            PictureBox pic = new PictureBox();
            Bitmap bm = LoadCardImage(number, color, x, y, image);
            pic.Image = bm;
            pic.SizeMode = PictureBoxSizeMode.AutoSize;
            pic.BorderStyle = BorderStyle.Fixed3D;
            pic.Parent = pan;
            if (number != 14)
            {
                pic.DoubleClick += Pic_DoubleClick;
            }
            else
            {
                pic.DoubleClick += Pic_DoubleClick;
                pic.Enabled = false;
            }
            pic.Tag = new Cards(number, color, bm, player);
            pic.Visible = false;
            return pic;
        }

        private void Pic_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Panel pan = ((Control)sender).Parent.Parent.Parent.Controls.Find("panel1", true)[0] as Panel;
                PictureBox pic = sender as PictureBox;
                Button bt = pan.Parent.Parent.Parent.Controls.Find("BT_Stop", true)[0] as Button;
                Cards card = pic.Tag as Cards;
                Kolory Color = (Kolory)card.Color1;
                Figury Number = (Figury)card.Number1;
                Form myForm = pan.FindForm();
                Player player = null;
                if (card.Player == p1)
                    player = p2;
                else
                    player = p1;


                if (OnTableList.Count > 0)
                {
                    Cards karta = OnTableList.Last().Tag as Cards;

                    if (MustColor == card.Color1 || MustNumber == card.Number1 || card.Number1 == 11)
                    {
                        myForm.Text = "";
                        bt.Visible = false;
                        karta.OnTable1 = false;
                        OnTableList.Clear();
                        OnTableList.Add(Pics[card.Number1, card.Color1]);
                        MustColor = card.Color1;
                        MustNumber = card.Number1;
                        Pics[card.Number1, card.Color1].BringToFront();
                        Pics[card.Number1, card.Color1].Location = new Point(pic.Parent.Width / 2, pic.Parent.Height / 2);
                        p1.RemoveCard(card);
                        if (card.Number1 == 0 || card.Number1 == 1 || card.Number1 == 2
                            || card.Number1 == 3 || card.Number1 == 10
                            || (card.Number1 == 12 && card.Color1 == 0) || (card.Number1 == 12 && card.Color1 == 3))
                        {
                            SprawdzSpecjalne(card.Number1, card.Color1, pan, player);
                        }
                        if (player == p1)
                            UstawKartyGracza(pan, player);
                        else
                            UstawKartyKomputera(pan, player);

                        ZagranieKomputera(pan);
                    }

                }
                else
                {
                    RozpocznijGre(((Control)sender).Parent.Parent.Parent.Controls.Find("panel1", true)[0] as Panel);
                }



                if (p1.CardsList().Count == 0)
                {
                    pan.Visible = false;
                    bt = pan.Parent.Parent.Parent.Controls.Find("BT_End", true)[0] as Button;
                    pan.Controls.Clear();
                    pan.Controls.Add(bt);
                    bt.Text = "Wygrana!";
                    bt.Visible = true;
                    pan.Visible = true;
                }
                else if(p2.CardsList().Count == 0)
                {
                    pan.Visible = false;
                    bt = pan.Parent.Parent.Parent.Controls.Find("BT_End", true)[0] as Button;
                    pan.Controls.Clear();
                    pan.Controls.Add(bt);
                    bt.Text = "Przegrana!";
                    bt.Visible = true;
                    pan.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Błąd");
            }
        }

        public void ZagranieKomputera(Panel pan)
        {
            int i = 1;
            if (p2.CardsList().Count == 0)
            {
                Button bt = pan.Parent.Parent.Parent.Controls.Find("BT_Stop", true)[0] as Button;
                pan.Visible = false;
                bt = pan.Parent.Parent.Parent.Controls.Find("BT_End", true)[0] as Button;
                bt.Text = "Przegrana!";
                pan.Controls.Clear();
                pan.Controls.Add(bt);
                bt.Visible = true;
                pan.Visible = true;
            }
            foreach (var karty in p2.CardsList())
            {
                Cards karta = OnTableList.Last().Tag as Cards;
                if (karty.Number1 == MustNumber && karty.Color1 == MustColor)
                {
                    karta.OnTable1 = false;
                    OnTableList.Clear();
                    OnTableList.Add(Pics[karty.Number1, karty.Color1]);
                    MustColor = karty.Color1;
                    MustNumber = karty.Number1;
                    Pics[karty.Number1, karty.Color1].BringToFront();
                    Pics[karty.Number1, karty.Color1].Location = new Point(pan.Width / 2, pan.Height / 2);
                    Pics[karty.Number1, karty.Color1].Visible = true;
                    PicsBacks[karty.Number1, karty.Color1].Visible = false;
                    Pics[MustNumber, MustColor].Visible = true;
                    p2.RemoveCard(karty);
                    if (karty.Number1 == 0 || karty.Number1 == 1 || karty.Number1 == 2
                        || karty.Number1 == 3 || karty.Number1 == 10
                        || (karty.Number1 == 12 && karty.Color1 == 0) || (karty.Number1 == 12 && karty.Color1 == 3))
                    {
                        SprawdzSpecjalne(karty.Number1, karty.Color1, pan, p1);
                    }
                    UstawKartyGracza(pan, p1);
                    UstawKartyKomputera(pan, p2);
                    return;
                }
                else if (MustColor == 4 && MustNumber == 3)
                {
                    Cards k = OnTableList.Last().Tag as Cards;
                    MustColor = k.Color1;
                    MustNumber = k.Number1;
                    UstawKartyGracza(pan, p1);
                    UstawKartyKomputera(pan, p2);
                    return;
                }
                else if (karty.Color1 == MustColor)
                {
                    karta.OnTable1 = false;
                    OnTableList.Clear();
                    OnTableList.Add(Pics[karty.Number1, karty.Color1]);
                    MustColor = karty.Color1;
                    MustNumber = karty.Number1;
                    Pics[karty.Number1, karty.Color1].BringToFront();
                    Pics[karty.Number1, karty.Color1].Location = new Point(pan.Width / 2, pan.Height / 2);
                    Pics[karty.Number1, karty.Color1].Visible = true;
                    PicsBacks[karty.Number1, karty.Color1].Visible = false;
                    Pics[MustNumber, MustColor].Visible = true;
                    p2.RemoveCard(karty);
                    if (karty.Number1 == 0 || karty.Number1 == 1 || karty.Number1 == 2
                        || karty.Number1 == 3 || karty.Number1 == 10
                        || (karty.Number1 == 12 && karty.Color1 == 0) || (karty.Number1 == 12 && karty.Color1 == 3))
                    {
                        SprawdzSpecjalne(karty.Number1, karty.Color1, pan, p1);
                    }
                    UstawKartyGracza(pan, p1);
                    UstawKartyKomputera(pan, p2);
                    return;
                }
                else if (karty.Number1 == MustNumber)
                {
                    karta.OnTable1 = false;
                    OnTableList.Clear();
                    OnTableList.Add(Pics[karty.Number1, karty.Color1]);
                    MustColor = karty.Color1;
                    MustNumber = karty.Number1;
                    Pics[karty.Number1, karty.Color1].BringToFront();
                    Pics[karty.Number1, karty.Color1].Location = new Point(pan.Width / 2, pan.Height / 2);
                    Pics[karty.Number1, karty.Color1].Visible = true;
                    PicsBacks[karty.Number1, karty.Color1].Visible = false;
                    Pics[MustNumber, MustColor].Visible = true;
                    p2.RemoveCard(karty);
                    if (karty.Number1 == 0 || karty.Number1 == 1 || karty.Number1 == 2
                        || karty.Number1 == 3 || karty.Number1 == 10
                        || (karty.Number1 == 12 && karty.Color1 == 0) || (karty.Number1 == 12 && karty.Color1 == 3))
                    {
                        SprawdzSpecjalne(karty.Number1, karty.Color1, pan, p1);
                    }
                    UstawKartyGracza(pan, p1);
                    UstawKartyKomputera(pan, p2);
                    return;
                }
                else if (karty.Number1 == 11)
                {
                    karta.OnTable1 = false;
                    OnTableList.Clear();
                    OnTableList.Add(Pics[karty.Number1, karty.Color1]);
                    MustColor = karty.Color1;
                    MustNumber = karty.Number1;
                    Pics[karty.Number1, karty.Color1].BringToFront();
                    Pics[karty.Number1, karty.Color1].Location = new Point(pan.Width / 2, pan.Height / 2);
                    Pics[karty.Number1, karty.Color1].Visible = true;
                    PicsBacks[karty.Number1, karty.Color1].Visible = false;
                    Pics[MustNumber, MustColor].Visible = true;
                    p2.RemoveCard(karty);
                    if (karty.Number1 == 0 || karty.Number1 == 1 || karty.Number1 == 2
                        || karty.Number1 == 3 || karty.Number1 == 10
                        || (karty.Number1 == 12 && karty.Color1 == 0) || (karty.Number1 == 12 && karty.Color1 == 3))
                    {
                        SprawdzSpecjalne(karty.Number1, karty.Color1, pan, p1);
                    }
                    UstawKartyGracza(pan, p1);
                    UstawKartyKomputera(pan, p2);
                    return;
                }
                else if (i == p2.CardsList().Count)
                {
                    PullCardForPlayer(pan, p2, 1);
                    return;
                }
                i++;
            }
        }
        public void SprawdzSpecjalne(int number, int color, Panel pan, Player player)
        {
            if (number == 0)//AS
            {
                if (player == p2)
                {
                    MessageBoxManager.Yes = "Kier";
                    MessageBoxManager.No = "Karo";
                    MessageBoxManager.Cancel = "Inny";
                    MessageBoxManager.Register();

                    DialogResult dialogResult = MessageBox.Show("Jaki kolor chcesz wybrać?", "Wybierz kolor", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MustColor = 0;
                        Form myForm = pan.FindForm();
                        myForm.Text = "Wymagany kolor to kier!";
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MustColor = 1;
                        Form myForm = pan.FindForm();
                        myForm.Text = "Wymagany kolor to karo!";
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        MessageBoxManager.Unregister();
                        MessageBoxManager.Yes = "Trefl";
                        MessageBoxManager.No = "Pik";
                        MessageBoxManager.Register();
                        DialogResult dialogResult2 = MessageBox.Show("Jaki kolor chcesz wybrać?", "Wybierz kolor", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            MustColor = 2;
                            Form myForm = pan.FindForm();
                            myForm.Text = "Wymagany kolor to trefl!";
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MustColor = 3;
                            Form myForm = pan.FindForm();
                            myForm.Text = "Wymagany kolor to "+ (Kolory)MustColor;
                        }
                    }
                    MessageBoxManager.Unregister();
                }
                else
                {
                    Random r = new Random(DateTime.Now.Millisecond);
                    MustColor = r.Next(0, 3);
                    Form myForm = pan.FindForm();
                    myForm.Text = "Wymagany kolor to pik!";
                }
            }
            else if (number == 1)//2
            {
                PullCardForPlayer(pan, player, 2);
            }
            else if (number == 2)//3
            {
                PullCardForPlayer(pan, player, 3);
            }
            else if (number == 3)//4
            {
                MustNumber = 3;
                MustColor = 4;
                if (player == p1)
                {
                    Form myForm = pan.FindForm();
                    myForm.Text = "Rzucasz 4 albo stoisz kolejkę!";
                    Button bt = pan.Parent.Parent.Parent.Controls.Find("BT_Stop", true)[0] as Button;
                    bt.Visible = true;
                }
                else
                {
                    MustNumber = 3;
                    MustColor = 2;
                }
            }
            else if (number == 10)//J
            {
                if (player == p2)
                {
                    MessageBoxManager.Yes = "5";
                    MessageBoxManager.No = "6";
                    MessageBoxManager.Cancel = "Inny";
                    MessageBoxManager.Register();

                    DialogResult dialogResult = MessageBox.Show("Jaką figurę chcesz wybrać?", "Wybierz figurę", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MustNumber = 4;
                        MustColor = 4;
                        Form myForm = pan.FindForm();
                        myForm.Text = "Wymagana karta to 5!";
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MustNumber = 5;
                        MustColor = 4;
                        Form myForm = pan.FindForm();
                        myForm.Text = "Wymagana karta to 6!";
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        MessageBoxManager.Unregister();
                        MessageBoxManager.Yes = "7";
                        MessageBoxManager.No = "8";
                        MessageBoxManager.Register();
                        DialogResult dialogResult2 = MessageBox.Show("Jaką figurę chcesz wybrać?", "Wybierz figurę", MessageBoxButtons.YesNoCancel);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            MustNumber = 6;
                            MustColor = 4;
                            Form myForm = pan.FindForm();
                            myForm.Text = "Wymagana karta to 7!";
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            MustNumber = 7;
                            MustColor = 4;
                            Form myForm = pan.FindForm();
                            myForm.Text = "Wymagana karta to 8!";
                        }
                        else if (dialogResult2 == DialogResult.Cancel)
                        {
                            MessageBoxManager.Unregister();
                            MessageBoxManager.Yes = "9";
                            MessageBoxManager.No = "10";
                            MessageBoxManager.Cancel = "Brak";
                            MessageBoxManager.Register();
                            DialogResult dialogResult3 = MessageBox.Show("Jaką figurę chcesz wybrać?", "Wybierz figurę", MessageBoxButtons.YesNoCancel);
                            if (dialogResult3 == DialogResult.Yes)
                            {
                                MustNumber = 8;
                                MustColor = 4;
                                Form myForm = pan.FindForm();
                                myForm.Text = "Wymagana karta to 9!";
                            }
                            else if (dialogResult3 == DialogResult.No)
                            {
                                MustNumber = 9;
                                MustColor = 4;
                                Form myForm = pan.FindForm();
                                myForm.Text = "Wymagana karta to 10!";
                            }
                            else if (dialogResult == DialogResult.Cancel)
                            {

                            }
                        }
                    }
                    MessageBoxManager.Unregister();
                }
                else
                {
                    Random r = new Random(DateTime.Now.Millisecond);
                    MustNumber = r.Next(4, 9);
                    MustColor = 4;
                    Form myForm = pan.FindForm();
                    myForm.Text = "Wymagana karta to !" + (MustNumber + 1);
                }
            }
            else if (number == 12 && color == 0)//K
            {
                PullCardForPlayer(pan, player, 5);
            }
            else if (number == 12 && color == 3)//K
            {
                PullCardForPlayer(pan, player, 5);
            }
        }

        public void Stop(Panel pan)
        {
            Cards karta = OnTableList.Last().Tag as Cards;
            MustColor = karta.Color1;
            MustNumber = karta.Number1;
            Form myForm = pan.FindForm();
            myForm.Text = "";
            Button bt = pan.Parent.Parent.Parent.Controls.Find("BT_Stop", true)[0] as Button;
            bt.Visible = false;
            ZagranieKomputera(pan);
        }


        public void PullCard(Panel pan)
        {
            DodajKarte(pan, p1);
            UstawKartyGracza(pan, p1);
            if (MustColor == 4)
            {
                Cards karta = OnTableList.Last().Tag as Cards;
                MustColor = karta.Color1;
                Form myForm = pan.FindForm();
                myForm.Text = "";
            }
            ZagranieKomputera(pan);
        }

        public void PullCardForPlayer(Panel pan, Player player, int ile)
        {
            for (int i = 0; i < ile; i++)
            {
                DodajKarte(pan, player);
            }
            if (player == p1)
                UstawKartyGracza(pan, player);
            else
                UstawKartyKomputera(pan, player);

            if (MustColor == 4)
            {
                Cards karta = OnTableList.Last().Tag as Cards;
                MustColor = karta.Color1;
                Form myForm = pan.FindForm();
                myForm.Text = "";
            }
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
                        Cards karta = OnTableList.Last().Tag as Cards;
                        MustColor = karta.Color1;
                        MustNumber = karta.Number1;
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
                foreach (var karty in player.CardsList())
                {
                    int x = player.X1;
                    int y = player.Y1;
                    PicsBacks[karty.Number1, karty.Color1].Location = new Point(x0 + x - ((PicsBacks[karty.Number1, karty.Color1].Width / 2) * player.CardsList().Count), y);
                    PicsBacks[karty.Number1, karty.Color1].Visible = true;
                    if (player.CardsList().Count > 10 && player.CardsList().Count < 18)
                    {
                        x0 += PicsBacks[karty.Number1, karty.Color1].Width / 2;
                        player.X1 = pan.Width / 2 + (pan.Width / 4);
                    }
                    else if (player.CardsList().Count >= 18)
                    {
                        x0 += PicsBacks[karty.Number1, karty.Color1].Width / 2;
                        player.X1 = pan.Width / 2 + (pan.Width / 3) + 10;
                    }
                    else
                    {
                        x0 += PicsBacks[karty.Number1, karty.Color1].Width;
                        player.X1 = pan.Width / 2;
                    }
                }
            }
            catch (Exception ex)
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
                    int x = player.X1;
                    int y = player.Y1;
                    Pics[karty.Number1, karty.Color1].BringToFront();
                    Pics[karty.Number1, karty.Color1].Location = new Point(x0 + x - ((Pics[karty.Number1, karty.Color1].Width / 2) * player.CardsList().Count), y);
                    Pics[karty.Number1, karty.Color1].Visible = true;
                    if (player.CardsList().Count > 10 && player.CardsList().Count < 18)
                    {
                        x0 += Pics[karty.Number1, karty.Color1].Width / 2;
                        player.X1 = pan.Width / 2 + (pan.Width / 4);
                    }
                    else if (player.CardsList().Count >= 18)
                    {
                        x0 += Pics[karty.Number1, karty.Color1].Width / 2;
                        player.X1 = pan.Width / 2 + (pan.Width / 3) + 10;
                    }
                    else
                    {
                        x0 += Pics[karty.Number1, karty.Color1].Width + 3;
                        player.X1 = pan.Width / 2;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void RzucPierwsza(Panel pan)
        {
            try
            {
                bool dod = true;
                while (dod)
                {
                    Random rnd = new Random(DateTime.Now.Millisecond);
                    int a = rnd.Next(0, 12);
                    int b = rnd.Next(0, 3);
                    Cards karta = Pics[a, b].Tag as Cards;
                    if (karta.OnTable1 == false && (karta.Number1 != 0 && karta.Number1 != 1 && karta.Number1 != 2
                        && karta.Number1 != 3 && karta.Number1 != 10
                        || ((karta.Number1 == 12 && karta.Color1 != 0) || (karta.Number1 == 12 && karta.Color1 != 3))))
                    {
                        OnTableList.Add(Pics[a, b]);
                        Pics[a, b].BringToFront();
                        karta.OnTable1 = true;
                        Pics[a, b].Location = new Point(pan.Width / 2, pan.Height / 2);
                        Pics[a, b].Visible = true;
                        dod = false;
                    }
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
                    Cards karta = Pics[a, b].Tag as Cards;

                    if (karta.OnTable1 == false)
                    {
                        player.AddCard(Pics[a, b].Tag as Cards);
                        Pics[a, b].BringToFront();
                        karta.Player = player;
                        karta.OnTable1 = true;
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
