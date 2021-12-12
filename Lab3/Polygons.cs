using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Polygons : Form
    {
        public Polygons()
        {
            InitializeComponent();

            Polygon1 polygon1 = new Polygon1();
            polygon1.createPolygon(pbFirst);

            Polygon2 polygon2 = new Polygon2();
            polygon2.createPolygon(pbSecond);

        }









	}
}
