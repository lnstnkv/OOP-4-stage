using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class TargetMover
    {
        public abstract Point TargetMove(Point startCoordinate, Point endCoordinate);

        protected Point Move(Point shift, Point startCoordinate)
        {
            if (GoOutside(startCoordinate.X + shift.X))
                startCoordinate.X += shift.X;
            if (GoOutside(startCoordinate.Y + shift.Y))
                startCoordinate.Y += shift.Y;
            return startCoordinate;
        }

        private bool GoOutside(int x)
        {
            return x >= 0 && x < 1000;
        }
    }
}