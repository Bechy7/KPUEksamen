// CDLLclass23Imp.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "CDLLclass23Imp.h"

using namespace std;

// This is the constructor of a class that has been exported.
// see CDLLclass23Imp.h for the class definition
CDLLclass23Imp::CDLLclass23Imp()
{
	pName = NULL;
}

CDLLclass23Imp::~CDLLclass23Imp()
{
	if (pName != NULL)
	{
		delete[] pName;
	}
}

bool CDLLclass23Imp::Init(CAppUtil * pUtil)
{
	pAppUtil = pUtil;

	string name = pAppUtil->GetName();
	rsize_t nameLength = name.length() + 1;
	pName = new char[nameLength];
	strcpy_s(pName, nameLength, name.c_str());
	return true;
}

bool CDLLclass23Imp::Run(void)
{
	string message = pAppUtil->MyAddString("Hi", pName);
	cout << message << endl;
	cout << "I am called from Run in CDLLclass23Imp" << endl;
	return true;
}

void CDLLclass23Imp::TearDown(void)
{
	if (pName != NULL)
	{
		delete[] pName;
		pName = NULL;
	}
}

CDLLclass * CreateDLLObject()
{
	return new CDLLclass23Imp();
}

void DeleteDLLObject(CDLLclass* obj)
{
	delete obj;
}
