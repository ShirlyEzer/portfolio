#include "Teacher.h"
#include "Person.h"
#include "Course.h"
#include "Student.h"
#include <iostream>
#include <vector>
using namespace std;
Teacher::Teacher(const long int id,const string fname,const string lname):Person(id,fname, lname)
{
}
Teacher::~Teacher()
{
}
vector <Course*>& Teacher:: getVector()
{
	return myCourses;
}
void Teacher ::AddCourse(Course *c)
{
	myCourses.push_back(c);
}
void Teacher::AddStudent(long int id)
{
	myStudents.push_back(id);
}
Course* Teacher:: SearchCourse(const int courseNum) const
{
	for (std::size_t i=0; i<myCourses.size();i++)
	{
		if (myCourses[i]->getCourseNumber()==courseNum)
			return myCourses[i];
	}
	return NULL;
}
vector <long int>& Teacher::getStudentsVector()
{
	return myStudents;
}
int Teacher::SearchStudent(const long int id) const
{
	for (std::size_t i=0; i<myStudents.size();i++)
	{
		if (myStudents[i]==id)
			return 1;
	}
	return 0;
}
void Teacher::PrintDetails() const
{
	cout <<"--------Teacher Info----------"<<endl;
	cout << "First name : "<<this->getFname() <<endl;
	cout << "Lname name : "<<this->getLname() <<endl;
	cout << "ID : "<<this->getID() <<endl;
	if (myCourses[0] != NULL)
	{
		cout <<"Your courses : "<<endl;
		for (size_t i=0;i<myCourses.size();i++)
			myCourses[i]->PrintDetails();
	}

}