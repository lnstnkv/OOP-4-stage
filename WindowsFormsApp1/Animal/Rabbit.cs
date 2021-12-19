using System;

namespace WindowsFormsApp1
{
    public class Rabbit:HerbivoresAnimal
    {
       
        public Rabbit(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            satietly = 200;
            max_satietly = 200;
            _freeMover = new NearBirthFreeMover(_birthPoint);
            _targetMover = new TargetMoverSavingDirection();
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            return new Rabbit(x, y, _map, rnd, land);
        }
    }
}