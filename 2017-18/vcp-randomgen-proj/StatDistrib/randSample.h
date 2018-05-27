#pragma once
class randSample
{
private:
	long double *data;
	int sampleSize;
	double par1, par2; //VYBEROVY PRUMER, VYBEROVY ROZPTYL
	void clearData();
public:
	randSample(int sSize);
	randSample(randSample& image);
	~randSample();
	void setSampleSize(int sSize);
	void randgen(int sSize);
	int size() { return sampleSize; };
	void printout();
	double meanSum();
	double varSum();
	void  sampleMean();
	void  sampleVar();
	double getSampleMean() { return par1; };
	double getSampleVar() { return par2; };
	long double& operator [] (int a) { return data[a]; };
	randSample itSampling(char distname, double* pars); //Inverse Transform Sampling
};