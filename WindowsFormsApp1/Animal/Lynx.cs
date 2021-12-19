using System;

namespace WindowsFormsApp1
{
    public class Lynx:CarnivoresAnimal
    {
        public Lynx(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            satietly = 250;
            max_satietly = 250;
            _freeMover = new NearBirthFreeMover(_birthPoint);
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
                satietly = 250;
                _hibernationForm = HibernationForm.Sleep;
            }
        }

        protected override CarnivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            return new Lynx(x, y, _map, rnd, land);
        }
    }
}