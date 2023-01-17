using System;

namespace WindowsFormsApp1
{
    public class Elephant:HerbivoresAnimal
    {
        public Elephant(int x, int y, Map map, Random random,Land[,] land) : base(x, y, map, random,land)
        {
            Satiety = 150;
            MaxSatiety = 150;
            FreeMover = new ProbabilityFreeMover();
            TargetMover = new TargetMoverSavingDirection();
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land)
        {
            return new Elephant(x, y, _map, random, land);
        }
    }
}