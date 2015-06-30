//Templates & Exceptions
//Writen by Shirly Ezer, ID: 304816499

#ifndef DICTIONARY_H
#define DICTIONARY_H
#include <iostream>
#include <typeinfo>
#include "DictionaryOverflow.h"
using namespace std;
//Start of defining the class
template <class T1,class T2>
class Dictionary
{
public:
	Dictionary();
	int AddToDictionary (const T1 word1,const T2 word2);
	bool SearchInFirstLan (const T1 word,T2 *result) const;
	bool SearchInSecondLan (T1 *result,const T2 word) const;
	~Dictionary();
private:
	T1 FirstLan[100];
	T2 SecondLan[100];
};
#endif
//End of defining the class

template <class T1,class T2>
Dictionary< T1,T2 >::Dictionary()
{
	for (int i=0; i<100 ; i++)
	{
		FirstLan[i]=0;
		SecondLan[i]=0;
	}

}
//End of constructor

template <class T1,class T2>
int Dictionary< T1,T2 >::AddToDictionary (const T1 word1,const T2 word2)
{
	int i=0;
	while (FirstLan[i]!=0 || SecondLan[i]!=0)
		i++;
	if (i < 100)
	{
		FirstLan[i]=word1;
		SecondLan[i]=word2;
		return 1;
	}
	else
		throw DictionaryOverflow();
}
//End of defining adding to the dictionary

template <class T1,class T2>
bool Dictionary< T1,T2 >::SearchInFirstLan (const T1 word,T2 *result) const
{
	for (int i=0; i<100; i++)
		if (FirstLan[i] == word)
		{
			*result=SecondLan[i];
			return true;
		}
	return false;
}
//End of defining search number 1

template <class T1,class T2>
bool Dictionary< T1,T2 >::SearchInSecondLan (T1 *result,const T2 word) const
{
	for (int i=0; i<100; i++)
		if (SecondLan[i] == word)
		{
			*result=FirstLan[i];
			return true;
		}
	return false;
}
//End of defining search number 2

template <class T1,class T2>
Dictionary< T1,T2 >::~Dictionary()
{
}