using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class Human : HerbivoresAnimal
    {
        public int capacity;
        public List<Tool> Tools;
        public Human(int x, int y, Map map, Random random,Land[,] land) : base(x, y, map, random,land)
        {
            capacity = 10;
            Tools = new List<Tool>();
        }
    }
}