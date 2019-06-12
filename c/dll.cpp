#pragma comment(lib, "XX.lib")

#ifdef DLL_CUST_API_EXPORT
#define DLL_CUST_API extern "C"  __declspec(dllexport)
#else
#define DLL_CUST_API extern "C"  __declspec(dllimport)
#endif

DLL_CUST_API int add(int a, int b);
class DLL_CUST_API Point{}
class DLL_CUST_API Point
{
public:
	DLL_CUST_API int add(int a, int b);
	
};

#define DLL_CUST_API_EXPORT
int add(int a, int b){return a+b;}
int Point::add(){return a+b;}

HISTAMCE hInst = LoadLibrary("use.dll");
typedef int (*ADDPROC)(int a, int b);
ADDPROC add = (ADDPROC)GetProcAddress(hInst, "add");
if(add)
{

}




