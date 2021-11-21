using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Stand:FreeMover
    {
        public override Point Move(Point coordinate, Random x)
        {
            return coordinate;
        }
    }
}