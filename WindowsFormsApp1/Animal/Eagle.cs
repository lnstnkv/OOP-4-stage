using System;

namespace WindowsFormsApp1
{
    public class Eagle:CarnivoresAnimal
    {
        public Eagle(int x, int y, Map map, Random random,Land[,] land) : base(x, y, map, random,land)
        {
            Satiety = 140;
            MaxSatiety = 140;
            FreeMover = new ProbabilityFreeMover();
            TargetMover = new TargetMoverSavingDirection();
        }

        protected override CarnivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land)
        {
            return new Eagle(x, y, _map, random, land);
        }
    }
}