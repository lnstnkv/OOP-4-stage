using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Plant
    {
        protected Point coordinatPlant;
        private int age;
        protected bool _isVirulence;
        protected bool _isEat;
        protected Map _map;
        protected Stage _stage;

        public Plant(int x, int y, Map map, bool isVirulence, bool isEat)
        {
            coordinatPlant = new Point(x, y);
            _isVirulence = isVirulence;
            _isEat = isEat;
            _map = map;
            age = 0;
            _stage = Stage.Seed;
        }

        public bool IsEat()
        {
            return _isEat;
        }

        public bool IsVirulence()
        {
            return _isVirulence;
        }

        public Point GetPoint()
        {
            return coordinatPlant;
        }

        public void Die()
        {
            _map.DeletePlant(this);
        }

        public virtual void Start(Random x)
        {
           
            if (_stage == Stage.Increase)
            {
                Grow(x);
            }

            IsStage();
        }

        public void Grow(Random x)
        {
            //if (!_map.isWinter) return;
            var probability = x.Next(100);
            if (probability > 0) return;
            var land = _map.FindNearbyLand(coordinatPlant);
            var positionX = 0;
            var positionY = 0;
            if (land.Count > 0)
            {
                positionX = land[x.Next(land.Count)].X;
                positionY = land[x.Next(land.Count)].Y;
            }

            _map.AddPlant(NewSproutsPlant(positionX, positionY, _map, _isVirulence, _isEat));
        }

        public virtual Plant NewSproutsPlant(int x, int y, Map map, bool _isVirulence, bool _isEat)
        {
            return new Plant(x, y, _map, _isVirulence, _isEat);
        }

        public bool IsIncrease()
        {
            if (_stage == Stage.Increase)
                return true;
            return false;
        }

        private Stage IsStage()
        {
            if (age > 15)
            {
                _stage = Stage.Died;
              //  Die();
            }

            if (age > 5)
            {
                _stage = Stage.Sprout;
            }

            if (age > 10)
            {
                _stage = Stage.Increase;
            }

            age++;
            return _stage;
        }
    }

    public enum Stage
    {
        Seed,
        Sprout,
        Increase,
        Died
    }
}