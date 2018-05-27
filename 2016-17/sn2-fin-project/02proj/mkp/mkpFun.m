function dy = mkpFun(t,y)
dy = zeros(2,1);   % inicializace

dy(1)=y(2);
dy(2)=((-14*t)./(7*t.*t+1))*y(2)+(5.5/((t+1)*(7*t.*t+1)))*y(1)-cos(t.*t)./(7*t.*t+1);



