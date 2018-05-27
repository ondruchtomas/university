function [t,y] = pecleOndruch %PRO VELKE LAMBDA EXPLICITNI METODA HAVARUJE, NEBOT musi platit podminka: tau < 2/lambda...
format long

%VSTUPY ZE ZADANI ULOHY
cas = [0 4]; %interval ze zadani
pocpodm = [2 9];%poc. podminky ze zadani
N=1000; %deleni ze zadani
%%%%%%%%

%DALSI UZITECNE PROMENNE
tau = (cas(2)-cas(1))/N; %vytvoreni casoveho kroku
t=cas(1):tau:cas(2); %predchystani vektoru pro cas
y = zeros(length(pocpodm),N+1); %deklarace promenne y pro ukladani reseni v jednotlivych casech
y(:,1)=pocpodm; %hodnota hledane funkce v pocatecnim case...prvni ze trich pocatecnich kroku pro moje trikrokove metody
%%%%%%%%

%URCENI DRUHEHO A TRETIHO KROKU JAKO NUTNYCH VSTUPU PRO MOJE TRIKROKOVE METODY...URCENO PODLE HEUNEHO METODY
for i=2:3
    y(:,i)=y(:,i-1)+0.5*tau*(fcePecle(t(i-1),y(:,i-1))+fcePecle(t(i-1)+tau,y(:,i-1)+tau*fcePecle(t(i-1),y(:,i-1))));
end
%%%%%%%%


%POSTUP PODLE PECLE...KOEFICIENTY PRO AB3 A AM3 METODU ODECTENY Z TABULKY Z TEXTU OD DOC.CERMAKA
for n=3:N
    ystar=y(:,n)+(1/12)*tau*(23*fcePecle(t(n),y(:,n))-16*fcePecle(t(n-1),y(:,n-1))+5*fcePecle(t(n-2),y(:,n-2))); %krok P, AB3...koeficienty beta urceny z prislusne tabulky
    fstar=fcePecle(t(n+1),ystar); %krok E, AB3
    ydoublestar=y(:,n)+(1/12)*tau*(5*fstar + 8*fcePecle(t(n),y(:,n))-fcePecle(t(n-1),y(:,n-1)));%krok C, AM3...koeficienty beta urceny z prislusne tabulky
    est=-0.1*(ydoublestar-ystar); %krok L, AB3...hodnoty C a C* urceny z prislusnych tabulek...podil dava hodnotu -0,1
    y(:,n+1)=ydoublestar + est; %zaverecne urceni reseni
end
%%%%%%%%%

%UKOL a) VYKRESLENI GRAFU + POROVNANI S ODE113
[t113,y113]=ode113(@fcePecle,t,pocpodm); %vypocet podle funkce ode113
plot(t,y(1,:),t,y(2,:),t113,y113(:,1),'r',t113,y113(:,2),'y'); hold on %vykresleni reseni

title('Srovnani metody AB3-AM3 a funkce ode113'); %popis grafu
xlabel('y'); ylabel('t'); %osy grafu
legend('y1 podle AB3-AM3','y2 podle AB3-AM3', 'y1 podle ode113','y2 podle ode113');hold on %legenda
%%%%%%%%%%%

%UKOL b) VYPSANI APROXIMACE PRO CAS t=4
disp('y1 v èase t=4 podle AB3-AM3-PECLE');
disp(y(1,end)); %podle AB3-AM3-PECLE
disp('y1 v èase t=4 podle ode113');
disp(y113(end,1)); %podle ode113

disp('y2 v èase t=4 podle AB3-AM3-PECLE');
disp(y(2,end)); %podle AB3-AM3-PECLE
disp('y2 v èase t=4 podle ode113');
disp(y113(end,2)); %podle ode113
%%%%%%%%%%%

 