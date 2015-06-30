#include <iostream>
#include "FirstDegree.h"
#include "AdvancedFirstDegreeCourse.h"
#include "FirstDegreeCourse.h"
#include "Student.h"
#include "Course.h"
#include "SecondDegreeCourse.h"
#include <vector>
#include <typeinfo>
using namespace std;
FirstDegree ::	FirstDegree():Student()
{
}
FirstDegree:: ~FirstDegree()
{
}
void FirstDegree:: PassDegree()
{
	int countFcourse=0;
	int countFADVcourse=0;
	AdvancedFirstDegreeCourse *a=NULL;
	FirstDegreeCourse *c=NULL;
	for(std::size_t i=0; i< this->getVector().size(); i++)
	{
		countFcourse+=this->getVector()[i].c->getPoint();
		if(typeid(this->getVector()[i])==typeid(a))
		{
			countFADVcourse+=this->getVector()[i].c->getPoint();
		}
	}
	if(countFcourse>=20)
	{
		if(countFADVcourse>=5)
		{
			cout << "You pass First Degree Successfully\n";
		}
		cout <<"You need at least 5 pointd in Advenced First Degree courses\n";
	}
	else
		cout << "Your total points are not enough to pass the First Degree\n";
}
void FirstDegree::AddCourse(Course *c)
{
	int f=0;
	if(typeid(*c)!=typeid(SecondDegreeCourse))
	{
		if ( c->HowManyStudents() < 150) // cheking if there is open place in course
			{
				for ( int i=0 ; i<5 ; i++ ) // searching the pre courses in Student course list
				{
					int num=c->getPreCourse(i);
					if (num !=0)
					{
						if( this->SearchCourse(num) )   // checking if there is such course existed
						{
							cout <<"You cant register the student to this course he didnt completed the Pre-Course number :" << num << endl;
							f=1;
						}
						else if(this->SearchCourse(num)->grade < 60) // checking the course final grade
						{
								cout <<"The student failed the Pre-Course number :"<< num << endl;
								f=1;
						}
					}
				}
				if( f==1 )
					cout << "Register Student to the course failed\n";
				else
				{
					CourseDetails temp;
					temp.c=c;
					temp.grade=0;
					this->getVector().push_back(temp);
					c->AddStusent(this);
					c->getTeacher()->getStudentsVector().push_back(this->getID()); /// In the Course we take th Teacher and then we take the Teacher's StudentVector and add the Student ID to the Students list
					cout << "Register succeeded\n";
				}
		}
		else cout <<"There is no place left to register the student\n";
	}
	
	else cout << "You can not register First degree student to Second degree course\n";
	cout <<endl;
	
}