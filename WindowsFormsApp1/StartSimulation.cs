﻿using System;
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

        public StartSimulation(PictureBox picture, Form1 form)
        {
            _form = form;
            pictureSimulation = picture;
            rnd = new Random();
            _mastingSize = 5;
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
            index++;
            if (index < 250)
            {
                map.isWinter = false;
                if (index == 1)
                {
                    map.BuildFactory(x);
                }

              
            }
            else
            {
                map.isWinter = true;
                map.DeleteFactory();
               
            }
            foreach (var elf in _factoriesElves.ToList())
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
            rendering.ResizePictureBox(1000 * _mastingSize, 1000 * _mastingSize);
        }

        public void UnResize()
        {
            UnScale();
            rendering.ResizePictureBox(1000 * _mastingSize, 1000 * _mastingSize);
        }


        public void Scale()
        {
            _mastingSize += 5;
        }

        public void UnScale()
        {
            _mastingSize -= 5;
        }

        public Map GetMap()
        {
            return map;
        }
    }
}