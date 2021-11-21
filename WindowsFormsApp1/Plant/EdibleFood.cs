using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class EdibleFood
    {
        public abstract Point FindEdibleFood(Point coordinate, Point coords);
    }
}