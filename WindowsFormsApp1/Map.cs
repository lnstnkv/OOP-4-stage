using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Map
    {
        private List<Animal> animals;
        private List<Plant> plants;
        private List<Plant> sproutsPlants;
        private List<Fruit> sproutsFruits;
        private List<Human> _humans;
        private List<FruitingPlant> _fruitingPlants;
        private List<FruitingPlant> sproutsFruitingPlants;
        private List<Fruit> fruits;
        private Land[,] _land;
        public bool isWinter;

        public Map(Random x)
        {
            sproutsFruits = new List<Fruit>();
            sproutsPlants = new List<Plant>();
            isWinter = false;
            sproutsFruitingPlants = new List<FruitingPlant>();
            int countAnimal = 1400;
            animals = new List<Animal>();
            _humans = new List<Human>();
            _land = new Land[1000, 1000];
            for (var i = 0; i < 1000; i++)
            for (var j = 0; j < 1000; j++)
            {
                _land[i, j] = new Land();
            }

        
            for (int i = 0; i < countAnimal; i++)
            {
                var originalCoordinateX = x.Next(0, 1000);
                var originalCoordinateY = x.Next(0, 1000);
                if (i <= 400)
                {
                    if (i <= 130)
                    {
                        animals.Add(new Horse(originalCoordinateX, originalCoordinateY, this, x));
                    }


                    if (i > 130 && i <= 263)
                    {
                        animals.Add(new Elephant(originalCoordinateX, originalCoordinateY, this, x));
                    }

                    if (i > 263 && i <= 400)
                    {
                        animals.Add(new Rabbit(originalCoordinateX, originalCoordinateY, this, x));
                    }
                }

                if (i > 400)
                {
                    if (i <= 530)
                    {
                        animals.Add(new Eagle(originalCoordinateX, originalCoordinateY, this, x));
                    }

                    if (i > 530 && i <= 633)
                    {
                        animals.Add(new Lynx(originalCoordinateX, originalCoordinateY, this, x));
                    }

                    if (i > 633 && i <= 800)
                    {
                        animals.Add(new Owl(originalCoordinateX, originalCoordinateY, this, x));
                    }
                }

                if (i > 800)
                {
                    if (i <= 930)
                    {
                        animals.Add(new Squirrel(originalCoordinateX, originalCoordinateY, this, x));
                    }

                    if (i > 930 && i <= 1065)
                    {
                        animals.Add(new Pig(originalCoordinateX, originalCoordinateY, this, x));
                    }

                    if (i > 1065 && i <= 1200)
                    {
                        animals.Add(new Mouse(originalCoordinateX, originalCoordinateY, this, x));
                    }
                }

                if (i > 1200)
                {
                    animals.Add(new Human(originalCoordinateX, originalCoordinateY, this, x));
                }


                _land[originalCoordinateX, originalCoordinateY].SetAnimal(animals[i]);
            }

            int countHuman = 500;
            for (int i = 0; i < countHuman; i++)
            {
                var originalCoordinateX = x.Next(0, 1000);
                var originalCoordinateY = x.Next(0, 1000);
                _humans.Add(new Human(originalCoordinateX, originalCoordinateY, this, x));
                _land[originalCoordinateX, originalCoordinateY].SetHuman(_humans[i]);
            }

            int countPlant = 300;

            plants = new List<Plant>();
            for (int i = 0; i < countPlant; i++)
            {
                var originalCoordinateX = x.Next(0, 1000);
                var originalCoordinateY = x.Next(0, 1000);
                plants.Add(new Plant(originalCoordinateX, originalCoordinateY, this, i < 250, i > 50 && i < 400));
                _land[originalCoordinateX, originalCoordinateY].SetPlant(plants[i]);
            }


            _fruitingPlants = new List<FruitingPlant>();
            for (int i = 0; i < countPlant; i++)
            {
                var originalCoordinateX = x.Next(0, 1000);
                var originalCoordinateY = x.Next(0, 1000);
                _fruitingPlants.Add(new FruitingPlant(originalCoordinateX, originalCoordinateY, this, i < 100, i > 0));
                _land[originalCoordinateX, originalCoordinateY].SetPlant(_fruitingPlants[i]);
            }

            fruits = new List<Fruit>();
            
        }

        public void AddPlant(Plant plant)
        {
            var position = plant.GetPoint();
            _land[position.X, position.Y].SetPlant(plant);
            if (plant is FruitingPlant)
            {
                sproutsFruitingPlants.Add((FruitingPlant) plant);
            }
            else
            {
                sproutsPlants.Add(plant);
            }
        }

        public int countPlant()
        {
            return plants.Count;
        }
        /*    public bool IsSeason(Random x)
            {
                int probability = x.Next(0, 10000);
                if (probability % 2 != 0)
                {
                    isWinter = false;
                }
    
                return isWinter;
            }
            */

        public void AddFruit(Fruit fruit)
        {
            var position = fruit.GetPoint();
            _land[position.X, position.Y].SetFruit(fruit);
            sproutsFruits.Add(fruit);
        }

        public List<Animal> GetAnimal()
        {
            return animals;
        }

        public List<Plant> GetPlant()
        {
            return plants;
        }

        public List<Fruit> GetFruits()
        {
            return fruits;
        }

        public List<Human> GetHumans()
        {
            return _humans;
        }

        public List<FruitingPlant> GetFruitingPlants()
        {
            return _fruitingPlants;
        }

        public void DeletePlant(Plant plant)
        {
            var position = plant.GetPoint();
            _land[position.X, position.Y].DeletePlant();
            if (plant is FruitingPlant)
            {
                _fruitingPlants.Remove((FruitingPlant) plant);
            }
            else
            {
                plants.Remove(plant);
            }

            
        }

        public void DeleteAnimal(Animal animal)
         {
             var position = animal.GetPoint();
             _land[position.X, position.Y].DeleteAnimal();
             animals.Remove(animal);
         }
         


        public void DeleteFruit(Fruit fruit)
        {
            var position = fruit.GetPoint();
            _land[position.X, position.Y].DeletePlant();
            fruits.Remove(fruit);
        }

        public List<Point> FindNearbyLand(Point position)
        {
            var x = position.X;
            var y = position.Y;
            var nearLand = new List<Point>();
            for (var i = -1; i < 2; i++)
            for (var j = -1; j < 2; j++)
                if (GoOutside(i, j, x, y))
                    if (_land[x + i, x + i].IsEmpty())
                    {
                        nearLand.Add(new Point(x + i, y + j));
                    }

            return nearLand;
        }

        private bool GoOutside(int i, int j, int x, int y)
        {
            if (x + i >= 0 && x + i < 1000 && y + j >= 0 && y + j < 1000)
                return true;
            return false;
        }


        public void AddSprouts()
        {
            plants.AddRange(sproutsPlants);
            _fruitingPlants.AddRange(sproutsFruitingPlants);
            fruits.AddRange(sproutsFruits);
            sproutsFruits.Clear();
            sproutsFruitingPlants.Clear();
            sproutsPlants.Clear();
        }

        public Plant FindPlant(Point coor) // передавать точку 
        {
            // var coor = animal.GetPoint();
            var distance = 1;
            while (true)
            {
                for (var i = coor.X - distance; i <= coor.X + distance; i++)
                for (var j = coor.Y - distance; j <= coor.Y + distance; j++)
                    if (i > 0 && i <= 999 && j > 0 && j <= 999)
                        if (Math.Abs(coor.X - i) + Math.Abs(coor.Y - j) == distance)
                            if (_land[i, j].GetIsHere() == IsHere.Plant)
                                if (_land[i, j].IsPlantHere().IsEat())
                                {
                                    var temp = _land[i, j].IsPlantHere();
                                    if (temp.IsIncrease())
                                        return _land[i, j].IsPlantHere();
                                }


                distance += 1;
            }
        }

        public Animal FindAnimal(Point coor) // передавать точку 
        {
            // var coor = animal.GetPoint();
            /*  Animal temp = null;
              var min_distance = Double.MaxValue;
              foreach (var animals in animals)
              {
                  var coordinat = animals.GetPoint();
                  if (Math.Sqrt((coor.X - coordinat.X) + (coor.Y - coordinat.Y)) < min_distance && min_distance != 0)
                  {
                      min_distance = (Math.Sqrt((coor.X - coordinat.X) + (coor.Y - coordinat.Y)));
                      temp = animals;
                  }
              }
  
              return temp;*/
            var radius = 1;
            while (true)
            {
                for (var i = coor.X - radius; i <= coor.X + radius; i++)
                for (var j = coor.Y - radius; j <= coor.Y + radius; j++)
                    if (i > 0 && i <= 999 && j > 0 && j <= 999)
                        if (Math.Abs(coor.X - i) + Math.Abs(coor.Y - j) == radius)
                            if (_land[i, j].GetIsHere() == IsHere.Animal)
                            {
                                return _land[i, j].IsAnimalHere();
                            }


                radius += 1;
            }
        }

        public Plant IsFood(Point position)
        {
            var tempPlant = _land[position.X, position.Y].GetPlant();
            if (tempPlant == null) return null;
            if (tempPlant.IsEat() && tempPlant.IsIncrease())
                return tempPlant;
            return null;
        }
    }
}