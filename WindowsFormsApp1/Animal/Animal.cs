using System;
using System.Drawing;
using System.IO;

namespace WindowsFormsApp1
{
    public abstract class Animal
    {
        protected int satietly;
        private int age;
        protected int health;
        protected Point coordinat;
        protected Map _map;
        protected Animal _animal;
        protected Plant _plant;
        private bool isDied;
        protected Gender _gender;
        protected int max_satietly;
        protected Point _birthPoint;
        protected FreeMover _freeMover;
        protected TargetMover _targetMover;

        public Animal(int x, int y, Map map, Random rnd)
        {
            coordinat = new Point(x, y);
            _map = map;
            isDied = false;
            _plant = null;
            _gender = Gender.Female;
            _birthPoint.X = coordinat.X;
            _birthPoint.Y = coordinat.Y;
            _freeMover = new RandomFreeMover();
            _targetMover = new TargetMoverSavingDirection();
        }


        public Point GetPoint()
        {
            return coordinat;
        }

        public virtual void Loop(Random x)
        {
            Walk(x);
        }

        protected abstract void FindDifferentEat(Random x);
        protected abstract void ChangeEat(Point coords);

        //  protected abstract void FindEat(Point shift);
        //protected abstract void Wander(Random x);

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
            satietly -= 1;

            if (satietly > max_satietly * 0.8) //рандомное движение 
            {
                coordinat = _freeMover.Move(coordinat, x);
            }

            if (health < 0 || age > 20)
            {
                Die();
            }

            if (satietly < max_satietly * 0.1)
            {
                health -= 1;
            }

            if (satietly < max_satietly * 0.75)
            {
                FindDifferentEat(x);
            }
        }

        public void IsWinter(Random x)
        {
            satietly -= 2;

            if (satietly > max_satietly * 0.7) //рандомное движение 
            {
                coordinat = _freeMover.Move(coordinat, x);
            }

            if (health < 0 || age > 20)
            {
                Die();
            }

            if (satietly < max_satietly * 0.2)
            {
                health -= 1;
            }

            if (satietly < max_satietly * 0.75)
            {
                FindDifferentEat(x);
            }
        }

        public Enum IsGender()
        {
            if (_gender == Gender.Female)
                return Gender.Female;
            return Gender.Male;
        }


        public void IsMale()
        {
            _gender = Gender.Male;
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
            // _map.DeleteAnimal(this);
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