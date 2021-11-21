using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class RandomFreeMover:FreeMover
    {
        public override Point Move(Point coordinate, Random x)
        {
            var shift = x.Next(-1, 2); // рандомное движение с 
            if (GoOutside(coordinate.X + shift))
                coordinate.X += shift;
 
            shift = x.Next(-1, 2);
            if (GoOutside(coordinate.Y + shift))
                coordinate.Y += shift;
            return coordinate;
        }
    }
}