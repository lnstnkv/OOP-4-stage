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

        private Kind _form;
        public Fruit(int x, int y, Map map, bool isVirulence)
        {
            coordinatFruit = new Point(x, y);
            age = 0;
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

        public Kind IsKind()
        {
            if (age > 5)
            {
                _form = Kind.Flower;
            }

            if (age > 10)
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