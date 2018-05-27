#pragma once
class distribution
{
private:
	char name;
	double mean;
	double var;
	int parSize;
	double *par;
	bool error;
	void clearData();

public:
	distribution(char name);
	~distribution();
	void setParSize(int nn);
	char getName() { return name; };
	void setPars(int i, double val);
	double getParSize() { return parSize; };
	void setMean();
	void setVar();
	bool getError() { return error; };
	double getMean() { return mean; };
	double getVar() { return var; };
	double* getPar() { return par; };
};

