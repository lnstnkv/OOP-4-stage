using System;
using System.Drawing;
using System.Linq.Expressions;

namespace WindowsFormsApp1
{
    public  abstract class CarnivoresAnimal : Animal
    {
   
        protected abstract CarnivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land);
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

        protected override void Propagate(Random x)
        {
            _map.AddAnimal(NewAnimal(coordinat.X, coordinat.Y, _map, x, _land));
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


        public CarnivoresAnimal(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            health = 5;
        }
    }
}