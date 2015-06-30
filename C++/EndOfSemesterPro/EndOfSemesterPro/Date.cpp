#include <iostream>
#include "Date.h"
using namespace std;
Date::Date(const int d,const int m,const int y)
{
	setDay(d);
	setMonth(m);
	setYear(y);
}
Date::~Date()
{
}
void Date:: setDay(const int d)
{
	day=d;
}
void Date:: setMonth(const int m)
{
	month=m;
}
void Date:: setYear(const int y)
{
	year=y;
}
int Date :: getDay()const
{
	return day;
}
int Date:: getMonth()const
{
	return month;
}
int Date:: getYear()const
{
	return year;
}
ostream &operator<<(ostream &output,const Date &d)
{
	output << d.day <<"."<< d.month << "." << d.year<< endl;
	return output;

}
istream &operator>>(istream &input, Date &d)
{
	input >> d.day >>d.month >> d.year;
	return input;
}