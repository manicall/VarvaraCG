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
        static private Point[][] myPointArrays = {
        new [] {
            new Point(55, 104),
            new Point(56, 74),
            new Point(68, 57),
            new Point(115, 70),
            new Point(126, 77),
            new Point(120, 103),
            new Point(71, 149),
        },

        new [] {
            new Point(51, 118),
            new Point(64, 86),
            new Point(118, 66),
            new Point(130, 82),
            new Point(131, 150),
            new Point(76, 137),
        },
        new [] {
            new Point(66, 119),
            new Point(67, 86),
            new Point(127, 58),
            new Point(144, 125),
            new Point(103, 138),
            new Point(71, 123),
        }


        };


        static public Point[] getMyPointArrays(int index) { return myPointArrays[index]; }
    }





}
