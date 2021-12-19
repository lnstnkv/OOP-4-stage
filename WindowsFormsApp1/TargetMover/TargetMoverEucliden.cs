using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class TargetMoverEucliden : TargetMover
    {
        public override Point TargetMove(Point coordinate, Point coords)
        {
            var diffx = coords.X - coordinate.X;
            var diffy = coords.Y - coordinate.Y;
            if (diffx == 0 && diffy == 0)
            {
                return Move(new Point(0, 0), coordinate);
            }

            if (diffx > 0)
            {
                var x = coordinate.X + 1;
                if (diffy > 0)
                {
                    var y = coordinate.Y + 1;
                    if (Math.Sqrt(Math.Pow(coords.X - x, 2) + Math.Pow(coords.Y - coordinate.Y, 2)) <
                        Math.Sqrt(Math.Pow(coords.Y - y, 2) + Math.Pow(coords.X - coordinate.X, 2)))
                    {
                        return Move(new Point(1, 0), coordinate);
                    }
                    else
                    {
                        return Move(new Point(0, 1), coordinate);
                    }
                }
                else
                {
                    var y = coordinate.Y - 1;
                    if (Math.Sqrt(Math.Pow(coords.X - x, 2) + Math.Pow(coords.Y - coordinate.Y, 2)) <
                        Math.Sqrt(Math.Pow(coords.Y - y, 2) + Math.Pow(coords.X - coordinate.X, 2)))
                    {
                        return Move(new Point(1, 0), coordinate);
                    }
                    else
                    {
                        return Move(new Point(0, -1), coordinate);
                    }
                }
            }
            else
            {
                var x = coordinate.X - 1;
                if (diffy > 0)
                {
                    var y = coordinate.Y + 1;
                    if (Math.Sqrt(Math.Pow(coords.X - x, 2) + Math.Pow(coords.Y - coordinate.Y, 2)) <
                        Math.Sqrt(Math.Pow(coords.Y - y, 2) + Math.Pow(coords.X - coordinate.X, 2)))
                    {
                        return Move(new Point(-1, 0), coordinate);
                    }
                    else
                    {
                        return Move(new Point(0, 1), coordinate);
                    }
                }
                else
                {
                    var y = coordinate.Y - 1;
                    if (Math.Sqrt(Math.Pow(coords.X - x, 2) + Math.Pow(coords.Y - coordinate.Y, 2)) <
                        Math.Sqrt(Math.Pow(coords.Y - y, 2) + Math.Pow(coords.X - coordinate.X, 2)))
                    {
                        return Move(new Point(-1, 0), coordinate);
                    }
                    else
                    {
                        return Move(new Point(0, -1), coordinate);
                    }
                }
            }
        }
    }
}