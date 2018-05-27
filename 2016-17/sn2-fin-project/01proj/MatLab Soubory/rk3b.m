function [t,y,yp] = rk3b %PRO VELKE LAMBDA EXPLICITNI METODA HAVARUJE, NEBOT musi platit podminka: tau < 2/lambda...
format long

order = 3;
c2 = 1;%zadani koeficientu c2
c3 = 2;%zadani koeficientu c3
matice = [1 1 1; 0 c2^2 c3^2; 0 c2 c3];
pravstr = [1 1/3 1/2]';
vecb = linsolve(matice,pravstr);

b1=vecb(1); b2=vecb(2); b3=vecb(3); a32=1/(6*c2*b3);


f = @(t,y) 9-0.002*y;
cas = [0 250];
N=10;
y0=0; %poc. podminka

tau = (cas(2)-cas(1))/N;
t=cas(1):tau:cas(2);

y = zeros(1,N+1);
y(1)=y0;
k = zeros(1,order);

for n=1:N
    k(1)=f(t(n),y(n));
    k(2)=f(t(n)+tau*c2,y(n)+tau*c2*k(1));
    k(3)=f(t(n)+tau*c3, y(n)+tau*((c3-a32)*k(1)+a32*k(2)));
    y(n+1)=y(n)+tau*(b1*k(1)+b2*k(2)+b3*k(3));
end

yp = 4500*(1-exp(-0.002*t)); %presne reseni
[tMatLab,yMatLab] = ode45(f, cas, y0);

y', yp' %vypis vysledku
maxChyba=max(abs(yp-y)) %chyba v reseni

%zachrana zivota v nadrzi: y(t) = 1; t=? -> t=0.111123459hod = 6min 40sec (urceno z presneho reseni)

 plot(t,yp,'r'),hold on;
 plot(t,y,'b'), hold on;
 plot(tMatLab,yMatLab,'g'), hold on;
 
 title('Exact Solution vs. Numerical RK3 Solution vs. MatLab ode45 Solution');
xlabel('time [hours]'); ylabel('Concentration [mg/1000m^3]');
legend('Exact Solution','RK2 Solution','ode45 Solution');hold on