#pragma
#ifndef NOTSTUDING_H
#define NOTSTUDING_H
#include "Student.h"
#include <string>
using namespace std;
class NotStuding: public Student
{
public:
	NotStuding(const long int id,const string fname,const string lname,const Address *a,const Date *d):Student(id,fname, lname,a,d){};
	NotStuding();
	void PassDegree();
	~NotStuding();
};
#endif