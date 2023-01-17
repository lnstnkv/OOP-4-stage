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
        private Simulation _simulation;
        private Random x;
        private Animal animal;
        private Plant _plant;
        private const int Approximation = 5000;
        private const int Distancing = 5000;
        private const int MaxSizeBitmap = 20000;
        private const int MinSizeBitmap = 0;
        

        public Form1()
        {
            InitializeComponent();
            _simulation = new Simulation(pictureBox, this);
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
            _simulation.Start();
            _simulation.Update(x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox.Width + Approximation >= MaxSizeBitmap && pictureBox.Height + Approximation >= MaxSizeBitmap) return;
            var size = new Size(pictureBox.Width + Approximation, pictureBox.Height + Approximation);
            _simulation.Resize();
            pictureBox.Size = size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox.Width - Distancing <= MinSizeBitmap && pictureBox.Height - Distancing <= MinSizeBitmap) return;
            var size = new Size(pictureBox.Width - Distancing, pictureBox.Height - Distancing);
            _simulation.UnResize();
            pictureBox.Size = size;
        }

        void OnPictureBoxClicked(object sender, MouseEventArgs args)
        {
            var location = args.Location;
            var map = _simulation.GetMap();
            location = new Point(location.X / _simulation.MaskingSize, location.Y / _simulation.MaskingSize);
            label1.Text = "";
            animal = map.GetAnimal(location);
            _plant = map.GetPlant(location);
        }

        public void TrackObject()
        {
            label1.Text = "";
            if (animal != null)
            {
                label1.Text += animal.GetCoordinateInformation();
                label1.Text += "\nЗдоровье: \n";
                label1.Text += animal.GetHealthInformation();
                label1.Text += "\nСытость: \n";
                label1.Text += animal.GetSatietyInformation();
                label1.Text += "\nКласс: \n";
                label1.Text += animal.GetClassInformation();
            }

            if (_plant != null)
            {
                label1.Text += _plant.GetCoordinateInformation();
                label1.Text += "\nКласс: \n";
                label1.Text += _plant.GetClassInformation();
            }
        }
    }
}