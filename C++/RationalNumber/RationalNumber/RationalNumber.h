//Project number 2 - Rational Number
//Written by Shirly Ezer ID: 304816499
//Header File named RationalNumber.h
#pragma
#include <iostream>
using namespace std;
#ifndef RATIONALNUMBER_H
#define RATIONALNUMBER_H
class RationalNumber
{
	friend ostream &operator<<( ostream &output, const RationalNumber &);
	friend istream &operator>>( istream &input, RationalNumber &);
public:
	RationalNumber(); //Defaulut constructor
	RationalNumber(int,int); //Constructor which checks the input
	RationalNumber(const RationalNumber &);  //Copy constructor
	// Defining the functions of the operators
	RationalNumber operator-();
	RationalNumber operator+(const RationalNumber &) const;
	RationalNumber operator-(const RationalNumber &) const;
	RationalNumber operator*(const RationalNumber &) const;
	RationalNumber operator/(const RationalNumber &) const;
	int operator<(const RationalNumber &) const;
	int operator>(const RationalNumber &) const;
	~RationalNumber();
private:
	// Set functions:
	void SetMone(int);
	void SetMechane(int);
	void SetRational(int,int); // Keeps the reduction of a fraction
	// Get functions:
	int GetMone() const;
	int GetMechane() const;
	// Mathematics functions (helps calculating):
	int GCD(int,int) const;
	int LCM(int,int) const;
	// private fields:
	int mone;
	int mechane;
};
#endif
// 1 of 3 files