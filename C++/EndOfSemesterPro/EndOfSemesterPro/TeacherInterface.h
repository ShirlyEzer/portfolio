#pragma
#ifndef TEACHERINTERFACE_H
#define TEACHERINTERFACE_H
#include "UsersInterface.h"
using namespace std;
class Teacher;

class TeacherInterface : public UsersInterface
{
public:
	TeacherInterface():UsersInterface(){};
	~TeacherInterface(){};
	void DisplayInterface();
	void WatchMyCourse(Teacher *t) const;
	void WatchMyStudent(Teacher *t) const;
};

#endif