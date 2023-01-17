using System;

namespace WindowsFormsApp1
{
    public class Owl:CarnivoresAnimal
    {
        public Owl(int x, int y, Map map, Random random,Land[,] land) : base(x, y, map, random,land)
        {
            Satiety = 200;
            MaxSatiety = 200;
            FreeMover = new RandomFreeMover();
            TargetMover = new TargetMoverSavingDirection();
        }

        protected override CarnivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land)
        {
            return new Owl(x, y, _map, random, land);
        }
    }
}