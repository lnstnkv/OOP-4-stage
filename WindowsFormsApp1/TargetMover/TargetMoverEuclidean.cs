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
                    if(CalculateClosestDistance(startCoordinate,endCoordinate,xShift,yShift))
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
                    if (CalculateClosestDistance(startCoordinate,endCoordinate,xShift,yShift))
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
                    var yShift = startCoordinate.Y + Shift;
                    if (CalculateClosestDistance(startCoordinate,endCoordinate,xShift,yShift))
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
                    if (CalculateClosestDistance(startCoordinate,endCoordinate,xShift,yShift))
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

        private bool CalculateClosestDistance(Point startCoordinate, Point endCoordinate, int xShift, int yShift)
        {
            return Math.Sqrt(CalculateDistanceBetweenPoint(startCoordinate, endCoordinate, xShift)) <
                   Math.Sqrt(CalculateDistanceBetweenPoint(startCoordinate, endCoordinate, yShift));
        }

        private double CalculateDistanceBetweenPoint(Point startCoordinate, Point endCoordinate, int valueShift)
        {
            return Math.Pow(endCoordinate.X - valueShift, 2) + Math.Pow(endCoordinate.Y - startCoordinate.Y, 2);
        }
    }
}