#include "Map.h"

float* Map::getPos()
{
	return out;
}

int Map::getSize()
{
	return arrSize;
}

void Map::locLoad(int _vecSize)
{
	i = 0;

	ifstream text;

	char inputString[CHAR_BUFFER_SIZE];

	out = new float[_vecSize];

	float temp;

	text.open("Map.txt");
	
	if (text.is_open()) 
	{

		while(!text.eof())
		{
			text.getline(inputString, CHAR_BUFFER_SIZE);
			sscanf(inputString, "%f", &out[i]);
			
			i++;
		}
	}	

	text.close();
}

void Map::locSave(Coord vecArray[], int vecSize)
{
	ofstream text;
	text.open("Map.txt");
	arrSize = vecSize;

	//text << vecSize << endl;

	for (int i = 0; i < (vecSize/4); i++)
	{
		text << vecArray[i].x << endl;
		text << vecArray[i].y << endl;
		text << vecArray[i].z << endl;
		text << vecArray[i].item << endl;
	}	
	text.close();
}
