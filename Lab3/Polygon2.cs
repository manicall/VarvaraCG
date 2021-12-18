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


        // Простой алгоритм заполнения с затравкой с использованием рекурсии
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
        void drawLine(int ix0, int iy0, int ix1, int iy1)
        {
            int ix, iy, delta_x, delta_y, esh, sx, sy;
            int temp, swab, i;
            ix = ix0;
            iy = iy0;
            delta_x = Math.Abs(ix1 - ix0);
            delta_y = Math.Abs(iy1 - iy0);
            if (ix1 - ix0 >= 0) sx = 1;
            else sx = -1;
            if (iy1 - iy0 >= 0) sy = 1;
            else sy = -1;
            if (ix1 == ix0) sx = 0;
            if (iy1 == iy0) sy = 0;
            //Обмен значений delta_x delta_y в зависимости от угла
            if (delta_y > delta_x)
            {
                temp = delta_x;
                delta_x = delta_y;
                delta_y = temp;
                swab = 1;
            }
            else swab = 0;
            //Инициализация Е с поправкой на половину пиксела
            esh = 2 * delta_y - delta_x;
            for (i = 0; i <= delta_x; i++)
            {
                bitmap.SetPixel(ix, iy, Color.Black);
                if (esh >= 0)
                {
                    if (swab == 1) ix += sx;
                    else iy += sy;
                    esh = esh - 2 * delta_x;
                }
                if (swab == 1) iy += sy;
                else ix += sx;
                esh = esh + 2 * delta_y;
            }
        }

    }
}
