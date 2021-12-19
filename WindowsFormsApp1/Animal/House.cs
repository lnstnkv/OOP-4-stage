using System.Drawing;

namespace WindowsFormsApp1
{
    public class House
    {
        protected Point coordinat;
        public House(int x, int y)
        {
            coordinat = new Point(x, y);
        }
        public Point GetPoint()
        {
            return coordinat;
        }
    }
}