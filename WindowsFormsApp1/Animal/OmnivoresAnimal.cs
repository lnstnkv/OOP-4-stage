using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class OmnivoresAnimal : HerbivoresAnimal
    {
        private const int MaximumHealth = 5;
        private const int AdditionSatiety = 5;
        
        protected override void FindFood(Random x)
        {
            base.FindFood(x);
            
            
            if (_animal == null)
            {
                _animal = _map.FindAnimal(this.GetPoint());
                FindAnimal();
            }
        }

        protected override void Propagate(Random x)
        {
            _map.AddAnimal(NewAnimal(Coordinate.X, Coordinate.Y, _map, x, _land));

        }


        private void FindAnimal()
        {
            Coordinate = TargetMover.TargetMove(Coordinate, _animal.GetPoint());
            FindEat();
        }

      
        protected void Eat(Animal eat, Random x)
        {
            if (eat is OmnivoresAnimal)
            {
                FindFood(x);
            }
            else
            {
                Satiety += AdditionSatiety;
                eat.Die();
            }
        }


        protected OmnivoresAnimal(int x, int y, Map map, Random random,Land[,] land) : base(x, y, map, random,land)
        {
            Health = MaximumHealth;
            
        }
    }
}
