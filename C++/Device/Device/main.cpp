//Project number 3 -Input & Output Device
//Written by shirly ezer, ID: 304816499
//main.cpp
#include <iostream>
#include "Input_Device.h"
#include "Output_Device.h"
#include "Keyboard.h"
#include "Screen.h"

using namespace std;

void Copy (InputDevice *, OutputDevice *);

void main ()
{
	InputDevice *In = new Keyboard;
	OutputDevice *Out = new Screen;
	cout <<"Write what ever you want..."<<endl;
	Copy (In,Out);
	cout <<endl<<"GoodBye \3"<<endl;
}
// 8 of 8

