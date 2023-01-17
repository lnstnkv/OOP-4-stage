using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Map
    {
        private List<Animal> _animals;
        private List<Plant> _plants;
        private List<House> _houses;
        private List<Plant> _sproutsPlants;
        private List<Fruit> _sproutsFruits;
        private List<Human> _humans;
        private List<FruitingPlant> _fruitingPlants;
        private List<FruitingPlant> _sproutsFruitingPlants;
        private List<Fruit> _fruits;
        private Land[,] _land;
        private List<Factory> _factories;
        private List<Elf> _elves;
        public bool isWinter;
        private const int CountAnimal = 1500;
        private const int Size = 1000;
        private const int MinimumCoordinate = 0;
        private const int MaximumCoordinate = 1000;

        public Map(Random x)
        {
            _houses = new List<House>();
            _sproutsFruits = new List<Fruit>();
            _sproutsPlants = new List<Plant>();
            _factories = new List<Factory>();
            _elves = new List<Elf>();
            isWinter = false;
            _sproutsFruitingPlants = new List<FruitingPlant>();
            _animals = new List<Animal>();
            _humans = new List<Human>();
            _land = new Land[Size, Size];
            for (var i = 0; i < Size; i++)
            for (var j = 0; j < Size; j++)
            {
                _land[i, j] = new Land();
            }

            for (int i = 0; i < CountAnimal; i++)
            {
                var originalCoordinateX = x.Next(0, Size);
                var originalCoordinateY = x.Next(0, Size);

                if (i < 1200)
                {
                    if (i <= 400)
                    {
                        if (i <= 130)
                        {
                            _animals.Add(new Horse(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }

                        if (i > 130 && i <= 263)
                        {
                            _animals.Add(new Elephant(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }

                        if (i > 263 && i <= 400)
                        {
                            _animals.Add(new Rabbit(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }
                    }

                    if (i > 400)
                    {
                        if (i <= 530)
                        {
                            _animals.Add(new Eagle(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }

                        if (i > 530 && i <= 633)
                        {
                            _animals.Add(new Lynx(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }

                        if (i > 633 && i <= 800)
                        {
                            _animals.Add(new Owl(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }
                    }

                    if (i > 800)
                    {
                        if (i <= 930)
                        {
                            _animals.Add(new Squirrel(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }

                        if (i > 930 && i <= 1065)
                        {
                            _animals.Add(new Pig(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }

                        if (i > 1065 && i <= 1200)
                        {
                            _animals.Add(new Mouse(originalCoordinateX, originalCoordinateY, this, x, _land));
                        }
                    }

                    _land[originalCoordinateX, originalCoordinateY].SetAnimal(_animals[i]);
                }

                if (i >= 1200 && i <= 1350)
                {
                    _animals.Add(new Male(originalCoordinateX, originalCoordinateY, this, x, _land));
                    _land[originalCoordinateX, originalCoordinateY].SetMale(_animals[i]);
                }

                if (i > 1350)
                {
                    _animals.Add(new Female(originalCoordinateX, originalCoordinateY, this, x, _land));
                    _land[originalCoordinateX, originalCoordinateY].SetFemale(_animals[i]);
                }
            }

            int countPlant = 700;
            _plants = new List<Plant>();
            for (int i = 0; i < countPlant; i++)
            {
                var originalCoordinateX = x.Next(0, Size);
                var originalCoordinateY = x.Next(0, Size);
                _plants.Add(new Plant(originalCoordinateX, originalCoordinateY, this, i < 250, i > 50 && i < 400));
                _land[originalCoordinateX, originalCoordinateY].SetPlant(_plants[i]);
            }

            _fruitingPlants = new List<FruitingPlant>();
            for (int i = 0; i < countPlant; i++)
            {
                var originalCoordinateX = x.Next(0, Size);
                var originalCoordinateY = x.Next(0, Size);
                _fruitingPlants.Add(new FruitingPlant(originalCoordinateX, originalCoordinateY, this, i < 100, i > 0));
                _land[originalCoordinateX, originalCoordinateY].SetPlant(_fruitingPlants[i]);
            }

            _fruits = new List<Fruit>();
        }

        public void BuildFactory(Random x)
        {
            for (int i = 0; i < 50; i++)
            {
                var originalCoordinateX = x.Next(0, Size);
                var originalCoordinateY = x.Next(0, Size);
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

        public Animal GetAnimal(Point coordinate)
        {
            return _land[coordinate.X, coordinate.Y].GetAnimal();
        }

        public Plant GetPlant(Point coordinate)
        {
            return _land[coordinate.X, coordinate.Y].GetPlant();
        }


        public void AddPlant(Plant plant)
        {
            var position = plant.GetPoint();
            _land[position.X, position.Y].SetPlant(plant);
            if (plant is FruitingPlant)
            {
                _sproutsFruitingPlants.Add((FruitingPlant) plant);
            }
            else
            {
                _sproutsPlants.Add(plant);
            }
        }

        public void AddAnimal(Animal human)
        {
            var position = human.GetPoint();
            _land[position.X, position.Y].SetAnimal(human);
            _animals.Add(human);
        }

        public void AddHouse(House house)
        {
            var position = house.GetPoint();
            _land[position.X, position.Y].SetHouse();
            _houses.Add(house);
        }

        public int CountPlant()
        {
            return _plants.Count;
        }

        public void AddFruit(Fruit fruit)
        {
            var position = fruit.GetPoint();
            _land[position.X, position.Y].SetFruit(fruit);
            _sproutsFruits.Add(fruit);
        }

        public List<Animal> GetAnimal()
        {
            return _animals;
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
            return _houses;
        }

        public List<Plant> GetPlant()
        {
            return _plants;
        }

        public List<Fruit> GetFruits()
        {
            return _fruits;
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
                _plants.Remove(plant);
            }
        }

        public void DeleteAnimal(Animal animal)
        {
            var position = animal.GetPoint();
            _land[position.X, position.Y].DeleteAnimal();
            _animals.Remove(animal);
        }

        public void DeleteFruit(Fruit fruit)
        {
            var position = fruit.GetPoint();
            _land[position.X, position.Y].DeletePlant();
            _fruits.Remove(fruit);
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
            if (x + i >= MinimumCoordinate && x + i < MaximumCoordinate && y + j >= MinimumCoordinate &&
                y + j < MaximumCoordinate)
                return true;
            return false;
        }


        public void AddSprouts()
        {
            _plants.AddRange(_sproutsPlants);
            _fruitingPlants.AddRange(_sproutsFruitingPlants);
            _fruits.AddRange(_sproutsFruits);
            _sproutsFruits.Clear();
            _sproutsFruitingPlants.Clear();
            _sproutsPlants.Clear();
        }

        public Plant FindPlant(Point coordinate)
        {
            var distance = 1;
            while (true)
            {
                for (var i = coordinate.X - distance; i <= coordinate.X + distance; i++)
                for (var j = coordinate.Y - distance; j <= coordinate.Y + distance; j++)
                    if (i > 0 && i <= 999 && j > 0 && j <= 999)
                        if (Math.Abs(coordinate.X - i) + Math.Abs(coordinate.Y - j) == distance)
                            if (_land[i, j].GetIsHere() == IsHere.Plant)
                                if (_land[i, j].GetPlant()._isEat)
                                {
                                    var temp = _land[i, j].GetPlant();
                                    if (temp.IsIncrease())
                                        return _land[i, j].GetPlant();
                                }


                distance += 1;
            }
        }

        public Animal FindAnimal(Point coordinate)
        {
            var radius = 1;
            if (coordinate.X < 0 || coordinate.X > 999 || coordinate.Y < 0 || coordinate.Y > 999)
            {
                return null;
            }

            while (true)
            {
                for (var i = coordinate.X - radius; i <= coordinate.X + radius; i++)
                for (var j = coordinate.Y - radius; j <= coordinate.Y + radius; j++)
                    if (i > 0 && i <= 999 && j > 0 && j <= 999)
                        if (Math.Abs(coordinate.X - i) + Math.Abs(coordinate.Y - j) == radius)
                            if (_land[i, j].GetIsHere() == IsHere.Animal)
                            {
                                return _land[i, j].GetAnimal();
                            }


                radius += 1;
            }
        }

        public Human FindHuman(Point coords)
        {
            int minDistance = Int32.MaxValue;
            Human ward = null;
            foreach (var animal in _animals)
            {
                var position = animal.GetPoint();

                if (Math.Abs(coords.X - position.X) + Math.Abs(coords.Y - position.Y) < minDistance && animal is Human)
                {
                    minDistance = Math.Abs(coords.X - position.X) + Math.Abs(coords.Y - position.Y);
                    ward = (Human) animal;
                }
            }

            return ward;
        }

        public Factory FindFactory(Point coords)
        {
            int minDistance = Int32.MaxValue;
            Factory factoryNear = null;
            foreach (var factory in _factories)
            {
                var position = factory.GetPoint();

                if (Math.Abs(coords.X - position.X) + Math.Abs(coords.Y - position.Y) < minDistance)
                {
                    minDistance = Math.Abs(coords.X - position.X) + Math.Abs(coords.Y - position.Y);
                    factoryNear = factory;
                }
            }

            return factoryNear;
        }

        public Animal FindCouple(Animal animalAlone)
        {
            var coordinate = animalAlone.GetPoint();
            if (coordinate.X < 0 || coordinate.X > 999 || coordinate.Y < 0 || coordinate.Y > 999)
            {
                return null;
            }

            int min = Int32.MaxValue;
            Animal animalCouple = null;
            foreach (var animal in _animals)
            {
                var position = animal.GetPoint();
                if (animalAlone.IsMaleGender() == animal.IsMaleGender())
                {
                    continue;
                }
                else
                {
                    if (Math.Abs(coordinate.X - position.X) + Math.Abs(coordinate.Y - position.Y) < min &&
                        animal.GetCouple() == null && ((animal is Human && animalAlone is Human) ||
                                                       animal.GetType() == animalAlone.GetType()))
                    {
                        min = Math.Abs(coordinate.X - position.X) + Math.Abs(coordinate.Y - position.Y);
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


        public Plant GetEdiblePlant(Point position)
        {
            var tempPlant = _land[position.X, position.Y].GetPlant();
            if (tempPlant == null) return null;
            if (tempPlant._isEat && tempPlant.IsIncrease())
                return tempPlant;
            return null;
        }
    }
}