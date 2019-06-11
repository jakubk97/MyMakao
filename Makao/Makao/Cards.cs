using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Makao
{
    class Cards
    {
        private int Color;
        private int Number;
        private Bitmap Picture;
        private bool OnTable;
        private Player player;

        public int Color1
        {
            get
            {
                return Color;
            }

            set
            {
                Color = value;
            }
        }

        public int Number1
        {
            get
            {
                return Number;
            }

            set
            {
                Number = value;
            }
        }

        public bool OnTable1
        {
            get
            {
                return OnTable;
            }

            set
            {
                OnTable = value;
            }
        }

        public Bitmap Picture1
        {
            get
            {
                return Picture;
            }

            set
            {
                Picture = value;
            }
        }

        internal Player Player
        {
            get
            {
                return player;
            }

            set
            {
                player = value;
            }
        }

        public Cards(int number, int color, Bitmap picture, Player player,bool ontable=false)
        {
            Number1 = number;
            Color1 = color;
            Picture1 = picture;
            OnTable1 = ontable;
            Player = player;
        }
    }
}
