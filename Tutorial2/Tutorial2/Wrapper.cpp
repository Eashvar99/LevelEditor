#include "Wrapper.h"
Map map;

PLUGIN_API void locLoad(int _vecSize)
{
	return map.locLoad(_vecSize);
}

PLUGIN_API float* getPos()
{
	return map.getPos();
}

PLUGIN_API int getSize()
{
	return map.getSize();
}

PLUGIN_API void locSave(Coord vecArray[], int vecSize)
{
	return map.locSave(vecArray, vecSize);
}