function [t,y,yp] = rk2b %PRO VELKE LAMBDA EXPLICITNI METODA HAVARUJE, NEBOT musi platit podminka: tau < 2/lambda...
format long

order = 2;
a = 1; %zadani koeficientu a
f = @(t,y) 9-0.002*y;
cas = [0 250];
N=10;
y0=0; %poc. podminka

tau = (cas(2)-cas(1))/N;
t=cas(1):tau:cas(2);

y = zeros(1,N+1);
y(1)=y0;
b = 1/(2*a);
k = zeros(1,order);

for n=1:N
    k(1)=f(t(n),y(n));
    k(2)=f(t(n)+tau*a,y(n)+tau*a*k(1));
    
    y(n+1)=y(n)+tau*((1-b)*k(1)+b*k(2));
end

yp = 4500*(1-exp(-0.002*t)); %presne reseni
[tMatLab,yMatLab] = ode45(f, cas, y0);



y', yp' %vypis vysledku
maxChyba=max(abs(yp-y)) %chyba v reseni

%zachrana zivota v nadrzi: y(t) = 1; t=? -> t=0.111123459hod = 6min 40sec (urceno z presneho reseni)

 plot(t,yp,'r'),hold on;
 plot(t,y,'b'), hold on;
 plot(tMatLab,yMatLab,'g'), hold on;
 
 title('Exact Solution vs. Numerical RK2 Solution vs. MatLab ode45 Solution');
xlabel('time [hours]'); ylabel('Concentration [mg/1000m^3]');
legend('Exact Solution','RK2 Solution','ode45 Solution');hold on