// Lab8_3.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "Lab8_3.h"

using namespace std;

// This exported function call backs pF in a loop where x is incremented by 1
extern "C" DLLWITHCALLBACK_API void SomeUnmanagedFunctionUsingCallback(double x, FafX pF)
{
	double res = 0.0;

	MessageBox(NULL, "The DLL is now going to use your callback function.", "Unmanaged DLL says", MB_OK);

	for (int i = 0; i < 10; i++)
	{
		res = (*pF)(x);
		cout << "x: " << x << "     F: " << res << endl;
		x += 1.0;
	}
}