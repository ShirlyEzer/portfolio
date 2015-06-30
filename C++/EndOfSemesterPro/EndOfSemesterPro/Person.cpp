#include <iostream>
#include "Person.h"
#include <string>
using namespace std;
Person :: Person(long int id,string fname,string lname):ID(id)
{
	setFname(fname);
	setLname(lname);
}
Person:: ~Person()
{
}
void Person:: setFname(const string fname)
{
	Fname=fname;
}
void Person:: setLname(const string lname)
{
	Lname=lname;
}
long int Person:: getID()const 
{
	return ID;
}
string Person:: getFname()const 
{
	return Fname;
}
string Person:: getLname()const 
{
	return Lname;
}