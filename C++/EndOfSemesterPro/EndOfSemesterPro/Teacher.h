#pragma
#ifndef TEACHER_H
#define TEACHER_H
#include <string>
#include <vector>
#include "Person.h"
class Course;
class Student;
using namespace std;
class Teacher: public Person
{
public:
	vector <Course*>& getVector();
	vector <long int>& getStudentsVector();
	Teacher(const long int id,const string fname,const string lname);
	Teacher():Person(){};
	~Teacher();
	void AddCourse(Course *c);
	void AddStudent(long int id);
	Course* SearchCourse(const int courseNum)const;
	int SearchStudent(const long int id)const;
	void PrintDetails() const;
private:
	vector <Course*> myCourses;
	vector <long int> myStudents;
};
#endif