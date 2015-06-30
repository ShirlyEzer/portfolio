#pragma
#ifndef ALLSTUDENTS_H
#define ALLSTUDENTS_H
#include <string>
#include <vector>
class Student;
using namespace std;
class  AllStudents
{
public:
	static AllStudents* GetInstance ();
	~AllStudents();
	vector <Student*>& getVector();
	void AddStudent(Student *s);
	Student* SearchStudent(const long int id)const;
	void DisplayAll() const;
private:
	AllStudents();
	vector <Student*> ListSt;
	static AllStudents* myInstance;
};
#endif