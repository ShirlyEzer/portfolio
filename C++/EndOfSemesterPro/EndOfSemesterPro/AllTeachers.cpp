#include <iostream>
#include "Teacher.h"
#include "AllTeachers.h"
#include <vector>
using namespace std;
AllTeachers* AllTeachers::myInstance=0;
AllTeachers::AllTeachers()
{
}
AllTeachers* AllTeachers::GetInstance () // Checking if there is already existed list of students
{
	if (!myInstance)
		myInstance = new AllTeachers;
	return myInstance;
}
AllTeachers::~AllTeachers()
{
}
vector <Teacher*>& AllTeachers:: getVector()
{
	return ListTeach;
}
void AllTeachers:: AddTeacher(Teacher *t)
{
	ListTeach.push_back(t);
}
Teacher * AllTeachers:: SearchTeacher(const long int id)const
{
	for(std::size_t i=0; i<ListTeach.size(); i++)
	{
		if(ListTeach[i]->getID()==id)
			return ListTeach[i];
	}
	return NULL;
}