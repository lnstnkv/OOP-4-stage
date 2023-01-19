using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class HerbivoresAnimal : Animal
    {
        private const int MaximumHealth = 10;
        private const int AdditionSatiety = 5;

        protected HerbivoresAnimal(int x, int y, Map map, Random random, Land[,] land) : base(x, y, map, random, land)
        {
            Health = MaximumHealth;
        }

        protected abstract HerbivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land);

        protected override void FindFood(Random x)
        {
            
            if (_plant == null)
            {
                _plant = _map.FindPlant(this.GetPoint());
            }

            if (_plant != null)
            {
                EatPlant(_plant.GetPoint());
            }
        }

        protected override void Propagate(Random x)
        {
            _map.AddAnimal(NewAnimal(Coordinate.X, Coordinate.Y, _map, x, _land));
        }

        private void EatPlant(Point coordinate)
        {
            Coordinate = TargetMover.TargetMove(Coordinate, _plant.GetPoint());
            FindEat();
            if (coordinate.X == Coordinate.X && coordinate.Y == Coordinate.Y)
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
            var coordinate = new Point(Coordinate.X, Coordinate.Y);
            var eat = _map.GetEdiblePlant(coordinate);
            if (eat != null)
            {
                Eat();
            }
        }

        private void Eat()
        {
            if (_plant._isVirulence)
            {
                Die();
                _plant.Die();
            }
            else
            {
                Satiety += AdditionSatiety;
                _plant.Die();
            }
        }
    }
}