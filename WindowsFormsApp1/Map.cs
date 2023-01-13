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
        private List<House> houses;
        private List<Plant> sproutsPlants;
        private List<Fruit> sproutsFruits;
        private List<Human> _humans;
        private List<FruitingPlant> _fruitingPlants;
        private List<FruitingPlant> sproutsFruitingPlants;
        private List<Fruit> fruits;
        private Land[,] _land;
        private List<Factory> _factories;
        private List<Elf> _elves;
        public bool isWinter;

        public Map(Random x)
        {
            houses = new List<House>();
            sproutsFruits = new List<Fruit>();
            sproutsPlants = new List<Plant>();
            _factories = new List<Factory>();
            _elves = new List<Elf>();
            isWinter = false;
            sproutsFruitingPlants = new List<FruitingPlant>();
            int countAnimal = 1500;
            animals = new List<Animal>();
            _humans = new List<Human>();
            const int size = 1000;
            _land = new Land[size, size];
            for (var i = 0; i < size; i++)
            for (var j = 0; j < size; j++)
            {
                _land[i, j] = new Land();
            }


            for (int i = 0; i < countAnimal; i++)
            {
                var originalCoordinateX = x.Next(0, size);
                var originalCoordinateY = x.Next(0, size);

                if (i < 1200)
                {
                    if (i <= 400)
                    {
                        if (i <= 130)
                        {
                            animals.Add(new Horse(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }


                        if (i > 130 && i <= 263)
                        {
                            animals.Add(new Elephant(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }

                        if (i > 263 && i <= 400)
                        {
                            animals.Add(new Rabbit(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }
                    }

                    if (i > 400)
                    {
                        if (i <= 530)
                        {
                            animals.Add(new Eagle(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }

                        if (i > 530 && i <= 633)
                        {
                            animals.Add(new Lynx(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }

                        if (i > 633 && i <= 800)
                        {
                            animals.Add(new Owl(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }
                    }

                    if (i > 800)
                    {
                        if (i <= 930)
                        {
                            animals.Add(new Squirrel(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }

                        if (i > 930 && i <= 1065)
                        {
                            animals.Add(new Pig(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }

                        if (i > 1065 && i <= 1200)
                        {
                            animals.Add(new Mouse(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }
                    }

                    _land[originalCoordinateX, originalCoordinateY].SetAnimal(animals[i]);
                }


                if (i >= 1200 && i <= 1350)
                {
                    animals.Add(new Male(originalCoordinateX, originalCoordinateY, this, x, _land));
                    _land[originalCoordinateX, originalCoordinateY].SetMale(animals[i]);
                }

                if (i > 1350)
                {
                    animals.Add(new Female(originalCoordinateX, originalCoordinateY, this, x, _land));
                    _land[originalCoordinateX, originalCoordinateY].SetFemale(animals[i]);
                }
            }

            int countPlant = 700;

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

        public void BuildFactory(Random x)
        {
            for (int i = 0; i < 50; i++)
            {
                var originalCoordinateX = x.Next(0, 1000);
                var originalCoordinateY = x.Next(0, 1000);
                _factories.Add(new Factory(originalCoordinateX, originalCoordinateY, this));
                _elves.Add(new Elf(originalCoordinateX + 1, originalCoordinateY + 1, x, this));
                _land[originalCoordinateX, originalCoordinateY].SetFactory(_factories[i]);
            }
        }

        public void DeleteFactory()
        {
            _factories.Clear();
            DeleteElf();
        }

        private void DeleteElf()
        {
            _elves.Clear();
        }

        public Animal IsAnimal(Point coords)
        {
            return _land[coords.X, coords.Y].IsAnimalHere();
        }

        public Plant IsPlant(Point coords)
        {
            return _land[coords.X, coords.Y].IsPlantHere();
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

        public void AddAnimal(Animal human)
        {
            var position = human.GetPoint();
            _land[position.X, position.Y].SetAnimal(human);
            animals.Add(human);
        }

        public void AddHouse(House house)
        {
            var position = house.GetPoint();
            _land[position.X, position.Y].SetHouse();
            houses.Add(house);
        }

        public int countPlant()
        {
            return plants.Count;
        }

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

        public List<Factory> GetFactory()
        {
            return _factories;
        }

        public List<Elf> GetElf()
        {
            return _elves;
        }

        public List<House> GetHouse()
        {
            return houses;
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

        public Plant FindPlant(Point coor)
        {
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

        public Animal FindAnimal(Point coor)
        {
            var radius = 1;
            if (coor.X < 0 || coor.X > 999 || coor.Y < 0 || coor.Y > 999)
            {
                return null;
            }
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

        public Human FindHuman(Point coords)
        {
            int min = Int32.MaxValue;
            Human ward = null;
            foreach (var animal in animals)
            {
                var position = animal.GetPoint();

                if (Math.Abs(coords.X - position.X) + Math.Abs(coords.Y - position.Y) < min && animal is Human)
                {
                    min = Math.Abs(coords.X - position.X) + Math.Abs(coords.Y - position.Y);
                    ward = (Human) animal;
                }
            }

            return ward;
        }

        public Factory FindFactory(Point coords)
        {
            int min = Int32.MaxValue;
            Factory factoryNear = null;
            foreach (var factory in _factories)
            {
                var position = factory.GetPoint();

                if (Math.Abs(coords.X - position.X) + Math.Abs(coords.Y - position.Y) < min)
                {
                    min = Math.Abs(coords.X - position.X) + Math.Abs(coords.Y - position.Y);
                    factoryNear = factory;
                }
            }

            return factoryNear;
        }

        public Animal FindCouple(Animal animalAlone)
        {
            var coor = animalAlone.GetPoint();
            if (coor.X < 0 || coor.X > 999 || coor.Y < 0 || coor.Y > 999)
            {
                return null;
            }

            int min = Int32.MaxValue;
            Animal animalCouple = null;
            foreach (var animal in animals)
            {
                var position = animal.GetPoint();
                if (animalAlone.IsMaleGender() == animal.IsMaleGender())
                {
                    continue;
                }
                else
                {
                    if (Math.Abs(coor.X - position.X) + Math.Abs(coor.Y - position.Y) < min &&
                        animal.GetCouple() == null && ((animal is Human && animalAlone is Human) ||
                                                       animal.GetType() == animalAlone.GetType()))
                    {
                        min = Math.Abs(coor.X - position.X) + Math.Abs(coor.Y - position.Y);
                        animalCouple = animal;
                    }
                }
            }

            return animalCouple;
        }

        public List<Point> FindNearHouse(Point position)
        {
            var x = position.X;
            var y = position.Y;
            var nearLand = new List<Point>();
            for (var i = -1; i < 2; i++)
            for (var j = -1; j < 2; j++)
                if (GoOutside(i, j, x, y))
                    if (_land[x + i, x + i].GetIsHere() == IsHere.House)
                    {
                        nearLand.Add(new Point(x + i, y + j));
                    }

            return nearLand;
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