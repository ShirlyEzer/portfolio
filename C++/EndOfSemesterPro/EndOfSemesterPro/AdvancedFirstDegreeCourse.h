#pragma
#ifndef ADVANCEDFIRSTDEGREECOURSE_H
#define ADVANCEDFIRSTDEGREECOURSE_H
#include <string>
#include "Student.h"
#include "Course.h"
#include "Teacher.h"
using namespace std;
class AdvancedFirstDegreeCourse : public Course
{
public:
	AdvancedFirstDegreeCourse(const int Cnum,const string Cname,const char s,Teacher *t,const int p):Course(Cnum,Cname,s,t,p){};
	AdvancedFirstDegreeCourse(){}; 
	~AdvancedFirstDegreeCourse(){};
};
#endif