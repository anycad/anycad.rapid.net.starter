using Prism.Events;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp3
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow 
	{
		private IEventAggregator _ea;

		public MainWindow(IEventAggregator ea)
		{
			InitializeComponent();
			_ea = ea;

			_ea.GetEvent<WpfLibrary2.Events.Selected>().Subscribe(onDeviceSelected);
		}

		private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
		{
			property.Hide();
		}


		private void onDeviceSelected(int i)
		{
			if (i == 1)
			{
				property.Show();
			}
			else
			{
				property.Hide();
			}	
		}
	}
}