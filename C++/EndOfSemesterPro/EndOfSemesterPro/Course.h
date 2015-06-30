#pragma
#ifndef COURSE_H
#define COURSE_H
#include <string>
class Student;
class Teacher;
#include <vector>

using namespace std;
class Course
{
public:
	Course(const int Cnum,const string Cname,const char s,Teacher *t,const int p);
	Course(){};
	vector <Student *>& getVector ();
	virtual ~Course()=0;
	void AddStusent(Student *s);
	void setCourseNumber(const int Cnum);
	void setNameOfCourse(const string Cname);
	void setSemester(const char s);
	void setTeacher(Teacher *t);
	void setPoint(const int p);
	void setPreCourse(int i,int CourseNum);
	int getCourseNumber()const;
	string getNameOfCourse()const;
	char getSemester()const;
	Teacher* getTeacher()const;
	int getPoint()const;
	int getPreCourse(int i)const;
	void PrintDetails()const;
	int HowManyStudents()const;
private:
	int CourseNumber;
	string NameOfCourse;
	char Semester;
	Teacher *teach;
	int point;
	vector < Student * > mySt;
	int PreCourse[5];
};
#endif