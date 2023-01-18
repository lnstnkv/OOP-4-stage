using System.Drawing;

namespace WindowsFormsApp1
{
    public class TargetMoverSavingDirection : TargetMover
    {
        public override Point TargetMove(Point startCoordinate, Point endCoordinate)
        {
            var differenceBetweenAxesX = endCoordinate.X - startCoordinate.X;
            var differenceBetweenAxesY = endCoordinate.Y - startCoordinate.Y;
            if (differenceBetweenAxesX == 0 && differenceBetweenAxesY == 0)
            {
                return Move(new Point(0, 0), startCoordinate);
            }

            if (differenceBetweenAxesX == 0)
            {
                if (differenceBetweenAxesY > 0)
                    return Move(new Point(0, 1), startCoordinate);

                else
                    return Move(new Point(0, -1), startCoordinate);
            }
            else
            {
                if (differenceBetweenAxesX > 0)
                    return Move(new Point(1, 0), startCoordinate);
                else
                    return Move(new Point(-1, 0), startCoordinate);
            }
        }
    }
}