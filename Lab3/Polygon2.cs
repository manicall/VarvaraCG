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
            flstr(Color.FromArgb(255, 255, 255, 255), Color.Cyan, 89, 109);
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

        void flstr(Color oldColor, Color newColor, int x, int y)
        {
            int xCurrent, xLeft, xRight;
            int xEnter, flag, i;
            push(x, y);
            while (deep > 0)
            {
                x = stx[--deep];
                y = sty[deep]; // pop
                if (bitmap.GetPixel(x, y) == oldColor)
                {
                    bitmap.SetPixel(x, y, newColor);
                    xCurrent = x; //сохранение текущей коорд. x
                    x++;     //перемещение вправо
                    while (bitmap.GetPixel(x, y) == oldColor && x <= xmax) bitmap.SetPixel(x++, y, newColor);
                    xRight = x - 1;
                    x = xCurrent;
                    x--; //перемещение влево
                    while (bitmap.GetPixel(x, y) == oldColor && x >= xmin) bitmap.SetPixel(x--, y, newColor);
                    xLeft = x + 1;
                    x = xCurrent;
                    for (i = 0; i < 2; i++)
                    {
                        // при i=0 проверяем нижнюю, а при i=1 - верхнюю строку
                        if (y <= ymax && y >= ymin)
                        {
                            x = xLeft;
                            y += 1 - i * 2;
                            while (x <= xRight)
                            {
                                flag = 0;
                                while (bitmap.GetPixel(x, y) == oldColor && x <= xRight)
                                {
                                    if (flag == 0) flag = 1;
                                    x++;
                                }
                                if (flag == 1)
                                {
                                    if (x == xRight && bitmap.GetPixel(x, y) == oldColor)
                                    {
                                        push(x, y);
                                    }
                                    else
                                    {
                                        push(x - 1, y);
                                    }
                                    flag = 0;
                                }

                                xEnter = x;
                                while (bitmap.GetPixel(x, y) == newColor && x <= xRight) x++;
                                if (x == xEnter) x++;
                            }
                        }
                        y--;
                    }
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
				bitmap.SetPixel(x, y, Color.Black);    // перемещение, изменяющее знак
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
