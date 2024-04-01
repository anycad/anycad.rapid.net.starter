using AnyCAD.Forms;
using AnyCAD.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.NET472
{
    public partial class Form1 : Form
    {
        IRenderView _Render;
        public Form1()
        {
            InitializeComponent();

            _Render = new RenderControl(this.splitContainer1.Panel2);
        }
    }
}
