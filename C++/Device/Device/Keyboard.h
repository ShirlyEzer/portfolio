//Project number 3 -Input & Output Device
//Written by shirly ezer, ID: 304816499
//Keyboard.h
#pragma
#ifndef KEYBOARD_H
#define KEYBOARD_H
#include "Input_Device.h"
class Keyboard : public InputDevice
{
public:
	Keyboard() {}; //Constructor
	virtual char Get_Char() const; //Returns the Char recieved
	virtual int End_Of_Input(const char) const; //Checks the char recieved, returns 1 if recieved ~
	~Keyboard () {}; //Destructor
};
#endif
// 4 of 8