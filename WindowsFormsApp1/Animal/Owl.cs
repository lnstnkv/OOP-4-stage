using System;

namespace WindowsFormsApp1
{
    public class Owl:CarnivoresAnimal
    {
        public Owl(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            satietly = 200;
            max_satietly = 200;
            _freeMover = new RandomFreeMover();
            _targetMover = new TargetMoverSavingDirection();
        }

        protected override CarnivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            return new Owl(x, y, _map, rnd, land);
        }
    }
}