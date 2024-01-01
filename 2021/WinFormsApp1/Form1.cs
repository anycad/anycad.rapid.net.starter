using AnyCAD.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        RenderControl _RenderControl;
        public Form1()
        {
            InitializeComponent();

            _RenderControl = new RenderControl(this.panel1);
        }
    }
}