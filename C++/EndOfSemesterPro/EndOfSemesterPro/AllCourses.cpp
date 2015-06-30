#include <iostream>
#include "AllCourses.h"
#include <vector>
#include "Course.h"
using namespace std;
AllCourses* AllCourses::myInstance=0;
AllCourses::AllCourses()
{
}
AllCourses* AllCourses:: GetInstance ()
{
	if (!myInstance)
		myInstance = new AllCourses;
	return myInstance;
}
AllCourses::~AllCourses()
{
}
vector <Course*>& AllCourses:: getVector()
{
	return ListCo;
}
void AllCourses:: AddCourse(Course *c) //מוסיפה קורס בקטלוג לא לרשימה של הקורסים של הסטודנט
{
	int n;
	cout<<"Are there any Pre-Courses to this Course?\n1. yes\n2. no"<<endl;
	cin >>n;
	if (n==1)
	{
		cout<<"Enter the number of the Courses till 0 (there is only 5 Pre-Courses possible)"<<endl;
		cin>> n;
		int i=0;
		while (n!=0 && i<5)
		{
			c->setPreCourse(i,n);
			cin>> n;
		}
	}
	ListCo.push_back(c);
	system("cls");
}
Course* AllCourses:: SearchCourse(const int courseNum) const
{
	for (size_t i=0; i<ListCo.size();i++)
	{
		if (ListCo[i]->getCourseNumber()==courseNum)
			return ListCo[i];
	}
	return NULL;
}
void AllCourses::DisplayAll() const
{
	for (size_t i=0;i<ListCo.size();i++)
		ListCo[i]->PrintDetails();
}