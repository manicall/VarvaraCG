using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    class Polygon2
    {
		Bitmap bitmap;
		private static int currentPolygon = 0;
		private static Point[] myPointArray = PolygonArrays.getMyPointArrays(currentPolygon);
		
        public static void updatePointArray(int value) {
            currentPolygon = value;
			myPointArray = PolygonArrays.getMyPointArrays(currentPolygon);
		}

        public void createPolygon(PictureBox pictureBox)
		{
			bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
			// Графический объект — некий холст
			Graphics graph = Graphics.FromImage(bitmap);
			// Очищаем область
			graph.Clear(Color.White);

			drawPolygon();
			fillPolygon();

			pictureBox.Image = bitmap;
		}
		private void drawPolygon()
		{
			int j = myPointArray.Length - 1;
			for (int i = 0; i < myPointArray.Length; i++)
			{
				drawLine(myPointArray[i].X, myPointArray[i].Y, myPointArray[j].X, myPointArray[j].Y);
				j = i;
			}
		}

		private void fillPolygon()
		{
            flrec(Color.FromArgb(255, 0, 0, 0), 89, 109);
		}

        int deep = 0;
        int[] stx = new int[1000];
        int[] sty = new int[1000];
        int xmax = 300, xmin = 0, ymax = 300, ymin = 0;

        void push(int a, int b)
        {
            stx[deep] = a;
            sty[deep++] = b;
        }


        // Построчный алгоритм заполнения с затравкой с использованием рекурсии
        void flrec(Color color, int x, int y)
        {
            int xleft = x, xright = x, yy;
            if (bitmap.GetPixel(x, y) == color) return;
            if (y > ymax || y < ymin) return;
            if (x > xmax || x < xmin) return;
            while (bitmap.GetPixel(xleft, y) != color && xleft >= xmin)
                bitmap.SetPixel(xleft--, y, color);
            xright++;
            while (bitmap.GetPixel(xright, y) != color && xright <= xmax)
                bitmap.SetPixel(xright++, y, color);
            for (yy = y - 1; yy <= y + 1; yy += 2)
            {
                x = xleft + 1;
                while (x < xright && x < xmax)
                {
                    if (bitmap.GetPixel(x, yy) != color) flrec(color, x, yy);
                    x++;
                }
            }
        }

		// Генерация точек прямой методом приращений, использующий четыре перемещения
		private void drawLine(int x0, int y0, int x1, int y1)
		{
			int dx = Math.Abs(x1 - x0), dy = Math.Abs(y1 - y0);
			int ex, ey;

			if (x1 > x0) ex = 1; else ex = -1;
			if (y1 > y0) ey = 1; else ey = -1;

			int E = 0, x = x0, y = y0;

			while ((y != y1) || (x != x1))
			{
				bitmap.SetPixel(x, y, Color.Black);  // перемещение, изменяющее знак
				if (E > 0)
				{
					E -= dx;
					y += ey;
				}
				else
				{
					E += dy;
					x += ex;
				}
			}
			bitmap.SetPixel(x, y, Color.Black);
		}

	}
}
