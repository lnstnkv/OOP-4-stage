using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class FreeMover
    {
        public abstract Point Move(Point coordinate, Random x);


        protected bool GoOutside(int x)
        {
            return x >= 0 && x < 1000;
        }
    }
}