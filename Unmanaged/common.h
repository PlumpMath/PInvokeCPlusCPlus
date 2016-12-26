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
};