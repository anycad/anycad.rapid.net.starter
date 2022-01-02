using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AnyCAD.Foundation;

namespace WpfStarter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mRenderCtrl_ViewerReady()
        {
            var shape = ShapeBuilder.MakeCylinder(GP.XOY(), 10, 20, 0);
            mRenderCtrl.ShowShape(shape, ColorTable.AliceBlue);
        }
    }
}
