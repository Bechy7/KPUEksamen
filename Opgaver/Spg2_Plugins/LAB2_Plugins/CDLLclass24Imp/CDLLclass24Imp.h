// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the CDLLCLASS24IMP_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// CDLLCLASS24IMP_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef CDLLCLASS24IMP_EXPORTS
#define CDLLCLASS24IMP_API __declspec(dllexport)
#else
#define CDLLCLASS24IMP_API __declspec(dllimport)
#endif

// This class is not exported!
class CDLLclass24Imp : public CDLLclass
{
public:
	CDLLclass24Imp(void);
	~CDLLclass24Imp();
	bool Init(CAppUtil* pUtil);
	bool Run(void);
	void TearDown(void);
private:
	CAppUtil * pAppUtil;
	char* pName;
};

extern "C" CDLLCLASS24IMP_API CDLLclass* CreateDLLObject();
extern "C" CDLLCLASS24IMP_API void DeleteDLLObject(CDLLclass*);
CDLLCLASS24IMP_API int fnCDLLclass24Imp(void);


