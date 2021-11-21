using System;

namespace WindowsFormsApp1
{
    public class Horse:HerbivoresAnimal
    {
        public Horse(int x, int y, Map map, Random rnd) : base(x, y, map, rnd)
        {
            satietly = 150;
            _freeMover = new RandomFreeMover();
            _targetMover = new TargetMoverEucliden();
            
        }
    }
}