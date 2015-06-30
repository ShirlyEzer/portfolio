//Project number 3 -Input & Output Device
//Written by shirly ezer, ID: 304816499
//Keyboard.cpp
#include <iostream>
#include "Keyboard.h"
using namespace std;

char Keyboard:: Get_Char() const
{
	char c;
	c=getchar();
	return c;
}
int Keyboard::End_Of_Input(const char c) const
{
	if (c=='~')
		return 1;
	return 0;
}
// 6 of 8
