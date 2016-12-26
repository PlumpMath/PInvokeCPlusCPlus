#include "stdafx.h"
#include "common.h"

extern "C" __declspec(dllexport) int add(int parm1, int parm2)
{
	return parm1 + parm2;
}

extern "C" __declspec(dllexport) int sum(Parameters parameters)
{
	return parameters.Parm1 + parameters.Parm2;
}

extern "C" __declspec(dllexport) Parameters getParameters()
{
	Parameters returnValue;

	returnValue.Parm1 = 6;
	returnValue.Parm2 = 9;

	return returnValue;
}

extern "C" __declspec(dllexport) char* getGreeting()
{
	char* returnValue = "Hello World";

	return returnValue;
}

extern "C" __declspec(dllexport) double getCost(LineItem* lineItem)
{
	double cost = lineItem->Price * lineItem->Quantity;

	double costWithTax = cost + cost * lineItem->SalesTax;

	return costWithTax;
}

extern "C" __declspec(dllexport) double getTotalCost(LineItem** lineItems, int totalLineItems)
{
	double returnValue = 0;

	for (int i = 0; i < totalLineItems; i++)
	{
		returnValue = returnValue + getCost(lineItems[i]);
	}

	return returnValue;
}