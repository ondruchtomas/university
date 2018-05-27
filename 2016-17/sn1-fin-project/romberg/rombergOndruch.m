function[T,I,deltaI] = rombergOndruch

format long
%krok 1...dle skript
%ZADANI VZOROVEHO PRIKLADU
f = @(x) (2/sqrt(pi))*exp(-x*x); %integrovana funkce
a = 0; %dolni mez
b = 1; %horni mez
n0 = 20; %pocatecni pocet dilku deleni
epsil = 1e-8; %tolerance
exactVal=erf(1); %presna hodnota integralu

times = linspace(a,b,n0+1); %vytvoreni jednotlivych (ekvidistantnich) dilku v intervalu <a,b>...n0 dilku deleni je urceno n0+1 delicimi body

for j = 1:n0+1
    fvalue(j) = f(times(j)); %vypocet funkcnich hodnot v delicich bodech intervalu
end

%krok 2
s = 1; %startuje se na prvnim radku...ve skriptech se zacina nultym radkem
n(1)=n0;
h(1)=(b-a)/n0; %krok h(1)

T(1,1)= h(1)*(sum(fvalue(2:(end-1)))+0.5*(fvalue(1)+fvalue(end))) %ve skriptech znaceno jako T00 = Tsi v prvnim radku (a prvnim sloupci)...je rovno slozene lichobeznikove formuli


%krok 3
kontrol1 = 0; %kontrolni hodnota pro overeni provadeni cyklu
while kontrol1 == 0

%vypocet sumy pro nasledujici vzorec
suma=0;
for k=1:n(s)
    suma = suma + f(a+((k-0.5)*h(s)));
end
T(s+1,1)=0.5*(T(s,1)+h(s)*suma); %vypocet clenu Tsi pro prvni sloupec na novem radku

%krok 4
n(s+1)=2*n(s); %prepocet delicich dilku
h(s+1)=0.5*h(s); %prepocet velikosti kroku
s=s+1 %vypise aktualni index radku tabulky Tsi
i=1; %index pro sloupce

%krok 5
kontrol2 = 0; %kontrolni hodnota pro overeni provadeni cyklu
while kontrol2 == 0
    
delta = (T(s,i)-T(s-1,i))/((power(4,i))-1); %vypocet rozdilu dvou tsi…jeho velikost bude srovnavana se zadanou toleranci v kriteriu pro ukonceni vypoctu
T(s,i+1)=T(s,i)+delta; %vypocet Tsi pro nasledujici sloupec

if abs(delta) < max(epsil*abs(T(s,i+1)),epsil)
    kontrol1 = 1; kontrol2 = 1; %v tomto pripade dojde k opusteni obou cyklu a nasleduje urceni vysledne hodnoty integralu

elseif i == s-1
    kontrol2 = 1; %v tomto pripade je index sloupce roven indexu radku…nasleduje vytvoreni noveho radku tabulky

elseif (abs(delta) >= max(epsil*abs(T(s,i+1)),epsil)) && (i ~= s)
    i=i+1; %neni-li splnena ani jedna ze dvou vyse uvedenych podminek, dale se pokracuje ve vypoctech na stavajicim radku
end
end
end
I = T(s,i+1); %vysledna hodnota integralu
deltaI = abs(I-exactVal); %absolutni odchylka vypocitane a presne hodnoty integralu
end



