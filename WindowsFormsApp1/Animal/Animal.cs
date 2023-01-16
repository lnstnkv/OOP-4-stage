using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;

namespace WindowsFormsApp1
{
    public abstract class Animal
    {
        public int satietly;
        protected int age;
        protected int health;
        protected Land[,] _land;
        protected Point coordinat;
        protected Map _map;
        protected Animal _animal;
        public Plant _plant;
        private bool isDied;
        protected Gender _gender;
        public int max_satietly;
        protected Point _birthPoint;
        protected FreeMover _freeMover;
        protected Animal couple;
        protected TargetMover _targetMover;
        protected HibernationForm _hibernationForm;
        private const int ProbabilityMaleGender = 200;
        private const int AdditionParameter = 1;
        private const int ReductionParameter = 1;
        private const int ReductionSatiety = 30;
        private const int ReductionSatietyForSummer = 1;
        private const int ReductionSatietyForWinter = 2;
        private const int MinimalHealth = 0;
        private const int MaximumAgeForSummer = 200;
        private const int MaximumAgeForWinter = 20;
        private const double LowSatietyPercentageForSummer = 0.1;
        private const double MaxSatietyPercentageForSummer = 0.85;
        private const double AboveAverageSatietyPercentageForSummer = 0.8;
        private const double MediumSatietyPercentageForSummer = 0.75;
        private const double LowSatietyPercentageForWinter = 0.2;
        private const double MaxSatietyPercentageForWinter = 0.75;
        private const double MediumSatietyPercentageForWinter = 0.7;
        private const int LeftRangePercentage = 0;
        private const int IntRightRangePercentage = 500;


        public Animal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            coordinat = new Point(x, y);
            _map = map;
            couple = null;
            isDied = false;
            _plant = null;
            _hibernationForm = HibernationForm.Life;
            _birthPoint.X = coordinat.X;
            _birthPoint.Y = coordinat.Y;
            _land = land;
            _freeMover = new RandomFreeMover();
            _targetMover = new TargetMoverSavingDirection();
            isGender(rnd);
        }

        protected virtual void isGender(Random x)
        {
            var probability = x.Next(LeftRangePercentage, IntRightRangePercentage);
            if (probability > ProbabilityMaleGender)
            {
                _gender = Gender.Male;
            }

            else
            {
                _gender = Gender.Female;
            }
        }

        public Point GetPoint()
        {
            return coordinat;
        }


        public virtual void Loop(Random x)
        {
            Walk(x);
        }

        public bool IsSleep()
        {
            return _hibernationForm == HibernationForm.Sleep;
        }

        public String InfoCoordinate()
        {
            return coordinat.ToString();
        }

        public String InfoHealth()
        {
            return health.ToString();
        }

        public String InfoSatietly()
        {
            return satietly.ToString();
        }

        public String ClassAnimal()
        {
            switch (this)
            {
                case Horse _:
                    return "Horse";
                case Eagle _:
                    return "Eagle";
                case Rabbit _:
                    return "Rabbit";
                case Pig _:
                    return "Pig";
                case Squirrel _:
                    return "Squirrel";
                case Lynx _:
                    return "Lynx";
                case Elephant _:
                    return "Elephant";
                case Owl _:
                    return "Owl";
                case Mouse _:
                    return "Mouse";
                case Human _:
                    return "Human";
                default:
                    return "Привет!";
            }
        }

        protected abstract void FindDifferentEat(Random x);
        protected abstract void Propagate(Random x);
        protected abstract void ChangeEat(Point coords);

        public void Walk(Random x)
        {
            if (_map.isWinter)
            {
                IsSummer(x);
            }
            else
            {
                IsWinter(x);
            }
        }

        public void IsSummer(Random x)
        {
            satietly -= ReductionSatietyForSummer;
            if (satietly == max_satietly)
            {
                coordinat = _freeMover.Move(coordinat, x);
                age += AdditionParameter;
            }

            if (satietly > max_satietly * MaxSatietyPercentageForSummer)
            {
                if (couple == null)
                {
                    FindAnimalCouple();
                }

                if (couple != null)
                {
                    couple.SetCouple(this);
                    coordinat = _targetMover.TargetMove(coordinat, couple.GetPoint());
                }


                if (coordinat == couple?.GetPoint())
                {
                    //Propagate(x);
                    satietly -= ReductionSatiety;
                }
            }


            if (satietly > max_satietly * AboveAverageSatietyPercentageForSummer&& satietly < max_satietly * MaxSatietyPercentageForSummer)
            {
                coordinat = _freeMover.Move(coordinat, x);
            }

            if (health < MinimalHealth || age > MaximumAgeForSummer)
            {
                Die();
            }

            if (satietly < max_satietly * LowSatietyPercentageForSummer)
            {
                health -= ReductionParameter;
            }

            if (satietly < max_satietly * MediumSatietyPercentageForSummer)
            {
                FindDifferentEat(x);
            }
        }

        protected virtual void FindAnimalCouple()
        {
            couple = _map.FindCouple(this);
        }

        protected virtual void SetCouple(Animal animal)
        {
            couple = animal;
        }

        public Animal GetCouple()
        {
            return couple;
        }

        public void IsWinter(Random x)
        {
            satietly -= ReductionSatietyForWinter;
            if (satietly == max_satietly)
            {
                coordinat = _freeMover.Move(coordinat, x);
            }

            if (satietly > max_satietly * MediumSatietyPercentageForWinter)
            {
                coordinat = _freeMover.Move(coordinat, x);
            }

            if (health < MinimalHealth || age > MaximumAgeForWinter)
            {
                Die();
            }

            if (satietly < max_satietly * LowSatietyPercentageForWinter)
            {
                health -= ReductionParameter;
            }

            if (satietly < max_satietly * MaxSatietyPercentageForWinter)
            {
                FindDifferentEat(x);
            }
        }

        public Gender IsGender()
        {
            if (_gender == Gender.Female)
                return Gender.Female;
            return Gender.Male;
        }


        public bool IsMaleGender()
        {
            return _gender == Gender.Male;
        }

        public bool GoOutside(int x)
        {
            return x >= 0 && x < 1000;
        }

        public void Die()
        {
            isDied = true;
            _map.DeleteAnimal(this);
        }

        public bool IsDied()
        {
            return isDied;
        }
    }

    public enum Gender
    {
        Female,
        Male
    }
}