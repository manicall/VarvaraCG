using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
	class Polygon1
	{
		Bitmap bitmap;
		private static int currentPolygon = 0;
		private static Point[] myPointArray = PolygonArrays.getMyPointArrays(currentPolygon);

		public static void updatePointArray(int value)
		{
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

		// вызывает рекурсивное заполнение
		private void fillPolygon() {
			recFill(Color.FromArgb(255, 255, 255, 255), Color.Red, 89, 109);
		}

		// Простой алгоритм заполнения с затравкой с использованием рекурсии
		void recFill(Color oldColor, Color newColor, int x, int y)
		{
			int step = 1;
			if (bitmap.GetPixel(x, y) != oldColor) return;
			bitmap.SetPixel(x, y, newColor);
			recFill(oldColor, newColor, x - step, y);
			recFill(oldColor, newColor, x + step, y);
			recFill(oldColor, newColor, x, y - step);
			recFill(oldColor, newColor, x, y + step);
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
