#pragma once
#include "PluginSettings.h"
#include "Map.h"
#ifdef __cplusplus
extern "C"
{
#endif
	// Put your functions here
	PLUGIN_API void locLoad(int _vecSize);
	PLUGIN_API float* getPos();
	PLUGIN_API int getSize();
	PLUGIN_API void locSave(Coord vecArray[], int vecSize);

#ifdef __cplusplus
}
#endif