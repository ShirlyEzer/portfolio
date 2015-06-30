#include<iostream>
#include<string>
#include"StudentInterface.h"
#include"AllStudents.h"
#include"Student.h"
void StudentInterface::DisplayInterface()
{
	long int id;
	int n=5;
	cout <<"Enter your ID : \n";
	cin >> id;
	AllStudents *listST=AllStudents::GetInstance();
	Student *s=listST->SearchStudent(id);
	system("cls");
	while ( n!=0 )
	{
		cout << "Please choose what you want to do : " << endl;
		cout<< "If you want to watch details please press 1"<<endl;
		cout<< "If you want to check whether you pass the degree or not press 2"<<endl;
		cout<< "If you want to exit please press 0"<<endl;
		cin >> n;
		if ( n == 1 )
		{
			system("cls");
			WatchDetailes(s);
		}
		if ( n == 2 )
		{
			system("cls");
			StudentPassDegree(s);
		}
	}
	cout << "Goodbye!\n"; 
}
void StudentInterface::WatchDetailes(Student *s) const
{
	s->DisplayDetails();
	cout <<endl;
}
void StudentInterface::StudentPassDegree(Student *s) const
{
	s->PassDegree();
	cout <<endl;
}