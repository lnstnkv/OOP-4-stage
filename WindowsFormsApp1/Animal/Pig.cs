using System;

namespace WindowsFormsApp1
{
    public class Pig:OmnivoresAnimal
    {
        public Pig(int x, int y, Map map, Random rnd) : base(x, y, map, rnd)
        {
            satietly = 245;
            _freeMover = new RandomFreeMover();
            _targetMover = new TargetMoverSavingDirection();
        }
        public override void Loop(Random x)
        {
            if (_map.isWinter)
            {
                Walk(x);
            }
            else
            {
                satietly = 245;
                _hibernationForm = HibernationForm.Sleep;
            }
        }
    }
}