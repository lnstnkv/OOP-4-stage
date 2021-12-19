using System;

namespace WindowsFormsApp1
{
    public class Horse : HerbivoresAnimal
    {
        public Horse(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            satietly = 150;
            max_satietly = 150;
            _freeMover = new RandomFreeMover();
            _targetMover = new TargetMoverEucliden();
        }

        public override void Loop(Random x)
        {
            if (_map.isWinter)
            {
                Walk(x);
            }
            else
            {
                satietly = 150;
                _hibernationForm = HibernationForm.Sleep;
            }
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            return new Horse(x, y, _map, rnd, land);
        }
    }
}