using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Factory
    {
        private Point coordinat;
        private Map _map;
        private List<Gift> _gifts;
        public Factory( int x, int y, Map map)
        {
            coordinat = new Point(x, y);
            _map = map;
        }

        public Point GetPoint()
        {
            return coordinat;
        }
        public virtual void Start(Random x)
        {
          

        }
        
    }
}