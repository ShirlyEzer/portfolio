#pragma
#ifndef ADDRESS_H
#define ADDRESS_H
#include <string>
#include <iostream>
using namespace std;
class Address
{
	friend ostream &operator<<(ostream &,const Address &);
	friend istream &operator>>(istream &, Address &);

public:
	Address(const int b,const string c,const string s);
	Address(){};
	~Address();
	void setBlock(const int b);
	void setCity(const string c);
	void setStreet(const string s);
	int getBlock()const;
	string getCity()const;
	string getStreet()const;
private:
	int block;
	string city;
	string street;
};
#endif