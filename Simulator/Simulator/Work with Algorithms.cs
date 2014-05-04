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
    public partial class Work_with_Algorithms : Form
    {
        private Form f;
       // private int sign = 0;
        public Work_with_Algorithms()
        {
            InitializeComponent();
        }
        public Work_with_Algorithms(Form t)
        {
            InitializeComponent();
            this.f = t;
            
        }
       
     


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            ((Form1)this.f.FindForm()).buttonshow();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if(maskedTextBox1.Text == "" || maskedTextBox2.Text == "") //|| maskedTextBox3.Text == "" || maskedTextBox4.Text == "")
            //{
              //  MessageBox.Show("You missed important inputs!");
           // }

          // else
            //{
            string algo = " ";
            if (this.radioButton1.Checked) algo = "Dijkstra Algorithm";
            if (this.radioButton3.Checked) algo = "A* (A Star) Algorithm";
            if (this.radioButton4.Checked) algo = "Bellman-Ford Algorithm";
            if (this.radioButton5.Checked) algo = "Floyd-Warshall Algorithm";
                errorProvider1.Dispose();
                GraphCreator fr2 = new GraphCreator();
                fr2.MdiParent = ((Form1)this.f.FindForm()).g();
                //this.Hide();
                fr2.al = algo;
                //fr2.nodes_and_lines((int)Convert.ToInt64(maskedTextBox1.Text), (int)Convert.ToInt64(maskedTextBox2.Text));
            fr2.Show();
            //}

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Work_with_Algorithms_FormClosed(object sender, EventArgs e)
        {
            ((Form1)this.f.FindForm()).buttonshow();
        }
        private void Work_with_Algorithms_Load(object sender, EventArgs e)
        {
            ((Form1)this.f.FindForm()).buttonhide();

        }

      

     
    }
}

