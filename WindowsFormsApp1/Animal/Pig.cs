using System;

namespace WindowsFormsApp1
{
    public class Pig:OmnivoresAnimal
    {
        public Pig(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            satietly = 245;
            max_satietly = 245;
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

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            return new Pig(x, y, _map, rnd, land);
        }
    }
}