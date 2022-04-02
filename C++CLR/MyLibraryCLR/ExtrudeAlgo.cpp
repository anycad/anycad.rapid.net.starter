#include "pch.h"
#include "ExtrudeAlgo.h"
#include "AnyCADUtil.h"

#include <BRepPrimAPI_MakePrism.hxx>

AnyCAD::Foundation::TopoShape^ ExtrudeAlgo::Create(MyLibrarySharp::SketchInfo^ info)
{
	auto sketch = AnyCADUtil::ToShape(info->Sketch);
	if(sketch.IsNull())
		return nullptr;
	BRepPrimAPI_MakePrism builder(sketch, gp_Vec(0, 0, info->Height), true);
	if (!builder.IsDone())
		return nullptr;
	return AnyCADUtil::ToShape(builder.Shape());
}