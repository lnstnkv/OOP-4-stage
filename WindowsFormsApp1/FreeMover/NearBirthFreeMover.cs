using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class NearBirthFreeMover : FreeMover
    {
        private Point _birthPoint;
        private const int LeftRangeShift = -1;
        private const int RightRangeShift = 2;
        private const int CellsNearBirthPoint = 5;

        public NearBirthFreeMover(Point birthPoint)
        {
            _birthPoint = birthPoint;
        }

        public override Point Move(Point coordinate, Random random)
        {
            var shift = random.Next(LeftRangeShift, RightRangeShift);
            if (GoOutside(coordinate.X + shift) && MoveAwayFromX((coordinate.X + shift), _birthPoint))
                coordinate.X += shift;

            shift = random.Next(LeftRangeShift, RightRangeShift);
            if (GoOutside(coordinate.Y + shift) && MoveAwayFromY((coordinate.Y + shift), _birthPoint))
                coordinate.Y += shift;
            return coordinate;
        }

        private bool MoveAwayFromX(int shiftCoordinate, Point birthPoint)
        {
            return (shiftCoordinate >= birthPoint.X - CellsNearBirthPoint && shiftCoordinate <= birthPoint.X + CellsNearBirthPoint);
        }

        private bool MoveAwayFromY(int shiftCoordinate, Point birthPoint)
        {
            return (shiftCoordinate >= birthPoint.Y - CellsNearBirthPoint && shiftCoordinate <= birthPoint.Y + CellsNearBirthPoint);
        }
    }
}