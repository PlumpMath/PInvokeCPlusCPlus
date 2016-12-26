#include "stdafx.h"

extern "C" __declspec(dllexport) int add(int parm1, int parm2)
{
	return parm1 + parm2;
}