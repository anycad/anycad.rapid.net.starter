using AnyCAD.Forms;
using AnyCAD.Foundation;

namespace WinFormsStarter
{
    public partial class Form1 : Form
    {
        RenderControl mRenderView; 
        public Form1()
        {
            InitializeComponent();
            mRenderView = new RenderControl(this.splitContainer1.Panel2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var shape = ShapeBuilder.MakeSphere(new GPnt(0, 0, 0), 10);
            mRenderView.ShowShape(shape, ColorTable.PaleVioletRed);
        }
    }
}