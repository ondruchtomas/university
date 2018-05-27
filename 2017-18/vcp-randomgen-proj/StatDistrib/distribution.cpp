#include "stdafx.h"
#include "distribution.h"
#include <iostream> //hlavicka pro vytvareni instanci proudu
#include <iomanip> //hlavicka s deklarovanymi manipulatory proudu (podoba vypisu)

//KONSTRUKTOR CHARAKTERIZOVANY TYPEM ROZDELENI PRAVDEPODOBNOSTI
distribution::distribution(char x)
{
	error = 1; //PRO OVERENI, ZDA x JE JEDNIM Z PISMEN U / E / G
	if ((x == 'U') || (x == 'u'))
	{ 
		name = 'U';
		setParSize(1);
		error = 0;
	}
	else if ((x == 'E') || (x == 'e'))
	{ 
		name = 'E';
		setParSize(1);
		error = 0;
	}
	else if ((x == 'G') || (x == 'g'))
	{
		name = 'G';
		setParSize(2);
		error = 0;
	}
}

//DESTRUKTOR
distribution::~distribution()
{
	clearData();
}

//METODA PRO DESTRUKCI INSTANCE; VYNULOVANI HODNOT A VYMAZANI PAMETI
void distribution::clearData()
{
	delete[] par; 
	par = 0;
	parSize = 0;
	mean = var = 0;
	name = NULL;
}

//METODA PRO ALOKACI DYNAMICKE PAMETI PRO HODNOTY PARAMETRU CHARAKTERIZUJICICH DANE ROZDELENI
void	distribution::setParSize(int nn)
{
			parSize = nn;
			par = new double[nn];
	
}

//METODA PRO NASTAVENI PARAMETRU ROZDELENI UZIVATELEM Z OBRAZOVKY
void distribution::setPars(int i, double val)
{
	par[i] = val;
}

//SETTER METODA PRO VYPOCET HODNOTY STREDNI HODNOTY JAKO CISELNE CHARAKTERISTIKY
void distribution::setMean()
{
	if (name == 'U')
		mean = par[0] / 2;
	else if (name == 'E')
		mean = 1 / par[0];
	else mean = par[0]; //PRO PRIPAD GAUSS.ROZDELENI
}

//SETTER METODA PRO VYPOCET HODNOTY PRUMERU JAKO CISELNE CHARAKTERISTIKY
void distribution::setVar()
{
	if (name == 'U')
		var = (par[0] * par[0])/12;
	else if (name == 'E')
		var = 1 / (par[0] * par[0]);
	else var = par[1]; //PRO PRIPAD GAUSS.ROZDELENI
}