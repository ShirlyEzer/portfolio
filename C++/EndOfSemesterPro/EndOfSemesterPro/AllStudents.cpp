#include <iostream>
#include "Student.h"
#include "AllStudents.h"
#include <vector>
using namespace std;
AllStudents* AllStudents::myInstance=0;
AllStudents::AllStudents()
{
}
AllStudents* AllStudents::GetInstance () // Checking if there is already existed list of students
{
	if (!myInstance)
		myInstance = new AllStudents;
	return myInstance;
}
AllStudents::~AllStudents()
{
}
vector <Student*>& AllStudents:: getVector()
{
	return ListSt;
}
void AllStudents:: AddStudent(Student *s)
{
	ListSt.push_back(s);
}
Student * AllStudents:: SearchStudent(const long int id)const
{
	for(size_t i=0; i<ListSt.size(); i++)
	{
		if(ListSt[i]->getID()==id)
			return ListSt[i];
	}
	return NULL;
}
void AllStudents::DisplayAll() const
{
	for (size_t i=0; i<ListSt.size() ; i++)
		ListSt[i]->DisplayDetails();
}