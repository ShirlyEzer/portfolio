//Templates & Exceptions
//Writen by Shirly Ezer, ID: 304816499

#include "Dictionary.h"
#include "DictionaryOverflow.h"
void main ()
{
	Dictionary <int,char> ASCIId; // Definition of Ascii Dictionary which will contain part of Ascii Table
	char c=' ';
	char result1;
	int result2;
	for (int i=0 ; i<101 ;i++) //Adding to the Ascii Dictionary
	{
		try
		{
				ASCIId.AddToDictionary(i,c);
				cout<< "Good"<<endl;
		}
		catch (DictionaryOverflow &f)
		{
			cout << "Exeption occurred: "<<f.what();
		}
		c++;
	}    // End of the loop fo adding to the dictionary 
	if (ASCIId.SearchInFirstLan(1,&result1))
	{
		cout <<"The char with the Ascii 1 of is: "<<result1<<endl;
	}
	else
		cout <<"The char was not found in the dictionary"<<endl;
	if (ASCIId.SearchInSecondLan(&result2,'A'))
	{
		cout <<"The Ascii number of 'A' is: "<<result2<<endl;
	}
	else
		cout <<"The Ascii number of A was not found in the dictionary"<<endl;
	
	if (ASCIId.SearchInFirstLan(-1,&result1))
	{
		cout <<"The char with the Ascii -1 of is: "<<result1<<endl;
	}
	else
		cout <<"The char was not found in the dictionary"<<endl;

}