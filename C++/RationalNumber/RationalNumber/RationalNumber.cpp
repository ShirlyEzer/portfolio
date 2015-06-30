//Project number 2 - Rational Number
//Written by Shirly Ezer ID: 304816499
//Cpp File named RationalNumber.cpp
#include <iostream>
#include "RationalNumber.h"
using namespace std;
//Defining operators for output and input for rational number
ostream &operator<<( ostream &output, const RationalNumber &r)
{
	output << r.mone <<"\\"<<r.mechane;
	return output;
}
istream &operator>>( istream &input, RationalNumber &r)
{
	input >> r.mone >> r.mechane;
	return input;
}
//Default Constructor set fraction in 1
RationalNumber::RationalNumber()
{
	SetRational(1,1);
}
void RationalNumber::SetRational(int x,int y)
{
	int d=GCD(abs(x),abs(y));
	this->SetMone(x/d);
	this->SetMechane(y/d);
}
//Constructor which checks and reduce the fraction if possiable
RationalNumber::RationalNumber(int x,int y)
{
	if (y==0)
		SetRational(1,1);
	else
	{
		if (y<0)
			SetRational(-x,-y);
		else 
			SetRational(x,y);
	}
}
//Copy Constructor which copy and reduce the fraction with SetRational
RationalNumber::RationalNumber(const RationalNumber &r)
{
	SetRational(r.mone,r.mechane);
}
//Set functios:
void RationalNumber::SetMone(int x)
{
	this->mone=x;
}
void RationalNumber::SetMechane(int x)
{
	this->mechane=x;
}
//End of Set functions

//Get functions:
int RationalNumber::GetMone() const
{
	return this->mone;
}
int RationalNumber::GetMechane() const
{
	return this->mechane;
}
//End of Get functions

//Operators functions:
RationalNumber RationalNumber::operator-()
{
	return RationalNumber(-1*this->mone,this->mechane);
}
RationalNumber RationalNumber::operator+(const RationalNumber & r) const
{
	int Mtemp1=LCM(this->mechane,r.mechane);
	int Mtemp2=(Mtemp1/this->mechane)*this->mone+(Mtemp1/r.mechane)*r.mone;
	return RationalNumber(Mtemp2,Mtemp1);
}
RationalNumber RationalNumber::operator-(const RationalNumber &r) const
{
	int Mtemp1=LCM(this->mechane,r.mechane);
	int Mtemp2=(Mtemp1/this->mechane)*this->mone-(Mtemp1/r.mechane)*r.mone;
	return RationalNumber(Mtemp2,Mtemp1);
}
RationalNumber RationalNumber::operator*(const RationalNumber &r) const
{
	return RationalNumber(this->mone*r.mone,this->mechane*r.mechane);
}
RationalNumber RationalNumber::operator/(const RationalNumber &r) const
{
	if (r.mone != 0)
	{
		RationalNumber temp (r.mechane,r.mone);
		return this->operator*(temp);
	}
	else
	{
		cout <<"Error canot divide zero"<<endl;
		return RationalNumber(0,1);
	}
}
int RationalNumber::operator<(const RationalNumber &r) const
{
	int Mtemp1=LCM(this->mechane,r.mechane);
	int Temp1=this->mone*(Mtemp1/this->mechane);
	int Temp2=r.mone*(Mtemp1/r.mechane);
	if (Temp1<Temp2)
		return 1;
	else
		return 0;
}
int RationalNumber::operator>(const RationalNumber &r) const
{
	if (*this < r)
		return 0;
	else 
		return 1;
}
//End of Operators function

//Help functions:
int RationalNumber::GCD(int x,int y) const
{
	if (y==0)
		return x;
	return GCD(y,x%y);
}
int RationalNumber::LCM(int x,int y) const
{
	int x1=abs(x),y1=abs(y);
	return x1*y1/GCD(x1,y1);
}
RationalNumber::~RationalNumber()
{
	cout<<"Rational number deleted"<<endl;
}
// 2 of 3 files