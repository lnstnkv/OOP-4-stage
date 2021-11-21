using System;

namespace WindowsFormsApp1
{
    public class Owl:CarnivoresAnimal
    {
        public Owl(int x, int y, Map map, Random rnd) : base(x, y, map, rnd)
        {
            satietly = 200;
            _freeMover = new RandomFreeMover();
            _targetMover = new TargetMoverSavingDirection();
        }
    }
}