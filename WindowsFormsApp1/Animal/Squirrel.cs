using System;

namespace WindowsFormsApp1
{
    public class Squirrel:OmnivoresAnimal
    {
        public Squirrel(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            satietly = 250;
            max_satietly = 250;
            _freeMover = new NearBirthFreeMover(_birthPoint);
            _targetMover = new TargetMoverEucliden();
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            return new Squirrel(x, y, _map, rnd, land);
        }
    }
}