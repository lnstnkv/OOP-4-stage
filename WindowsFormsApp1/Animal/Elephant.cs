using System;

namespace WindowsFormsApp1
{
    public class Elephant:HerbivoresAnimal
    {
        public Elephant(int x, int y, Map map, Random rnd) : base(x, y, map, rnd)
        {
            satietly = 150;
            _freeMover = new ProbabilityFreeMover();
            _targetMover = new TargetMoverSavingDirection();
        }
    }
}