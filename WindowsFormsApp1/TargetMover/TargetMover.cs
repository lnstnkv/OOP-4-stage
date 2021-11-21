using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class TargetMover
    {
        public abstract Point TargetMove(Point coordinate, Point coords);
       protected Point Move(Point shift,Point coordinat)
       {
            if (GoOutside(coordinat.X + shift.X))
                coordinat.X += shift.X;
            if (GoOutside(coordinat.Y + shift.Y))
                coordinat.Y += shift.Y;
            return coordinat;
        }
        
        protected bool GoOutside(int x)
        {
            return x >= 0 && x < 1000;
        }
    }
}