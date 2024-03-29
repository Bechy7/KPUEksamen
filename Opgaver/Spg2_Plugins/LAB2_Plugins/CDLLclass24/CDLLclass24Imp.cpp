// CDLLclass24.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "CDLLclass24Imp.h"

CDLLclass24Imp::CDLLclass24Imp(void)
{
	pName = NULL;
}

CDLLclass24Imp::~CDLLclass24Imp()
{
	if (pName != NULL)
		delete[] pName;
}

bool CDLLclass24Imp::Init(CAppUtil * pUtil)
{
	pAppUtil = pUtil;

	string name = pAppUtil->GetName();
	rsize_t nameLength = name.length() + 1;
	pName = new char[nameLength];
	strcpy_s(pName, nameLength, name.c_str());
	return true;
}

bool CDLLclass24Imp::Run(void)
{
	string message = pAppUtil->MyAddString("Hi", pName);
	cout << message << endl;
	cout << "I am doing something else?!" << endl;
	return true;
}

void CDLLclass24Imp::TearDown(void)
{
	if (pName != NULL)
	{
		delete[] pName;
		pName = NULL;
	}
}

CDLLclass* CreateDLLObject()
{
	return new CDLLclass24Imp();
}

void DeleteDLLObject(CDLLclass* obj)
{
	delete obj;
}
