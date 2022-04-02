#include "pch.h"
#include "AnyCADUtil.h"
#include "TopoDS_Shape.hxx"
#include <BRepTools.hxx>
#include <BRep_Builder.hxx>
#include <msclr\marshal_cppstd.h>

namespace AnyCADUtil
{
	TopoDS_Shape ToShape(AnyCAD::Foundation::TopoShape^ shape)
	{
		TopoDS_Shape newShape;
		if (!shape)
			return newShape;

		auto buffer = shape->Write();
		std::istringstream iss(msclr::interop::marshal_as<std::string>(buffer));

		BRep_Builder builder;
		BRepTools::Read(newShape, iss, builder);
		return newShape;
	}

	AnyCAD::Foundation::TopoShape^ ToShape(const TopoDS_Shape& shape)
	{
		std::ostringstream oss;
		BRepTools::Write(shape, oss);
		auto buffer = gcnew System::String(oss.str().c_str());

		return AnyCAD::Foundation::TopoShape::Read(buffer);
	}
}
