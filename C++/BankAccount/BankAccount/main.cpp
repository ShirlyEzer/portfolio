// Main File named: main.cpp
// Writen by: Shirly Ezer, ID: 304816499
#include <iostream>
#include "BankAccount.h"
using namespace std;
void main()
{
	BankAccount b1(130),b2,b3(b1);
	cout <<"The accounts were created!"<<endl<<endl;
	cout <<"The first:"<<endl<<endl;
	b1.Display();
	cout <<"The second:"<<endl<<endl;
	b2.Display();
	cout <<"The third: (copy of the first)"<<endl<<endl;
	b3.Display();
	cout <<"How much money you want to withdraw from the first account? ";
	int m;
	cin >> m;
	b1.Withdraw(m);
	cout <<"How much money you want to deposit to the second account? ";
	cin >> m;
	b2.Deposit(m);
	system("cls");
	cout <<"The first:"<<endl<<endl;
	b1.Display();
	cout <<"The second:"<<endl<<endl;
	b2.Display();
}


// 3 out 3 Files