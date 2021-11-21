using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private StartSimulation startSimulation;
        private Random x;
        private Animal animal;
        private Plant _plant;

        public Form1()
        {
            InitializeComponent();
            startSimulation = new StartSimulation(pictureBox, this);
            x = new Random();
            pictureBox.MouseClick += OnPictureBoxClicked;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            startSimulation.Start();
            startSimulation.Loop(x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox.Width + 5000 >= 20000 && pictureBox.Height + 5000 >= 20000) return;
            var size = new Size(pictureBox.Width + 5000, pictureBox.Height + 5000);
            startSimulation.Resize();
            pictureBox.Size = size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox.Width - 5000 <= 0 && pictureBox.Height - 5000 <= 0) return;
            var size = new Size(pictureBox.Width - 5000, pictureBox.Height - 5000);
            startSimulation.UnResize();
            pictureBox.Size = size;
        }

        void OnPictureBoxClicked(object sender, MouseEventArgs args)
        {
            var location = args.Location;
            var map = startSimulation.GetMap();
            location = new Point(location.X / startSimulation._mastingSize, location.Y / startSimulation._mastingSize);
            label1.Text = "";
            animal = map.IsAnimal(location);
            _plant = map.IsPlant(location);
        }

        public void TrackObject()
        {
            label1.Text = "";
            if (animal != null)
            {
                label1.Text += animal.InfoCoordinate();
                label1.Text += "\nЗдоровье: \n";
                label1.Text += animal.InfoHealth();
                label1.Text += "\nСытость: \n";
                label1.Text += animal.InfoSatietly();
                label1.Text += "\nКласс: \n";
                label1.Text += animal.ClassAnimal();
            }

            if (_plant != null)
            {
                label1.Text += _plant.InfoCoordinate();
                label1.Text += "\nКласс: \n";
                label1.Text += _plant.ClassPlant();
            }
        }
    }
}