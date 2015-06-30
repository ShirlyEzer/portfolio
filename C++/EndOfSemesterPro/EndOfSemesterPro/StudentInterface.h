#pragma
#include <iostream>
#ifndef STUDENTINTERFACE_H
#define STUDENTINTERFACE_H
#include "UsersInterface.h"
using namespace std;
class AllStudents;
class Student;
class StudentInterface : public UsersInterface
{
public:
	StudentInterface():UsersInterface(){};
	~StudentInterface(){};
	void DisplayInterface();
	void WatchDetailes(Student *s) const;
	void StudentPassDegree(Student *s) const;
};

#endif