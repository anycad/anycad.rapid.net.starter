#include "pch.h"
#include "MyNativePlugin.h"
#include "ExtrudeAlgo.h"

bool MyNativePlugin::Initialize()
{
	MyLibrarySharp::AlgoManager::Extrude = gcnew ExtrudeAlgo();

	return true;
}