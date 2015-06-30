#pragma
#ifndef STUDENT_H
#define STUDENT_H
#include <string>
#include <vector>
#include "Person.h"
#include "Address.h"
#include "Date.h"
class Course;
using namespace std;
struct CourseDetails
{
	Course *c;
	int grade;
}; 
class Student: public Person
{
public:
	Student(const long int id,const string fname, const string lname,const Address *a,const Date *d);
	Student(){};
	vector <CourseDetails>& getVector();
	virtual ~Student()=0;
	void setDate(const Date *d);
	void setAddress(const Address *add);
	void setAvg ();
	void setPoint();
	Date getDate()const;
	Address getAddress()const;
	double getAvg()const;
	int getPoint()const;
	virtual void AddCourse(Course *c);
	void DisplayDetails()const;
	CourseDetails* SearchCourse(const int courseNum);
	virtual void PassDegree();
private:
	Date BirthDay;
	Address Add;
	double avg;
	int point;
	vector <CourseDetails> myCourses;
};
#endif