#pragma
#ifndef DATE_H
#define DATE_H
#include <iostream>
using namespace std;
class Date
{
	friend ostream &operator<<(ostream &,const Date &d);
	friend istream &operator>>(istream &, Date &d);

public:
	Date(const int,const int,const int);
	Date(){};
	~Date();
	void setDay(const int d);
	void setMonth(const int m);
	void setYear(const int y);
	int getDay()const;
	int getMonth()const;
	int getYear()const;

private:
	int day;
	int month;
	int year;
};
#endif