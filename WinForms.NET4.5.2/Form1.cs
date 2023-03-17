using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnyCAD.Forms;
namespace WinForms.NET4
{
    public partial class Form1 : Form
    {
        RenderControl mRenderView;
        public Form1()
        {
            InitializeComponent();
            mRenderView = new RenderControl(this.panel1);
        }
    }
}
