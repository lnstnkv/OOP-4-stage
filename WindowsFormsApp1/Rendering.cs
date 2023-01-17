using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private const int SizeBitmap = 5000;

        public Rendering(Random rnd)
        {
            bmp = new Bitmap(SizeBitmap, SizeBitmap);
            x = rnd;
            _summer = new Summer();
            _winter = new Winter();
        }

        Image Pig = Image.FromFile("..\\..\\pig.png");
        Image Mouse = Image.FromFile("..\\..\\mouse.png");
        Image Squirrel = Image.FromFile("..\\..\\squirrel.png");
        Image Eagle = Image.FromFile("..\\..\\eagle.png");
        Image Lynx = Image.FromFile("..\\..\\lynx.png");
        Image Horse = Image.FromFile("..\\..\\horse.png");
        Image Rabbit = Image.FromFile("..\\..\\rabbit.png");
        Image Elephant = Image.FromFile("..\\..\\elephant.png");
        Image Owl = Image.FromFile("..\\..\\owl.png");
        Image Human = Image.FromFile("..\\..\\human.png");
        Image Female = Image.FromFile("..\\..\\female.png");
        Image blue = Image.FromFile("..\\..\\blue.png");
        Image red = Image.FromFile("..\\..\\red.png");
        Image orange = Image.FromFile("..\\..\\orange.png");
        Image pink = Image.FromFile("..\\..\\pink.png");
        Image berry = Image.FromFile("..\\..\\blueBerry.png");
        Image virBerry = Image.FromFile("..\\..\\berry.png");
        Image elfImage = Image.FromFile("..\\..\\elf.png");
        Image diedPlant = Image.FromFile("..\\..\\died.png");
        Image factoryImage = Image.FromFile("..\\..\\factory.png");

        public void SimulationRender(PictureBox pictureSimulation, List<Animal> animals, List<Plant> plants,
            List<Fruit> fruits, List<FruitingPlant> fruitingPlants, List<Human> humans, bool isSeason, int mastingSize,
            List<House> houses, List<Factory> _factories, List<Elf> _elves)
        {
            index++;
            Graphics graph = Graphics.FromImage(bmp);

            _color = isSeason == true ? _summer.ChangeSeason() : _winter.ChangeSeason();


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
                            graph.DrawImage(Rabbit,
                                new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                    mastingSize));
                            break;
                        case Horse _:
                            graph.DrawImage(Horse,
                                new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                    mastingSize));
                            break;
                        case Elephant _:
                            graph.DrawImage(Elephant,
                                new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                    mastingSize));
                            break;
                    }
                }

                if (animal is OmnivoresAnimal)
                {
                    switch (animal)
                    {
                        case Mouse _:
                            graph.DrawImage(Mouse,
                                new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                    mastingSize));
                            break;
                        case Squirrel _:
                            graph.DrawImage(Squirrel,
                                new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                    mastingSize));
                            break;
                        case Pig _:
                            graph.DrawImage(Pig,
                                new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                    mastingSize));
                            break;
                    }
                }

                if (animal is CarnivoresAnimal)
                {
                    switch (animal)
                    {
                        case Owl _:
                            graph.DrawImage(Owl,
                                new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                    mastingSize));
                            break;
                        case Lynx _:
                            graph.DrawImage(Lynx,
                                new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                    mastingSize));
                            break;
                        case Eagle _:
                            graph.DrawImage(Eagle,
                                new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                    mastingSize));
                            break;
                    }
                }

                if (animal is Male)
                {
                    graph.DrawImage(Human,
                        new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize, mastingSize));
                }

                if (animal is Female)
                {
                    graph.DrawImage(Female,
                        new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize, mastingSize));
                }
            }

            foreach (var plant in plants)
            {
                var position = plant.GetPoint();
               
                if (plant.IsVirulence() && plant.IsEat())
                    graph.DrawImage(pink,
                        new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                            mastingSize));
                if (!plant.IsVirulence() && plant.IsEat()) 
                    graph.DrawImage(blue,
                        new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                            mastingSize));
                if (plant.IsVirulence() && !plant.IsEat())
                    graph.DrawImage(orange,
                        new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                            mastingSize));
                if (!plant.IsVirulence() && !plant.IsEat())
                    graph.DrawImage(red,
                        new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                            mastingSize));
            }

            foreach (var fruit in fruits)
            {
                var position = fruit.GetPoint();
                graph.FillRectangle(Brushes.DarkBlue,
                    new Rectangle(position.X + 1 * mastingSize, position.Y + 1 * mastingSize, 3, 3));
            }

            foreach (var factory in _factories)
            {
                var position = factory.GetPoint();
                graph.DrawImage(factoryImage,
                    new Rectangle(position.X + 1 * mastingSize, position.Y + 1 * mastingSize, mastingSize, mastingSize));
            }

            foreach (var elf in _elves)
            {
                var position = elf.GetPoint();
                graph.DrawImage(elfImage,
                    new Rectangle(position.X + 1 * mastingSize, position.Y + 1 * mastingSize, mastingSize, mastingSize));
            }


            foreach (var house in houses)
            {
                var position = house.GetPoint();
                graph.FillRectangle(Brushes.Black,
                    new Rectangle(position.X + 1 * mastingSize, position.Y + 1 * mastingSize, 3, 3));
            }

            foreach (var fruitingPlant in fruitingPlants)
            {
                var position = fruitingPlant.GetPoint();

                if (fruitingPlant.IsVirulence())
                    graph.DrawImage(virBerry,
                        new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize, mastingSize));
                else
                {
                    graph.DrawImage(berry,
                        new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize, mastingSize));
                }
            }

            pictureSimulation.Image = bmp;
            pictureSimulation.Refresh();
        }

        public void ResizePictureBox(int height, int width)
        {
            bmp = new Bitmap(width, height);
        }
    }
}