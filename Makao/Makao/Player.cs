using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    class Player
    {
        List<Karty> karty;
        private int X, Y; //pozycja na planszy
        List<string> Players = new List<string>();
        private string Name;

        public Player(string name, int x, int y)
        {
            Players.Add(name);
            Name = name;
            X = x;
            Y = y;
            karty = new List<Karty>();
        }

        public List<string> PlayersList()
        {
            return Players;
        }
        public List<Karty> CardsList()
        {
            return karty;
        }
        public void AddCard(Karty karta)
        {
            karty.Add(karta);
        }

        public int X1()
        {
            return X;
        }

        public string Name1()
        {
            return Name;
        }

        public int Y1()
        {
            return Y;
        }

        public int RemoveCard(Karty karta)
        {
            karty.Remove(karta);
            return karty.Count;
        }

    }
}
