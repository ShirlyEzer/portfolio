#include <iostream>
#include <string>
#include "UsersInterface.h"
#include "AllStudents.h"
#include "AllTeachers.h"
#include "Teacher.h"
#include "AllCourses.h"
#include "Date.h"
#include "Address.h"
#include "AdministrativePeopleInterface.h"
#include "Student.h"
#include "FirstDegree.h"
#include "SecondDegree.h"
#include "NotStuding.h"
#include "Course.h"
#include "FirstDegreeCourse.h"
#include "SecondDegreeCourse.h"
#include "AdvancedFirstDegreeCourse.h"
using namespace std;
void AdministrativePeopleInterface:: DisplayInterface() 
{
	int n=5;	
	while ( n!=0 )
	{
		cout << "Please choose what you want to do : " << endl;
		cout<< "If you want to create new student please press 1"<<endl;
		cout<< "If you want to change student's first name please press 2"<<endl;
		cout<< "If you want to change student's last name please press 3"<<endl;
		cout<< "If you want to change student's address please press 4"<<endl;
		cout<< "If you want to register student to course please press 5"<<endl;
		cout<< "If you want to create new course please press 6"<<endl;
		cout<< "If you want to change course details please press 7"<<endl;
		cout<< "If you want to change student's grade in a course please press 8"<<endl;
		cout<< "If you want to add teacher to the system please press 9"<<endl;
		cout<< "If you want to see all students list please press 10"<<endl;
		cout<< "If you want to see all courses list please press 11"<<endl;
		cout<< "If you want to exit please press 0"<<endl;
		cin >> n;
		if ( n == 1 )
		{
			system("cls");
			CreateStudent();
		}
		if ( n == 2 ) 
		{
			system("cls");
			ChangeFname();
		}
		if ( n == 3 ) 
		{
			system("cls");
			ChangeLname();
		}
		if ( n == 4 ) 
		{
			system("cls");
			ChangeAddress();
		}
		if ( n == 5 )
		{
			system("cls");
			RegisterCourse();
		}
		if ( n == 6 )
		{
			system("cls");
			CreateCourse();
		}
		if ( n == 7 )
		{
			system("cls");
			ChangeCourse();
		}
		if ( n == 8 )
		{
			system("cls");
			ChangeStudentGrade();
		}
		if ( n == 9 )
		{
			system("cls");
			AddTeacher();
		}
		if ( n == 10 )
		{
			system("cls");
			DisplayAllStudents();
		}
		if ( n == 11 )
		{
			system("cls");
			DisplayAllCourses();
		}
	}
	cout << "Goodbye!\n"; 
}
void AdministrativePeopleInterface:: CreateStudent() const
{
	Address a;
	string fname;
	string lname;
	long int id;
	Date d;
	int n;
	Student *s1=NULL;
	cout << "Please Enter the student First Name\n";
	cin >> fname;
	cout << "Please Enter the student Last Name\n";
	cin >> lname;
	cout << "Please Enter the student ID\n";
	cin >> id;
	cout << "Please Enter the student Address (number of block , street and city)\n";
	cin >> a;
	cout << "Please Enter the student Date of Birth\n";
	cin >> d;
	AllStudents *list=AllStudents::GetInstance();
	cout << "Which kind of student?\n1.First Degree\n2.Second Degree\n3.Not Studing\n";
	cin >>n;
	if(n==1)
		s1=new FirstDegree (id,fname,lname,&a,&d);
	if(n==2)
		s1=new SecondDegree (id,fname,lname,&a,&d);
	if(n==3)
		s1=new NotStuding (id,fname,lname,&a,&d);
	list->AddStudent(s1);
	cout << "Register succeeded\n";
	cout <<endl;
}
void AdministrativePeopleInterface:: ChangeFname() const
{
	long int id;
	string fname;
	cout << "Please Enter the Student ID\n";
	cin >> id;
	cout << "Please Enter the new First Name :\n";
	cin >> fname;
	AllStudents *list=AllStudents::GetInstance();
	Student *s=list->SearchStudent(id);
	if (s!=NULL)
		s->setFname(fname);
	else
		cout<<"Student not found\n";
	cout <<endl;
}
void AdministrativePeopleInterface:: ChangeLname() const
{
	long int id;
	string lname;
	cout << "Please Enter the Student ID\n";
	cin >> id;
	cout << "Please Enter the new Last Name :\n";
	cin >> lname;
	AllStudents *list=AllStudents::GetInstance();
	Student *s=list->SearchStudent(id);
	if (s!=NULL)
		s->setLname(lname);
	else
		cout<<"Student not found\n";
	cout <<endl;
}
void AdministrativePeopleInterface:: ChangeAddress()const
{
	long int id;
	string lname;
	cout << "Please Enter the Student ID\n";
	cin >> id;
	Address add;
	cout << "Please Enter the new Address (number of block , street and city)\n";
	cin >> add;
	AllStudents *list=AllStudents::GetInstance();
	Student *s=list->SearchStudent(id);
	if (s!=NULL)
		s->setAddress(&add);
	else
		cout<<"Student not found\n";
	cout <<endl;
}
void AdministrativePeopleInterface:: RegisterCourse() const
{
	int f=0;
	long int id;
	int courseNum;
	cout << "Please Enter the Student ID\n";
	cin >> id;
	cout << "Please Enter Course Number\n";
	cin >> courseNum;
	AllCourses *catalog=AllCourses::GetInstance();   // to get the instance of all courses
	Course *c=catalog->SearchCourse(courseNum); // to search in AllCourses the specific course
	AllStudents *list=AllStudents::GetInstance();  // to get the instance of all studenst
	Student *s=list->SearchStudent(id); //to search in All students the specific student
	s->AddCourse(c);
}
void AdministrativePeopleInterface :: CreateCourse()  const
{
	AllTeachers *List=AllTeachers:: GetInstance(); // to get the instance of all teachers list
	AllCourses *list=AllCourses::GetInstance(); // to get the instance of all courses list 
	int n;
	Course *c1=NULL;
	long int id;
	int Cnum;
	string Cname;
	char s;
	Teacher *t;
	int p;
	// to create a course we need all the details of the course
	cout << "Please Enter the Course Number\n";
	cin >> Cnum;
	cout << "Please Enter the Course Name\n";
	cin >> Cname;
	cout << "Enter the Teacher ID\n";
	cin >> id;
	t=List->SearchTeacher(id);
	cout << "Enter the Course Academic points\n";
	cin >> p;
	cout << "Enter the semester of the course Course \n";
	cin >> s;
	cout << "Which kind of course?\n1.Course For First Degree\n2.Advanced Course For First Degree\n3.Course For Second Degree\n \n";
	cin >>n;
	if(n==1)
		c1=new FirstDegreeCourse (Cnum,Cname,s,t,p);
	if(n==2)
		c1=new AdvancedFirstDegreeCourse (Cnum,Cname,s,t,p);
	if(n==3)
		c1=new SecondDegreeCourse (Cnum,Cname,s,t,p);
	list->AddCourse(c1); // we added the course to the courses catalog
	t->AddCourse(c1); // we added the course to the teacher courses list
	cout <<endl;
}
void AdministrativePeopleInterface:: ChangeCourse()  const
{
	int courseNum;
	AllCourses *list=AllCourses::GetInstance();
	cout << "Please Enter the Course Number \n ";
	cin >>courseNum;
	Course *c=list->SearchCourse(courseNum);
	int n;

	if (c!=NULL)
	{
		n=5;
		while ( n!= 0)
		{
			cout <<"If you want to change the course number please press 1"<<endl;
			cout <<"If you want to change the name of course  please press 2"<<endl;
			cout <<"If you want to change the point please press 3"<<endl;
			cout <<"If you want to change the semester please press 4"<<endl;
			cout <<"If you want to exit please press 0"<<endl;
			cin >> n;
			if (n==1)
			{
				cout<<"Please enter the new course number"<<endl;
				cin >>n;
				c->setCourseNumber(n);
			}
			if (n==2)
			{
				string s;
				cout<<"Please enter the new course name"<<endl;
				cin >>s;
				c->setNameOfCourse(s);
			}
			if (n==3)
			{
				cout<<"Please enter the new point"<<endl;
				cin >>n;
				c->setPoint(n);
			}
			if (n==4)
			{
				char s;
				cout<<"Please enter the new semester"<<endl;
				cin >>s;
				c->setSemester(s);
			}
			if ( n == 0 )
				cout << "Goodbye\n";
		}
	}
	else
		cout<<"The course is not exist "<<endl;
	cout <<endl;
}
void AdministrativePeopleInterface:: ChangeStudentGrade() const
{
	long int id;
	int CourseNum;
	int g;
	int n;
	cout << "Please Enter the Student ID\n";
	cin >> id;
	cout << "Please Enter the Course Number \n ";
	cin >>CourseNum;
	AllStudents *list=AllStudents::GetInstance();  // to get the instance of all studenst
	Student *s=list->SearchStudent(id); //to search in All the specific student
	CourseDetails *temp=s->SearchCourse(CourseNum); // search in StudentsCourses the specific course
	if (temp != NULL) // CHECKING IF THERE IS SUCH COURSE EXISTED IN STUDENT COURSES
	{
		
		cout << "Please Enter The Student Grade\n";
		cin >>g;
		temp->grade=g;
		// UPDATE STUDENT AVERAGE
		s->setAvg();
	}
	else
		cout<< "The student doesnt study this course"<<endl;
	if ( g < 60 )
	{
		cout << "Student failed the Course , Do you want to register the student to the course again?\n 1.Yes\n 2.No\n";
		cin >> n;
		if( n==1 )
			RegisterCourse();
	}
	cout <<endl;
}
void AdministrativePeopleInterface::AddTeacher() const
{
	string fname,lname;
	long int id;
	cout << "Please enter the ID of the teacher\n";
	cin >> id;
	cout<< "Please enter the First name of the teacher\n";
	cin >> fname;
	cout<< "Please enter the last name of the teacher\n";
	cin >> lname;
	Teacher t(id,fname,lname);
	AllTeachers *list=AllTeachers::GetInstance(); // to get the instance of all studenst
	list->AddTeacher(&t);
	cout<<endl;
}
void AdministrativePeopleInterface::DisplayAllStudents() const
{
	AllStudents *list=AllStudents::GetInstance();  // to get the instance of all studenst
	list->DisplayAll();
}
void AdministrativePeopleInterface::DisplayAllCourses() const
{
	AllCourses *list=AllCourses::GetInstance();  // to get the instance of all studenst
	list->DisplayAll();
}