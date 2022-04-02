#pragma once


public ref class ExtrudeAlgo 
	: public MyLibrarySharp::IExtrude
{
public:
	virtual AnyCAD::Foundation::TopoShape^ Create(MyLibrarySharp::SketchInfo^ info);
};

