using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Carb
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            lblHelp.Text = System.IO.File.ReadAllText(@"..\..\External\helptext.txt");
        
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {

        }
        }
    }

