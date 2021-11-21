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
        Image blue = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/blue.png");
        Image red = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/red.png");
        Image orange = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/orange.png");
        Image pink = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/pink.png");
        Image berry = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/blueBerry.png");
        Image virBerry = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/berry.png");
        Image diedPlant = Image.FromFile("F:\\RiderProjects/WindowsFormsApp1/WindowsFormsApp1/died.png");

        public void SimulationRender(PictureBox pictureSimulation, List<Animal> animals, List<Plant> plants,
            List<Fruit> fruits, List<FruitingPlant> fruitingPlants, List<Human> humans, bool isSeason, int mastingSize)
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

                if (animal is Human)
                {
                    graph.DrawImage(Human,
                        new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize, mastingSize));
                }
            }

            foreach (var plant in plants)
            {
                var position = plant.GetPoint();
               /* if (plant.IsDied())
                {
                    graph.DrawImage(diedPlant,
                        new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize, mastingSize));
                }
                else
                {*/
                    if (plant.IsVirulence() && plant.IsEat()) // ядовитое съедобное 
                        graph.DrawImage(pink,
                            new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                mastingSize));
                    if (!plant.IsVirulence() && plant.IsEat()) // неядовитое съедобное
                        graph.DrawImage(blue,
                            new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                mastingSize));
                    if (plant.IsVirulence() && !plant.IsEat()) // ядовитое несъедобное
                        graph.DrawImage(orange,
                            new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                mastingSize));
                    if (!plant.IsVirulence() && !plant.IsEat()) // неядовитое несъедобное
                        graph.DrawImage(red,
                            new Rectangle(position.X * mastingSize, position.Y * mastingSize, mastingSize,
                                mastingSize));
                //}
            }

            foreach (var fruit in fruits)
            {
                var position = fruit.GetPoint();
                graph.FillRectangle(Brushes.DarkBlue,
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