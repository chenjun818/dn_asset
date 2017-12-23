/*
 * <auto-generated>
 *	 The code is generated by tools
 *	 Edit manually this code will lead to incorrect behavior
 * </auto-generated>
 */

#ifndef __EquipSuit__
#define __EquipSuit__

#include "NativeReader.h"
#include "Log.h"
#include <vector>
#include <unordered_map>


struct EquipSuitRow
{
	
	int suitid;
	char suitname[MaxStringSize];
	int level;
	int profid;
	int suitquality;
	bool iscreateshow;
	int equipid[MaxArraySize];
	char effect1[MaxStringSize];
	Seq<uint> effect2;
	Seq<uint> effect3;
	Seq<uint> effect4;
	Seq<uint> effect5;
	Seq<uint> effect6;
	Seq<uint> effect7;
	Seq<uint> effect8;
	Seq<uint> effect9;
	Seq<uint> effect10;
};

class EquipSuit:public NativeReader
{
public:
	EquipSuit(void);
	void ReadTable();
	void GetRow(int val,EquipSuitRow* row);
	void GetByUID(uint id, EquipSuitRow* row);
	int GetLength();

protected:
	std::string name;
	std::vector<EquipSuitRow*> m_data;
	std::unordered_map<uint, EquipSuitRow*> m_map;
};


extern "C"
{
	ENGINE_INTERFACE_EXPORT int iGetEquipSuitLength();
	ENGINE_INTERFACE_EXPORT void iGetEquipSuitRow(int idx,EquipSuitRow* row);
	ENGINE_INTERFACE_EXPORT void iGetEquipSuitRowByID(uint id, EquipSuitRow* row);
};

#endif