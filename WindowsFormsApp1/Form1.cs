﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Form1()
        {
            InitializeComponent();
            startSimulation = new StartSimulation(pictureBox);
            x = new Random();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Stop();
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
    }
}