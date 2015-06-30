#pragma
#ifndef FIRSTDEGREE_H
#define FIRSTDEGREE_H
#include "Student.h"
#include <string>
class Course;
using namespace std;
class FirstDegree: public Student
{
public:
	FirstDegree(const long int id,const string fname,const string lname,const Address *a,const Date *d):Student(id,fname,lname,a,d){};
	void PassDegree();
	virtual void AddCourse(Course *c);
	FirstDegree();
	~FirstDegree();
};
#endif