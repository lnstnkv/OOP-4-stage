using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class OmnivoresAnimal : HerbivoresAnimal
    {
       
        protected override void FindDifferentEat(Random x)
        {
            base.FindDifferentEat(x);
            
            
            if (_animal == null)
            {
                _animal = _map.FindAnimal(this.GetPoint());
                FindWay();
            }
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
                satietly += 5;
                eat.Die();
            }
        }


        public OmnivoresAnimal(int x, int y, Map map, Random rnd) : base(x, y, map, rnd)
        {
            max_satietly = 250;
            satietly = 250;
            health = 5;
            
        }
    }
}
