using System.Drawing;

namespace WindowsFormsApp1
{
    public class House
    {
        protected Point coordinate;
        public House(int x, int y)
        {
            coordinate = new Point(x, y);
        }
        public Point GetPoint()
        {
            return coordinate;
        }
    }
}