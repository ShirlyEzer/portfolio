#pragma
#ifndef SECONDDEGREECOURSE_H
#define SECONDDEGREECOURSE_H
#include <string>
#include "Student.h"
#include "Course.h"
#include "Teacher.h"
using namespace std;
class SecondDegreeCourse : public Course
{
public:
	SecondDegreeCourse(const int Cnum,const string Cname,const char s,Teacher *t,const int p):Course(Cnum,Cname,s,t,p){};
	SecondDegreeCourse(){};
	~SecondDegreeCourse(){};
};
#endif