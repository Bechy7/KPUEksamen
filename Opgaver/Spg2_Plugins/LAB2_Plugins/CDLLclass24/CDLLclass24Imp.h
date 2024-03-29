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
