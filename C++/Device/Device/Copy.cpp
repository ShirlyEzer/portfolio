//Project number 3 -Input & Output Device
//Written by shirly ezer, ID: 304816499
//Copy.cpp Global Function
#include <iostream>
#include "Input_Device.h"
#include "Output_Device.h"
using namespace std;

void Copy (InputDevice *k, OutputDevice *s)  //Gets 2 objects and Copy from keyboard to screen
{
	char c=k->Get_Char();
	while ( k->End_Of_Input(c) != 1)
	{
		s->Put_Char(c);
		c= k->Get_Char();
	}
}
// 7 of 8