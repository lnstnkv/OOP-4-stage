using System;

namespace WindowsFormsApp1
{
    public class Eagle:CarnivoresAnimal
    {
        public Eagle(int x, int y, Map map, Random rnd) : base(x, y, map, rnd)
        {
            satietly = 140;
            _freeMover = new ProbabilityFreeMover();
            _targetMover = new TargetMoverSavingDirection();
        }
    }
}