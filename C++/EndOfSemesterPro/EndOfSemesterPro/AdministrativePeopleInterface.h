#pragma
#ifndef ADMINISTTRATIVEPEOPLEINTERFACE_H
#define ADMINISTTRATIVEPEOPLEINTERFACE_H
#include <string>
#include <iostream>
using namespace std;
#include "UsersInterface.h"
class AllStudents;
class Teacher;
class AllCourses;
class Student;
class Date;
class Address;
class AdministrativePeopleInterface : public UsersInterface
{
public:
	AdministrativePeopleInterface():UsersInterface(){};
	~AdministrativePeopleInterface(){};
	void DisplayInterface();
	void CreateStudent()const;
	void ChangeFname()const;
	void ChangeLname()const;
	void ChangeAddress()const;
	void RegisterCourse()const;
	void CreateCourse()const;
	void ChangeCourse()const;
	void ChangeStudentGrade()const;
	void AddTeacher()const;
	void DisplayAllStudents()const;
	void DisplayAllCourses()const;
};

#endif