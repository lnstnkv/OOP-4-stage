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

        private void DrawEntity(Image image, Graphics graph, int maskingSize, Point position)
        {
            graph.DrawImage(image,
                new Rectangle(position.X * maskingSize, position.Y * maskingSize, maskingSize,
                    maskingSize));
        }

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
                var animalImage = GetImageAnimal(animal);
                DrawEntity(animalImage, graph, maskingSize, position);
            }

            foreach (var plant in plants)
            {
                var position = plant.GetPoint();
                var plantImage = GetImagePlant(plant);
                DrawEntity(plantImage, graph, maskingSize, position);
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
                DrawEntity(_factory, graph, maskingSize, new Point(position.X + 1, position.Y + 1));
            }

            foreach (var elf in elves)
            {
                var position = elf.GetPoint();
                DrawEntity(_elf, graph, maskingSize, new Point(position.X + 1, position.Y + 1));
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
                    DrawEntity(_poisonousBerry, graph, maskingSize, new Point(position.X + 1, position.Y + 1));
                else
                {
                    DrawEntity(_berry, graph, maskingSize, new Point(position.X + 1, position.Y + 1));
                }
            }

            pictureSimulation.Image = _bitmap;
            pictureSimulation.Refresh();
        }

        private Image GetImageAnimal(Animal animal)
        {
            if (animal is HerbivoresAnimal)
            {
                switch (animal)
                {
                    case Rabbit _:
                        return _rabbit;

                    case Horse _:
                        return _horse;

                    case Elephant _:
                        return _elephant;
                }
            }

            switch (animal)
            {
                case OmnivoresAnimal _:
                    switch (animal)
                    {
                        case Mouse _:
                            return _mouse;

                        case Squirrel _:
                            return _squirrel;

                        case Pig _:
                            return _pig;
                    }

                    break;
                case CarnivoresAnimal _:
                    switch (animal)
                    {
                        case Owl _:
                            return _owl;
                        case Lynx _:
                            return _lynx;
                        case Eagle _:
                            return _eagle;
                    }

                    break;
                case Male _:
                    return _human;
                case Female _:
                    return _female;
            }

            return null;
        }

        private Image GetImagePlant(Plant plant)
        {
            switch (plant._isVirulence)
            {
                case true when plant._isEat:
                    return _poisonousEdiblePlant;
                case false when plant._isEat:
                    return _nonPoisonousEdiblePlant;
                case true when !plant._isEat:
                    return _poisonousNonEdiblePlant;
                case false when !plant._isEat:
                    return _nonPoisonousNonEdiblePlant;
            }

            return null;
        }


        public void ResizePictureBox(int height, int width)
        {
            _bitmap = new Bitmap(width, height);
        }
    }
}