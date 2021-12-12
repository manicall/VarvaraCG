using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;


namespace Lab5
{


    public partial class Fractals : Form
    {
        public Fractals()
        {
            InitializeComponent();

            Fractal1 fractal1 = new Fractal1();
            fractal1.drawFractal(pbFractalFirst);

            Fractal2 fractal2 = new Fractal2();
            fractal2.drawFractal(pbFractalSecond);

        }

    }


}

