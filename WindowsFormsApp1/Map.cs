using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

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
        private int _index = 0;
        private const int CountAnimal = 1500;
        private const int CountKindPlant = 700;
        private const int Size = 1000;
        private const int MinimumCoordinate = 0;
        private const int MaximumCoordinate = 1000;
        private const int CountKindOfAnimal = 9;

        private void AddAnimalForMap(Random random)
        {
            var result = CountAnimal / CountKindOfAnimal;
            Animal animal;
            for (var i = 0; i < CountKindOfAnimal; i++)
            {
                for (var j = 0; j < result; j++)
                {
                    var position = GetRandomPoint(random);
                    animal = MakeKindOfAnimal(i, random, new Point(position.X, position.Y));
                    _animals.Add(animal);
                    _land[position.X, position.Y].SetAnimal(_animals[i]);
                }
            }
        }

        private Animal MakeKindOfAnimal(int index, Random random, Point coordinate)
        {
            switch (index)
            {
                case 0:
                    return new Eagle(coordinate.X, coordinate.Y, this, random, _land);
                case 1:
                    return new Mouse(coordinate.X, coordinate.Y, this, random, _land);
                case 2:
                    return new Rabbit(coordinate.X, coordinate.Y, this, random, _land);
                case 3:
                    return new Elephant(coordinate.X, coordinate.Y, this, random, _land);
                case 4:
                    return new Lynx(coordinate.X, coordinate.Y, this, random, _land);
                case 5:
                    return new Pig(coordinate.X, coordinate.Y, this, random, _land);
                case 6:
                    return new Squirrel(coordinate.X, coordinate.Y, this, random, _land);
                case 7:
                    return new Owl(coordinate.X, coordinate.Y, this, random, _land);
                case 8:
                    return new Horse(coordinate.X, coordinate.Y, this, random, _land);
            }

            throw new Exception("Unknown animal");
        }

        public Map(Random random)
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

            AddAnimalForMap(random);
            for (int i = 1200; i < CountAnimal; i++)
            {
                var position = GetRandomPoint(random);

                if (i >= 1200 && i <= 1350)
                {
                    _animals.Add(new Male(position.X, position.Y, this, random, _land));
                    _land[position.X, position.Y].SetMale(_animals[i]);
                }

                if (i > 1350)
                {
                    _animals.Add(new Female(position.X, position.Y, this, random, _land));
                    _land[position.X, position.Y].SetFemale(_animals[i]);
                }
            }

            _plants = new List<Plant>();
            for (int i = 0; i < CountKindPlant; i++)
            {
                var position = GetRandomPoint(random);
                _plants.Add(new Plant(position.X, position.Y, this, i < 250, i > 50 && i < 400));
                _land[position.X, position.Y].SetPlant(_plants[i]);
            }

            _fruitingPlants = new List<FruitingPlant>();
            for (int i = 0; i < CountKindPlant; i++)
            {
                var position = GetRandomPoint(random);
                _fruitingPlants.Add(new FruitingPlant(position.X, position.Y, this, i < 100, i > 0));
                _land[position.X, position.Y].SetPlant(_fruitingPlants[i]);
            }

            _fruits = new List<Fruit>();
        }

        private Point GetRandomPoint(Random random)
        {
            var originalCoordinateX = random.Next(0, Size);
            var originalCoordinateY = random.Next(0, Size);
            return new Point(originalCoordinateX, originalCoordinateY);
        }

        public void BuildFactory(Random random)
        {
            for (int i = 0; i < 50; i++)
            {
                var position = GetRandomPoint(random);
                _factories.Add(new Factory(position.X, position.Y, this));
                _elves.Add(new Elf(position.X + 1, position.Y + 1, random, this));
                _land[position.X, position.Y].SetFactory(_factories[i]);
            }
        }

        private void DeleteFactory()
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

        public void Update(Random random)
        {
            List<Elf> elves = null;
            _index++;
            if (_index < 250)
            {
                isWinter = false;
                if (_index == 1)
                {
                    BuildFactory(random);
                }

                elves = GetElf();
            }
            else
            {
                isWinter = true;
                DeleteFactory();
            }

            if (elves != null)
                foreach (var elf in elves.ToList())
                {
                    elf.Update(random);
                }

            if (_index > 500)
            {
                _index = 0;
            }

            foreach (var animal in _animals.ToList().Where(animal => !animal.IsDied()))
            {
                animal.Update(random);
            }
        }

        public Plant FindPlant(Point coordinate)
        {
            var distance = 1;
            while (true)
            {
                for (var i = coordinate.X - distance; i <= coordinate.X + distance; i++)
                for (var j = coordinate.Y - distance; j <= coordinate.Y + distance; j++)
                    if (i > 0 && i <= 999 && j > 0 && j <= 999)
                        if (CheckForBeingWithinRadius(coordinate, i, j, distance))
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

        private bool GoOutsideFromMap(Point coordinate)
        {
            return coordinate.X < 0 || coordinate.X > 999 || coordinate.Y < 0 || coordinate.Y > 999;
        }

        public Animal FindAnimal(Point coordinate)
        {
            var radius = 1;
            if (GoOutsideFromMap(coordinate))
            {
                return null;
            }

            while (true)
            {
                for (var i = coordinate.X - radius; i <= coordinate.X + radius; i++)
                for (var j = coordinate.Y - radius; j <= coordinate.Y + radius; j++)
                    if (i > 0 && i <= 999 && j > 0 && j <= 999)
                        if (CheckForBeingWithinRadius(coordinate, i, j, radius))
                            if (_land[i, j].GetIsHere() == IsHere.Animal)
                            {
                                return _land[i, j].GetAnimal();
                            }


                radius += 1;
            }
        }

        private bool CheckForBeingWithinRadius(Point coordinate, int i, int j, int radius)
        {
            return Math.Abs(coordinate.X - i) + Math.Abs(coordinate.Y - j) == radius;
        }

        public Human FindHuman(Point coordinate)
        {
            int minDistance = Int32.MaxValue;
            Human ward = null;
            foreach (var animal in _animals)
            {
                var position = animal.GetPoint();

                if (GetMinDistance(coordinate, position, minDistance) && animal is Human)
                {
                    minDistance = SetMinDistance(coordinate, position);
                    ward = (Human) animal;
                }
            }

            return ward;
        }

        private bool GetMinDistance(Point coordinate, Point position, int minDistance)
        {
            return Math.Abs(coordinate.X - position.X) + Math.Abs(coordinate.Y - position.Y) < minDistance;
        }

        public Factory FindFactory(Point coordinate)
        {
            int minDistance = Int32.MaxValue;
            Factory factoryNear = null;
            foreach (var factory in _factories)
            {
                var position = factory.GetPoint();
                if (!GetMinDistance(coordinate, position, minDistance)) continue;
                minDistance = SetMinDistance(coordinate, position);
                factoryNear = factory;
            }

            return factoryNear;
        }

        public Animal FindCouple(Animal animalAlone)
        {
            var coordinate = animalAlone.GetPoint();
            if (GoOutsideFromMap(coordinate))
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
                    if (!GetMinDistance(coordinate, position, min) || animal.GetCouple() != null ||
                        !CheckSimilarity(animal, animalAlone)) continue;
                    min = SetMinDistance(coordinate, position);
                    animalCouple = animal;
                }
            }

            return animalCouple;
        }

        private int SetMinDistance(Point coordinate, Point position)
        {
            return Math.Abs(coordinate.X - position.X) + Math.Abs(coordinate.Y - position.Y);
        }

        private bool CheckSimilarity(Animal animal, Animal animalAlone)
        {
            return ((animal is Human && animalAlone is Human) ||
                    animal.GetType() == animalAlone.GetType());
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