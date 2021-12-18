using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
	public partial class Curves : Form
	{

		protected Bitmap bitmap;
		protected Graphics graphic;

		protected int x0, y0;         // Координаты центра PictureBox

		public Curves()
		{
			InitializeComponent();
			drawFirstGraphic(pbFirst);
			drawSecondGraphic(pbSecond);
		}

		// отрисовывает оси координат
		private void drawAxes(Bitmap bitmap, PictureBox pictureBox)
		{
			graphic = Graphics.FromImage(bitmap);                       // графический объект — некий холст
			graphic.Clear(Color.White);

			int width, height;     // Размеры PictureBox
			width = pictureBox.Width;  // ширина 
			height = pictureBox.Height; // высота
			x0 = width / 2; y0 = height / 2;

			// Выводим линии обцисс коодинат
			lineXY(x0, 0, x0, height);
			lineXY(0, y0, width, y0);

			// Выводим полученный Bitmap на экран
			pictureBox.Image = bitmap;
		}


		// Метод для вывода линий обцисс координат
		private void lineXY(int x0, int y0, int x1, int y1)
		{
			Pen grayPen = new Pen(Color.Gray);
			graphic.DrawLine(grayPen, x0, y0, x1, y1);
		}

		private void drawFirstGraphic(PictureBox pictureBox)
		{
			// Без bitmap появляются мерцания при рисовке изображения
			Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height); // буфер для Bitmap-изображения
			drawAxes(bitmap, pictureBox);

			int x = 0, y = 0;
			float delta = 0;
			float a = float.Parse(textBox1.Text);

			while (2 * a * x > 1)
			{
				setPixel(x, y); //ставим точку с координатами (x,y)
				if (delta < 0) delta += a * (2 * x + 1); //положительное приращение
				else
				{ //отрицательное приращение
					delta += a * (2 * x + 1) - 1;
					y++;
				}
				x--;
			}

			while (y < pictureBox.Height / 2)
			{
				setPixel(x, y);    //ставим точку с координатами (x,y)
				if (delta >= 0) delta += -1;    //отрицательное приращение
				else
				{ //положительное приращение
					delta += a * (2 * x + 1) - 1;
					x--;
				}
				y++;
			}

			pictureBox.Image = bitmap;
		}

		void drawSecondGraphic(PictureBox pictureBox)
		{
			// Без bitmap появляются мерцания при рисовке изображения
			Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height); // буфер для Bitmap-изображения
			drawAxes(bitmap, pictureBox);

			int x = 0, y = 0;
			float delta = 0;
			float a = float.Parse(textBox2.Text);

			while (3 * a * Math.Pow(y, 2) < 1)
			{
				setPixel(x, y); // ставим точку с координатами (x,y)
				if (delta < 0) delta += 3 * a * (float)(Math.Pow(y, 2)) + 3 * a * y + a; // положительное приращение
				else
				{ // отрицательное приращение
					delta += 3 * a * (float)(Math.Pow(y, 2)) + 3 * a * y + a - 1;
					x++;
				}
				y++;
			}

			while (x < pictureBox.Width / 2)
			{
				setPixel(x, y);    //ставим точку с координатами (x,y)
				if (delta >= 0) delta += -1;    //отрицательное приращение
				else
				{ //положительное приращение
					delta += 3 * a * (float)(Math.Pow(y, 2)) + 3 * a * y + a - 1;
					y++;
				}
				x++;
			}

			pictureBox.Image = bitmap;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			try
			{
				float a = float.Parse(textBox1.Text);
				if (a < 0) drawFirstGraphic(pbFirst);
			}
			catch { }
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			try
			{
				float a = float.Parse(textBox2.Text);
				if (a > 0) drawSecondGraphic(pbSecond);
			}
			catch { }
		}

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
			drawFirstGraphic(pbFirst);
			drawSecondGraphic(pbSecond);
		}

        private void trackBarInterval_Scroll(object sender, EventArgs e)
        {
			drawFirstGraphic(pbFirst);
			drawSecondGraphic(pbSecond);
		}

        protected void setPixel(int x, int y)
		{
			int size = trackBarSize.Value;
			int offset = trackBarInterval.Value;

			graphic.FillRectangle(new SolidBrush(Color.Black),
				x0 + offset * x,
				y0 - offset * y,
				size,
				size);
		}

	}
}
