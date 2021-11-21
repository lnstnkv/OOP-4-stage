using System;
using System.Drawing;
using System.Linq.Expressions;

namespace WindowsFormsApp1
{
    public class CarnivoresAnimal : Animal
    {
   
        protected override void FindDifferentEat(Random x)
        {
            if (_animal == null)
            {
                _animal = _map.FindAnimal(this.GetPoint());
                if (_animal is CarnivoresAnimal || _animal.IsSleep())
                {
                    _animal = null;
                    
                }
            }

            if (_animal != null )
            {
                
                FindWay(_animal.GetPoint());
                
            }

           
        }

        private void FindWay(Point coords)
        {
            coordinat = _targetMover.TargetMove(coordinat, _animal.GetPoint());

            if (coords.X == coordinat.X && coords.Y == coordinat.Y)
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
                satietly += 5;
                _animal.Die();
                _animal = null;
                
            }
        }


        public CarnivoresAnimal(int x, int y, Map map, Random rnd) : base(x, y, map, rnd)
        {
            max_satietly = 250;
            satietly = 250;
            health = 5;
        }
    }
}