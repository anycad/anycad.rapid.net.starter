
using Prism.DryIoc;
using Prism.Ioc;
using PrismCAD.ViewModels;
using PrismCAD.Views;
using System.Windows;

namespace PrismCAD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AnyCAD.Foundation.GlobalInstance.Initialize();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            AnyCAD.Foundation.GlobalInstance.Destroy();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<CreateDxfView, CreateDxfViewModel>();
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterForNavigation<OrderManagementView, OrderManagementViewModel>();
            containerRegistry.RegisterForNavigation<ProcessDesignView, ProcessDesignViewModel>();
        }
    }
}
