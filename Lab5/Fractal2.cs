using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    class Fractal2
    {

        private int maxX, maxY;                // ширина и высота PictureBox
        private Color[] colors = new Color[6]; // цвета точек rgb и темные rgb
        private float xMin, yMin, xMax, yMax;  // область видимости фрактала

        public Fractal2()
        {
            colors[0] = Color.FromArgb(127, 0, 0);
            colors[1] = Color.FromArgb(255, 0, 0);
            colors[2] = Color.FromArgb(0, 127, 0);
            colors[3] = Color.FromArgb(0, 255, 0);
            colors[4] = Color.FromArgb(0, 0, 127);
            colors[5] = Color.FromArgb(0, 0, 255);

            // Область видимости фрактала
            xMin = -6; yMin = -4;
            xMax = 6; yMax = 4;

        }

        private Complex[] getRoot()
        {
            // Корни многочлена
            Complex firstRoot = 1.0/4.0;
            Complex secondRoot = new Complex(0.5, 1);
            Complex thirdRoot = new Complex(0.5, -1);

            return new Complex[] { firstRoot, secondRoot, thirdRoot };
        }

        private Complex func(Complex complex)
        {
            // Общий вид уравнения для построения бассейна ньютона
            return -5 / 16.0 + Complex.Pow(complex, 3) - 5 * Complex.Pow(complex, 2) / 4.0 + 3 * complex / 2.0;
        }

        private Complex funcDiff(Complex complex)
        {
            // Общий вид уравнения для построения бассейна ньютона
            return 3 / 2.0 + 3 * Complex.Pow(complex, 2) - 5 * complex / 2.0;
        }

        public void drawFractal(PictureBox pictureBox)
        {
            Bitmap myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            // Графический объект — некий холст
            Graphics graph = Graphics.FromImage(myBitmap);

            // Очищаем область
            graph.Clear(Color.White);

            // Размеры окна
            maxX = myBitmap.Width;
            maxY = myBitmap.Height;

            float re, im;
            float xInc = (xMax - xMin) / maxX;
            float yInc = (yMax - yMin) / maxY;

            Complex[] root = getRoot();

            for (re = xMin; re < xMax; re += xInc)
            {
                for (im = yMin; im < yMax; im += yInc)
                {
                    Complex eq = new Complex(re, im);

                    int level = 0;
                    const int minLevel = 0;
                    const int maxLevel = 100;

                    do
                    {
                        if (Complex.Abs(funcDiff(eq)) < 0.0001) level = -1;

                        else
                        {
                            eq = eq - func(eq) / funcDiff(eq);
                            level++;
                        }
                    }
                    while (level >= minLevel && level < maxLevel && Complex.Abs(func(eq)) >= 0.01);

                    if (level < minLevel) continue;

                    const int nColors = 3;
                    for (int color = 0; color < nColors; color++)
                    {
                        if (Complex.Abs(eq - root[color]) < 0.01)
                        {
                            putPoint(myBitmap, re, im, colors[2 * color + level % 2]);
                        }
                    }
                }
            }

            pictureBox.Image = myBitmap;
        }

        private void putPoint(Bitmap myBitmap, float x, float y, Color color)
        {
            if (x < xMax && x > xMin && y < yMax && y > yMin)
            {
                float x0 = (x - xMin) * maxX / (xMax - xMin);
                float y0 = (yMax - y) * maxY / (yMax - yMin);
                myBitmap.SetPixel((int)x0, (int)y0, color);
            }
        }
    }
}
