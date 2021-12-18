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
        Polygon1 polygon1;
        Polygon2 polygon2;

        public Polygons()
        {
            InitializeComponent();

            polygon1 = new Polygon1();
            polygon1.createPolygon(pbFirst);

            polygon2 = new Polygon2();
            polygon2.createPolygon(pbSecond);
        }
            
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Polygon1.updatePointArray(comboBox1.SelectedIndex);
            polygon1.createPolygon(pbFirst);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Polygon2.updatePointArray(comboBox2.SelectedIndex);
            polygon2.createPolygon(pbSecond);
        }
    }
}
