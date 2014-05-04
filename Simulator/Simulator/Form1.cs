using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simulator
{
    public partial class Form1 : Form
    {
        public int FormCount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public Form g()
        {
            return this;
        }

   

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void buttonhide()
        {
            button1.Visible = false;
            button2.Visible = false;
           
        }
        public void buttonshow()
    {
            button1.Visible = true;
            button2.Visible = true;
            
    }
        private void button1_Click(object sender, EventArgs e)
        {
            Lectures fr2 = new Lectures(this);
            fr2.MdiParent = this;
            fr2.Show();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Work_with_Algorithms fr2 = new Work_with_Algorithms(this);
            fr2.MdiParent = this;
            fr2.Show();
        }

        private void lecturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lectures fr2 = new Lectures(this);
            fr2.MdiParent = this;
            fr2.Show();
        }

        private void workWithAlgorithmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Work_with_Algorithms fr2 = new Work_with_Algorithms(this);
            fr2.MdiParent = this;
            fr2.Show();
        }

      

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary fr2 = new Dictionary();
            fr2.MdiParent = this;
            fr2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        
         
    }
}
