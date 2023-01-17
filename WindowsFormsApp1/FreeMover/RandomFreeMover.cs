﻿using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class RandomFreeMover:FreeMover
    {
        private const int LeftRangeShift = -1;
        private const int RightRangeShift = 2;
        public override Point Move(Point coordinate, Random x)
        {
            var shift = x.Next(LeftRangeShift, RightRangeShift); // рандомное движение с 
            if (GoOutside(coordinate.X + shift))
                coordinate.X += shift;
 
            shift = x.Next(LeftRangeShift, RightRangeShift);
            if (GoOutside(coordinate.Y + shift))
                coordinate.Y += shift;
            return coordinate;
        }
    }
}