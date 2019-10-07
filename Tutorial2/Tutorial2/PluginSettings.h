#pragma once

//Plugin Code by Tom Tsiliopoulus
#ifdef MAP_EXPORTS
#define PLUGIN_API __declspec(dllexport)
#elif MAP_IMPORTS
#define PLUGIN_API __declspec(dllimport)
#else
#define PLUGIN_API
#endif
