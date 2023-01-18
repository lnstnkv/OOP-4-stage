using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class RandomFreeMover:FreeMover
    {
        private const int LeftRangeShift = -1;
        private const int RightRangeShift = 2;
        public override Point Move(Point coordinate, Random random)
        {
            var shift = random.Next(LeftRangeShift, RightRangeShift);
            if (GoOutside(coordinate.X + shift))
                coordinate.X += shift;
 
            shift = random.Next(LeftRangeShift, RightRangeShift);
            if (GoOutside(coordinate.Y + shift))
                coordinate.Y += shift;
            return coordinate;
        }
    }
}