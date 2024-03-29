// LAB2_Plugins.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "../CDLLclass.h"
#include "CAppUtilImp.h"

// Typedefs
// A typedef to hold the address of the create factory method.
typedef CDLLclass * (*PFNCreateDllObject) (); //Type def

// A typedef to hold the address of the delete method.
typedef void(*PFNDeleteDllObject)(CDLLclass *);

int main()
{
	PFNCreateDllObject pfnCreateDllObject;
	PFNDeleteDllObject pfnDeleteDllObject;
	CAppUtillmp *pUtil;
	string name;
	wstring DLLName;
	HINSTANCE dllHandle = NULL;

	cout << "Enter plugin name to load: " << endl;
	wcin >> DLLName;

	dllHandle = LoadLibrary(DLLName.c_str());

	if (dllHandle == NULL)
	{
		cout << "Unable to load library: " << DLLName.c_str() << endl;
	}

	// Get pointer to the myAdd function using GetProcAddress:
	pfnCreateDllObject = (PFNCreateDllObject)GetProcAddress(dllHandle, "CreateDLLObject");

	if (pfnCreateDllObject == NULL)
	{
		return 1;
	}

	cout << "Please enter your name: ";
	cin >> name;
	cout << endl;

	pUtil = new CAppUtillmp(name);

	// Now uses the factory method that returns instance of the DLL
	CDLLclass *pPlugin = pfnCreateDllObject();

	// Call some functions within the DLL
	pPlugin->Init(pUtil);
	pPlugin->Run();
	pPlugin->TearDown();

	pfnDeleteDllObject = (PFNDeleteDllObject)GetProcAddress(dllHandle, "DeleteDLLObject");

	if (pfnDeleteDllObject == NULL)
	{
		return 1;
	}

	pfnDeleteDllObject(pPlugin);

	delete pUtil;

	FreeLibrary(dllHandle);

	cout << "Press enter to terminate program: ";
	getline(cin, name);

	return 0;
}

