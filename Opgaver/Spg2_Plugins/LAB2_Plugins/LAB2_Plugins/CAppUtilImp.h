#pragma once

#include "../CAppUtil.h"

class CAppUtillmp : public CAppUtil
{
public:
	CAppUtillmp();
	CAppUtillmp(string name);
	string GetName();
	string MyAddString(string str1, string str2);
	~CAppUtillmp();
private:
	string m_name;
};

