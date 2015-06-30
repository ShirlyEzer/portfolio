// Cpp File named: BankAccount.cpp 
// Writen by: Shirly Ezer, ID: 304816499
#include <iostream>
#include "BankAccount.h"
using namespace std;

int BankAccount::Count=0;

//Default constructor
BankAccount::BankAccount()  
{
	Count++;
	Balance=0;
	SetAccountNum();
}

//Constructor which set balance
BankAccount::BankAccount(const int b)  
{
	Count++;
	SetBalance(b);
	SetAccountNum();
}

//Copy constructor
BankAccount::BankAccount(const BankAccount &CopyFromMe)  
{
	Count++;
	SetAccountNum();
	Balance=CopyFromMe.Balance;
}

//Set functions:
void BankAccount::SetBalance(const int b)
{
	Balance=b;
}
void BankAccount::SetAccountNum()
{
	AccountNum=rand() % 50 + 1;
}

// Get functions:
int BankAccount::GetBalance()
{
	return Balance;
}
int BankAccount::GetAccountNum()
{
	return AccountNum;
}
int BankAccount::GetCount()
{
	return Count;
}

//Deposit money (only positive number) to account
void BankAccount::Deposit(const int m)
{
	if (m < 0)
		cout <<"Error, you have entered negative number"<<endl;
	else
		Balance+=m;
}

//Withdraw money from the account
void BankAccount::Withdraw(const int m)  
{
	char x;
	if (Balance-m < 0)
	{
		cout<<"You dont have enough money in your account"<<endl;
		cout<<"To withdraw the money press y, else press any key..."<<endl;
		cin >>x;
		if (x == 'y')
			Balance-=m;
	}
	else
		Balance-=m;
}

//Display account details
void BankAccount::Display()  
{
	cout <<"The account details are:"<<endl;
	cout <<"Balnce- "<<Balance<<endl;
	cout <<"Account Number- "<<AccountNum<<endl;
	cout <<"Total Account open- "<<Count<<endl<<endl;
}

//Destructor
BankAccount::~BankAccount()  
{
	cout <<"The account number "<<AccountNum<<" is closed!"<<endl;
	Count--;
}

// 2 out 3 Files
