using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    class Player
    {
        List<Cards> karty;
        private int X, Y; //pozycja na planszy
        List<string> Players = new List<string>();
        private string Name;

        public int X1
        {
            get
            {
                return X;
            }

            set
            {
                X = value;
            }
        }

        public int Y1
        {
            get
            {
                return Y;
            }

            set
            {
                Y = value;
            }
        }

        public Player(string name, int x, int y)
        {
            Players.Add(name);
            Name = name;
            X1 = x;
            Y1 = y;
            karty = new List<Cards>();
        }

        public List<string> PlayersList()
        {
            return Players;
        }
        public List<Cards> CardsList()
        {
            return karty;
        }
        public void AddCard(Cards karta)
        {
            karty.Add(karta);
        }

        //public int X1()
        //{
        //    return X2;
        //}

        public string Name1()
        {
            return Name;
        }

        //public int Y1()
        //{
        //    return Y;
        //}

        public int RemoveCard(Cards karta)
        {
            karty.Remove(karta);
            return karty.Count;
        }

    }
}
