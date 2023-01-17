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
        protected bool isDied;
        protected Stage _stage;
        private const int MinimumAge = 0;
        private const int MaxAge = 15;
        private const int MediumAge = 10;
        private const int LandingAge = 5;
        private const int MaxValueProbability = 500;
        private const int MaxCountPlant = 800;

        public Plant(int x, int y, Map map, bool isVirulence, bool isEat)
        {
            coordinatPlant = new Point(x, y);
            _isVirulence = isVirulence;
            _isEat = isEat;
            isDied = false;
            _map = map;
            age = MinimumAge;
            _stage = Stage.Seed;
        }

        public String InfoCoordinate()
        {
            return coordinatPlant.ToString();
        }

        public String ClassPlant()
        {
            if (this is FruitingPlant)
            {
                if (this.IsVirulence())
                    return "Virulence Fruiting Plant";
                else
                {
                    return "Fruiting Plant";
                }
            }
            else
            {
                if (IsVirulence())
                    return "Virulence Plant";
                else
                {
                    return "Plant";
                }
            }
        }

        public bool IsEat()
        {
            return _isEat;
        }

        public bool IsVirulence()
        {
            return _isVirulence;
        }

        public bool IsDied()
        {
            return isDied;
        }

        public Point GetPoint()
        {
            return coordinatPlant;
        }

        public void Die()
        {
            isDied = true;
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
            if (!_map.isWinter) return;
            if (_map.countPlant() > MaxCountPlant) return;
            var probability = x.Next(MaxValueProbability);
            if (probability > 0) return;
            var land = _map.FindNearbyLand(coordinatPlant);
            var positionX = 0;
            var positionY = 0;
            if (land.Count > 0)
            {
                positionX = land[x.Next(land.Count)].X;
                positionY = land[x.Next(land.Count)].Y;
            }

            if (isDied == false)
            {
                _map.AddPlant(NewSproutsPlant(positionX, positionY, _map, _isVirulence, _isEat));
            }
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
            if (age > MaxAge)
            {
                _stage = Stage.Died;
                isDied = true;
            }

            if (age > LandingAge)
            {
                _stage = Stage.Sprout;
            }

            if (age > MediumAge)
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