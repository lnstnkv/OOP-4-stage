using System;

namespace WindowsFormsApp1
{
    public class Mouse:OmnivoresAnimal
    {
        public Mouse(int x, int y, Map map, Random rnd) : base(x, y, map, rnd)
        {
            satietly = 300;
            _freeMover = new ProbabilityFreeMover();
            _targetMover = new TargetMoverEucliden();
        }
    }
}