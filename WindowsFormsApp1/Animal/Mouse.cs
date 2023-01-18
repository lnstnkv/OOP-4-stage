using System;

namespace WindowsFormsApp1
{
    public class Mouse:OmnivoresAnimal
    {
        public Mouse(int x, int y, Map map, Random random,Land[,] land) : base(x, y, map, random,land)
        {
            Satiety = 300;
            MaxSatiety =300;
            FreeMover = new ProbabilityFreeMover();
            TargetMover = new TargetMoverEuclidean();
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land)
        {
            return new Mouse(x, y, _map, random, land);
        }
    }
}