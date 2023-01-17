using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class TargetMoverEuclidean : TargetMover
    {
        private const int Shift = 1;
        public override Point TargetMove(Point startCoordinate, Point endCoordinate)
        {
            var differenceBetweenAxesX = endCoordinate.X - startCoordinate.X;
            var differenceBetweenAxesY = endCoordinate.Y - startCoordinate.Y;
            if (differenceBetweenAxesX == 0 && differenceBetweenAxesY == 0)
            {
                return Move(new Point(0, 0), startCoordinate);
            }

            if (differenceBetweenAxesX > 0)
            {
                var xShift = startCoordinate.X + Shift;
                if (differenceBetweenAxesY > 0)
                {
                    var yShift = startCoordinate.Y + Shift;
                    if (Math.Sqrt(Math.Pow(endCoordinate.X - xShift, 2) + Math.Pow(endCoordinate.Y - startCoordinate.Y, 2)) <
                        Math.Sqrt(Math.Pow(endCoordinate.Y - yShift, 2) + Math.Pow(endCoordinate.X - startCoordinate.X, 2)))
                    {
                        return Move(new Point(1, 0), startCoordinate);
                    }
                    else
                    {
                        return Move(new Point(0, 1), startCoordinate);
                    }
                }
                else
                {
                    var yShift = startCoordinate.Y - Shift;
                    if (Math.Sqrt(Math.Pow(endCoordinate.X - xShift, 2) + Math.Pow(endCoordinate.Y - startCoordinate.Y, 2)) <
                        Math.Sqrt(Math.Pow(endCoordinate.Y - yShift, 2) + Math.Pow(endCoordinate.X - startCoordinate.X, 2)))
                    {
                        return Move(new Point(1, 0), startCoordinate);
                    }
                    else
                    {
                        return Move(new Point(0, -1), startCoordinate);
                    }
                }
            }
            else
            {
                var xShift = startCoordinate.X - Shift;
                if (differenceBetweenAxesY > 0)
                {
                    var y = startCoordinate.Y + Shift;
                    if (Math.Sqrt(Math.Pow(endCoordinate.X - xShift, 2) + Math.Pow(endCoordinate.Y - startCoordinate.Y, 2)) <
                        Math.Sqrt(Math.Pow(endCoordinate.Y - y, 2) + Math.Pow(endCoordinate.X - startCoordinate.X, 2)))
                    {
                        return Move(new Point(-1, 0), startCoordinate);
                    }
                    else
                    {
                        return Move(new Point(0, 1), startCoordinate);
                    }
                }
                else
                {
                    var yShift = startCoordinate.Y - Shift;
                    if (Math.Sqrt(Math.Pow(endCoordinate.X - xShift, 2) + Math.Pow(endCoordinate.Y - startCoordinate.Y, 2)) <
                        Math.Sqrt(Math.Pow(endCoordinate.Y - yShift, 2) + Math.Pow(endCoordinate.X - startCoordinate.X, 2)))
                    {
                        return Move(new Point(-1, 0), startCoordinate);
                    }
                    else
                    {
                        return Move(new Point(0, -1), startCoordinate);
                    }
                }
            }
        }
    }
}