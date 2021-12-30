using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class Human : HerbivoresAnimal
    {
        public int capacity;
        public List<Tool> _tools;
        public Human(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            capacity = 10;
            _tools = new List<Tool>();
        }
    }
}