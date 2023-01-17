using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Fruit
    {
        private Point coordinatFruit;
        private int age;
        private Map _map;
        private bool _isVirulence;
        private List<FruitingPlant> _fruitingPlants;
        private const int FloweringAge = 5;
        private const int MatureAge = 10;
        private const int MinimumAge = 0;
        private Kind _form;
        public Fruit(int x, int y, Map map, bool isVirulence)
        {
            coordinatFruit = new Point(x, y);
            age = MinimumAge;
            _isVirulence = isVirulence;
            _form = Kind.Fetus;
            _map = map;
            _fruitingPlants = new List<FruitingPlant>();
        }

        public void Die()
        {
            _map.DeleteFruit(this);
        }
        public bool IsVirulence()
        {
            return _isVirulence;
        }


        public Point GetPoint()
        {
            return coordinatFruit;
        }

        public Kind GetKindPlant()
        {
            if (age > FloweringAge)
            {
                _form = Kind.Flower;
            }

            if (age > MatureAge)
            {
                _form = Kind.Mature;
            }

            age++;
            return _form;
        }
      
    }
    public enum Kind
             {
                 Fetus,
                 Flower,
                 Mature
             }
}