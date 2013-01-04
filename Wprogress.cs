using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrimeFinder
{
    public partial class Wprogress : Form
    {
        public Wprogress(string message)
        {
            this.Text = message;
            InitializeComponent();
        }

        public void Changeprogress(double value)
        {
            int pourcentage = (int)Math.Round(value*100,0);
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    progressBar1.Value = pourcentage;
                    label1.Text = pourcentage.ToString() + "%";
                });
            }
            catch(Exception e)
            {
                
            }
        }
    }
}
