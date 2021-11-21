using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class NearBirthFreeMover:FreeMover
    {
        private Point _birthPoint;

        public NearBirthFreeMover(Point birthPoint)
        {
            _birthPoint = birthPoint;
        }

        public override Point Move(Point coordinate, Random x)
        {
            var shift = x.Next(-1, 2);
            if (GoOutside(coordinate.X + shift) && MoveAwayFromX((coordinate.X + shift),_birthPoint))
                coordinate.X += shift;
 
            shift = x.Next(-1, 2);
            if (GoOutside(coordinate.Y + shift) && MoveAwayFromY((coordinate.Y + shift),_birthPoint))
                coordinate.Y += shift;
            return coordinate;
        }

        private bool MoveAwayFromX(int x,Point birthPoint)
        {
            var n = 5;
            return (x >= birthPoint.X - n && x <= birthPoint.X + n);
        }

        private bool MoveAwayFromY(int y,Point birthPoint)
        {
            var n = 5;
            return (y >= birthPoint.Y - n && y <= birthPoint.Y + n);
        }
    }
}