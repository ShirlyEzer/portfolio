#pragma
#ifndef FIRSTDEGREECOURSE_H
#define FIRSTDEGREECOURSE_H
#include <string>
#include "Student.h"
#include "Course.h"
#include "Teacher.h"
using namespace std;
class FirstDegreeCourse : public Course
{
public:
	FirstDegreeCourse(const int Cnum,const string Cname,const char s,Teacher *t,const int p):Course(Cnum,Cname,s,t,p){};
	FirstDegreeCourse(){};
	~FirstDegreeCourse(){};
};
#endif