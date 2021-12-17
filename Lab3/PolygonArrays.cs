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
                new Point(71, 72),
                new Point(148, 54),
                new Point(186, 158),
                new Point(157, 154),
                new Point(91, 143),
            },
            new [] {
                new Point(54, 68),
                new Point(141, 51),
                new Point(139, 127),
                new Point(113, 144),
                new Point(105, 135),
            },
            new [] {
                new Point(56, 72),
                new Point(79, 62),
                new Point(134, 56),
                new Point(149, 70),
                new Point(119, 131),
                new Point(60, 112),
            },
            new [] {
                new Point(62, 127),
                new Point(71, 97),
                new Point(88, 57),
                new Point(141, 64),
                new Point(149, 85),
                new Point(137, 118),
                new Point(122, 145),
                new Point(93, 138),
            },
            new [] {
                new Point(51, 54),
                new Point(99, 50),
                new Point(122, 58),
                new Point(145, 132),
                new Point(89, 117),
            }
        };


        static public Point[] getMyPointArrays(int index) { return myPointArrays[index]; }
    }





}
