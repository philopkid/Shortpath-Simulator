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
    public partial class Lectures : Form
    {
        Form f;
        public Lectures()
        {
            InitializeComponent();
        }
        public Lectures(Form t)
        {
            InitializeComponent();
            this.f = t;
        }
        
    
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            pictureBox5.Visible = false;

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = true;

        }

        

        private void pictureBox5_Click(object sender, EventArgs e)
        {
       
            LecturesForm fr2 = new LecturesForm("Floyd-Warshall");
            fr2.MdiParent = ((Form1)this.f.FindForm()).g();
            fr2.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
            LecturesForm fr2 = new LecturesForm("Bellman-Ford");
            fr2.MdiParent = ((Form1)this.f.FindForm()).g();
            fr2.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LecturesForm fr2 = new LecturesForm("A* Star");
            fr2.MdiParent = ((Form1)this.f.FindForm()).g();
            fr2.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //DijkstraForm fr2 = new DijkstraForm();
                LecturesForm fr2 = new LecturesForm("Djikstra");
                fr2.MdiParent = ((Form1)this.f.FindForm()).g();
                fr2.Show();
        }

        private void mainFormToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1 fr2 = new Form1();
            fr2.MdiParent = ((Form1)this.f.FindForm()).g();
           
            fr2.Show();
        }

        private void workWithAlgorithmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Work_with_Algorithms fr2 = new Work_with_Algorithms();
            fr2.MdiParent = ((Form1)this.f.FindForm()).g();
          
            fr2.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary fr2 = new Dictionary();
            fr2.MdiParent = ((Form1)this.f.FindForm()).g();
        
            fr2.Show();
        }

        private void Lectures_Load(object sender, EventArgs e)
        {
            ((Form1)this.f.FindForm()).buttonhide();
        }
        private void Lectures_FormClosed(object sender, EventArgs e)
        {
            ((Form1)this.f.FindForm()).buttonshow();
        }
    }
}
