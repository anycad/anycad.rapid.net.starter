using AnyCAD.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarySharp
{
    public interface IExtrude
    {
        TopoShape Create(SketchInfo sketchInfo);
    }
}
