using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;

namespace WindowsFormsApp1
{
    public abstract class Animal
    {
        public int Satiety;
        private int _age;
        protected int Health;
        protected Land[,] _land;
        protected Point Coordinate;
        protected Map _map;
        protected Animal _animal;
        public Plant _plant;
        private bool _isDied;
        protected Gender Gender;
        public int MaxSatiety;
        protected Point BirthPoint;
        protected FreeMover FreeMover;
        private Animal CoupleFoAnimal;
        protected TargetMover TargetMover;
        protected HibernationForm HibernationForm;
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
        private const int RightRangePercentage = 500;


        protected Animal(int x, int y, Map map, Random random, Land[,] land)
        {
            Coordinate = new Point(x, y);
            _map = map;
            CoupleFoAnimal = null;
            _isDied = false;
            _plant = null;
            HibernationForm = HibernationForm.Life;
            BirthPoint.X = Coordinate.X;
            BirthPoint.Y = Coordinate.Y;
            _land = land;
            FreeMover = new RandomFreeMover();
            TargetMover = new TargetMoverSavingDirection();
            SetGender(random);
        }

        protected virtual void SetGender(Random random)
        {
            var probability = random.Next(LeftRangePercentage, RightRangePercentage);
            if (probability > ProbabilityMaleGender)
            {
                Gender = Gender.Male;
            }

            else
            {
                Gender = Gender.Female;
            }
        }

        public Point GetPoint()
        {
            return Coordinate;
        }


        public virtual void Update(Random random)
        {
            SetLifecycle(random);
        }

        public bool IsSleep()
        {
            return HibernationForm == HibernationForm.Sleep;
        }

        public string GetCoordinateInformation()
        {
            return Coordinate.ToString();
        }

        public string GetHealthInformation()
        {
            return Health.ToString();
        }

        public string GetSatietyInformation()
        {
            return Satiety.ToString();
        }

        public string GetClassInformation()
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

        protected abstract void FindFood(Random x);
        protected abstract void Propagate(Random x);
        protected abstract void ChangeEat(Point coords);

        public void SetLifecycle(Random x)
        {
            if (_map.isWinter)
            {
                WalkInSummer(x);
            }
            else
            {
                WalkInWinter(x);
            }
        }

        private void WalkInSummer(Random random)
        {
            Satiety -= ReductionSatietyForSummer;
            if (Satiety == MaxSatiety)
            {
                Coordinate = FreeMover.Move(Coordinate, random);
                _age += AdditionParameter;
            }

            if (Satiety > MaxSatiety * MaxSatietyPercentageForSummer)
            {
                if (CoupleFoAnimal == null)
                {
                    FindCoupleForAnimal();
                }

                if (CoupleFoAnimal != null)
                {
                    CoupleFoAnimal.SetCouple(this);
                    Coordinate = TargetMover.TargetMove(Coordinate, CoupleFoAnimal.GetPoint());
                }


                if (Coordinate == CoupleFoAnimal?.GetPoint())
                {
                    Satiety -= ReductionSatiety;
                }
            }

            if (Satiety > MaxSatiety * AboveAverageSatietyPercentageForSummer &&
                Satiety < MaxSatiety * MaxSatietyPercentageForSummer)
            {
                Coordinate = FreeMover.Move(Coordinate, random);
            }

            MoveToNextLiveAction(MaximumAgeForSummer, LowSatietyPercentageForSummer, MediumSatietyPercentageForSummer,
                random);
        }

        private void MoveToNextLiveAction(int maximumAge, double lowSatietyPercentage, double percentage, Random random)
        {
            if (Health < MinimalHealth || _age > maximumAge)
            {
                Die();
            }

            if (Satiety < MaxSatiety * lowSatietyPercentage)
            {
                Health -= ReductionParameter;
            }

            if (Satiety < MaxSatiety * percentage)
            {
                FindFood(random);
            }
        }

        protected virtual void FindCoupleForAnimal()
        {
            CoupleFoAnimal = _map.FindCouple(this);
        }

        protected virtual void SetCouple(Animal animal)
        {
            CoupleFoAnimal = animal;
        }

        public Animal GetCouple()
        {
            return CoupleFoAnimal;
        }

        private void WalkInWinter(Random random)
        {
            Satiety -= ReductionSatietyForWinter;
            if (Satiety == MaxSatiety)
            {
                Coordinate = FreeMover.Move(Coordinate, random);
            }

            if (Satiety > MaxSatiety * MediumSatietyPercentageForWinter)
            {
                Coordinate = FreeMover.Move(Coordinate, random);
            }

            MoveToNextLiveAction(MaximumAgeForWinter, LowSatietyPercentageForWinter, MaxSatietyPercentageForWinter,
                random);
        }


        public Gender IsGender()
        {
            if (Gender == Gender.Female)
                return Gender.Female;
            return Gender.Male;
        }


        public bool IsMaleGender()
        {
            return Gender == Gender.Male;
        }

        public bool GoOutside(int x)
        {
            return x >= 0 && x < 1000;
        }

        public void Die()
        {
            _isDied = true;
            _map.DeleteAnimal(this);
        }

        public bool IsDied()
        {
            return _isDied;
        }
    }

    public enum Gender
    {
        Female,
        Male
    }
}