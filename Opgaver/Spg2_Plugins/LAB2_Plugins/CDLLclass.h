// The following ifdef block is the standard way of creating macros which make exporting 
#include <string>
#include "CAppUtil.h"

using namespace std;


class CDLLclass
{
public:
	virtual bool Init(CAppUtil* pUtil) = 0;
	virtual bool Run() = 0;
	virtual void TearDown() = 0;
};

// Specification of factory method functions

// CDLLclass* CreateDLLObject();
// void DeleteDllObject(CDLLclass*);
