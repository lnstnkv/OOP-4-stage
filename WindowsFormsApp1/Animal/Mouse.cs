using System;

namespace WindowsFormsApp1
{
    public class Mouse:OmnivoresAnimal
    {
        public Mouse(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            satietly = 300;
            max_satietly =300;
            _freeMover = new ProbabilityFreeMover();
            _targetMover = new TargetMoverEucliden();
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            return new Mouse(x, y, _map, rnd, land);
        }
    }
}