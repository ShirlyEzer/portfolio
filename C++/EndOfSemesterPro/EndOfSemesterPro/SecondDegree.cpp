#include <iostream>
#include <vector>
#include "Student.h"
#include "SecondDegree.h"
#include "SecondDegreeCourse.h"
#include "AdvancedFirstDegreeCourse.h"
using namespace std;

SecondDegree:: SecondDegree():Student()
{
}
SecondDegree::~SecondDegree()
{
}
void SecondDegree:: PassDegree()
{
	int countScourse=0;
	int countFADVcourse=0;
	SecondDegreeCourse *c=NULL;
	AdvancedFirstDegreeCourse *a=NULL;
	for(std::size_t i=0; i< this->getVector().size(); i++)
	{
		if(typeid(this->getVector()[i])==typeid(c))
		{
			countScourse+=this->getVector()[i].c->getPoint();
		}
		if(typeid(this->getVector()[i])==typeid(a))
		{
			countFADVcourse+=this->getVector()[i].c->getPoint();
		}
	}
	if( countFADVcourse<=4)
		countScourse+=countFADVcourse;
	if( countFADVcourse > 4)
		countScourse+=4;// if student have more then 4 points in advenced courses for first degree , then we take just 4 points out of all advanced courses points
	if(countScourse>=10)
	{
		cout <<"The Student pass Second Degree Successefully";
	}
	else
		cout << "Your total points are not enough to pass the Second Degree\n";
}