using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Carb
{
    class GraphicElement
    {
        protected Color color;
        protected Point pointS, pointKnDef;
        public Point pointF;
        public Pen myPen;

        public GraphicElement()
        {
            myPen = new Pen(Color.Red, 3);
            color = Color.Red;
            pointS = new Point();
            pointF = new Point();
        }

        public Point PointS
        {
            get { return this.pointS; }
        }

        public Point PointF
        {
            get { return this.pointF; }
        }

        public Point PointKnDef
        {
            get { return this.pointKnDef; }
        }

        public virtual int Radius
        {
            get { return 16; }
        }

        public Color AppearColor
        {
            get { return this.color; }
        }

        public int GetArrowX(float a, double b)
        {
            return Convert.ToInt32(100 + -(50 * Math.Cos(((((a / (float)100) - b) / (1 - b)) * Math.PI))));
        }

        public int GetArrowY(float a, double b)
        {
            return Convert.ToInt32(100 + -(50 * Math.Sin((((a / (float)100) - b) / (1 - b)) * Math.PI)));
        }

        public int GetTempX(int a) 
        {
            return Convert.ToInt32(((51 / 25) * a) - 38.8);
        }

        public int GetKnobX(int a, int b)
        {
            return Convert.ToInt32(45 - (25 * ((45 - a) / (Math.Sqrt(((a - 45) * (a - 45)) + ((b - 45) * (b - 45))) + 1))));
        }

}


    class RingMain : GraphicElement
    {
        public RingMain()
        {
            pointS = new Point(5, 100);
        }
    }

    class RingSecondary : RingMain
    {
        public RingSecondary()
        {
            color = Color.Gray;
            pointS = new Point(20, 20);
        }

        public override int Radius
        {
            get
            {
                return 50;
            }
        }
    }

    class LineSegmentMain : GraphicElement
    {
        Var variab = new Var();

        public LineSegmentMain()
        {
            pointS = new Point(100, 100);
        }
    }

    class LineSegmentSec : LineSegmentMain
    {
        KnobElements knobEl = new KnobElements();
        public LineSegmentSec()
        {
            pointS = new Point(13, 102);
            pointF = new Point(13, GetTempX(knobEl.yKnob));
        }
    }

    class LineSegmentThrd : LineSegmentMain
    {
        KnobElements knobEl = new KnobElements();
        public LineSegmentThrd()
        {
            pointS = new Point(45, 45);
            pointKnDef = new Point(45, 70);
        }
    }

    }

    

