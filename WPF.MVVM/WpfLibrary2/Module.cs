using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace WpfLibrary2
{
	public class Module : IModule
	{

		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion("Viewer3DRegion", typeof(View3DView));
			regionManager.RegisterViewWithRegion("BrowserRegion", typeof(DeviceView));
			regionManager.RegisterViewWithRegion("PropertyRegion", typeof(PropertyView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			//containerRegistry.Register<DeviceView>();
			//containerRegistry.Register<PropertyView>();
		}

	}
}
