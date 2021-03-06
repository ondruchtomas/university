#include "stdafx.h"

void main()
{
	//UVODNI DEKLARACE PROMENNYCH PRO KONSTRUKCI INSTANCI TRID A OSETRENI CHYB NA VSTUPU Z KLAVESNICE
	int n; char m; 
	bool error = true;
	bool noreps = true;
	int control = 0;
	int trynum = 1;
	double parval;
	std::cout << "RANDOM SAMPLE GENERATOR\n" << std::endl;

	//NASTAVENI TYPU ROZDELENI PRAVDEPODOBNOSTI
	while ((error) || (noreps))
	{
		if ((control == 0) && (trynum == 1)) //POKUD BYL PROGRAM PRAVE SPUSTEN
		{
			std::cout << "Insert the first letter of chosen distribution." << std::endl;
			std::cout << "Options: U = Uniform(0,b), G = Gauss(mu, sigma^2), E = Exponential(0,lambda)" << std::endl;
			m = getchar();
		}
		else if ((control == 0) && (trynum > 1)) //POKUD BYL UZIVATEL JIZ NAPOMENUT
		{
			std::cout << "\nInsert just one letter U / G / E according to options!" << std::endl;
			m = getchar();
		}
		else if (control == 1) //ZPRACOVANI DALSICH NACTENYCH ZNAKU PO PRVNIM
		{
			if (getchar() == 10) //POKUD DRUHY NACTENY ZNAK JE ZALOMENIM RADKU
				noreps = false; //OVERENI, ZE BYLO SKUTECNE ZADANO JEN JEDNO PISMENO
			else //POKUD DRUHY NACTENY ZNAK NENI ZALOMENIM RADKU...
			{
				while (m != 10) m = getchar();//...TAK SE VSTUP NAPRAZDNO PRECTE, DOKUD NENARAZI NA ZALOMENI RADKU...
			}
			control = -1; //A PAK SE HODNOTA CONTROL NASTAVI OPET TAK, ABY V NOVEM CYKLU BYL UZIVATEL OPET VYZVAN K ZADANI VSTUPU
			trynum++; //OVSEM UZ BUDE NAPOMENUT
		}
		else {}
		if (m == 10) { control = 0; trynum++; } //POKUD UZIVATEL ZADA POUZE ENTER BEZ ZADNEHO ZNAKU, TAK SE KONSTRUKTOR ANI NEVOLA
		else
		{
			control++;
			//OVERENI VALIDITY VSTUPNICH DAT V KONSTRUKTORU
			distribution testDistrib(m);
			if (testDistrib.getError() == 0)
				error = 0; //POKUD JE VYTVORENI KONSTRUKTORU USPESNE
			testDistrib.~distribution();//OBRATEM PO OVERENI VOLAM DESTRUKTOR
		}
	}

	distribution Distrib(m);
		std::cout << "\nYou chose distribution " << Distrib.getName() << "." << std::endl;
		m = 10; // 10='\n' = ZALOMENI RADKU
		//OSETRENI SPRAVNOSTI HODNOT NA VSTUPU PRI NACITANI HODNOT PARAMETRU PRO ROZDELENI
		for (int i = 0; i < Distrib.getParSize(); i++)
		{
			std::cout << "\nInsert value for parameter #" << i + 1 << ": " << std::ends;

			//OPAKUJ VYZVU K ZADANI VSTUPU, DOKUD (cin NEBUDE SCHOPEN VYHODNOTIT VSTUP || NACTENY ZNAK ZA CISLEM NENI ZALOMENIM RADKU) || ((NEVHYHODNOCUJE SE GAUSS.ROZDELENI && ZADANA HODNOTA JE NEKLADNA) || (VYHODNOCUJE SE ROZPTYL A ZADANA HODNOTA JE ZAPORNA))
			while ((!(std::cin >> parval) || (getchar() != 10)) || ((!((Distrib.getName() == 'g') || (Distrib.getName() == 'G'))  && (parval <= 0)) || ((i == 1) && (parval < 0))))
			{
				std::cin.clear(); //POKUD cin NENI SCHOPEN VYHODNOTIT VSTUP, VYTVORI SE ERROR FLAG - ZDE JI OPET ODEBEREME PRO DALSI VSTUP
				bool c = (-parval < 1e50); 
				if (!c) //POKUD parval NENI CISLO
				m = getchar();
				while (m != 10) m = getchar(); //NAPRAZDNO SE PRECTE VSTUP, DOKUD SE NENARAZI NA KONEC RADKU
				std::cout << "\nInvalid input! Please insert correct parameter #" << i + 1 << " numerical value: " << std::endl;;
				parval = -5e60; //SIMULACE POCATECNI INICIALIZACE parval
			}
			Distrib.setPars(i, parval); //NASTAV HODNOTU JAKO PARAMETR ROZDELENI
			while (m != 10) m = getchar(); //VYPRAZDNI ZASOBNIK NA VSTUPU, ABY SE DO DALSIHO NACITANI VSTUPU SLO S CISTYM STITEM
		}

	//NASTAVENI MOHUTNOSTI NAHODNEHO VYBERU
	std::cout << "\nInsert random sample size (n > 1): " << std::ends;
	//OSETRENI SPRAVNOSTI HODNOT NA VSTUPU
	while (!(std::cin >> n) || (getchar() != 10)) //DOKUD cin NEROZPOZNA VSTUP NEBO DOKUD ZNAK ZA CISLEM NEBUDE ZALOMENIM RADKU
	{
		std::cin.clear(); //POKUD cin NENI SCHOPEN VYHODNOTIT VSTUP, VYTVORI SE ERROR FLAG - ZDE JI OPET ODEBEREME PRO DALSI VSTUP
		m = getchar();
		while (m != 10) m = getchar(); //NAPRAZDNO PRECIST VSTUP, DOKUD NENARAZI NA ZALOMENI RADKU
		std::cout << "\nInvalid input! Please insert positive integer value: " << std::endl;;
	}
	if (n < 2) //POKUD JE ZADANE n PRILIS MALE (NEBO ZAPORNE), TAK SE AUTOMATICKY NASTAVI NA n = 2.
	{
		std::cout << "\nSuch sample size is not possible (see info above).\nThe sample size will be now set at its minimal possible value as n = 2.\n " << std::endl;;
		n = 2;
	}

	//VYTVORENI NAHODNEHO VYBERU Z ROVNOMERNEHO ROZDELENI Unif(0,1) A VYPIS HODNOT
	randSample Uniform(n);
	std::cout << "\nGenerated random sample with uniform distribution Unif(0,1): " << std::endl;
	Uniform.printout();
	std::cout << "\nPress Enter to start sample transformation: " << std::endl;
	std::cin.ignore(); //Press Enter

	//VYTVORENI HLUBOKE KOPIE POMOCI KOPIROVACIHO KONSTRUKTORU PRO DALSI ZPRACOVANI NAH.VYBERU
	randSample Transformed(Uniform);

	//TRANSFORMACE NAH.VYBERU Z ROVNOMERNEHO ROZDELENI Unif(0,1) DO JINEHO VYSE ZVOLENEHO A VYPIS HODNOT
	Transformed.itSampling(Distrib.getName(), Distrib.getPar());
	std::cout << "Generated random sample with chosen distribution: " << std::endl;
	Transformed.printout();

	std::cout << "\nPress Enter to see computed numerical characteristics: " << std::endl;
	std::cin.ignore(); //Press Enter

	//VYPOCET VYBEROVEHO PRUMERU A ROZPTYLU TRANSFORMOVANEHO NAHODNEHO VYBERU
	Transformed.sampleMean(); Transformed.sampleVar();

	//VYPOCET TEORETICKEHO PRUMERU A ROZPTYLU
	Distrib.setMean(); Distrib.setVar();

	//ZAVERECNY VYPIS CISELNYCH CHARAKTERISTIK
	std::cout << "\nTheoretical mean value: " << Distrib.getMean() << std::endl;
	std::cout << "Random sample mean value: " << Transformed.getSampleMean() << "\n" << std::endl;
	std::cout << "Theoretical variance: " << Distrib.getVar() << std::endl;
	std::cout << "Random sample variance: " << Transformed.getSampleVar() << "\n" << std::endl;
	std::cout << "Press Enter to exit..." << std::endl;
	std::cin.ignore(); //Press Enter

	//DESTRUKCE INSTANCI
	Uniform.~randSample();
	Transformed.~randSample();
	Distrib.~distribution();
}