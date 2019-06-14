#include "stdafx.h"
#include "CAppUtilImp.h"


CAppUtillmp::CAppUtillmp()
{
	m_name = "";
}

CAppUtillmp::CAppUtillmp(string name)
{
	m_name = name;
}

string CAppUtillmp::GetName()
{
	return m_name;
}

string CAppUtillmp::MyAddString(string str1, string str2)
{
	return str1 + " " + str2;
}


CAppUtillmp::~CAppUtillmp()
{
}
