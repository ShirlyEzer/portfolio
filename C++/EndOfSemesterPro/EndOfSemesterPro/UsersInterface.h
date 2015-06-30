#pragma
#include <iostream>
#ifndef USERSINTERFACE_H
#define USERSINTERFACE_H
using namespace std;
class UsersInterface
{
public:
	UsersInterface(){};
	virtual ~UsersInterface()=0{};
	virtual void DisplayInterface()=0{};
};
#endif