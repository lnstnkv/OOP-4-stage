using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Plant
    {
        private Point _coordinatePlant;
        private int _age;
        public bool _isVirulence { get; }
        public bool _isEat { get; }
        protected Map _map;
        private bool isDied;
        protected Stage Stage;
        protected string NameClass { get; set; }
        private const int MinimumAge = 0;
        private const int MaxAge = 15;
        private const int MediumAge = 10;
        private const int LandingAge = 5;
        private const int MaxValueProbability = 500;
        private const int MaxCountPlant = 800;

        public Plant(int x, int y, Map map, bool isVirulence, bool isEat)
        {
            _coordinatePlant = new Point(x, y);
            _isVirulence = isVirulence;
            _isEat = isEat;
            isDied = false;
            _map = map;
            _age = MinimumAge;
            Stage = Stage.Seed;
            NameClass = "Plant";
        }

        public string GetCoordinateInformation()
        {
            return _coordinatePlant.ToString();
        }

        public string GetClassInformation()
        {
            return _isVirulence ? "Virulence" + NameClass : NameClass;
        }

        public bool IsDied()
        {
            return isDied;
        }

        public Point GetPoint()
        {
            return _coordinatePlant;
        }

        public void Die()
        {
            isDied = true;
            _map.DeletePlant(this);
        }

        public virtual void Start(Random x)
        {
            if (Stage == Stage.Increase)
            {
                Grow(x);
            }

            SetStage();
        }

        private void Grow(Random random)
        {
            if (!_map.isWinter) return;
            if (_map.CountPlant() > MaxCountPlant) return;
            var probability = random.Next(MaxValueProbability);
            if (probability > 0) return;
            var land = _map.FindNearbyLand(_coordinatePlant);
            var positionX = 0;
            var positionY = 0;
            if (land.Count > 0)
            {
                positionX = land[random.Next(land.Count)].X;
                positionY = land[random.Next(land.Count)].Y;
            }

            if (isDied == false)
            {
                _map.AddPlant(NewSproutsPlant(positionX, positionY, _map, _isVirulence, _isEat));
            }
        }

        protected virtual Plant NewSproutsPlant(int x, int y, Map map, bool _isVirulence, bool _isEat)
        {
            return new Plant(x, y, _map, _isVirulence, _isEat);
        }

        public bool IsIncrease()
        {
            if (Stage == Stage.Increase)
                return true;
            return false;
        }

        private Stage SetStage()
        {
            if (_age > MaxAge)
            {
                Stage = Stage.Died;
                isDied = true;
            }

            if (_age > LandingAge)
            {
                Stage = Stage.Sprout;
            }

            if (_age > MediumAge)
            {
                Stage = Stage.Increase;
            }

            _age++;
            return Stage;
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