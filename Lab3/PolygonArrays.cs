using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	class PolygonArrays
	{
        static private int scale = 4;
        static private Point[][] myPointArrays = {
            new [] {  // Многоугольник 1
                 new Point(400 / scale, 200 / scale),
                 new Point(500 / scale, 250 / scale),
                 new Point(700 / scale, 125 / scale),
                 new Point(600 / scale, 100 / scale),
                 new Point(450 / scale, 100 / scale)
            },

            new [] { // Буква "Г"
		        new Point(400 / scale, 120 / scale),
                new Point(600 / scale, 120 / scale),
                new Point(600 / scale, 220 / scale),
                new Point(500 / scale, 220 / scale),
                new Point(500 / scale, 320 / scale),
                new Point(400 / scale, 320 / scale),
            },

            new [] { // Квадрат
                new Point(400 / scale, 200 / scale),
                new Point(600 / scale, 200 / scale),
                new Point(600 / scale, 400 / scale),
                new Point(400 / scale, 400 / scale),
            },

            new [] { // Прямоугольник
		        new Point(400 / scale, 200 / scale),
                new Point(800 / scale, 200 / scale),
                new Point(800 / scale, 400 / scale),
                new Point(400 / scale, 400 / scale),
            },

            new [] { // Галка
			    new Point(400 / scale, 120 / scale),
                new Point(450 / scale, 140 / scale),
                new Point(520 / scale, 115 / scale),
                new Point(475 / scale, 200 / scale),
            }

        };

        static public Point[] getMyPointArrays(int index) { return myPointArrays[index]; }
    }



}
