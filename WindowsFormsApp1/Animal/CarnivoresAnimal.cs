using System;
using System.Drawing;
using System.Linq.Expressions;

namespace WindowsFormsApp1
{
    public abstract class CarnivoresAnimal : Animal
    {
        private const int MaximumHealth = 5;
        private const int AdditionSatiety = 5;

        protected abstract CarnivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land);

        protected override void FindFood(Random x)
        {
            if (_animal == null)
            {
                _animal = _map.FindAnimal(this.GetPoint());
                if (_animal is CarnivoresAnimal || _animal.IsSleep())
                {
                    _animal = null;
                }
            }

            if (_animal != null)
            {
                EatAnimal(_animal.GetPoint());
            }
        }

        protected override void Propagate(Random x)
        {
            _map.AddAnimal(NewAnimal(Coordinate.X, Coordinate.Y, _map, x, _land));
        }

        private void EatAnimal(Point coords)
        {
            Coordinate = TargetMover.TargetMove(Coordinate, _animal.GetPoint());

            if (coords.X == Coordinate.X && coords.Y == Coordinate.Y)
            {
                Eat();
            }
        }

        protected override void ChangeEat(Point coords)
        {
            _animal = null;
        }


        private void Eat()
        {
            if (_animal is CarnivoresAnimal)
            {
                _animal = null;
            }
            else
            {
                Satiety += AdditionSatiety;
                _animal.Die();
                _animal = null;
            }
        }


        protected CarnivoresAnimal(int x, int y, Map map, Random random, Land[,] land) : base(x, y, map, random, land)
        {
            Health = MaximumHealth;
        }
    }
}