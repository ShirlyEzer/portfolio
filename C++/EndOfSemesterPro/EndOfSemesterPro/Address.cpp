#include <iostream>
#include "Address.h"
#include <string>
using namespace std;
Address::Address(const int b,const string c,const string s)
{
	setBlock(b);
	setCity(c);
	setStreet(s);
}
Address::~Address()
{
}
void Address:: setBlock(const int b)
{
	block=b;
}
void Address:: setCity(const string c)
{
	city=c;
}
void Address:: setStreet(const string s)
{
	street=s;
}
int Address:: getBlock()const
{
	return block;
}
string Address:: getCity()const
{
	return city;
}
string Address:: getStreet()const
{
	return street;
}
ostream &operator<<(ostream &output,const Address &a)
{
	output <<a.block<<" "<<a.street<<" "<<a.city<<endl;
	return output;
}
istream &operator>>(istream &input,Address &a)
{
	input >> a.block >>a.street >> a.city;
	return input;
}