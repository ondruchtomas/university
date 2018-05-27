using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carb
{
    class Var
    {

            private double r, qd, d0;
            public float x , cs, temp, time;
            public double c0 = 0.2;
            public string err = "INVALID INPUT";
            public string succ = "SUCCESS";

            public Var() {
                r = 8.31; //molarni plynova konstanta
                qd = 148000; //aktivacni energie k uskutecneni difuze
                d0 = 2.3e-5; //difuzni koeficient uhliku v gamma-Fe
            }
            public double concX()
            {
                    return Math.Round((((1 - ((SpecialFunction.erf((((x / (2 * Math.Sqrt((d0 * Math.Exp(-qd / (r * (temp + 273.15)))) * time))))))))) *
                         (cs - c0)) + c0),5);
                }
        }
}

