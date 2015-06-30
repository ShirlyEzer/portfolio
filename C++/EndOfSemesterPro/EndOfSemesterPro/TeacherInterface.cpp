#include<iostream>
#include<string>
#include"TeacherInterface.h"
#include"Teacher.h"
#include"Course.h"
#include"Student.h"
#include"AllStudents.h"
#include"AllTeachers.h"
void TeacherInterface::WatchMyCourse(Teacher *t) const
{
	int CourseNum;
	cout <<"Enter your Course Number : \n";
	cin >> CourseNum;
	t->SearchCourse(CourseNum)->PrintDetails();
	cout <<endl;
}
void TeacherInterface::WatchMyStudent(Teacher *t) const
{
	long int idS;
	cout <<"Enter your Student ID : \n";
	cin >> idS;
	if ( t->SearchStudent(idS) == 1 )
	{
		AllStudents *List2=AllStudents::GetInstance();
		List2->SearchStudent(idS)->DisplayDetails();
	}
	else
		cout << "You dont have the access to watch the student's detailes\n";
	cout <<endl;
}
void TeacherInterface::DisplayInterface()
{
	int n=5;
	long int id;
	cout <<"Enter your ID : \n";
	cin >> id;	
	AllTeachers *listTE=AllTeachers::GetInstance();
	Teacher *t=listTE->SearchTeacher(id);
	while ( n!=0 )
	{
		cout << "Please choose what you want to do : " << endl;
		cout<< "If you want to watch your Course details please press 1"<<endl;
		cout<< "If you want to watch your Student details please press 2"<<endl;
		cout<< "If you want to exit please press 0"<<endl;
		cin >> n;
		if ( n == 1 )
		{
			system("cls");
			WatchMyCourse(t);
		}
		if ( n == 2 )
		{
			system("cls");
			WatchMyStudent(t);
		}
	}
	cout << "Goodbye!\n"; 
}