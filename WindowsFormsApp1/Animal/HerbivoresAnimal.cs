using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class HerbivoresAnimal : Animal
    {
        public HerbivoresAnimalForm _herbAnimalForm;

        public HerbivoresAnimal(int x, int y, Map map, Random rnd, Land[,] land) : base(x, y, map, rnd, land)
        {
            health = 10;
         
        }

        protected abstract HerbivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land);
       // protected abstract void Propagate(Random x);
        protected override void FindDifferentEat(Random x)
        {
            if (_plant == null)
            {
                _plant = _map.FindPlant(this.GetPoint());
            }

            if (_plant != null)
            {
                FindWay(_plant.GetPoint());
            }
        }

        protected override void Propagate(Random x)
        {
            _map.AddAnimal(NewAnimal(coordinat.X, coordinat.Y, _map, x, _land));
        }

     
        protected void FindWay(Point coords)
        {
            coordinat = _targetMover.TargetMove(coordinat, _plant.GetPoint());
            FindEat();
            if (coords.X == coordinat.X && coords.Y == coordinat.Y)
            {
                Eat();
            }
        }

        protected override void ChangeEat(Point coords)
        {
            _plant = null;
        }

        protected void FindEat()
        {
            var coordinate = new Point(coordinat.X, coordinat.Y);
            var eat = _map.IsFood(coordinate);
            if (eat != null)
            {
                Eat();
            }
        }

        protected void Eat()
        {
            if (_plant.IsVirulence())
            {
                Die();
                _plant.Die();
            }
            else
            {
                satietly += 5;
                _plant.Die();
            }
        }
    }
}