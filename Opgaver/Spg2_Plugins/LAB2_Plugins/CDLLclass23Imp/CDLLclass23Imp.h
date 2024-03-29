// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the CDLLCLASS23IMP_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// CDLLCLASS23IMP_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef CDLLCLASS23IMP_EXPORTS
#define CDLLCLASS23IMP_API __declspec(dllexport)
#else
#define CDLLCLASS23IMP_API __declspec(dllimport)
#endif

// This class is not exported!
class CDLLclass23Imp : public CDLLclass
{
public:
	CDLLclass23Imp(void);
	~CDLLclass23Imp();
	bool Init(CAppUtil* pUtil);
	bool Run(void);
	void TearDown(void);
private:
	CAppUtil* pAppUtil;
	char* pName;
};

extern "C" CDLLCLASS23IMP_API CDLLclass* CreateDLLObject();
extern "C" CDLLCLASS23IMP_API void DeleteDLLObject(CDLLclass*);
