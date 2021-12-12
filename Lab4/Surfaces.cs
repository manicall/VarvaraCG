using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Surfaces : Form
    {
        public Surfaces()
        {
            InitializeComponent();

            Surface1 surface1 = new Surface1();
            surface1.drawSurface(pbFirst);

            Surface2 surface2 = new Surface2();
            surface2.drawSurface(pbSecond);
        }
    }
}
