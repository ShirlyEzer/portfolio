//Project number 3 -Input & Output Device
//Written by shirly ezer, ID: 304816499
//InputDevice.h
#pragma
#ifndef INPUT_DEVICE_H
#define INPUT_DEVICE_H
class InputDevice
{
public:
	InputDevice() {};
	virtual char Get_Char() const =0;
	virtual int End_Of_Input(const char) const =0;
};
#endif
// 2 of 8