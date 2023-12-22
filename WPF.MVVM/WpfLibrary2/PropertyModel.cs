using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary2
{
	public class PropertyModel : BindableBase
	{

		private bool _isModify = false;
		[Category("info")]
		[DisplayName("bool")]
		[ReadOnly(false)]
		public bool isModify
		{
			get { return _isModify; }
			set { SetProperty(ref _isModify, value); }
		}


	}
}
