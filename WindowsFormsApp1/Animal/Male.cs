using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Male : Human
    {
        public List<House> _houses;
        private isVillage _village;

        public Male(int x, int y, Map map, Random rnd,Land[,] land) : base(x, y, map, rnd,land)
        {
            _houses = new List<House>();
            max_satietly = 300;
            satietly = 300;
            _village = isVillage.No;
        }

        protected override void isGender(Random x)
        {
            _gender = Gender.Male;
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random rnd, Land[,] land)
        {
            return new Male(x, y, _map, rnd, land);
        }

        public List<House> SetHouses()
        {
            return _houses;
        }

        public void FindVillage()
        {
            List<Point> land;
            land=_map.FindNearHouse(coordinat);
            if (land.Count > 5)
            {
                _village = isVillage.Yes;
            }
        }
        public void BuildHouse()
        {
            var house = new House(coordinat.X, coordinat.Y);
            _houses.Add(house);
            _map.AddHouse(house);
        }

        protected override void SetCouple(Animal animal)
        {
            base.SetCouple(animal);
            if (_houses.Count < 1)
            {
               BuildHouse();
               FindVillage();
            }
        }

        protected override void FindAnimalCouple()
        {
         base.FindAnimalCouple();
         if (_houses.Count < 1)
         {
            BuildHouse();
            FindVillage();
         }
        }
    }

    public enum isVillage
    {
        Yes,
        No
    }
}