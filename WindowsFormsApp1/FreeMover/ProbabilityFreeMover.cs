using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class ProbabilityFreeMover : FreeMover
    {
        private const int Shift = 1;
        private const double SatietyPercentage = 0.7;
        private const int LeftRangePercentage = 0;
        private const int IntRightRangePercentage = 100;
        private const double DoubleRightRangePercentage = 100.0;
        
        public override Point Move(Point coordinate, Random random)
        {
            var probability = Convert.ToDouble(random.Next(LeftRangePercentage, IntRightRangePercentage) / DoubleRightRangePercentage);
            if (probability >SatietyPercentage)
            {
                if (GoOutside(coordinate.X + Shift))
                {
                    coordinate.X += Shift;
                }

                if (GoOutside(coordinate.Y + Shift))
                {
                    coordinate.Y += Shift;
                }
            }
            else
            {
                if (GoOutside(coordinate.X - Shift))
                {
                    coordinate.X -= Shift;
                }

                if (GoOutside(coordinate.Y - Shift))
                {
                    coordinate.Y -= Shift;
                }
            }
            return coordinate;
        }
    }
}