using System.Windows;
using System.Windows.Input;

namespace PrismCAD.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView 
    {
        public MainView()
        {
            InitializeComponent();
            meunBar.SelectionChanged += (s, e) =>//当选中过MenuBars中的元素时,将左侧菜单收起
            {
                drawerHost.IsLeftDrawerOpen = false;
            };
            zuidahua.Click += (s, e) =>
            {    //最大化窗口按钮
                if (this.WindowState == WindowState.Normal)
                {
                    zuidahua.Content = "❐";
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                    zuidahua.Content = "☐";
                }
            };
            zuixiaohua.Click += (s, e) => { this.WindowState = WindowState.Minimized; };//最小化窗口按钮
            guanbi.Click += (s, e) => { this.Close(); };
            ColorZone.MouseMove += (s, e) =>//鼠标左键按住最上方区域可移动窗体
            {
                if (e.LeftButton == MouseButtonState.Pressed)//如果路由事件的左键是按下状态
                {
                    this.DragMove();//当前窗口的拖拽移动事件
                }
            };
            ColorZone.MouseDoubleClick += (s, e) =>
            {
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                    zuidahua.Content = "❐";
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                    zuidahua.Content = "☐";
                }
            };

      
        }
    }
}
