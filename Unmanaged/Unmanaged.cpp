#include "stdafx.h"
#include "common.h"
#include <objbase.h>
#include <vector>

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

extern "C" __declspec(dllexport) Customer* getCustomer()
{
	void * allocation = CoTaskMemAlloc(sizeof(Customer));

	Customer* returnObject = new (allocation) Customer;

	returnObject->FirstName = "Jerry";
	returnObject->LastName = "Jones";
	returnObject->AccountNumber = 999999999;
	returnObject->IsActive = false;

	return returnObject;
}

extern "C" __declspec(dllexport) Customer** getCustomers()
{
	void * allocation = CoTaskMemAlloc(sizeof(Customer) * 2);

	Customer** returnArray = new (allocation) Customer*[2];

	returnArray[0] = new Customer();
	returnArray[0]->FirstName = "Josue";
	returnArray[0]->LastName = "Garcia";
	returnArray[0]->AccountNumber = 123456789;
	returnArray[0]->IsActive = true;

	returnArray[1] = new Customer();
	returnArray[1]->FirstName = "Natalie";
	returnArray[1]->LastName = "Giannios";
	returnArray[1]->AccountNumber = 987654321;
	returnArray[1]->IsActive = true;

	return returnArray;
}

extern "C" __declspec(dllexport) int getColumnTotal(int* array, int totalRows)
{
	int returnValue = 0;
	
	for (int i = 0; i < totalRows; i++)
	{
		returnValue += array[i];
	}

	return returnValue;
}

extern "C" __declspec(dllexport) int* getRowTotals(int* array, int totalRows, int totalColumns)
{
	int* returnArray = new int[totalRows];

	int currentIndex = -1;
	
	int currentRowTotal;

	for (int row = 0; row < totalRows; row++)
	{
		currentRowTotal = 0;

		for (int column = 0; column < totalColumns; column++)
		{
			currentIndex++;

			currentRowTotal += array[currentIndex];
		}

		returnArray[row] = currentRowTotal;
	}

	return returnArray;
}