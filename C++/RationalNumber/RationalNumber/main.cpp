//Project number 2 - Rational Number
//Written by Shirly Ezer ID: 304816499
//Cpp File main.cpp
#include <iostream>
#include "RationalNumber.h"
using namespace std;
void main ()
{
	RationalNumber r1(3,-4);
	cout << "Your first fraction is: "<<r1<<endl;
	RationalNumber r2(0,6);
	cout << "Your second fraction is: "<<r2<<endl;
	cout << "The negative fraction of the first is: "<<-r1<<endl;
	cout << "The multiplied fraction is: "<<r1*r2<<endl;
	cout << "Your first fraction is: "<<r1<<endl;
	cout << "Your second fraction is: "<<r2<<endl;
	cout << "The quotient fraction is: "<<r1/r2<<endl;
	cout << "The sum fraction is: "<<r1+r2<<endl;
	cout << "The subtraction fraction is: "<<r1-r2<<endl;
	if (r1 >r2 )
		cout << r1 <<" is bigger"<<endl;
	if (r1 < r2)
		cout << r2 <<" is bigger"<<endl;
	r1=r2;
	cout << "Your first fraction is: "<<r1<<endl;
	cout << "Your second fraction is: "<<r2<<endl;
	
}
// 3 of 3 files