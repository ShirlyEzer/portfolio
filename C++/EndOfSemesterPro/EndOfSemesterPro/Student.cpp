#include <iostream>
#include <vector>
#include "Student.h"
#include "Course.h"
#include "Teacher.h"
using namespace std;
Student:: Student(const long int id,const string fname,const string lname,const Address *a,const Date *d):Person( id,fname, lname)
{
	setDate(d);
	setAddress(a);
	setAvg();
}
Student::~Student()
{
}
void Student:: setDate(const Date *d)
{
	BirthDay=*d;
}
void Student:: setAddress(const Address *add)
{
	Add=*add;
}
void Student:: setAvg ()
{
	int sum=0;
	for(int i=0; i<myCourses.size(); i++)
	{
		sum+=myCourses[i].grade;
	}
	if (myCourses.size()!=0)
		avg=(sum/myCourses.size());
	else avg=0;
}
void Student:: setPoint()
{
	int p=0;
	for (int i=0;i<myCourses.size();i++)
	{
		if ( myCourses[i].grade > 60)
			p+=myCourses[i].c->getPoint();
	}
	point=p;
}
Date Student:: getDate()const
{
	return BirthDay;
}
Address Student:: getAddress()const
{
	return Add;
}
double Student:: getAvg()const
{
	return avg;
}
int Student:: getPoint()const
{
	return point;
}
vector <CourseDetails>& Student:: getVector()
{
	return myCourses;
}
void Student:: AddCourse(Course *c) /// virtual function every inheritence class use this function diffrentely
{
	int f=0;
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
void Student:: DisplayDetails()const
{
	cout <<"--------Student Info----------"<<endl;
	cout << "First name : "<<this->getFname() <<endl;
	cout << "Lname name : "<<this->getLname() <<endl;
	cout << "ID : "<<this->getID() <<endl;
	cout << "Date of birth : " << BirthDay;
	cout << "Address : " << Add;
	cout << "Average is : " << avg << endl;
	cout << "Total points : " << point << endl;
	if (myCourses.size() > 0 )
	{
		cout << "Your Courses :\n" ;
		for(size_t i=0; i<myCourses.size();i++)
		{
			myCourses[i].c->PrintDetails();
			cout<<"the Course grade : "<<myCourses[i].grade<<endl;
		}
	}
	cout <<endl;
}
CourseDetails* Student:: SearchCourse(const int courseNum)
{
	for (std::size_t i=0; i<myCourses.size();i++)
	{
		if (myCourses[i].c->getCourseNumber()==courseNum)
			return &myCourses[i];
	}
	cout << "There is Not such Course existed\n";
	return NULL;
}
void Student::PassDegree()
{
	cout <<"The Student didnt pass Degree"<<endl;
}