#pragma
#ifndef ALLTEACHERS_H
#define ALLTEACHERS_H
#include <string>
#include <vector>
class Teacher;
using namespace std;
class  AllTeachers
{
public:
	static AllTeachers* GetInstance ();
	~AllTeachers();
	vector <Teacher*>& getVector();
	void AddTeacher(Teacher *s);
	Teacher* SearchTeacher(const long int id)const;
private:
	AllTeachers();
	vector <Teacher*> ListTeach;
	static AllTeachers* myInstance;
};
#endif