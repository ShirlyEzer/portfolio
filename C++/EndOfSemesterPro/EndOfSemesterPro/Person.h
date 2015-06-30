#pragma
#ifndef PERSON_H
#define PERSON_H
#include <string>
using namespace std;
class Person
{
public:
	Person(const long int id,const string fname,const string lname);
	Person():ID(0){};
	virtual ~Person()=0;
	void setFname(const string);
	void setLname(const string);
	long int getID()const ;
	string getFname()const ;
	string getLname()const ;
private:
	const long int ID;
	string Fname;
	string Lname;
};
#endif