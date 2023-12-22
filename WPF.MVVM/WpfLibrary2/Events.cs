using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary2
{
	public class Events
	{

		public class Draw : PubSubEvent<int>
		{
		}

		public class Selected : PubSubEvent<int>
		{ 
		}
	}
}
