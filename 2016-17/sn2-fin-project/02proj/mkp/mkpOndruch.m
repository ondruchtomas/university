function [x,delta] = mkpOndruch %uzivateli se ulozi vektor x (cas) a ziskane reseni v uzlovych bodech
clear all
format long

%VSTUPY ZE ZADANI ULOHY
cas = [0 3]; %interval ze zadani
h=0.1; %krok
x=cas(1):h:cas(2); %predchystani vektoru pro cas
N=length(x);
bigK1=zeros(N,N); %inicializace globalni matice K1...zahrnuje clen p z rovnice pro okrajovy problem
bigK2=zeros(N,N); %inicializace globalni matice K2...zahrnuje clen q z rovnice pro okrajovy problem
bigF=zeros(N,1); %inicializace globalniho vektoru F
delta=zeros(N,1); %inicializace vektoru hodnot v uzlovych bodech = hlavni vystup

%cleny p, q, f zavedeny jako funkce, nebot nejsou konstantni
p = @(x) 7*x*x+1;
q = @(x) 5.5/(x+1);
f = @(x) cos(x*x);

%promenne vztahujici se k zadanym okrajovym podminkam
g0=12;
alfal=403.2; %vypocitano na papire
betal=221.44; %vypocitano na papire
%%%%%%%%%%

%VYTVARENI ELEMENTARNICH A NASLEDNE GLOBALNICH MATIC A VEKTORU PRO SOUSTAVU
for i=1:(N-1)
    konstK1=(p(x(i)+h/2))/h; %
    K1=konstK1*[1,-1;-1,1]; %elementarni matice K1
    bigK1(i,i)=bigK1(i,i)+K1(1,1); bigK1(i,i+1)=bigK1(i,i+1)+K1(1,2); bigK1(i+1,i)=bigK1(i+1,i)+K1(2,1); bigK1(i+1,i+1)=bigK1(i+1,i+1)+K1(2,2); %globalni matice K1...postupne se zaplnuje
    konstK2 = (h/2); 
    K2 = konstK2*[q(x(i)) 0; 0 q(x(i+1))]; %nepocitam s limitama, nebot zadana q je na mem intervalu spojita
    bigK2(i,i)=bigK2(i,i)+K2(1,1); bigK2(i,i+1)=bigK2(i,i+1)+K2(1,2); bigK2(i+1,i)=bigK2(i+1,i)+K2(2,1); bigK2(i+1,i+1)=bigK2(i+1,i+1)+K2(2,2);%globalni matice K2...postupne se zaplnuje
    F=[(h*f(x(i)))/2;(h*f(x(i)))/2]; %elementarni vektor F pro f^i konstantni na elementu
    bigF(i)=bigF(i)+F(1); bigF(i+1)=bigF(i+1)+F(2); %globalni vektor F...postupne se zaplnuje
end
bigK = bigK1+bigK2; %dam dohromady matice zahrnujici p i q
bigK(end:end)=bigK(end,end)+alfal; %na patricne pozice vlozim alfa_l a beta_l, ktere se vztahuji k okraj.podmince s derivaci
bigF(end)=bigF(end)+betal;
%%%%%%%%%%

%ELIMINACNI TECHNIKA, ZOHLEDNENI DIRICHLETOVY PODMINKY
delta(1)=g0;
elimK=bigK(2:end,2:end); %ze soustavy vyjmu prvni radek a sloupec, nebot znam prvni delta z dirichletovy podminky
bigF=bigF-g0*bigK(:,1); %odectu 12x prvni radek od prave strany
elimF=bigF(2:end); %z vektoru prave strany odeberu prvni slozku
delta(2:end)=linsolve(elimK,elimF); %urceni hodnot v uzlovych bodech = reseni soustavy s tridiagonalni matici soustavy (reseno klasicky pres linsolve, i kdyz je zde prostor pro optimalizaci kodu pouzitim vhodnejsiho algoritmu)
delta %vypis ziskanych hodnot v uzlovych bodech deleni
%%%%%%%%


%RESENI PRES PRIKAZ bvp4c
solinit = bvpinit(x,[1 0]); %pocatecni odhad
sol = bvp4c(@mkpFun,@mkp_podm, solinit); %spusteni metody bvp4c
ypres = deval(sol,x); %zisk "presneho" reseni
bvp4cRes=ypres(1,:)' %vypis hodnot pro metodu bvp4c
%%%%%%%%

%KONTROLNI VYPIS PRESNOSTI
res=max(bvp4cRes-delta) %VYPIS NEJVETSI ODCHYLKY MEZI RESENIM MKP A bvp4c
%%%%%%%%

hold on; plot(x,ypres(1,:),'r'); hold on; plot(x,delta,'b')

 title('Srovnani vystupu naprogramovane MKP a algoritmu bvp4c');
xlabel('x'); ylabel('y');
legend('bvp4c','MKP');hold on


 

 