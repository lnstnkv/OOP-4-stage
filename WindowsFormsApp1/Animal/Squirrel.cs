using System;

namespace WindowsFormsApp1
{
    public class Squirrel:OmnivoresAnimal
    {
        public Squirrel(int x, int y, Map map, Random random,Land[,] land) : base(x, y, map, random,land)
        {
            Satiety = 250;
            MaxSatiety = 250;
            FreeMover = new NearBirthFreeMover(BirthPoint);
            TargetMover = new TargetMoverEuclidean();
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land)
        {
            return new Squirrel(x, y, _map, random, land);
        }
    }
}