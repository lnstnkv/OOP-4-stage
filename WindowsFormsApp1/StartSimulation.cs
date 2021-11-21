using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class StartSimulation
    {
        private Rendering rendering;
        private PictureBox pictureSimulation;
        private Map map;
        public Random rnd;
        private List <Animal> animals;
        private List<Human> _humans;
        private List <Plant> plants;
        private List<FruitingPlant> _fruitingPlants;
        private List <Fruit> fruits;
        private int index;
        private int mastingSize;
        public StartSimulation(PictureBox picture)
        {
            pictureSimulation = picture;
            rnd = new Random();
            mastingSize = 5;
            map = new Map(rnd); 
            rendering = new Rendering(rnd);
            animals = map.GetAnimal();
            _humans = map.GetHumans();
           _fruitingPlants = map.GetFruitingPlants();
            plants = map.GetPlant();
            fruits = map.GetFruits();
        }
        public void Start()
        { 
            
            rendering.SimulationRender(pictureSimulation, animals,plants,fruits,_fruitingPlants,_humans,map.isWinter);
            foreach (var plant in plants)
            {
               
                plant.Start(rnd);
            }
            foreach (var fruitingPlant in _fruitingPlants)
            {
                fruitingPlant.Start(rnd);
            }
             
            
            
            foreach (var fruit in fruits)
            {
                fruit.IsKind();
            }

            map.AddSprouts();

        }

        public void Loop(Random x)
        {
            var animals = map.GetAnimal();
            index++;
            if(index<50)
            {
                map.isWinter = false;
            }
            else
            {
                map.isWinter = true;
            }

            if (index>100)
            {
                index = 0;
            }
            Debug.WriteLine("kdsf",map.isWinter.ToString());
            foreach (var animal in animals)
            {
                if (animal.IsDied())
                {
                    continue;
                }

                animal.Loop(x);
            }
            rendering.SimulationRender(pictureSimulation, animals,plants,fruits,_fruitingPlants,_humans,map.isWinter);
        }
    }
}