using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    class Surface2
    {
        private static int nX = 60;
        private static int nY = 60;
        private float xMax, xMin, yMax, yMin, zMax, zMin;
        private float hX, hY;

        private float exMax, exMin, eyMax, eyMin;
        private int gmex, gmey;


        // Функция z = f(x,y)
        private float fz(float x, float y)
        {
            // z = cos(sqrt(x^2+y^2))
            return (float)Math.Cos(Math.Sqrt(Math.Pow(x,2) + Math.Pow(y, 2)));
        }

        // x координата на плоскости параллельной проекциии
        private float ex(float x, float y, float z)
        {
            return (float)(-0.2 * x + 0.4 * y);
        }

        // y координата на плоскости параллельной проекции
        private float ey(float x, float y, float z)
        {
            return (float)(-0.1 * x + 0.2 * z);
        }


        public Surface2()
        {
            xMax = 5; xMin = -5;
            yMax = 5; yMin = -5;
            zMax = 0; zMin = 0;

            // Подготовка окна вывода
            hY = (yMax - yMin) / nY;
            hX = (xMax - xMin) / nX;

            exMax = ex(xMin, yMax, zMax) + 0.01f;
            exMin = ex(xMax, yMin, zMin) + 0.01f;
            eyMax = ey(xMin, yMin, zMax) + 0.01f;
            eyMin = ey(xMax, yMax, zMin) + 0.01f;
        }

        public void drawSurface(PictureBox pictureBox)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            // Графический объект — некий холст
            Graphics graph = Graphics.FromImage(bitmap);

            // Очищаем область
            graph.Clear(Color.White);

            // Размеры окна
            gmex = bitmap.Width;
            gmey = bitmap.Height;

            float[] xx = new float[4];
            float[] yy = new float[4];
            float[] zz = new float[4];

            SolidBrush blackBrush = new SolidBrush(Color.Black);
          

            for (int i = 0; i <= nX; i++)
            {
                for (int j = 0; j <= nY; j++)
                {
                    float z = fz(xMin + i * hX, yMin + j * hY);
                    if (z > zMax) zMax = z;
                    if (z < zMin) zMin = z;
                }
            }

            for (float x = xMin; x <= xMax; x += xMax - xMin)
            {
                for (float y = yMin; y <= yMax; y += yMax - yMin)
                {
                    for (float z = zMin; z <= zMax; z += zMax - zMin)
                    {
                        if (exMax < ex(x, y, z)) exMax = ex(x, y, z);
                        if (exMin > ex(x, y, z)) exMin = ex(x, y, z);
                        if (eyMax < ey(x, y, z)) eyMax = ey(x, y, z);
                        if (eyMin > ey(x, y, z)) eyMin = ey(x, y, z);
                    }
                }
            }

            for (int i = 0; i < nX; i++)
            {
                xx[0] = xMin + i * hX;
                xx[1] = xMin + (i + 1) * hX;
                xx[2] = xMin + (i + 1) * hX;
                xx[3] = xMin + i * hX;

                for (int j = 0; j < nY; j++)
                {
                    yy[0] = yMin + j * hY; zz[0] = fz(xx[0], yy[0]);
                    yy[1] = yMin + j * hY; zz[1] = fz(xx[1], yy[1]);
                    yy[2] = yMin + (j + 1) * hY; zz[2] = fz(xx[2], yy[2]);
                    yy[3] = yMin + (j + 1) * hY; zz[3] = fz(xx[3], yy[3]);
                    fPoly(graph, xx, yy, zz, 4);
                }
            }

            pictureBox.Image = bitmap;
        }

        // Вычисление координат полигона
        private void fPoly(Graphics graph, float[] x, float[] y, float[] z, int n)
        {
            int[] ix = new int[n];
            int[] iy = new int[n];
            PointF[] p = new PointF[n];

            for (int i = 0; i < n; i++)
            {
                float px = ex(x[i], y[i], z[i]);
                ix[i] = (int)((px - exMin) * gmex / (exMax - exMin));

                float py = ey(x[i], y[i], z[i]);
                iy[i] = (int)((py - eyMin) * gmey / (eyMax - eyMin));

                Point q = new Point(ix[i], gmey - iy[i]);
                p[i] = q;
            }

            Pen blackPen = new Pen(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            graph.FillPolygon(whiteBrush, p);
            graph.DrawPolygon(blackPen, p);
        }
    }

}

