#pragma
#ifndef ADMINISTRATIVEPEOPLE_H
#define ADMINISTRATIVEPEOPLE_H
#include <string>
#include "Person.h"
using namespace std;
class AdministrativePeople: public Person
{
public:
	AdministrativePeople():Person(){};
	AdministrativePeople(const long int id,const string fname,const string lname):Person(id,fname,lname){};
	~AdministrativePeople();
};
#endif