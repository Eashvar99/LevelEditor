#pragma once
#define _CRT_SECURE_NO_WARNINGS

#include "PluginSettings.h"

#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std; 
#define CHAR_BUFFER_SIZE 128

struct Coord
{
	float x;
	float y;
	float z;
	float item;
};

class PLUGIN_API Map
{
public:
	int getSize();
	float* getPos();
	void locLoad(int _vecSize);
	void locSave(Coord vecArray[], int vecSize);
	int arrSize;
	int i = 0;
	float* out = 0;
	float locs[];
};