#include "stdafx.h"
#include "randSample.h"
#include "cstdlib" //pro funkci rand()
#include <time.h> //pro originalni inicializaci seedu srand()

//KONSTRUKTOR VEKTORU PRO ULOZENI NAHODNEHO VYBERU, CHARAKTERIZOVAN SVOU MOHUTNOSTI
randSample::randSample(int sSize)
{
	sampleSize = 0;
	data = NULL;
	setSampleSize(sSize);
	randgen(sampleSize);
}

//KOPIROVACI KONSTRUKTOR PRO VYTVORENI HLUBOKE KOPIE
randSample::randSample(randSample& image)
{
	long double *predata;
	sampleSize = image.size();
	predata = new long double[sampleSize];
	setSampleSize(sampleSize);
	data = NULL;
	for (int p = 0; p< this->sampleSize; p++)
	{
		predata[p] = image.data[p];
	}
	this->data = predata;
}

//DESTRUKTOR
randSample::~randSample()
{
	clearData();
}

//METODA PRO ALOKACI PAMETI PRO NASLEDNE ULOZENI HODNOT REALIZACI NAH.VYBERU DANE VELIKOSTI
void randSample::setSampleSize(int sSize)
{
	if (sampleSize != sSize) {
		clearData();
		if (sampleSize = sSize)
			data = new long double[sSize];
	}
}

//METODA PRO VYTVORENI NAHODNEHO VYBERU Z ROVNOMERNEHO ROZDELENI Unif(0,1)
void randSample::randgen(int sSize)
{
	double epsil = 1e-10;
	setSampleSize(sSize);
	srand((uint32_t)time(NULL));
	for (int i = 0; i < sSize; i++)
	{ 
		data[i] = ((double)rand() / (RAND_MAX));
		if (data[i] > (1 - epsil)) data[i] = 1 - epsil; //OSETRENI PROTI NULOVEMU LOGARITMU V ITS U EXP.ROZD.
	}
}

//METODA PRO DESTRUKCI INSTANCE; VYNULOVANI HODNOT A VYMAZANI PAMETI
void randSample::clearData()
{
	if (data)
		delete[] data;
	data = NULL;
	sampleSize = 0;
	par1 = par2 = 0;
}

//METODA PRO VYSTUP HODNOT REALIZACI NAH.VYBERU NA OBRAZOVKU
void randSample::printout()
{
	for (int i = 0; i < sampleSize; i++)
		printf("%8.2f", data[i]);
	printf("\n");
}

//STATISTICKE METODY

//METODA PRO URCENI HODNOTY SUMY VE VZORCI PRO VYBEROVY PRUMER
double randSample::meanSum()
{
	double sum = 0;
	for (int i = 0; i < sampleSize; i++)
		sum += data[i];
	return sum;
}

//METODA PRO URCENI HODNOTY VYBEROVEHO PRUMERU
void  randSample::sampleMean()
{
	par1 = (1 / (double)sampleSize) * meanSum();
}

//METODA PRO URCENI HODNOTY SUMY VE VZORCI PRO VYBEROVY ROZPTYL
double randSample::varSum()
{
	double sum = 0;

	for (int i = 0; i < sampleSize; i++)
		sum += pow((data[i] - par1),2);
	return sum;
}

//METODA PRO URCENI HODNOTY VYBEROVEHO ROZPTYLU
void  randSample::sampleVar() //metoda pro zjisteni hodnoty prvniho parametru
{
	par2 = (1 / ((double)(sampleSize-1)))* varSum();
}

//INVERSE TRANSFORM SAMPLING (METODA INVERZNI TRANSFORMACE)
randSample randSample::itSampling(char distname, double* pars)
{
	static randSample unif = *this;
	if ((distname == 'U') || (distname == 'u'))
	{ 
		for (int i = 0; i < sampleSize; i++)
		data[i] = pars[0] * unif[i]; //LINEARNI UPRAVA V ZAVISLOSTI NA ZADANE HODNOTE b V ROZDELENI Unif(0,b)
		return *this;
	}
	if ((distname == 'E') || (distname == 'e'))
	{ 
		for (int i = 0; i < sampleSize; i++)
		{ 
			data[i] = -log(1.0 - unif[i]) / pars[0]; //VZOREC PRO TRANSFORMACI DO EXPONENCIALNIHO ROZDELENI
		}
		return *this;
	}
	if ((distname == 'G') || (distname == 'g')) //MARSAGLIA POLAR METHOD
	{
		int i = 1;
		double w1, w2, r;
		srand((uint32_t)time(NULL));
		for (int j = 0; j < sampleSize; j++)
		{

		do {
		w1 = 2.0 * ((double)rand() / (RAND_MAX)) - 1.0;
		i++;
		w2 = 2.0 * ((double)rand() / (RAND_MAX)) - 1.0;
		r = w1 * w1 + w2 * w2;
		} while ((r >= 1.0) || (r == 0.0)); //OPAKUJ GENEROVANI, DOKUD r NENI MENSI NEZ 1
		r = sqrt(-2.0*log(r) / r);
		data[j] = (pars[0] + (w1 * r * sqrt(pars[1]))); //TRANSFORMACE Z Gauss(0,1) NA Gauss(mu, sigma^2)
		}
		return *this;
	}
	else { return NULL; }
	unif.~randSample();
}