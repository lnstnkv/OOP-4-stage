using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Human:OmnivoresAnimal
    {
        public Human(int x, int y, Map map, Random rnd) : base(x, y, map, rnd)
        {
            satietly = 300;
        }
    }
}