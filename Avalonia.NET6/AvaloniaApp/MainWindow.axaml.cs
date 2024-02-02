using AnyCAD.Foundation;
using Avalonia.Controls;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void OnViewerReady()
        {
            var fullPath = DialogUtil.OpenFileDialog("选择模型文件", new StringList(new string[] { "CAD Files (.igs .iges .stp .step .brep)", "*.igs *.iges *.stp *.step *.brep" }));
            if (fullPath.IsEmpty())
                return;

            var shape = ShapeIO.Open(fullPath);
            if (shape != null)
            {
                var node = BrepSceneNode.Create(shape, null, null);
                mRenderView.ShowSceneNode(node);
            }
        }
    }
}