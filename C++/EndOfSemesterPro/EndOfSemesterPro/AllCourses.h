#ifndef ALLCOURSES_H
#define ALLCOURSES_H
#include <string>
#include <vector>
class Course;
using namespace std;
class  AllCourses
{
public:
	static AllCourses* GetInstance ();
	~AllCourses();
	vector <Course*>& getVector();
	void AddCourse(Course *c);
	Course* SearchCourse(const int courseNum)const;
	void DisplayAll()const;
private:
	vector <Course*> ListCo;
	AllCourses();
	static AllCourses* myInstance;
};
#endif