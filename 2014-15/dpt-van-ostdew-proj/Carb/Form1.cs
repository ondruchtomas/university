using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace Carb
{
    public partial class Form1 : Form
    {
        Var variab = new Var();
        KnobElements knobEl = new KnobElements();
        GraphicElement grEl = new GraphicElement();
        RingMain rMain = new RingMain();
        RingSecondary rSec = new RingSecondary();
        LineSegmentMain lSegMain = new LineSegmentMain();
        LineSegmentSec lSegSec = new LineSegmentSec();
        LineSegmentThrd lSegThrd = new LineSegmentThrd();


        public Form1()
        {
            InitializeComponent();
            lblTxtSurface.Text = (trackBar1.Value / (float)100).ToString();
            variab.cs = float.Parse(lblTxtSurface.Text);
        }



        private void btnRun_Click(object sender, EventArgs e)
        {
            variab.temp = float.Parse(lblTxtTemp.Text);
            if ((float.Parse(lblHH.Text) > 0) || (float.Parse(lblMM.Text) > 0) || (float.Parse(lblSS.Text) > 0))
            {
                lblResult.Text = variab.succ;

                if (lblResult.Text == variab.err)
                {
                    txtDepth.ReadOnly = true;
                }
                else
                {
                    txtDepth.ReadOnly = false;
                }
                }
                else
                    lblResult.Text = variab.err;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            variab.cs=(trackBar1.Value / (float)100);
            lblTxtSurface.Text = variab.cs.ToString();
            pBoxArrow.Invalidate();
        }

        private void txtDepth_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(txtDepth.Text, out variab.x);
        }

        private void pBoxArrow_Paint(object sender, PaintEventArgs e)
        {
            lSegMain.pointF.X = lSegMain.GetArrowX(trackBar1.Value, variab.c0);
            lSegMain.pointF.Y = lSegMain.GetArrowY(trackBar1.Value, variab.c0);

            Graphics g = e.Graphics;
            g.DrawLine(lSegMain.myPen, lSegMain.PointS, lSegMain.PointF);
        }

        private void pBoxKnob_MouseDown(object sender, MouseEventArgs e)
        {
            knobEl.onMove = true;
        }

        private void pBoxKnob_MouseUp(object sender, MouseEventArgs e)
        {
            knobEl.onMove = false;
        }

        private void pBoxKnob_MouseMove(object sender, MouseEventArgs e)
        {
            if ((knobEl.onMove == true)&&(e.X<=45))
            {
                knobEl.xMouse = e.X;
                knobEl.yMouse = e.Y;
                pBoxKnob.Invalidate();
            }
        }

        private void pBoxKnob_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush brushRSec = new SolidBrush(rSec.AppearColor);
            g.FillEllipse(brushRSec, rSec.PointS.X, rSec.PointS.Y, rSec.Radius, rSec.Radius);

            knobEl.YKnob();
            lSegThrd.pointF.X = lSegThrd.GetKnobX(knobEl.xMouse, knobEl.yMouse);
            lSegThrd.pointF.Y = knobEl.yKnob;

            if ((knobEl.xMouse == 0) && (knobEl.yMouse == 0))
            {
                g.DrawLine(grEl.myPen, lSegThrd.PointS, lSegThrd.PointKnDef);
                knobEl.yKnob = 70;
            }
            else
            {
                g.DrawLine(grEl.myPen, lSegThrd.PointS, lSegThrd.PointF);
            }

            Thermometer.Invalidate();
            }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawRectangle(Pens.Black, 3, 0, 20, 120);

            lSegSec.pointF.Y = lSegSec.GetTempX(knobEl.yKnob);

            SolidBrush brushRMain = new SolidBrush(rMain.AppearColor);
            g.FillEllipse(brushRMain,rMain.PointS.X,rMain.PointS.Y,rMain.Radius,rMain.Radius);
            
            g.DrawLine(lSegSec.myPen, lSegSec.PointS, lSegSec.PointF);
            lblTxtTemp.Text = ((-3 * knobEl.yKnob) + 1060).ToString();
        }

        private void btnHHPlus_Click(object sender, EventArgs e)
        {
            lblHH.Invalidate();
            variab.time = variab.time + 3600;
            lblHH.Text = ((float.Parse(lblHH.Text)+1).ToString());
        }

        private void btnHHMinus_Click(object sender, EventArgs e)
        {
            lblHH.Invalidate();
            if (float.Parse(lblHH.Text) == 0) { }
            else
            {
                variab.time = variab.time - 3600;
                lblHH.Text = ((float.Parse(lblHH.Text) - 1).ToString());
            }
        }

        private void btnMMPlus_Click(object sender, EventArgs e)
        {
            lblMM.Invalidate();
            if (float.Parse(lblMM.Text) == 59) { variab.time = variab.time-3540;}
            else
            {
            variab.time = variab.time + 60;}
            lblMM.Text = (((float.Parse(lblMM.Text) + 1)%60).ToString());
        }

        private void btnMMMinus_Click(object sender, EventArgs e)
        {
            lblMM.Invalidate();
                if ((float.Parse(lblMM.Text)==0)) { }
                else
                {
                    variab.time = variab.time - 60;
                    lblMM.Text = (((float.Parse(lblMM.Text) - 1)%60).ToString());
                }
        }

        private void btnSSPlus_Click(object sender, EventArgs e)
        {
            lblSS.Invalidate();
            if (float.Parse(lblSS.Text) == 59) { variab.time = variab.time - 59; }
            else
            {
                variab.time = variab.time + 1;
            }
                lblSS.Text = (((float.Parse(lblSS.Text) + 1) % 60).ToString());
        }

        private void btnSSMinus_Click(object sender, EventArgs e)
        {
            lblSS.Invalidate();
                if ((float.Parse(lblSS.Text) == 0)) { }
                else
                {
                    variab.time = variab.time - 1;
                    lblSS.Text = (((float.Parse(lblSS.Text) - 1) % 60).ToString());
                }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == variab.succ)
            {
                lblConcFinal.Text = (Convert.ToString(variab.concX()) + " %");
            }
        }
        }

    }

    
