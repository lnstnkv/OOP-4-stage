using System.Drawing;

namespace WindowsFormsApp1
{
    public class House
    {
        private Point coordinate;
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