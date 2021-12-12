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
			drawLine(50, 50, 100, 10);


		}

		private void fillPolygon()
		{




		}

		private void drawLine(int x0, int y0, int x1, int y1)
		{
			// 8-связный отрезок
			int x = x0, y = y0;
			int dx = x1 - x0, dy = y1 - y0;

			// Значение функции
			int delta = 0;

			// Знаки приращений
			int ex = Math.Sign(dx);
			int ey = Math.Sign(dy);

			bitmap.SetPixel(x, y, Color.Black);

			// Если dx = 0, то выводится вертикальный отрезок
			if (dx == 0) { while (y != y1) bitmap.SetPixel(x, y++, Color.Black); return; }

			// Если dy = 0, то выводится горизонтальный отрезок
			if (dy == 0) { while (x != x1) bitmap.SetPixel(x++, y, Color.Black); return; }

			// Если abs(dx) = abs(dy):
			if (Math.Abs(dx) == Math.Abs(dy))
			{
				while (x != x1)
				{
					x += ex;
					y += ey;
					bitmap.SetPixel(x, y, Color.Black);
				}
				return;
			}

			// Основной цикл
			while (!(x == x1 && y == y1))
			{
				if (delta <= 0) // если значение функции <=0
				{
					if (dy * ex - dx * ey > 0) // положит. перемещение
					{
						x += ex; y += ey;
						delta += dy * ex - dx * ey;
						bitmap.SetPixel(x, y, Color.Black);    // перемещение по x и y
					}
					// иначе перемещение по x
					else
					{
						if (Math.Abs(dx) > Math.Abs(dy))
						{
							x += ex;
							delta += dy * ex;
							bitmap.SetPixel(x, y, Color.Black);
						}
						else    // или по y
						{
							y += ey;
							delta -= dx * ey;
							bitmap.SetPixel(x, y, Color.Black);
						}
					}
				}
				// если значение функции > 0
				else
				{
					if (dy * ex - dx * ey < 0)
					{
						// делаем два перемещения
						x += ex;
						y += ey;
						delta += dy * ex - dx * ey;
						bitmap.SetPixel(x, y, Color.Black);
					}
					else
					{
						if (Math.Abs(dx) > Math.Abs(dy))
						{
							x += ex; delta += dy * ex;
							bitmap.SetPixel(x, y, Color.Black); // или по x
						}
						else
						{
							y += ey; delta -= dx * ey;
							bitmap.SetPixel(x, y, Color.Black); // или по y
						}
					}
				}
			}
		}

	}
}
