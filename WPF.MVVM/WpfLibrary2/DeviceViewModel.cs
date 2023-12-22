using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using AnyCAD.Foundation;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace WpfLibrary2
{
	public class DeviceViewModel : BindableBase
	{
		private IEventAggregator _ea;
		
		public ObservableCollection<DeviceModel> deviceTreeNodes { get; set; }

		public DeviceViewModel(IEventAggregator ea)
		{
			_ea =ea;
			deviceTreeNodes = new ObservableCollection<DeviceModel>();

			DeviceModel dtnm = new DeviceModel()
			{
				id = 1,
				name = "A",
			};
			deviceTreeNodes.Add(dtnm);

			DeviceModel dtnm1 = new DeviceModel()
			{
				id = 2,
				name = "B",
			};
			deviceTreeNodes.Add(dtnm1);
		}


		public ICommand selectTreeNodeCommand
		{
			get => new DelegateCommand<RoutedEventArgs>(selectTreeNode);
		}
		private void selectTreeNode(RoutedEventArgs e)
		{
			int deviceId = 0;
			var treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
			if (treeViewItem == null) return;
			treeViewItem.Focus();
			e.Handled = true;

			DeviceModel? deviceTreeNode = treeViewItem.DataContext as DeviceModel;
			if (deviceTreeNode != null)
			{
				 deviceId = deviceTreeNode.id;
			}

			_ea.GetEvent<WpfLibrary2.Events.Draw>().Publish(deviceId);

			_ea.GetEvent<WpfLibrary2.Events.Selected>().Publish(deviceId);
		}

		private static DependencyObject VisualUpwardSearch<M>(DependencyObject source)
		{
			while (source != null && source.GetType() != typeof(M))
			{
				if (source is Visual || source is Visual3D)
					source = VisualTreeHelper.GetParent(source);
				else
					source = LogicalTreeHelper.GetParent(source);
			}
			return source;
		}

	}
}
