function[reseni, reps] = gmresOndruch
format long

%Vzorove zadani prikladu
A = [-5 -2 3 -7 -6 -9 -9 -5 -4 -2; -10 1 -6 8 7 -4 -9 -9 8	8; 7 -4 2 0 -7 -7 9 -10 0 0; 6 -10 10 -6 9 9 2 2 0 9; -8 -5 -4 -5 6 -8 10 9 -1 -7;
-8 3 -8	4 9 -9 -7 5 -3 -4; -3 -5 5 6 -6 3 9 -9 -2 7; -2 -7 9 0 -1 -1 3 8 -2 6; -5 6 -3 9 3 -2 -2 -9 2 9; -10 7 -8 3 10 7 -8 7 -9 -6]; %Ctvercova matice radu 10
b=[-3; 4; 9; -1; 2; 4; 6; 8; -1; 5]; %Vektor prave strany
epsil=5e-14; %Tolerance
x0=zeros(length(b),1); %Bezny tvar pocatecniho vektoru reseni

%Dalsi nastavitelne parametry programu
maxReps=100; %Maximalni pocet opakovani algoritmu…zabrani cykleni programu pri divergenci vypoctu
reseni = 'Vypocet pro zadane parametry ulohy zrejme nekonverguje, pripadne konverguje prilis pomalu. Zkontrolujte prosim zadana vstupni data ulohy.';
m=length(b); %Pocet rovnic soustavy

%Vypocet
for reps=1:maxReps
    reps %Vypise aktualni cislo provadene iterace
r(:,1)=b-(A*x0); %Residuum pro pocitanou soustavu s vektorem reseni x0
beta=norm(r(:,1));

v(:,1)=r(:,1)/beta; %Normalizace sloupcoveho vektoru v(1); v(:) = ortonormalni baze Krylovova prostoru

for k=1:m
    w(:,k)=A*v(:,k); %konstrukce vektoru w
    for i=1:k
        h(i,k)=dot(w(:,k),v(:,i)); %h(:,:) = horni Hessenbergova matice
        w(:,k)=w(:,k)-h(i,k)*v(:,i);
    end
    h(k+1,k)=norm(w(:,k));
    if h(k+1,k) == 0
        if k == 1 %pro pripad nuloveho prvku v druhem radku a prvnim sloupci
            R(k,:,:)=h(1,1);
            d(k)=beta;
        end
        break
    end
    v(:,k+1)=w(:,k)/h(k+1,k); %normalizace vektoru v...
    
    
    
    %GIVENSUV QR ALGORITMUS…QR rozklad Hessenbergovy matice h(:,:)
    for a=1:m
        for bb=1:m
            G(:,:,a,bb)=eye(k+1); %prichystani matic G = Givensovych matic rovinnych rotaci (viz skripta NM1Mating.pdf, str.32). 
        end
    end
    Gfin=eye(k+1); %Ortonormalni matice…ve vysledku to bude matice G ze skript str. 33: G=Gn*Gn-1*...*G1, kde Gi = G (zavedeny v radku 45) 
    pomMatice(:,:,1,1)=h; %pomMatice je soucin soucinu Givensovych matic G a matice h, kterou rozkladame: 
    for l=1:k %pruchod sloupci matice
        d2=l; %d2 = promenna pro ulozeni aktualni hodnoty indexu sloupce
        GG(:,:,l)=eye(k+1); %GG predstavuje soucin Givensovych matic pro dany sloupec, ve kterem se nachazim
        for j=l+1:k+1 %pruchod radky matice
            if j == l+1 && l > 1 %jestlize zacnu pocitat v novem sloupci, musim cerpat z pomMatice z predesleho sloupce
                if pomMatice(j,l,c2,d2-1) == 0 %jestlize uz je nulovany prvek nulovy, tak pro nej vytvorim jednotkovou matici a jdu dal
                    G(:,:,j,l)=eye(k+1);
                    continue
                end
                d=sqrt((pomMatice(l,l,c2,d2-1)^2)+(pomMatice(j,l,c2,d2-1)^2)); %d…viz skripta str. 32
                G(l,l,j,l)=pomMatice(l,l,c2,d2-1)/d; %indexy = (radkovy index v matici, sloupcovy index v matici, prvni dolni index matice, druhy dolni index matice)
                G(j,l,j,l)=-pomMatice(j,l,c2,d2-1)/d; %viz skripta str. 32
                G(l,j,j,l)=pomMatice(j,l,c2,d2-1)/d;
                G(j,j,j,l)=pomMatice(l,l,c2,d2-1)/d;
            else
                c2=j-1; %c2 = promenna pro pevne ulozeni predesle hodnoty indexu radku, odkud cerpam hodnoty pomMatice

                if pomMatice(j,l,c2,d2) == 0 %jestlize uz je nulovany prvek nulovy, tak pro nej vytvorim jednotkovou matici a jdu dal
                G(:,:,j,l)=eye(k+1); 
                else
                d=sqrt((pomMatice(l,l,c2,d2)^2)+(pomMatice(j,l,c2,d2)^2));
                G(l,l,j,l)=pomMatice(l,l,c2,d2)/d; %indexy = (radkovy index, sloupcovy index, prvni dolni index matice, druhy dolni index matice)
                G(j,l,j,l)=-pomMatice(j,l,c2,d2)/d; %nahrazeni patricnych prvku matice G
                G(l,j,j,l)=pomMatice(j,l,c2,d2)/d;
                G(j,j,j,l)=pomMatice(l,l,c2,d2)/d;
                end
            end
            
        c2=j; d2=l;
        if j == l+1 && l ~= 1
            pomMatice(:,:,j,l)=G(:,:,c2,d2)*pomMatice(:,:,length(G(:,1)),d2-1); %vytvoreni pomMatice pro pozici, ve ktere se aktuane nachazim…kdyz zacnu v novem sloupci, odkazuji se pri vytvareni na pomMatici z posledniho radku predchoziho sloupce
        else    
        pomMatice(:,:,j,l)=G(:,:,c2,d2)*pomMatice(:,:,c2-1,d2); %vytvoreni pomMatice pro pozici, ve ktere se aktualne nachazim…cerpam z pomMatice z predchoziho radku
        end
        GG(:,:,d2)=G(:,:,c2,d2)*GG(:,:,d2); %vytvareni matice Gk pro soucasny sloupec
        end
        Gfin=GG(:,:,d2)*Gfin; %Kdyz dojdu na posledni radek pro dany sloupec, vynasobim Gfin zleva matici GG pro dany sloupec (viz popis matic GG, Gfin vyse)…Gfin bude ve vysledku soucin vsech G-cek ve vzorci pro matici R
        G(:,:,l+2,l+1)=eye(k+1);
    end
    R = Gfin*h; %Ziskam matici R z QR rozkladu…R = horni trojuhelnikova matice
    Q=Gfin'; %%Ziskam matici Q z QR rozkladu…Q = ortonormalni matice  
    %KONEC GIVENSOVA ALGORITMU

    e1=zeros(1,k+1);
    e1(1)=1; %konstrukce jednotkoveho vektoru delky k+1
    dc=beta*Q'*e1'; %vytvoreni vektoru d s carou (skripta str. 9)
    fi=dc(end); %fi…posledni prvek vektoru d s carou
    
    if abs(fi) < epsil %srovnani fi s hodnotou tolerance
        break
    end 
    
    
    clear G pomMatice Gfin GG; %vymazu data vypocitana v tomto kroku
end
            
    y=linsolve(R(1:end-1,1:end),dc(1:end-1)); %reseni soustavy R*y=d
    x=x0+v(:,1:end-1)*y; %stanoveni noveho reseni
    rr=b-A*x; %vypocet residua
    
x0=x; %x0 je nyni nové, právì vypocitane reseni
clear G pomMatice Gfin GG h v w r  c2 d2 j l beta; %vymazu data ziskana v teto iteraci vypoctu
if norm(rr,2) < epsil %jestlize je residuum dostatecne male, pak uloz reseni a ukonci program
             reseni=x; %ulozeni konecneho reseni do promenne, vyskonceni z cyklu a nasledne ukonceni vypoctu
             break
end
end
end
    