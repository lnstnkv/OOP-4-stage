using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class OmnivoresAnimal : HerbivoresAnimal
    {
        private const int MaximumHealth = 5;
        private const int AdditionSatiety = 5;
        
        protected override void FindDifferentEat(Random x)
        {
            base.FindDifferentEat(x);
            
            
            if (_animal == null)
            {
                _animal = _map.FindAnimal(this.GetPoint());
                FindWay();
            }
        }

        protected override void Propagate(Random x)
        {
            _map.AddAnimal(NewAnimal(coordinat.X, coordinat.Y, _map, x, _land));

        }
        

        protected void FindWay()
        {
            coordinat = _targetMover.TargetMove(coordinat, _animal.GetPoint());
            FindEat();
        }

      
        protected void Eat(Animal eat, Random x)
        {
            if (eat is OmnivoresAnimal)
            {
                FindDifferentEat(x);
            }
            else
            {
                satietly += AdditionSatiety;
                eat.Die();
            }
        }


        public OmnivoresAnimal(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            health = MaximumHealth;
            
        }
    }
}
