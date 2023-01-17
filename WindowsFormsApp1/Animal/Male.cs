using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Male : Human
    {
        private List<House> _houses;
        private isVillage _village;
        private const int MinimumHouseNearby = 5;
        private const int MinimumHouse = 1;

        public Male(int x, int y, Map map, Random random, Land[,] land) : base(x, y, map, random, land)
        {
            _houses = new List<House>();
            MaxSatiety = 300;
            Satiety = 300;
            _village = isVillage.No;
        }

        protected override void SetGender(Random random)
        {
            Gender = Gender.Male;
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land)
        {
            return new Male(x, y, _map, random, land);
        }

        public List<House> SetHouses()
        {
            return _houses;
        }

        private void FindVillage()
        {
            List<Point> land;
            land = _map.FindNearHouse(Coordinate);
            if (land.Count > MinimumHouseNearby)
            {
                _village = isVillage.Yes;
            }
        }

        private void BuildHouse()
        {
            var house = new House(Coordinate.X, Coordinate.Y);
            _houses.Add(house);
            _map.AddHouse(house);
        }

        protected override void SetCouple(Animal animal)
        {
            base.SetCouple(animal);
            if (_houses.Count < MinimumHouse)
            {
                BuildHouse();
                FindVillage();
            }
        }

        protected override void FindCoupleForAnimal()
        {
            base.FindCoupleForAnimal();
            if (_houses.Count < MinimumHouse)
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