#include <iostream>
#include <vector>
#include "Address.h"
#include "Date.h"
#include "FirstDegree.h"
#include "NotStuding.h"
#include "Person.h"
#include "SecondDegree.h"
#include "Student.h"
#include "Course.h"
#include "AdvancedFirstDegreeCourse.h"
#include "FirstDegreeCourse.h"
#include "SecondDegreeCourse.h"
#include "Teacher.h"
#include "AllCourses.h"
#include "AllStudents.h"
#include "AllTeachers.h"
#include "AdministrativePeopleInterface.h"
#include "AdministrativePeople.h"
#include "StudentInterface.h"
#include "TeacherInterface.h"
#include "UsersInterface.h"
using namespace std;

void main()
{
	Address a1(9,"ness-zione","nordao");
	Date d1(1,6,1990);
	Address a2(41,"holon","mifratz shlomo");
	Date d2(3,12,1990);
	Address a3(9,"ness-ziona","nordao");
	Date d3(24,5,1964);
	FirstDegree s1(201435484,"oreyan","sabah",&a1,&d1);
	SecondDegree s2(304816499,"shirly","ezer",&a2,&d2);
	NotStuding s3(58502840,"jackline","sabah",&a3,&d3);
	Teacher t1 (256874926,"alexnder","spivak");
	Teacher t2 (365489247,"liat","nakar");
	FirstDegreeCourse c1(2455,"infy 1",'a',&t1,6);
	t1.AddCourse(&c1);
	SecondDegreeCourse c2(3899,"infy 2",'b',&t1,5);
	t1.AddCourse(&c2);
	AdvancedFirstDegreeCourse c3(4566,"c++",'a',&t2,5);
	t2.AddCourse(&c3);
	AllCourses *list1=AllCourses::GetInstance();
	list1->AddCourse(&c1);
	list1->AddCourse(&c2);
	list1->AddCourse(&c3);
	AllStudents *list2=AllStudents::GetInstance();
	list2->AddStudent(&s1);
	list2->AddStudent(&s2);
	list2->AddStudent(&s3);
	AllTeachers *list3=AllTeachers::GetInstance();
	list3->AddTeacher(&t1);
	list3->AddTeacher(&t2);
	
	int choose;
	long int id;
	cout <<"Are you :\n1.Student\n2.Teacher\n3.Administrative\n";
	cin >> choose;
	system ("cls");
	if( choose == 1 )
	{
		StudentInterface S;
		S.DisplayInterface();
	}
	if( choose == 2 )
	{
		TeacherInterface T;
		T.DisplayInterface();
	}
	if( choose == 3 )
	{
		AdministrativePeopleInterface A;
		A.DisplayInterface();
	}
	AllStudents *l1=AllStudents::GetInstance();
	AllCourses *l2=AllCourses::GetInstance();
	l1->DisplayAll();
	l2->DisplayAll();
getchar();
}