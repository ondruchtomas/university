function dy = fcePecle(t,y)
dy = zeros(2,1);   % inicializace

dy(1)=-y(1)*sin((1.4+t)/3)-y(2);
dy(2)=((1.6*t)/(1+power(t,3)))*y(2)+3*cos(t);



