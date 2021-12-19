using System;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public class Female : Human
    {
        public Female(int x, int y, Map map, Random rnd, Land[,] land) : base(x, y, map, rnd, land)
        {
            max_satietly = 300;
            satietly = 300;
        }
        protected override void isGender(Random x)
        {
            _gender = Gender.Female;
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            return new Female(x, y, _map, rnd, land);
        }
        
        
    }
}