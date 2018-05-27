function [eigval] = eigvalOndruch %VSTUPY DO PROGRAMU JSOU UVEDENY NIZE
format long

%VSTUPY ZE ZADANI A DEKLARACE POTREBNYCH PROMENNYCH
A = [3.75 -0.25 -1.25 2.75; -0.25 2.75 2.75 1.25; -1.25 2.75 4.75 -0.25; 2.75 1.25 -0.25 7.75]; %vstupni matice
n = size(A,2); %velikost matice
epsil = 1e-6; %tolerance ze zadani
eigMatlab=eig(A); %takto vlastni cisla spocita MatLab...pouzije se na konci pro srovnani hodnot
eigval=zeros(n,1); %deklarace promenne pro vlastni hodnoty
val=zeros(1,n+1); %deklarace promenne pro nahravani hodnot polynomu v bode x

%PREVOD MATICE A NA HESSENBERGUV TVAR
HB = hess(A); %byl pouzit skript jiz obsazeny v Matlabu
%HB = hessen(A); %mozno spustit take timto prikazem...soubor hessen.m je obsazen v priloze. Jedna se o skript vytvoreny na cviceni, ktery matici A prevadi na Hessenberguv tvar pomoci Householderovych matic
%%%%%%%%%%%%

%PRIPRAVA CHARAKTERISTICKYCH POLYNOMU
p = zeros(n+1,n+1); %tady se budou nahravat charakteristicke polynomy p_r
p(1,1)=1; %p0 je takto dany
for i=2:n+1
    p(1:i,i)=(-1)^(i-1)*poly(HB(1:i-1,1:i-1)); %nahravani charakteristickych polynomu, ktere se vytvari z tridiagonalni matice HB...spravnost formule obsahujici (-1)^(i-1) byla na papire overena
end
%%%%%%%%%%%%%%%

%NAHRANI PRVKU NADDIAGONALY (=PODDIAGONALY) DO VEKTORU...PRVNI A POSLEDNI PRVEK JSOU DANE JAKO NULA
naddiag(1)=0;
naddiag(n+1)=0;

if n==2
    naddiag(2)=HB(1,2); %nahrani prvku naddiagonaly u matice radu 2x2...nutno napsat jinak nez pro matice vyssich radu, kde se pouzije prikaz diag.
else
naddiag(2:n) = diag(HB(1:n,2:n));
end


diagonala = diag(HB); %nahrani prvku diagonaly do vektoru
%%%%%%%%%%%%%%%%%%%%


%V TECHTO DVOU CYKLECH SE NAJDE PRVEK aMin=min{a(i)-abs(b(i))-abs(b(i+1))} A PRVEK bMax=max{a(i)+abs(b(i))+abs(b(i+1))}
%PRO PROVADENE SROVNAVANI SI ALE NEJPRVE URCIM JEJICH POCATECNI HODNOTY, KTERE JSOU SCHVALNE PØEHNANÌ VELKÉ, RESP. MALÉ
aMin=1e6;
bMax=0;
for i=1:n   
    a = diagonala(i)-abs(naddiag(i))-abs(naddiag(i+1));
    if a < aMin
        aMin = a;
    end

    b = diagonala(i)+abs(naddiag(i))+abs(naddiag(i+1));
    if b > bMax
        bMax = b;
    end
end
%%%%%%%%%%%%

%POUZE SI PREZNACIM PROMENNE, ABY OZNACENI ODPOVIDALA TEXTU VE SKRIPTECH
b=bMax; %stanoveni pocatecnich bodu a, b
a=aMin;
%%%%%%%%%%%%


%BUDE SE HLEDAT k-VLASTNICH CISEL, PRICEMZ k=1 ODPOVIDA NEJMENSIMU A k=n ODPOVIDA NEJVETSIMU VLASTNIMU CISLU DANE MATICE
for k=1:n
    if a == b %nutno osetrit pripad, kdy a == b...nastava pro specificke matice
        if a == 0
            x = 0; %nutna korekce napriklad pro vypocet vlastnich cisel nulove matice [0 0;0 0]
        else
        x = 1; %nutna korekce napriklad pro vypocet vlastnich cisel jednotkove matice [1 0;0 1]
        end
    else
        while b-a > epsil
            r=1; %index urcujici pocet koeficientu pro vyhodnocovany polynom
            V=0; %pocet zmen znamenka v posloupnosti char.polynomu
    
            x = (a+b)/2; %bisekce
    
        %zde budu prochazet polynomy, ktere jsem si drive nahral do matice, a budu vyhodnocovat jejich hodnoty v bode x
            for j=1:n+1
                val(j)=polyval(p(1:r,j),x); %vyhodnoceni vsech char. polynomu v bode x
                r=r+1;
            end
    
    %zde zkoumam znamenkove zmeny v posloupnosti polynomu {p(x)}
            for j=2:n+1
                if val(j-1)*val(j)<=0
                    V = V+1; %zde se nahrava pocet znamenkovych zmen v posloupnosti
                end
            end
    
    %zmena hodnoty meze a, pripadne b
            if V < k
                a=x;
            else
                b=x;
            end    
        end %jakmile je dodrzena tolerance, tak se ukonci cyklus
    end
        eigval(k)=x; %vlastni cislo je soucasna hodnota x...ta se nahraje do vektoru vlastnich cisel
        a=aMin; %znovu se urci pocatecni hodnoty pro a, b pro pocitani noveho vlastniho cisla
        b=bMax;
end %ukonci se cyklus, jakmile se spocitaji vsechna vlastni cisla
%%%%%%%%%%%%%%%%

%KONTROLNI VYPIS VYSLEDKU
eigMatlab %metoda eig(A) v Matlabu
eigval %vektor obsahujici nalezena vlastni cisla pres metodu bisekce
%%%%%%%%%%%%%%%%

