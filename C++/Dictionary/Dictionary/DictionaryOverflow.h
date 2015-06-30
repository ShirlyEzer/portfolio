//Templates & Exceptions
//Writen by Shirly Ezer, ID: 304816499

#ifndef DICTIONARYOVERFLOW_H
#define DICTIONARYOVERFLOW_H
#include <stdexcept>
using namespace std;
//Start of defining class of exception
class DictionaryOverflow : public runtime_error
{
public:
	DictionaryOverflow (): runtime_error("Error ,over flow!\n"){};
};
#endif
//End of defining class of exception