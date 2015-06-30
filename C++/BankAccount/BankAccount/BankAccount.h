//Project number 1
// Header File named: BankAccount.h
// Writen by: Shirly Ezer, ID: 304816499
#pragma
#ifndef BANKACCOUNT_H
#define BANKACCOUNT_H
class BankAccount
{
public: //member functions
	BankAccount();   //Default constructor
	BankAccount(const int b);  //Constructor set balance
	BankAccount(const BankAccount &CopyFromMe); //Copy constructor
	void SetBalance(const int b);
	void SetAccountNum();
	int GetBalance();
	int GetAccountNum();
	int GetCount();
	void Deposit(const int m);
	void Withdraw(const int m);
	void Display();
	~BankAccount();  //Destructor
private:
	int Balance;
	int AccountNum;
	static int Count;
};
#endif


// 1 out 3 Files