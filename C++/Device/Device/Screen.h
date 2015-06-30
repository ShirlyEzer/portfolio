//Project number 3 -Input & Output Device
//Written by shirly ezer, ID: 304816499
//Screen.h
#pragma
#ifndef SCREEN_H
#define SCREEN_H
#include "Output_Device.h"
class Screen : public OutputDevice
{
public:
	Screen() {}; //Constructor
	virtual void Put_Char(const char) const; //Prints on Screen char
	~Screen() {}; //Destructor
};
#endif
// 3 of 8