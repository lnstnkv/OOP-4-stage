using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using NUnit.Framework;
using Moq;
using WindowsFormsApp1;

namespace TestProject1
{
    public class TestMap
    {
        private Map _map;
        private Random random;
        private Land[,] _land;
        private StartSimulation _startSimulation;

        [SetUp]
        public void Setup()
        {
            random = new Random();
            var sizeLand = 1000;
            _land = new Land[sizeLand, sizeLand];
            _map = new Map(random);
            Animal animal;

            for (var i = 0; i < sizeLand; i++)
            {
                for (var j = 0; j < sizeLand; j++)
                {
                    _land[i, j] = new Land();

                    animal = i switch
                    {
                        var index when (i % 10 == 1) => new Eagle(1, 2, _map, random, _land),
                        var index when (i % 10 == 2) => new Pig(2, 250, _map, random, _land),
                        var index when (i % 10 == 3) => new Horse(10, 10, _map, random, _land),
                        var index when (i % 10 == 4) => new Squirrel(100, 100, _map, random, _land),
                        var index when (i % 10 == 5) => new Mouse(50, 50, _map, random, _land),
                        var index when (i % 10 == 6) => new Lynx(250, 250, _map, random, _land),
                        var index when (i % 10 == 7) => new Owl(25, 35, _map, random, _land),
                        var index when (i % 10 == 8) => new Rabbit(80, 100, _map, random, _land),
                        var index when (i % 10 == 9) => new Elephant(500, 70, _map, random, _land),
                        _ => new Eagle(500, 500, _map, random, _land)
                    };
                    _land[i, j].SetAnimal(animal);
                }
            }

            Type typeMap = typeof(Map);
            FieldInfo landInfo = typeMap.GetField("_land", BindingFlags.Instance | BindingFlags.NonPublic);
            landInfo.SetValue(_map, _land);
        }

        // Класс хороших данных
        [Test]
        public void FindAnimal_NearEagle_ReturnEagle()
        {
            var expected = typeof(Eagle);

            var actual = _map.FindAnimal(new Point(1, 1));

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimal_NearOwl_ReturnOwl()
        {
            var expected = typeof(Owl);

            var actual = _map.FindAnimal(new Point(8, 2));

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimal_NearRabbit_ReturnRabbit()
        {
            var expected = typeof(Rabbit);

            var actual = _map.FindAnimal(new Point(9, 3));

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimal_NearSquirrel_ReturnSquirrel()
        {
            var expected = typeof(Squirrel);

            var actual = _map.FindAnimal(new Point(25, 25));

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimal_NearElephant_ReturnElephant()
        {
            var expected = typeof(Elephant);

            var actual = _map.FindAnimal(new Point(100, 100));

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimal_NearLynx_ReturnLynx()
        {
            var expected = typeof(Lynx);

            var actual = _map.FindAnimal(new Point(967, 215));

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimal_NearHorse_ReturnHorse()
        {
            var expected = typeof(Horse);

            var actual = _map.FindAnimal(new Point(4, 250));

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimal_NearMouse_ReturnMouse()
        {
            var expected = typeof(Mouse);

            var actual = _map.FindAnimal(new Point(96, 250));

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimal_NearPig_ReturnPig()
        {
            var expected = typeof(Pig);

            var actual = _map.FindAnimal(new Point(93, 250));

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimalCouple_ForHorse_ReturnHorse()
        {
            var horse = new Horse(1, 1, _map, random, _land);
            var expected = typeof(Horse);

            var actual = _map.FindCouple(horse);

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimalCouple_ForMouse_ReturnMouse()
        {
            var animal = new Mouse(1, 1, _map, random, _land);
            var expected = typeof(Mouse);

            var actual = _map.FindCouple(animal);

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimalCouple_ForPig_ReturnPig()
        {
            var pig = new Pig(1, 1, _map, random, _land);
            var expected = typeof(Pig);

            var actual = _map.FindCouple(pig);

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimalCouple_ForSquirrel_ReturnSquirrel()
        {
            var squirrel = new Squirrel(1, 1, _map, random, _land);
            var expected = typeof(Squirrel);

            var actual = _map.FindCouple(squirrel);

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimalCouple_ForLynx_ReturnLynx()
        {
            var lynx = new Lynx(1, 1, _map, random, _land);
            var expected = typeof(Lynx);

            var actual = _map.FindCouple(lynx);

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimalCouple_ForOwl_ReturnOwl()
        {
            var owl = new Owl(1, 1, _map, random, _land);
            var expected = typeof(Owl);

            var actual = _map.FindCouple(owl);

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimalCouple_ForRabbit_ReturnRabbit()
        {
            var rabbit = new Rabbit(1, 1, _map, random, _land);
            var expected = typeof(Rabbit);

            var actual = _map.FindCouple(rabbit);

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimalCouple_ForEagle_ReturnEagle()
        {
            var eagle = new Eagle(1, 1, _map, random, _land);
            var expected = typeof(Eagle);

            var actual = _map.FindCouple(eagle);

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimalCouple_ForElephant_ReturnElephant()
        {
            var elephant = new Elephant(1, 1, _map, random, _land);
            var expected = typeof(Elephant);

            var actual = _map.FindCouple(elephant);

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс хороших данных
        [Test]
        public void FindAnimalCouple_ForFemale_ReturnMale()
        {
            var female = new Female(1, 1, _map, random, _land);
            var expected = typeof(Male);

            var actual = _map.FindCouple(female);

            Assert.AreEqual(expected, actual.GetType());
        }


        // Класс хороших данных
        [Test]
        public void FindAnimalCouple_ForMale_ReturnFemale()
        {
            var male = new Male(1, 1, _map, random, _land);
            var expected = typeof(Female);

            var actual = _map.FindCouple(male);

            Assert.AreEqual(expected, actual.GetType());
        }

        // Класс плохих данных
        [Test]
        public void FindAnimalCouple_OutOfMapAndFromTwoDirection_ReturnNull()
        {
            var male = new Male(-1, -1, _map, random, _land);

            var actual = _map.FindCouple(male);

            Assert.IsNull(actual);
        }

        // Класс плохих данных
        [Test]
        public void FindAnimalCouple_OutOfMapAndFromXAxesAndNegativeDirection_ReturnNull()
        {
            var male = new Male(-1, 500, _map, random, _land);

            var actual = _map.FindCouple(male);

            Assert.IsNull(actual);
        }

        // Класс плохих данных
        [Test]
        public void FindAnimalCouple_OutOfMapAndFromYAxesAndNegativeDirection_ReturnNull()
        {
            var male = new Male(500, -1000, _map, random, _land);

            var actual = _map.FindCouple(male);

            Assert.IsNull(actual);
        }
        
        // Класс плохих данных
        [Test]
        public void FindAnimalCouple_OutOfMapAndFromXAxesAndPositiveDirection_ReturnNull()
        {
            var male = new Male(10000, 500, _map, random, _land);
          
            var actual = _map.FindCouple(male);
            
            Assert.IsNull(actual);


        }
        
        // Класс плохих данных
        [Test]
        public void FindAnimalCouple_OutOfMapAndFromYAxesAndPositiveDirection_ReturnNull()
        {
            var male = new Male(500, 1000, _map, random, _land);
          
            var actual = _map.FindCouple(male);
            
            Assert.IsNull(actual);


        }
    }
}