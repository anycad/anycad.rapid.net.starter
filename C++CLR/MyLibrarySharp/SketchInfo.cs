using AnyCAD.Foundation;
using System;

namespace MyLibrarySharp
{
    public class SketchInfo
    {
        public double Height { get; set; } = 200;
        public TopoShape? Sketch { get; set; }

        public SketchInfo()
        {

        }
    }
}
