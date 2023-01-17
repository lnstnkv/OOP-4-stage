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
        private Bitmap _bitmap;
        private Random x;
        private Season _season;
        private Color _color;
        private Summer _summer;
        private Winter _winter;
        private int index;
        private const int SizeBitmap = 5000;

        public Rendering(Random rnd)
        {
            _bitmap = new Bitmap(SizeBitmap, SizeBitmap);
            x = rnd;
            _summer = new Summer();
            _winter = new Winter();
        }

        Image _pig = Image.FromFile("..\\..\\pig.png");
        Image _mouse = Image.FromFile("..\\..\\mouse.png");
        Image _squirrel = Image.FromFile("..\\..\\squirrel.png");
        Image _eagle = Image.FromFile("..\\..\\eagle.png");
        Image _lynx = Image.FromFile("..\\..\\lynx.png");
        Image _horse = Image.FromFile("..\\..\\horse.png");
        Image _rabbit = Image.FromFile("..\\..\\rabbit.png");
        Image _elephant = Image.FromFile("..\\..\\elephant.png");
        Image _owl = Image.FromFile("..\\..\\owl.png");
        Image _human = Image.FromFile("..\\..\\human.png");
        Image _female = Image.FromFile("..\\..\\female.png");
        Image _nonPoisonousEdiblePlant = Image.FromFile("..\\..\\blue.png");
        Image _nonPoisonousNonEdiblePlant = Image.FromFile("..\\..\\red.png");
        Image _poisonousNonEdiblePlant = Image.FromFile("..\\..\\orange.png");
        Image _poisonousEdiblePlant = Image.FromFile("..\\..\\pink.png");
        Image _berry = Image.FromFile("..\\..\\blueBerry.png");
        Image _poisonousBerry = Image.FromFile("..\\..\\berry.png");
        Image _elf = Image.FromFile("..\\..\\elf.png");
        Image diedPlant = Image.FromFile("..\\..\\died.png");
        Image _factory = Image.FromFile("..\\..\\factory.png");

        public void DrawSimulation(PictureBox pictureSimulation, List<Animal> animals, List<Plant> plants,
            List<Fruit> fruits, List<FruitingPlant> fruitingPlants, List<Human> humans, bool isSeason, int maskingSize,
            List<House> houses, List<Factory> factories, List<Elf> elves)
        {
            index++;
            Graphics graph = Graphics.FromImage(_bitmap);

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
                            graph.DrawImage(_rabbit,
                                new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                                    maskingSize));
                            break;
                        case Horse _:
                            graph.DrawImage(_horse,
                                new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                                    maskingSize));
                            break;
                        case Elephant _:
                            graph.DrawImage(_elephant,
                                new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                                    maskingSize));
                            break;
                    }
                }

                if (animal is OmnivoresAnimal)
                {
                    switch (animal)
                    {
                        case Mouse _:
                            graph.DrawImage(_mouse,
                                new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                                    maskingSize));
                            break;
                        case Squirrel _:
                            graph.DrawImage(_squirrel,
                                new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                                    maskingSize));
                            break;
                        case Pig _:
                            graph.DrawImage(_pig,
                                new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                                    maskingSize));
                            break;
                    }
                }

                if (animal is CarnivoresAnimal)
                {
                    switch (animal)
                    {
                        case Owl _:
                            graph.DrawImage(_owl,
                                new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                                    maskingSize));
                            break;
                        case Lynx _:
                            graph.DrawImage(_lynx,
                                new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                                    maskingSize));
                            break;
                        case Eagle _:
                            graph.DrawImage(_eagle,
                                new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                                    maskingSize));
                            break;
                    }
                }

                if (animal is Male)
                {
                    graph.DrawImage(_human,
                        new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize, maskingSize));
                }

                if (animal is Female)
                {
                    graph.DrawImage(_female,
                        new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize, maskingSize));
                }
            }

            foreach (var plant in plants)
            {
                var position = plant.GetPoint();
                
                if (plant._isVirulence && plant._isEat)
                    graph.DrawImage(_poisonousEdiblePlant,
                        new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                            maskingSize));
                if (!plant._isVirulence && plant._isEat) 
                    graph.DrawImage(_nonPoisonousEdiblePlant,
                        new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                            maskingSize));
                if (plant._isVirulence && !plant._isEat)
                    graph.DrawImage(_poisonousNonEdiblePlant,
                        new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                            maskingSize));
                if (!plant._isVirulence && !plant._isEat)
                    graph.DrawImage(_nonPoisonousNonEdiblePlant,
                        new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                            maskingSize));
            }

            foreach (var fruit in fruits)
            {
                var position = fruit.GetPoint();
                graph.FillRectangle(Brushes.DarkBlue,
                    new Rectangle(position.X + 1 * maskingSize, position.Y + 1 * maskingSize, 3, 3));
            }

            foreach (var factory in factories)
            {
                var position = factory.GetPoint();
                graph.DrawImage(_factory,
                    new Rectangle(position.X + 1 * maskingSize, position.Y + 1 * maskingSize, maskingSize, maskingSize));
            }

            foreach (var elf in elves)
            {
                var position = elf.GetPoint();
                graph.DrawImage(_elf,
                    new Rectangle(position.X + 1 * maskingSize, position.Y + 1 * maskingSize, maskingSize, maskingSize));
            }


            foreach (var house in houses)
            {
                var position = house.GetPoint();
                graph.FillRectangle(Brushes.Black,
                    new Rectangle(position.X + 1 * maskingSize, position.Y + 1 * maskingSize, 3, 3));
            }

            foreach (var fruitingPlant in fruitingPlants)
            {
                var position = fruitingPlant.GetPoint();

                if (fruitingPlant._isVirulence)
                    graph.DrawImage(_poisonousBerry,
                        new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize, maskingSize));
                else
                {
                    graph.DrawImage(_berry,
                        new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize, maskingSize));
                }
            }

            pictureSimulation.Image = _bitmap;
            pictureSimulation.Refresh();
        }

        public void ResizePictureBox(int height, int width)
        {
            _bitmap = new Bitmap(width, height);
        }
    }
}