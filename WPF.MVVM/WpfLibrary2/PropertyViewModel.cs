using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfLibrary2
{
	public class PropertyViewModel : BindableBase
	{
		private Visibility _visibility;
		public Visibility visibility
		{
			get { return _visibility; }
			set { SetProperty(ref _visibility, value); }
		}

		private PropertyModel _propertyModel = new PropertyModel();
		public PropertyModel propertyModel
		{
			get { return _propertyModel; }
			set { SetProperty(ref _propertyModel, value); }
		}


		public PropertyViewModel(IEventAggregator ea)
        {
                
        }



    }
}
