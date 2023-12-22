using Prism.Mvvm;

namespace WpfLibrary2
{
    public class DeviceModel : BindableBase
	{
		public int id { get; set; }

		public string? name { get; set; }

		private bool _isExpanded;
		public bool isExpanded
		{
			get { return _isExpanded; }
			set { SetProperty(ref _isExpanded, value); }
		}

		private bool _isSelected;
		public bool isSelected
		{
			get { return _isSelected; }
			set { SetProperty(ref _isSelected, value); }
		}
	
		public DeviceModel()
		{
			
		}

		internal static void toggleExpanded(DeviceModel node, bool isExpanded)
		{
			node.isExpanded = isExpanded;
		}

	
	}
}

