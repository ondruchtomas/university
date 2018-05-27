namespace Carb
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.lblSurface = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pBoxArrow = new System.Windows.Forms.PictureBox();
            this.pBoxKnob = new System.Windows.Forms.PictureBox();
            this.Thermometer = new System.Windows.Forms.PictureBox();
            this.btnHHPlus = new System.Windows.Forms.Button();
            this.btnHHMinus = new System.Windows.Forms.Button();
            this.lblHH = new System.Windows.Forms.Label();
            this.btnMMPlus = new System.Windows.Forms.Button();
            this.btnMMMinus = new System.Windows.Forms.Button();
            this.lblMM = new System.Windows.Forms.Label();
            this.btnSSPlus = new System.Windows.Forms.Button();
            this.btnSSMinus = new System.Windows.Forms.Button();
            this.lblSS = new System.Windows.Forms.Label();
            this.lblInC = new System.Windows.Forms.Label();
            this.lblMaxCConc = new System.Windows.Forms.Label();
            this.lbl850Deg = new System.Windows.Forms.Label();
            this.lbl1000Deg = new System.Windows.Forms.Label();
            this.lblTxtTemp = new System.Windows.Forms.Label();
            this.lblTxtSurface = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblConcFinal = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblHHInfo = new System.Windows.Forms.Label();
            this.lblMMInfo = new System.Windows.Forms.Label();
            this.lblSSInfo = new System.Windows.Forms.Label();
            this.lbl02Info = new System.Windows.Forms.Label();
            this.lbl06Info = new System.Windows.Forms.Label();
            this.lbl10Info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxKnob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Thermometer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemp.ForeColor = System.Drawing.Color.Black;
            this.lblTemp.Location = new System.Drawing.Point(15, 48);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(249, 33);
            this.lblTemp.TabIndex = 7;
            this.lblTemp.Text = "TEMPERATURE [°C]";
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDepth.ForeColor = System.Drawing.Color.Black;
            this.lblDepth.Location = new System.Drawing.Point(51, 403);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(283, 33);
            this.lblDepth.TabIndex = 8;
            this.lblDepth.Text = "MEASURED DEPTH [m]";
            // 
            // txtDepth
            // 
            this.txtDepth.BackColor = System.Drawing.SystemColors.ControlText;
            this.txtDepth.Font = new System.Drawing.Font("LcdD", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtDepth.ForeColor = System.Drawing.Color.Red;
            this.txtDepth.Location = new System.Drawing.Point(366, 407);
            this.txtDepth.Multiline = true;
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.ReadOnly = true;
            this.txtDepth.Size = new System.Drawing.Size(179, 29);
            this.txtDepth.TabIndex = 9;
            this.txtDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDepth.TextChanged += new System.EventHandler(this.txtDepth_TextChanged);
            // 
            // lblSurface
            // 
            this.lblSurface.AutoSize = true;
            this.lblSurface.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSurface.ForeColor = System.Drawing.Color.Black;
            this.lblSurface.Location = new System.Drawing.Point(680, 48);
            this.lblSurface.Name = "lblSurface";
            this.lblSurface.Size = new System.Drawing.Size(367, 33);
            this.lblSurface.TabIndex = 10;
            this.lblSurface.Text = "SURFACE CARB. CONC. [wt%]";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTime.ForeColor = System.Drawing.Color.Black;
            this.lblTime.Location = new System.Drawing.Point(343, 48);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(218, 33);
            this.lblTime.TabIndex = 12;
            this.lblTime.Text = "TIME [HH:MM:SS]";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(317, 287);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(106, 49);
            this.btnRun.TabIndex = 14;
            this.btnRun.Text = "Carburize";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblResult.Font = new System.Drawing.Font("LcdD", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(498, 299);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(123, 37);
            this.lblResult.TabIndex = 15;
            this.lblResult.Text = "RESULT";
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.Location = new System.Drawing.Point(708, 98);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(339, 33);
            this.trackBar1.TabIndex = 24;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Value = 20;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // pBoxArrow
            // 
            this.pBoxArrow.Location = new System.Drawing.Point(788, 151);
            this.pBoxArrow.Name = "pBoxArrow";
            this.pBoxArrow.Size = new System.Drawing.Size(161, 105);
            this.pBoxArrow.TabIndex = 25;
            this.pBoxArrow.TabStop = false;
            this.pBoxArrow.Paint += new System.Windows.Forms.PaintEventHandler(this.pBoxArrow_Paint);
            // 
            // pBoxKnob
            // 
            this.pBoxKnob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxKnob.Location = new System.Drawing.Point(21, 84);
            this.pBoxKnob.Name = "pBoxKnob";
            this.pBoxKnob.Size = new System.Drawing.Size(94, 103);
            this.pBoxKnob.TabIndex = 26;
            this.pBoxKnob.TabStop = false;
            this.pBoxKnob.Paint += new System.Windows.Forms.PaintEventHandler(this.pBoxKnob_Paint);
            this.pBoxKnob.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxKnob_MouseDown);
            this.pBoxKnob.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBoxKnob_MouseMove);
            this.pBoxKnob.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxKnob_MouseUp);
            // 
            // Thermometer
            // 
            this.Thermometer.Location = new System.Drawing.Point(138, 103);
            this.Thermometer.Name = "Thermometer";
            this.Thermometer.Size = new System.Drawing.Size(42, 138);
            this.Thermometer.TabIndex = 27;
            this.Thermometer.TabStop = false;
            this.Thermometer.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // btnHHPlus
            // 
            this.btnHHPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHHPlus.Location = new System.Drawing.Point(317, 130);
            this.btnHHPlus.Name = "btnHHPlus";
            this.btnHHPlus.Size = new System.Drawing.Size(17, 28);
            this.btnHHPlus.TabIndex = 28;
            this.btnHHPlus.Text = "+";
            this.btnHHPlus.UseVisualStyleBackColor = true;
            this.btnHHPlus.Click += new System.EventHandler(this.btnHHPlus_Click);
            // 
            // btnHHMinus
            // 
            this.btnHHMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHHMinus.Location = new System.Drawing.Point(317, 164);
            this.btnHHMinus.Name = "btnHHMinus";
            this.btnHHMinus.Size = new System.Drawing.Size(17, 28);
            this.btnHHMinus.TabIndex = 29;
            this.btnHHMinus.Text = "-";
            this.btnHHMinus.UseVisualStyleBackColor = true;
            this.btnHHMinus.Click += new System.EventHandler(this.btnHHMinus_Click);
            // 
            // lblHH
            // 
            this.lblHH.AutoSize = true;
            this.lblHH.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblHH.Font = new System.Drawing.Font("LcdD", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHH.ForeColor = System.Drawing.Color.Red;
            this.lblHH.Location = new System.Drawing.Point(340, 143);
            this.lblHH.Name = "lblHH";
            this.lblHH.Size = new System.Drawing.Size(26, 26);
            this.lblHH.TabIndex = 30;
            this.lblHH.Text = "0";
            // 
            // btnMMPlus
            // 
            this.btnMMPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMMPlus.Location = new System.Drawing.Point(420, 130);
            this.btnMMPlus.Name = "btnMMPlus";
            this.btnMMPlus.Size = new System.Drawing.Size(17, 28);
            this.btnMMPlus.TabIndex = 31;
            this.btnMMPlus.Text = "+";
            this.btnMMPlus.UseVisualStyleBackColor = true;
            this.btnMMPlus.Click += new System.EventHandler(this.btnMMPlus_Click);
            // 
            // btnMMMinus
            // 
            this.btnMMMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMMMinus.Location = new System.Drawing.Point(420, 164);
            this.btnMMMinus.Name = "btnMMMinus";
            this.btnMMMinus.Size = new System.Drawing.Size(17, 27);
            this.btnMMMinus.TabIndex = 32;
            this.btnMMMinus.Text = "-";
            this.btnMMMinus.UseVisualStyleBackColor = true;
            this.btnMMMinus.Click += new System.EventHandler(this.btnMMMinus_Click);
            // 
            // lblMM
            // 
            this.lblMM.AutoSize = true;
            this.lblMM.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblMM.Font = new System.Drawing.Font("LcdD", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMM.ForeColor = System.Drawing.Color.Red;
            this.lblMM.Location = new System.Drawing.Point(443, 143);
            this.lblMM.Name = "lblMM";
            this.lblMM.Size = new System.Drawing.Size(26, 26);
            this.lblMM.TabIndex = 33;
            this.lblMM.Text = "0";
            // 
            // btnSSPlus
            // 
            this.btnSSPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSSPlus.Location = new System.Drawing.Point(528, 130);
            this.btnSSPlus.Name = "btnSSPlus";
            this.btnSSPlus.Size = new System.Drawing.Size(17, 28);
            this.btnSSPlus.TabIndex = 34;
            this.btnSSPlus.Text = "+";
            this.btnSSPlus.UseVisualStyleBackColor = true;
            this.btnSSPlus.Click += new System.EventHandler(this.btnSSPlus_Click);
            // 
            // btnSSMinus
            // 
            this.btnSSMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSSMinus.Location = new System.Drawing.Point(528, 164);
            this.btnSSMinus.Name = "btnSSMinus";
            this.btnSSMinus.Size = new System.Drawing.Size(17, 27);
            this.btnSSMinus.TabIndex = 35;
            this.btnSSMinus.Text = "-";
            this.btnSSMinus.UseVisualStyleBackColor = true;
            this.btnSSMinus.Click += new System.EventHandler(this.btnSSMinus_Click);
            // 
            // lblSS
            // 
            this.lblSS.AutoSize = true;
            this.lblSS.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblSS.Font = new System.Drawing.Font("LcdD", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSS.ForeColor = System.Drawing.Color.Red;
            this.lblSS.Location = new System.Drawing.Point(551, 143);
            this.lblSS.Name = "lblSS";
            this.lblSS.Size = new System.Drawing.Size(26, 26);
            this.lblSS.TabIndex = 36;
            this.lblSS.Text = "0";
            // 
            // lblInC
            // 
            this.lblInC.AutoSize = true;
            this.lblInC.Location = new System.Drawing.Point(705, 134);
            this.lblInC.Name = "lblInC";
            this.lblInC.Size = new System.Drawing.Size(47, 13);
            this.lblInC.TabIndex = 37;
            this.lblInC.Text = "0,2% wt.";
            // 
            // lblMaxCConc
            // 
            this.lblMaxCConc.AutoSize = true;
            this.lblMaxCConc.Location = new System.Drawing.Point(1019, 134);
            this.lblMaxCConc.Name = "lblMaxCConc";
            this.lblMaxCConc.Size = new System.Drawing.Size(38, 13);
            this.lblMaxCConc.TabIndex = 38;
            this.lblMaxCConc.Text = "1% wt.";
            // 
            // lbl850Deg
            // 
            this.lbl850Deg.AutoSize = true;
            this.lbl850Deg.Location = new System.Drawing.Point(166, 203);
            this.lbl850Deg.Name = "lbl850Deg";
            this.lbl850Deg.Size = new System.Drawing.Size(36, 13);
            this.lbl850Deg.TabIndex = 39;
            this.lbl850Deg.Text = "850°C";
            // 
            // lbl1000Deg
            // 
            this.lbl1000Deg.AutoSize = true;
            this.lbl1000Deg.Location = new System.Drawing.Point(166, 103);
            this.lbl1000Deg.Name = "lbl1000Deg";
            this.lbl1000Deg.Size = new System.Drawing.Size(42, 13);
            this.lbl1000Deg.TabIndex = 40;
            this.lbl1000Deg.Text = "1000°C";
            // 
            // lblTxtTemp
            // 
            this.lblTxtTemp.AutoSize = true;
            this.lblTxtTemp.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblTxtTemp.Font = new System.Drawing.Font("LcdD", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTxtTemp.ForeColor = System.Drawing.Color.Red;
            this.lblTxtTemp.Location = new System.Drawing.Point(42, 190);
            this.lblTxtTemp.Name = "lblTxtTemp";
            this.lblTxtTemp.Size = new System.Drawing.Size(36, 26);
            this.lblTxtTemp.TabIndex = 41;
            this.lblTxtTemp.Text = "   ";
            // 
            // lblTxtSurface
            // 
            this.lblTxtSurface.AutoSize = true;
            this.lblTxtSurface.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblTxtSurface.Font = new System.Drawing.Font("LcdD", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTxtSurface.ForeColor = System.Drawing.Color.Red;
            this.lblTxtSurface.Location = new System.Drawing.Point(853, 287);
            this.lblTxtSurface.Name = "lblTxtSurface";
            this.lblTxtSurface.Size = new System.Drawing.Size(68, 26);
            this.lblTxtSurface.TabIndex = 42;
            this.lblTxtSurface.Text = "       ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(982, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblConcFinal
            // 
            this.lblConcFinal.AutoSize = true;
            this.lblConcFinal.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblConcFinal.Font = new System.Drawing.Font("LcdD", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblConcFinal.ForeColor = System.Drawing.Color.Lime;
            this.lblConcFinal.Location = new System.Drawing.Point(920, 403);
            this.lblConcFinal.Name = "lblConcFinal";
            this.lblConcFinal.Size = new System.Drawing.Size(127, 37);
            this.lblConcFinal.TabIndex = 44;
            this.lblConcFinal.Text = "           ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(737, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 49);
            this.button2.TabIndex = 45;
            this.button2.Text = "Calculate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblHHInfo
            // 
            this.lblHHInfo.AutoSize = true;
            this.lblHHInfo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHHInfo.Location = new System.Drawing.Point(372, 143);
            this.lblHHInfo.Name = "lblHHInfo";
            this.lblHHInfo.Size = new System.Drawing.Size(38, 24);
            this.lblHHInfo.TabIndex = 46;
            this.lblHHInfo.Text = "HH";
            // 
            // lblMMInfo
            // 
            this.lblMMInfo.AutoSize = true;
            this.lblMMInfo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMMInfo.Location = new System.Drawing.Point(475, 143);
            this.lblMMInfo.Name = "lblMMInfo";
            this.lblMMInfo.Size = new System.Drawing.Size(44, 24);
            this.lblMMInfo.TabIndex = 47;
            this.lblMMInfo.Text = "MM";
            // 
            // lblSSInfo
            // 
            this.lblSSInfo.AutoSize = true;
            this.lblSSInfo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSSInfo.Location = new System.Drawing.Point(583, 143);
            this.lblSSInfo.Name = "lblSSInfo";
            this.lblSSInfo.Size = new System.Drawing.Size(38, 24);
            this.lblSSInfo.TabIndex = 48;
            this.lblSSInfo.Text = "SS";
            // 
            // lbl02Info
            // 
            this.lbl02Info.AutoSize = true;
            this.lbl02Info.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl02Info.Location = new System.Drawing.Point(793, 239);
            this.lbl02Info.Name = "lbl02Info";
            this.lbl02Info.Size = new System.Drawing.Size(40, 24);
            this.lbl02Info.TabIndex = 49;
            this.lbl02Info.Text = "0,2";
            // 
            // lbl06Info
            // 
            this.lbl06Info.AutoSize = true;
            this.lbl06Info.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl06Info.Location = new System.Drawing.Point(868, 168);
            this.lbl06Info.Name = "lbl06Info";
            this.lbl06Info.Size = new System.Drawing.Size(40, 24);
            this.lbl06Info.TabIndex = 50;
            this.lbl06Info.Text = "0,6";
            // 
            // lbl10Info
            // 
            this.lbl10Info.AutoSize = true;
            this.lbl10Info.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl10Info.Location = new System.Drawing.Point(943, 239);
            this.lbl10Info.Name = "lbl10Info";
            this.lbl10Info.Size = new System.Drawing.Size(40, 24);
            this.lbl10Info.TabIndex = 51;
            this.lbl10Info.Text = "1,0";
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1117, 488);
            this.Controls.Add(this.lbl10Info);
            this.Controls.Add(this.lbl06Info);
            this.Controls.Add(this.lbl02Info);
            this.Controls.Add(this.lblSSInfo);
            this.Controls.Add(this.lblMMInfo);
            this.Controls.Add(this.lblHHInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblConcFinal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTxtSurface);
            this.Controls.Add(this.lblTxtTemp);
            this.Controls.Add(this.lbl1000Deg);
            this.Controls.Add(this.lbl850Deg);
            this.Controls.Add(this.lblMaxCConc);
            this.Controls.Add(this.lblInC);
            this.Controls.Add(this.lblSS);
            this.Controls.Add(this.btnSSMinus);
            this.Controls.Add(this.btnSSPlus);
            this.Controls.Add(this.lblMM);
            this.Controls.Add(this.btnMMMinus);
            this.Controls.Add(this.btnMMPlus);
            this.Controls.Add(this.lblHH);
            this.Controls.Add(this.btnHHMinus);
            this.Controls.Add(this.btnHHPlus);
            this.Controls.Add(this.Thermometer);
            this.Controls.Add(this.pBoxKnob);
            this.Controls.Add(this.pBoxArrow);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblSurface);
            this.Controls.Add(this.txtDepth);
            this.Controls.Add(this.lblDepth);
            this.Controls.Add(this.lblTemp);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Van-Ostrand Dewey Equation";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxKnob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Thermometer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.TextBox txtDepth;
        private System.Windows.Forms.Label lblSurface;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pBoxArrow;
        private System.Windows.Forms.PictureBox pBoxKnob;
        private System.Windows.Forms.PictureBox Thermometer;
        private System.Windows.Forms.Button btnHHPlus;
        private System.Windows.Forms.Button btnHHMinus;
        private System.Windows.Forms.Label lblHH;
        private System.Windows.Forms.Button btnMMPlus;
        private System.Windows.Forms.Button btnMMMinus;
        private System.Windows.Forms.Label lblMM;
        private System.Windows.Forms.Button btnSSPlus;
        private System.Windows.Forms.Button btnSSMinus;
        private System.Windows.Forms.Label lblSS;
        private System.Windows.Forms.Label lblInC;
        private System.Windows.Forms.Label lblMaxCConc;
        private System.Windows.Forms.Label lbl850Deg;
        private System.Windows.Forms.Label lbl1000Deg;
        private System.Windows.Forms.Label lblTxtTemp;
        private System.Windows.Forms.Label lblTxtSurface;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblConcFinal;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblHHInfo;
        private System.Windows.Forms.Label lblMMInfo;
        private System.Windows.Forms.Label lblSSInfo;
        private System.Windows.Forms.Label lbl02Info;
        private System.Windows.Forms.Label lbl06Info;
        private System.Windows.Forms.Label lbl10Info;
    }
}

