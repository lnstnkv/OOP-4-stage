using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Rendering
    {
        private Bitmap bmp;
        private Random x;
        private Season _season;
        private Color _color;
        private Summer _summer;
        private Winter _winter;
        private int index;

        public Rendering(Random rnd)
        {
            bmp = new Bitmap(5000, 5000);
            x = rnd;
            _summer = new Summer();
            _winter = new Winter();
        }
        Image Pig = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/pig.png");
        Image Mouse = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/mouse.png");
        Image Squirrel = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/squirrel.png");
        Image Eagle = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/eagle.png");
        Image Lynx = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/lynx.png");
        Image Horse = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/horse.png");
        Image Rabbit = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/rabbit.png");
        Image Elephant = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/elephant.png");
        Image Owl = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/owl.png");
        Image Human = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/human.png");
        Image blue= Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/blue.png");
        Image red= Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/red.png");
        Image orange= Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/orange.png");
        Image pink= Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/pink.png");
        Image berry= Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/blueBerry.png");
        Image virBerry= Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/berry.png");
        
       // Image Pig = Image.FromFile("C:\\Users/Zver/RiderProjects/WindowsFormsApp1/WindowsFormsApp1/pig.png");
        public void SimulationRender(PictureBox pictureSimulation, List<Animal> animals, List<Plant> plants,
            List<Fruit> fruits, List<FruitingPlant> fruitingPlants, List<Human> humans, bool isSeason)
        {
            index++;
            Graphics graph = Graphics.FromImage(bmp);

            if (isSeason==true)
            {
                _color = _summer.ChangeSeason();
            }
            else
            {
                _color = _winter.ChangeSeason();
            }
            
            
            graph.Clear(_color);
            foreach (var animal in animals)
            {
                if (animal.IsDied())
                {
                    continue;
                }
                var position = animal.GetPoint();
                if (animal is HerbivoresAnimal)
                {
                    switch (animal)
                    {
                        case Rabbit _:
                            graph.DrawImage(Rabbit, new Rectangle(position.X * 10, position.Y * 10, 10, 10));
                            break;
                        case Horse _:
                            graph.DrawImage(Horse, new Rectangle(position.X * 10, position.Y * 10, 10, 10));
                            break;
                        case Elephant _:
                            graph.DrawImage(Elephant, new Rectangle(position.X * 10, position.Y * 10, 10, 10));
                            break;
                    }
                }
                
                if (animal is OmnivoresAnimal)
                {
                    switch (animal)
                    {
                        case Mouse _:
                            graph.DrawImage(Mouse, new Rectangle(position.X * 10, position.Y * 10, 10, 10));
                            break;
                        case Squirrel _:
                            graph.DrawImage(Squirrel, new Rectangle(position.X * 10, position.Y * 10, 10, 10));
                            break;
                        case Pig _:
                            graph.DrawImage(Pig,
                                new Rectangle(position.X * 10, position.Y * 10, 10, 10));
                            break;
                    }
                }

                if (animal is CarnivoresAnimal)
                {
                    switch (animal)
                    {
                        case Owl _:
                            graph.DrawImage(Owl, new Rectangle(position.X * 10, position.Y * 10, 10, 10));
                            break;
                        case Lynx _:
                            graph.DrawImage(Lynx, new Rectangle(position.X * 10, position.Y * 10, 10, 10));
                            break;
                        case Eagle _:
                            graph.DrawImage(Eagle, new Rectangle(position.X * 10, position.Y * 10, 10, 10));
                            break;
                    }
                }

                if (animal is Human)
                {
                    graph.DrawImage(Human, new Rectangle(position.X * 10, position.Y * 10, 10, 10));
                }
            }
              /*  if (animal is HerbivoresAnimal)
                {
                    switch (animal)
                    {
                        case Rabbit _:
                            graph.FillEllipse(Brushes.Black, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                            break;
                        case Horse _:
                            graph.FillEllipse(Brushes.SandyBrown, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                            break;
                        case Elephant _:
                            graph.FillEllipse(Brushes.Firebrick, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                            break;
                    }
                }
                
                if (animal is OmnivoresAnimal)
                {
                    switch (animal)
                    {
                        case Mouse _:
                            graph.FillEllipse(Brushes.Lime, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                            break;
                        case Squirrel _:
                            graph.FillEllipse(Brushes.BlueViolet, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                            break;
                        case Pig _:
                            graph.FillEllipse(Brushes.PaleVioletRed,
                                new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                            break;
                    }
                }

                if (animal is CarnivoresAnimal)
                {
                    switch (animal)
                    {
                        case Owl _:
                            graph.FillEllipse(Brushes.DarkBlue, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                            break;
                        case Lynx _:
                            graph.FillEllipse(Brushes.White, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                            break;
                        case Eagle _:
                            graph.FillEllipse(Brushes.Olive, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                            break;
                    }
                }

                if (animal is Human)
                {
                    graph.FillRectangle(Brushes.Gold, new Rectangle(position.X + 1 * 5, position.Y + 1 * 5, 3, 3));
                }
            }
            */
/*
            foreach (var human in humans)
            {
                var position = human.GetPoint();
                
            }
*/
            foreach (var plant in plants)
            {
                var position = plant.GetPoint();
                if (plant.IsVirulence() && plant.IsEat()) // ядовитое съедобное 
                    graph.DrawImage(pink, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                if (!plant.IsVirulence() && plant.IsEat()) // неядовитое съедобное
                    graph.DrawImage(blue, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                if (plant.IsVirulence() && !plant.IsEat()) // ядовитое несъедобное
                    graph.DrawImage(orange, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                if (!plant.IsVirulence() && !plant.IsEat()) // неядовитое несъедобное
                    graph.DrawImage(red, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
            }

            foreach (var fruit in fruits)
            {
                var position = fruit.GetPoint();
                graph.FillRectangle(Brushes.DarkBlue, new Rectangle(position.X + 1 * 5, position.Y + 1 * 5, 3, 3));
            }

            foreach (var fruitingPlant in fruitingPlants)
            {
                var position = fruitingPlant.GetPoint();

                if (fruitingPlant.IsVirulence())
                    graph.DrawImage(virBerry, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                else
                {
                    graph.DrawImage(berry, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                }
            }
/*
            foreach (var plant in plants)
            {
                var position = plant.GetPoint();
                if (plant.IsVirulence() && plant.IsEat()) // ядовитое съедобное 
                    graph.FillRectangle(Brushes.DeepPink, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                if (!plant.IsVirulence() && plant.IsEat()) // неядовитое съедобное
                    graph.FillRectangle(Brushes.Green, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                if (plant.IsVirulence() && !plant.IsEat()) // ядовитое несъедобное
                    graph.FillRectangle(Brushes.Yellow, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                if (!plant.IsVirulence() && !plant.IsEat()) // неядовитое несъедобное
                    graph.FillRectangle(Brushes.Black, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
            }

            foreach (var fruit in fruits)
            {
                var position = fruit.GetPoint();
                graph.FillRectangle(Brushes.DarkBlue, new Rectangle(position.X + 1 * 5, position.Y + 1 * 5, 3, 3));
            }

            foreach (var fruitingPlant in fruitingPlants)
            {
                var position = fruitingPlant.GetPoint();

                if (fruitingPlant.IsVirulence())
                    graph.FillRectangle(Brushes.Aqua, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                else
                {
                    graph.FillRectangle(Brushes.Olive, new Rectangle(position.X * 5, position.Y * 5, 5, 5));
                }
            }
            */
        
            pictureSimulation.Image = bmp;
            pictureSimulation.Refresh();
        }
    }
}