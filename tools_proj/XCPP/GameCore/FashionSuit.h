/*
 * <auto-generated>
 *	 The code is generated by tools
 *	 Edit manually this code will lead to incorrect behavior
 * </auto-generated>
 */

#ifndef __FashionSuit__
#define __FashionSuit__

#include "NativeReader.h"
#include "Log.h"
#include <vector>
#include <unordered_map>


struct FashionSuitRow
{
	
	uint suitid;
	char suitname[MaxStringSize];
	int suitquality;
	char suitatlas[MaxStringSize];
	char suiticon[MaxStringSize];
	int fashionid[MaxArraySize];
	char effect2[MaxStringSize];
	char effect3[MaxStringSize];
	char effect4[MaxStringSize];
	char effect5[MaxStringSize];
	char effect6[MaxStringSize];
	char effect7[MaxStringSize];
	int all1;
	int all2;
	int all3;
	int all4;
	int all0sp;
	int all1sp;
	int all2sp;
	int all3sp;
	int all4sp;
	bool nosale;
	int showlevel;
	int overall;
};

class FashionSuit:public NativeReader
{
public:
	FashionSuit(void);
	void ReadTable();
	void GetRow(int val,FashionSuitRow* row);
	void GetByUID(uint id, FashionSuitRow* row);
	int GetLength();

protected:
	std::string name;
	std::vector<FashionSuitRow*> m_data;
	std::unordered_map<uint, FashionSuitRow*> m_map;
};


extern "C"
{
	ENGINE_INTERFACE_EXPORT int iGetFashionSuitLength();
	ENGINE_INTERFACE_EXPORT void iGetFashionSuitRow(int idx,FashionSuitRow* row);
	ENGINE_INTERFACE_EXPORT void iGetFashionSuitRowByID(uint id, FashionSuitRow* row);
};

#endif