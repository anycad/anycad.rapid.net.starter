using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

namespace WpfApp3
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			return;
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<WpfLibrary2.Module>();
		}

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			AnyCAD.Foundation.GlobalInstance.Initialize(); 
		}

		private void Application_Exit(object sender, ExitEventArgs e)
		{
			AnyCAD.Foundation.GlobalInstance.Destroy(); 
		}


	}

}
