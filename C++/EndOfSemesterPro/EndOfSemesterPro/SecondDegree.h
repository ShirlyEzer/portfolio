#pragma
#ifndef SECONDDEGREE_H
#define SECONDDEGREE_H
#include "Student.h"
#include <string>
using namespace std;
class SecondDegree: public Student
{
public:
	SecondDegree(const long int id,const string fname,const string lname,const Address *a,const Date *d):Student(id,fname, lname,a,d){};
	SecondDegree();
	~SecondDegree();
	void PassDegree();
};
#endif