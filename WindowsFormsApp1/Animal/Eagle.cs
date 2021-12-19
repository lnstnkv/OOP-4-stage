using System;

namespace WindowsFormsApp1
{
    public class Eagle:CarnivoresAnimal
    {
        public Eagle(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            satietly = 140;
            max_satietly = 140;
            _freeMover = new ProbabilityFreeMover();
            _targetMover = new TargetMoverSavingDirection();
        }

        protected override CarnivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            return new Eagle(x, y, _map, rnd, land);
        }
    }
}