using System;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public class Female : Human
    {
        public Female(int x, int y, Map map, Random random, Land[,] land) : base(x, y, map, random, land)
        {
            MaxSatiety = 300;
            Satiety = 300;
        }
        protected override void SetGender(Random random)
        {
            Gender = Gender.Female;
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land)
        {
            return new Female(x, y, _map, random, land);
        }
        
        
    }
}