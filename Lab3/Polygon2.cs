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
		private Bitmap bitmap;
		private static int currentPolygon = 3;
		private static Point[] myPointArray = PolygonArrays.getMyPointArrays(CurrentPolygon);

        public static int CurrentPolygon { get => currentPolygon; set{ 
				currentPolygon = value; 
				myPointArray = PolygonArrays.getMyPointArrays(CurrentPolygon); } }

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

			switch (CurrentPolygon) {
				case 0:
					// Многоугольник 1
					drawLine(myPointArray[0].X, myPointArray[0].Y, myPointArray[1].X, myPointArray[1].Y);
					drawLine(myPointArray[1].X, myPointArray[1].Y, myPointArray[2].X, myPointArray[2].Y);
					drawLine(myPointArray[2].X, myPointArray[2].Y, myPointArray[3].X, myPointArray[3].Y);
					drawLine(myPointArray[4].X, myPointArray[4].Y, myPointArray[3].X, myPointArray[3].Y);
					drawLine(myPointArray[4].X, myPointArray[4].Y, myPointArray[0].X, myPointArray[0].Y);
					break;
				case 1:
					// Буква "Г"
/*					drawLine(myPointArray[0].X, myPointArray[0].Y, myPointArray[1].X, myPointArray[1].Y);
					drawLine(myPointArray[1].X, myPointArray[1].Y, myPointArray[2].X, myPointArray[2].Y);
					drawLine(myPointArray[3].X, myPointArray[3].Y, myPointArray[2].X, myPointArray[2].Y);
					drawLine(myPointArray[3].X, myPointArray[3].Y, myPointArray[4].X, myPointArray[4].Y);
					drawLine(myPointArray[5].X, myPointArray[5].Y, myPointArray[4].X, myPointArray[4].Y);
					drawLine(myPointArray[0].X, myPointArray[0].Y, myPointArray[5].X, myPointArray[5].Y);*/
					break;
                case 2: // Квадрат
				case 3: // Прямоугольник
				case 4: // Галка
					drawLine(myPointArray[0].X, myPointArray[0].Y, myPointArray[1].X, myPointArray[1].Y);
					drawLine(myPointArray[1].X, myPointArray[1].Y, myPointArray[2].X, myPointArray[2].Y);
					drawLine(myPointArray[3].X, myPointArray[3].Y, myPointArray[2].X, myPointArray[2].Y);
					drawLine(myPointArray[0].X, myPointArray[0].Y, myPointArray[3].X, myPointArray[3].Y);
					break;

			} 
		
		}

		private void fillPolygon()
		{

			switch (CurrentPolygon)
			{
				case 0:
					// Многоугольник 1

					break;
				case 1:
					// Буква "Г"

					break;
				case 2:
					// Квадрат

					break;
				case 3:
					// Прямоугольник

					break;
				case 4: 
					// Галка

					break;

			}

		}

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
