#pragma once

class TopoDS_Shape;

namespace AnyCADUtil
{
	TopoDS_Shape ToShape(AnyCAD::Foundation::TopoShape^ shape);
	AnyCAD::Foundation::TopoShape^ ToShape(const TopoDS_Shape& shape);
};

