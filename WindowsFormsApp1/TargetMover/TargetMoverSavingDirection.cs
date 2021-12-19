using System.Drawing;

namespace WindowsFormsApp1
{
    public class TargetMoverSavingDirection : TargetMover
    {
        public override Point TargetMove(Point coordinate, Point coords)
        {
            var x = coords.X - coordinate.X;
            var y = coords.Y - coordinate.Y;
            if (x == 0 && y == 0)
            {
                return Move(new Point(0, 0), coordinate);
            }

            if (x == 0)
            {
                if (y > 0)
                    return Move(new Point(0, 1), coordinate);

                else
                    return Move(new Point(0, -1), coordinate);
            }
            else
            {
                if (x > 0)
                    return Move(new Point(1, 0), coordinate);
                else
                    return Move(new Point(-1, 0), coordinate);
            }
        }
    }
}