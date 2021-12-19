using System;

namespace WindowsFormsApp1
{
    public class Elephant:HerbivoresAnimal
    {
        public Elephant(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            satietly = 150;
            max_satietly = 150;
            _freeMover = new ProbabilityFreeMover();
            _targetMover = new TargetMoverSavingDirection();
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            return new Elephant(x, y, _map, rnd, land);
        }
    }
}