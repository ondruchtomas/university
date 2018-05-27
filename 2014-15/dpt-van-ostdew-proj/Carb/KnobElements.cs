using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Carb
{
    class KnobElements
    {
        public int xMouse;
        public int yMouse;
        public bool onMove;
        public int yKnob;

        public void YKnob()
        {
            if (yMouse > 45)
            { yKnob = Convert.ToInt32(45 + (25 * (Math.Sin(Math.Acos((45 - xMouse) / (Math.Sqrt(((xMouse - 45) * (xMouse - 45)) + ((yMouse - 45) * (yMouse - 45))) + 1)))))); }
            else
            { yKnob = Convert.ToInt32(45 - (25 * (Math.Sin(Math.Acos((45 - xMouse) / (Math.Sqrt(((xMouse - 45) * (xMouse - 45)) + ((yMouse - 45) * (yMouse - 45))) + 1)))))); }
        }
    }

    }

