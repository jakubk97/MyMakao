using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Makao
{
    class Karty
    {
        public int Number, Color;
        public Bitmap Picture;
        private bool OnTable;

        public Karty(int number, int color, Bitmap picture,bool ontable=false)
        {
            Number = number;
            Color = color;
            Picture = picture;
            OnTable = ontable;
        }
    }
}
