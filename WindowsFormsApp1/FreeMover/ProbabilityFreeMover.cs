using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class ProbabilityFreeMover : FreeMover
    {
        public override Point Move(Point coordinate, Random x)
        {
            var probability = Convert.ToDouble(x.Next(0, 100) / 100.0);
            if (probability > 0.7)
            {
                if (GoOutside(coordinate.X + 1))
                {
                    coordinate.X += 1;
                }

                if (GoOutside(coordinate.Y + 1))
                {
                    coordinate.Y += 1;
                }
            }
            else
            {
                if (GoOutside(coordinate.X - 1))
                {
                    coordinate.X -= 1;
                }

                if (GoOutside(coordinate.Y - 1))
                {
                    coordinate.Y -= 1;
                }
            }
            return coordinate;
        }
    }
}