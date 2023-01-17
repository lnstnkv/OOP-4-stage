using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Simulation
    {
        private Rendering _rendering;
        private PictureBox _pictureBox;
        private Map _map;
        private Random Random;
        private List<Animal> _animals;
        private List<Human> _humans;
        private List<Factory> _factories;
        private List<Elf> _factoriesElves;
        private Form1 _form;
        private List<Plant> plants;
        private List<FruitingPlant> _fruitingPlants;
        private List<Fruit> fruits;
        private int _index;
        public int MaskingSize;
        private List<House> _houses;
        private const int LensSize = 5;
        private const int ParameterForResize = 1000;

        public Simulation(PictureBox picture, Form1 form)
        {
            _form = form;
            _pictureBox = picture;
            Random = new Random();
            MaskingSize = LensSize;
            _map = new Map(Random);
            _houses = new List<House>();
            _rendering = new Rendering(Random);
            _animals = _map.GetAnimal();
            _houses = _map.GetHouse();
            _humans = _map.GetHumans();
            _fruitingPlants = _map.GetFruitingPlants();
            plants = _map.GetPlant();
            fruits = _map.GetFruits();
            _factories = _map.GetFactory();
            _factoriesElves = _map.GetElf();
        }

        public void Start()
        {
            _rendering.DrawSimulation(_pictureBox, _animals, plants, fruits, _fruitingPlants, _humans,
                _map.isWinter, MaskingSize, _houses, _factories, _factoriesElves);
            foreach (var plant in plants)
            {
                plant.Start(Random);
            }

            foreach (var fruit in fruits)
            {
                fruit.GetKindPlant();
            }

            foreach (var factory in _factories.ToList())
            {
                factory.Start(Random);
            }

            _map.AddSprouts();
        }

        public void Update(Random random)
        {
            var animals = _map.GetAnimal();
            List<Elf> elves = null;
            _index++;
            if (_index < 250)
            {
                _map.isWinter = false;
                if (_index == 1)
                {
                    _map.BuildFactory(random);
                }

                elves = _map.GetElf();
            }
            else
            {
                _map.isWinter = true;
                _map.DeleteFactory();
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

            foreach (var animal in animals.ToList())
            {
                if (animal.IsDied())
                {
                    continue;
                }

                animal.Update(random);
            }

            _form.TrackObject();
            _rendering.DrawSimulation(_pictureBox, animals, plants, fruits, _fruitingPlants, _humans,
                _map.isWinter, MaskingSize, _houses, _factories, _factoriesElves);
        }

        public void Resize()
        {
            Scale();
            _rendering.ResizePictureBox(ParameterForResize * MaskingSize, ParameterForResize * MaskingSize);
        }

        public void UnResize()
        {
            UnScale();
            _rendering.ResizePictureBox(ParameterForResize * MaskingSize, ParameterForResize * MaskingSize);
        }

        private void Scale()
        {
            MaskingSize += LensSize;
        }

        private void UnScale()
        {
            MaskingSize -= LensSize;
        }

        public Map GetMap()
        {
            return _map;
        }
    }
}