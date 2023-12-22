using AnyCAD.Foundation;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfLibrary2
{
	/// <summary>
	/// View3DView.xaml 的交互逻辑
	/// </summary>
	public partial class View3DView : UserControl
	{
		public AnyCAD.WPF.RenderControl renderControl { get => View3d; }
		private IEventAggregator _ea;

		public View3DView(IEventAggregator ea)
		{
			InitializeComponent();
			_ea = ea;
		}


		private void View3d_ViewerReady()
		{
			//显示/隐藏网格
			renderControl.ShowCoordinateGrid(false);

			//设置框选
			renderControl.ViewContext.SetRectPick(true);

			//设置框选颜色
			renderControl.SelectionManager.SetSelectionColor(new Vector3(128, 0, 128));
			renderControl.SelectionManager.SetPointSize(10f);
			renderControl.SelectionManager.SetPointStyle(EnumPointStyle.Dot);
			renderControl.SelectionManager.SetHilighting(true);
			renderControl.SelectionManager.SetHilightingColor(new Vector3(128, 0, 128)); //鼠标掠过的颜色
			renderControl.SelectionManager.SetLineWidth(5);

			//设置鼠标中键旋转（右键旋转与右键菜单重叠）
			//renderControl.ViewContext.SetOrbitButton(EnumMouseButton.Middle);
			//renderControl.ViewContext.SetPanButton(EnumMouseButton.LeftRight);

			// 设置选中回调函数
			renderControl.SetSelectCallback((ViewerListener.AfterSelectHandler)selectCallback);

			var vm = this.DataContext as View3DViewModel;
			vm?.SetRenderControl(renderControl);
		}


		private void selectCallback(PickedResult result)
		{
		

			Trace.WriteLine(" ");



		}

	}
}
