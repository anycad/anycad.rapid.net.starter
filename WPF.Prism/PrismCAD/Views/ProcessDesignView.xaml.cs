using AnyCAD.Foundation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrismCAD.Views
{
    /// <summary>
    /// ProcessDesignView.xaml 的交互逻辑
    /// </summary>
    public partial class ProcessDesignView : StackPanel
    {
        // 定义路由命令
        public static readonly RoutedCommand ExecuteCommand = new RoutedCommand("Rapid", typeof(ProcessDesignView));
        public ProcessDesignView()
        {
            InitializeComponent();
            //命令被绑定到了 ​ExecuteCommand​命令，当这个命令被触发时将执行名为 ​OnExecuteCommand​的方法
           // CommandBindings.Add(new CommandBinding(ExecuteCommand, OnExecuteCommand));
        }

        private void mView3d_ViewerReady()
        {
            // 设置成0,0,0将会彻底黑化，这里我们还是留点余地
            mView3d.Viewer.SetBackgroundColor(new Vector4(30.0f / 255, 30.0f / 255, 30.0f / 255, 0));
        }

       // 处理点击命令
        private void OnExecuteCommand(object sender, ExecutedRoutedEventArgs e)
        {
            switch (e.Parameter.ToString())
            {
                case "point":
                    {
                        var material = PointsMaterial.Create("my-material1");
                        //设置渐变
                        material.SetSizeAttenuation(false);
                        //金属感
                        material.SetPointSize(5.0F);
                        //透明度
                        material.SetTransparent(true);
                        //颜色
                        material.SetColor(ColorTable.AliceBlue);
                        var point = GeometryBuilder.CreatePoint(new Vector3(0, 0, 0));
                        var node1 = new PrimitiveSceneNode(point, material);
                        mView3d.ShowSceneNode(node1);
                    }
                    break;
                case "line":
                    {
                        var shape = SketchBuilder.MakeLine(new GPnt(0, 0, 0), new GPnt(10, 10, 0));
                        mView3d.ShowShape(shape, ColorTable.AliceBlue);
                    }
                    break;
                case "arc":
                    {
                        var shape = SketchBuilder.MakeArcOfCircle(new GPnt(0, 0, 0), new GPnt(10, 10, 0), new GPnt(5, 15, 0));
                        mView3d.ShowShape(shape, ColorTable.AliceBlue);
                    }
                    break;
                case "circle":
                    {
                        var shape = SketchBuilder.MakeCircle(new GPnt(0, 0, 0), 5, GP.DZ());
                        mView3d.ShowShape(shape, ColorTable.AliceBlue);
                    }
                    break;

                case "aixin":
                    {
                        var arc1 = SketchBuilder.MakeArcOfCircle(new GPnt(0, 2, 0), new GPnt(10, 0, 0), new GPnt(5, 5, 0));
                        var arc2 = SketchBuilder.MakeArcOfCircle(new GPnt(0, 2, 0), new GPnt(-10, 0, 0), new GPnt(-5, 5, 0));
                        var bottomPt = new GPnt(0, -12, 0);
                        var line1 = SketchBuilder.MakeLine(new GPnt(-10, 0, 0), bottomPt);
                        var line2 = SketchBuilder.MakeLine(bottomPt, new GPnt(10, 0, 0));

                        var shapeList = new TopoShapeList();
                        shapeList.Add(arc1);
                        shapeList.Add(arc2);
                        shapeList.Add(line1);
                        shapeList.Add(line2);

                        var wire = SketchBuilder.MakeWire(shapeList);
                        var face = SketchBuilder.MakePlanarFace(wire);
                        var shape = FeatureTool.Extrude(face, 5, GP.DZ());

                        shape = FeatureTool.Fillet(shape, 1);

                        mView3d.ShowShape(shape, ColorTable.PaleVioletRed);
                    }
                    break;
                case "text":
                    {
                        var mesh = FontManager.Instance().CreateMesh("情人节快乐！");
                        var material = MeshPhongMaterial.Create("love-material");
                        material.SetColor(ColorTable.OrangeRed);
                        var shape = new PrimitiveSceneNode(mesh, material);
                        mView3d.ShowSceneNode(shape);
                    }
                    break;
                case "open":
                    {
                        var dlg = new Microsoft.Win32.OpenFileDialog();
                        dlg.DefaultExt = ".stp";
                        dlg.Filter = "STEP Files (*.stp;step)|*.stp;*.step|IGES Files (*.igs;*.iges)|*.igs;*.iges|STL Files (*.stl)|*.stl|BREP Files (*.brep)|*.brep";
                        var result = dlg.ShowDialog();
                        if (result == true)
                        {
                            var filename = dlg.FileName;
                            var shape = ShapeIO.Open(filename);
                            if (shape != null)
                            {
                                mView3d.ShowShape(shape, ColorTable.Bisque);
                            }
                        }
                    }
                    break;
            }
        }
    }
}
