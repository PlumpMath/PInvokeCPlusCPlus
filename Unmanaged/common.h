#pragma once

struct Parameters
{
public:
	int Parm1;
	int Parm2;
};

class LineItem
{
public:
	char* Name;
	double Price;
	int Quantity;
	double SalesTax;
	bool IncludeGiftReceipt;
};

class Customer
{
public:
	Customer() {}
	char* FirstName;
	char* LastName;
	int AccountNumber;
	bool IsActive;
};