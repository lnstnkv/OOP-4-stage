using System;

namespace WindowsFormsApp1
{
    public class Rabbit:HerbivoresAnimal
    {
       
        public Rabbit(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            Satiety = 200;
            MaxSatiety = 200;
            FreeMover = new NearBirthFreeMover(BirthPoint);
            TargetMover = new TargetMoverSavingDirection();
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land)
        {
            return new Rabbit(x, y, _map, random, land);
        }
    }
}