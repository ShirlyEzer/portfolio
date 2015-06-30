#include "Course.h"
#include "Teacher.h"
#include <iostream>
#include "Student.h"
#include <string>
#include "Student.h"
using namespace std;

Course::Course(const int Cnum,const string Cname,const char s,Teacher *t,const int p) 
{
	setCourseNumber(Cnum);
	setNameOfCourse(Cname);
	setTeacher(t);
	setSemester(s);
	setPoint(p);
	for (int i=0;i<5;i++)
		PreCourse[i]=0;
}
Course:: ~Course()
{
}
vector <Student *>& Course::getVector ()
{
	return mySt;
}
void Course::AddStusent(Student *s)
{
	mySt.push_back(s);
}
void Course::setCourseNumber(const int Cnum)
{
	CourseNumber=Cnum;
}
void Course::setNameOfCourse(const string Cname)
{
	NameOfCourse=Cname;
}
void Course::setSemester(const char s)
{
	Semester=s;
}
void Course::setTeacher(Teacher *t)
{
	teach=t;
}
void Course::setPoint(const int p)
{
	point=p;
}
void Course::setPreCourse(int i,int CourseNum)
{
	PreCourse[i]=CourseNum;
}
int Course::getPreCourse(int i) const
{
	return PreCourse[i];
}
int Course::getCourseNumber()const
{
	return CourseNumber;
}
string Course::getNameOfCourse()const
{
	return NameOfCourse;
}
char Course::getSemester()const
{
	return Semester;
}
Teacher* Course::getTeacher()const
{
	return this->teach;
}
int Course::getPoint()const
{
	return point;
}
void Course::PrintDetails()const
{
	cout << "Course Number : " << CourseNumber<<endl;
	cout << "Name of Course : " << NameOfCourse<<endl;
	cout << "Semster is : " << Semester << endl;
	cout << "Num of student registered : " << mySt.size() << endl<<endl;
}
int Course::HowManyStudents() const
{
	return mySt.size();
}