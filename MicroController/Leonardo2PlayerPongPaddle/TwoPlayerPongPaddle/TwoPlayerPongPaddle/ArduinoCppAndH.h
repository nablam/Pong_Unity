// ArduinoCppAndH.h

#ifndef _ArduinoCppAndH_h
#define _ArduinoCppAndH_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

void CppandHFunction() {}

#endif

