using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class StartSimulation
    {
        private Rendering rendering;
        private PictureBox pictureSimulation;
        private Map map;
        public Random rnd;
        private List<Animal> animals;
        private List<Human> _humans;
        private List<Factory> _factories;
        private List<Elf> _factoriesElves;
        private Form1 _form;
        private List<Plant> plants;
        private List<FruitingPlant> _fruitingPlants;
        private List<Fruit> fruits;
        private int index;
        public int _mastingSize;
        private List<House> _houses;
        private const int LensSize = 5;
        private const int ParameterForResize = 1000;

        public StartSimulation(PictureBox picture, Form1 form)
        {
            _form = form;
            pictureSimulation = picture;
            rnd = new Random();
            _mastingSize = LensSize;
            map = new Map(rnd);
            _houses = new List<House>();
            rendering = new Rendering(rnd);
            animals = map.GetAnimal();
            _houses = map.GetHouse();
            _humans = map.GetHumans();
            _fruitingPlants = map.GetFruitingPlants();
            plants = map.GetPlant();
            fruits = map.GetFruits();
            _factories = map.GetFactory();
            _factoriesElves = map.GetElf();
        }

        public void Start()
        {
            rendering.SimulationRender(pictureSimulation, animals, plants, fruits, _fruitingPlants, _humans,
                map.isWinter, _mastingSize, _houses, _factories, _factoriesElves);
            foreach (var plant in plants)
            {
                plant.Start(rnd);
            }

            foreach (var fruit in fruits)
            {
                fruit.IsKind();
            }

            foreach (var factory in _factories.ToList())
            {
                factory.Start(rnd);
            }


            map.AddSprouts();
        }

        public void Loop(Random x)
        {
            var animals = map.GetAnimal();
            List<Elf> elves = null;
            index++;
            if (index < 250)
            {
                map.isWinter = false;
                if (index == 1)
                {
                    map.BuildFactory(x);
                }

                elves = map.GetElf();
            }
            else
            {
                map.isWinter = true;
                map.DeleteFactory();
            }

            if (elves != null)
                foreach (var elf in elves.ToList())
                {
                    elf.Loop(x);
                }


            if (index > 500)
            {
                index = 0;
            }


            foreach (var animal in animals.ToList())
            {
                if (animal.IsDied())
                {
                    continue;
                }

                animal.Loop(x);
            }

            _form.TrackObject();
            rendering.SimulationRender(pictureSimulation, animals, plants, fruits, _fruitingPlants, _humans,
                map.isWinter, _mastingSize, _houses, _factories, _factoriesElves);
        }

        public void Resize()
        {
            Scale();
            rendering.ResizePictureBox(ParameterForResize * _mastingSize, ParameterForResize * _mastingSize);
        }

        public void UnResize()
        {
            UnScale();
            rendering.ResizePictureBox(ParameterForResize * _mastingSize, ParameterForResize * _mastingSize);
        }


        public void Scale()
        {
            _mastingSize += LensSize;
        }

        public void UnScale()
        {
            _mastingSize -= LensSize;
        }

        public Map GetMap()
        {
            return map;
        }
    }
}