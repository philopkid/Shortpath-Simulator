using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Simulator
{
    public partial class GraphCreator : Form
    {
        /* Lists of all nodes and edges */
        private List<Vertex> Vertices = new List<Vertex>();
        private List<Edge> Edges = new List<Edge>();
        private String[] token;
        /* Counter for giving nodes a unique ID */
        private int numV = 0;
        private int count;
        private double[] dist;
        private int[] path;
        private double[,] fdist;
        private int[,] fpath;
        private int[] shortest_path;
      
        private int count_of_nodes, ngek = 0;
        public GraphCreator()
        {
            InitializeComponent();
        }
        public String al
        {
            set { label4.Text = value; }

        }
        /* Adds the vertex that was last created to the comboboxes */
        private void ReloadVertexList()
        { 
            cmbFrom.Items.Add(ReturnChar(Vertices[Vertices.Count - 1].ident));
            cmbTo.Items.Add(ReturnChar(Vertices[Vertices.Count - 1].ident));
            
        }
        private void HighlightText(string word ,Color color)
        {
            int s_start = this.richTextBox2.SelectionStart, startIndex = 0, index;

            while ((index = this.richTextBox2.Text.IndexOf(word, startIndex)) != -1)
            {
                this.richTextBox2.Select(index, word.Length);

                this.richTextBox2.SelectionColor = color;
                this.richTextBox2.ScrollToCaret();
                startIndex = index + word.Length;
            }

            //  myRtb.SelectionStart = s_start;
            // myRtb.SelectionLength = 0;
            //  myRtb.SelectionColor = Color.Black;
        }


        private String ReturnChar(int i)
        {
            String a = " ";
            if (i == 0) { a = "A"; }

            else if (i == 1) { a = "B"; }

            else if (i == 2) { a = "C"; }

            else if (i == 3) { a = "D"; }

            else if (i == 4) { a = "E"; }

            else if (i == 5) { a = "F"; }

            else if (i == 6) { a = "G"; }

            else if (i == 7) { a = "H"; }

            else if (i == 8) { a = "I"; }

            else if (i == 9) { a = "J"; }

            else if (i == 10) { a = "K"; }

            else if (i == 11) { a = "L"; }

            else if (i == 12) { a = "M"; }

            else if (i == 13) { a = "N"; }

            else if (i == 14) { a = "O"; }

            else if (i == 15) { a = "P"; }

            else if (i == 16) { a = "Q"; }

            else if (i == 17) { a = "R"; }

            else if (i == 18) { a = "S"; }

            else if (i == 19) { a = "T"; }

            else if (i == 20) { a = "U"; }

            else if (i == 21) { a = "V"; }

            else if (i == 22) { a = "W"; }

            else if (i == 23) { a = "X"; }

            else if (i == 24) { a = "Y"; }

            else if (i == 25) { a = "Z"; }
            return a;
        }
        private int ReturnNum(String i)
        {
            int a = 0;
            if (i == "A") { a = 0; }

            else if (i == "B") { a = 1; }

            else if (i == "C") { a = 2; }

            else if (i == "D") { a = 3; }

            else if (i == "E") { a = 4; }

            else if (i == "F") { a = 5; }

            else if (i == "G") { a = 6; }

            else if (i == "H") { a = 7; }

            else if (i == "I") { a = 8; }

            else if (i == "J") { a = 9; }

            else if (i == "K") { a = 10; }

            else if (i == "L") { a = 11; }

            else if (i == "M") { a = 12; }

            else if (i == "N") { a = 13; }

            else if (i == "O") { a = 14; }

            else if (i == "P") { a = 15; }

            else if (i == "Q") { a = 16; }

            else if (i == "R") { a = 17; }

            else if (i == "S") { a = 18; }

            else if (i == "T") { a = 19; }

            else if (i == "U") { a = 20; }

            else if (i == "V") { a = 21; }

            else if (i == "W") { a = 22; }

            else if (i == "X") { a = 23; }

            else if (i == "Y") { a = 24; }

            else if (i == "Z") { a = 25; }
            return a;
        }
        /* Draws a vertex on the map */
        private void DrawVertex(int vertex)
        {

            Graphics g = panMap.CreateGraphics();

            /* Draws the new vertice */
            Vertex p = Vertices[vertex];
            g.FillEllipse(new SolidBrush(Color.Black), p.p.X -15, p.p.Y -15, 30, 30);
            //this.ReturnChar(p.ident);
            g.DrawString(this.ReturnChar(p.ident), new Font("Verdana", 11), new SolidBrush(Color.Black), p.p.X - 30, p.p.Y - 20);

            g.Dispose();
        }

        /* Draws an edge on the map */
        private void DrawEdge(int edge)
        {
            Graphics g = panMap.CreateGraphics();

            /* Gets the edge to draw and the points it connects */
            Edge p = Edges[edge];
            Vertex from = Vertices[p.from];
            Vertex to = Vertices[p.to];
            Point pFrom;
            Point pTo;

            /* Figures out which side of the nodes to draw the edge */
            pFrom = new Point(from.p.X + (from.p.X < to.p.X ? 1 : -1) * 15, from.p.Y);
            pTo = new Point(to.p.X + (from.p.X < to.p.X ? -1 : 1) * 15, to.p.Y);


            Pen pen = new Pen(Color.Black, 3);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.ArrowAnchor;

            /* Draws weight and the connecting line */
            g.DrawString(p.weight.ToString(), new Font("Verdana", 11), new SolidBrush(Color.Black), new Point((pFrom.X + pTo.X) / 2, (pFrom.Y + pTo.Y) / 2  + (pFrom.Y < pTo.Y ? (-20) : 10)));
            g.DrawLine(pen, pFrom, pTo);

            g.Dispose();
        }

        private void DrawEdge2(int frome, int toe, Color l)
        {
            Graphics g = panMap.CreateGraphics();

            /* Gets the edge to draw and the points it connects */
            //Edge p = Edges[edge];
            Vertex from = Vertices[frome];
            Vertex to = Vertices[toe];
            Point pFrom;
            Point pTo;

            /* Figures out which side of the nodes to draw the edge */
            pFrom = new Point(from.p.X + (from.p.X < to.p.X ? 1 : -1) * 15, from.p.Y);
            pTo = new Point(to.p.X + (from.p.X < to.p.X ? -1 : 1) * 15, to.p.Y);


            Pen pen = new Pen(l, 3);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.ArrowAnchor;

            /* Draws weight and the connecting line */
            //g.DrawString(p.weight.ToString(), new Font("Verdana", 11), new SolidBrush(Color.Black), new Point((pFrom.X + pTo.X) / 2, (pFrom.Y + pTo.Y) / 2 + (pFrom.Y < pTo.Y ? (-20) : 10)));
            g.DrawLine(pen, pFrom, pTo);

            g.Dispose();
        }


        private void GUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /* Whenever a click happens on the panel, create a new node in the collection and draw it */
        private void panMap_MouseClick(object sender, MouseEventArgs e)
        {
            Vertices.Add(new Vertex(new Point(e.X, e.Y), numV));
            numV++;

            /* Draws the new vertex */
            DrawVertex(Vertices.Count - 1);

            /* Update the vertex list */
            ReloadVertexList();
        }

        /* Adds a new Edge */
        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            try
            {
                int from = ReturnNum(cmbFrom.SelectedItem.ToString());//Int32.Parse(cmbFrom.SelectedItem.ToString());
                int to = ReturnNum(cmbTo.SelectedItem.ToString());//Int32.Parse(cmbTo.SelectedItem.ToString());
                Double weight = Double.Parse(txtWeight.Text);

                /* Add the new edge to the collection */
                Edges.Add(new Edge(from, to, weight));

                /* Draws the new edge */
                DrawEdge(Edges.Count - 1);
                txtWeight.Text  = "";
            }
            catch (FormatException fe)
            {
                MessageBox.Show("No weight specified or wrong format");
            }
            catch (NullReferenceException ne)
            {
                MessageBox.Show("No vertex selected");
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            /* Create the array containing the adjacency matrix */
            double[,] G = new double[Vertices.Count, Vertices.Count];

         
            /* Set the connections and weights based on each edge in the collection */
            foreach (Edge edge in Edges)
            {
                G[edge.from, edge.to] = edge.weight;
            }
            if (this.label4.Text == "A* (A Star) Algorithm")
            {
                A_star astar = new A_star(G, 0);
                dist = astar.g_score;
                path = astar.came_from;

                count = 0;
                count_of_nodes = 0;
                // nodes = new int[dist.Length];
                timer1.Enabled = true;
                // timer1.Start();
                this.btnRun.Enabled = false;
               
              //  richTextBox1.AppendText("\n\n" + a[Vertices.Count - 1]);
                if (dist[Vertices.Count - 1] != Double.PositiveInfinity)
                {
                    BinaryPriorityQueue pa = new BinaryPriorityQueue();

                    //int count2 = path.Length-1;
                    // shortest_path = new int[count2];
                    //shortest_path[count2 - 1] = Vertices.Count - 1;
                    // int i = path.Length - 1;
                    // pa.Push(Vertices.Count - 1);
                    // count2 -= 2;
                    for (int i = Vertices.Count - 1; i > -1; )
                    {
                        if (i == Vertices.Count - 1)
                        {
                            // MessageBox.Show(i.ToString());
                            pa.Push(i);
                            i = path[i];
                            // continue;
                        }
                        //MessageBox.Show(i.ToString());
                        pa.Push(i);
                        // shortest_path[i] = path[i];
                        i = path[i];
                        //count2 -= 1;
                        //if (path[i] == 0) break;
                        //if (i == 0) break;
                        // count2 -= count2;
                    }

                    // MessageBox.Show("Ang laog:" + pa.Count.ToString());

                    shortest_path = new int[pa.Count];
                    int c = 0;
                    for (int i = Vertices.Count - 1; i >= 0; )
                    {
                        if (i == Vertices.Count - 1)
                        {
                            // MessageBox.Show(i.ToString());
                            shortest_path[c] = i;
                            i = path[i];
                            c += 1;
                            // continue;
                        }
                        //MessageBox.Show(i.ToString());
                        shortest_path[c] = i;
                        // shortest_path[i] = path[i];
                        i = path[i];
                        c += 1;
                    }

                }
            }
            if (this.label4.Text == "Dijkstra Algorithm")
            {
                /* Runs dijkstra */
                try
                {
                    Dijkstra dijk = new Dijkstra(G, 0);
                    dist = dijk.dist;
                    path = dijk.path;
                    count = 0;
                    count_of_nodes = 0;
                    // nodes = new int[dist.Length];
                    timer1.Enabled = true;
                    // timer1.Start();
                    this.btnRun.Enabled = false;
                    if (dist[Vertices.Count - 1] != Double.PositiveInfinity)
                    {
                        BinaryPriorityQueue pa = new BinaryPriorityQueue();

                        //int count2 = path.Length-1;
                       // shortest_path = new int[count2];
                        //shortest_path[count2 - 1] = Vertices.Count - 1;
                        // int i = path.Length - 1;
                       // pa.Push(Vertices.Count - 1);
                       // count2 -= 2;
                        for (int i = Vertices.Count - 1; i > -1; )
                        {
                            if (i == Vertices.Count - 1)
                            {
                               // MessageBox.Show(i.ToString());
                                pa.Push(i);
                                i = path[i]; 
                               // continue;
                            }
                            //MessageBox.Show(i.ToString());
                             pa.Push(i);
                           // shortest_path[i] = path[i];
                            i = path[i];
                            //count2 -= 1;
                            //if (path[i] == 0) break;
                            //if (i == 0) break;
                            // count2 -= count2;
                        }
                       
                       // MessageBox.Show("Ang laog:" + pa.Count.ToString());
                        
                       shortest_path = new int[pa.Count];
                        int c = 0;
                         for (int i = Vertices.Count - 1; i >= 0; )
                        { 
                             if (i == Vertices.Count - 1)
                            {
                               // MessageBox.Show(i.ToString());
                               shortest_path[c] = i;
                                i = path[i];
                                c += 1;
                               // continue;
                            }
                            //MessageBox.Show(i.ToString());
                             shortest_path[c] = i;
                           // shortest_path[i] = path[i];
                            i = path[i];
                            c += 1;
                         }
                      
                    }
                    //  timer1.Start();
                    // HighlightText(token[1], Color.Red);

                    // for (int o = 0; o < 100000000; o++) 
                    //timer1.Stop();
                    //timer1.Enabled = false;
                    // for (int i = 1; i < dist.Length ; i++)
                    // {

                    //    Graphics g = panMap.CreateGraphics();

                    //     nodes[i] = i;

                    //  Vertex p = Vertices[i];
                    // StringFormat distFormat = new StringFormat();
                    // distFormat.Alignment = StringAlignment.Center;
                    //g.DrawString(dist[d].ToString(), new Font("Verdana", 11), new SolidBrush(Color.White), p.p.X, p.p.Y - 7, distFormat);
                    //    g.FillEllipse(new SolidBrush(Color.Red), p.p.X - 25, p.p.Y - 25, 50, 50);
                    //    for (int q = 0; q < 100000000; q++);
                    //HighlightText(this.richTextBox2, token[1], Color.Red);
                    //HighlightText(this.richTextBox2, token[0], Color.Black);
                    // }

                    // count_of_nodes = 1;
                   // print_Report(dist, path);
                   // btnstepf.Enabled = true;

                    }
                    catch (ArgumentException err)
                    {
                      MessageBox.Show(err.Message);
                    }
                }
                if (this.label4.Text == "Bellman-Ford Algorithm")
                {
                    /* Runs bellman-ford */
                    try
                    {
                        BellmanFord bell = new BellmanFord(G, Edges, 0);
                        dist = bell.dist;
                        path = bell.path;
                        count = 0;
                        count_of_nodes = 0;
                  
                        timer1.Enabled = true;
                  
                        this.btnRun.Enabled = false;
                        if (dist[Vertices.Count - 1] != Double.PositiveInfinity)
                        {
                            BinaryPriorityQueue pa = new BinaryPriorityQueue();

                            //int count2 = path.Length-1;
                            // shortest_path = new int[count2];
                            //shortest_path[count2 - 1] = Vertices.Count - 1;
                            // int i = path.Length - 1;
                            // pa.Push(Vertices.Count - 1);
                            // count2 -= 2;
                            for (int i = Vertices.Count - 1; i > -1; )
                            {
                                if (i == Vertices.Count - 1)
                                {
                                    // MessageBox.Show(i.ToString());
                                    pa.Push(i);
                                    i = path[i];
                                    // continue;
                                }
                                //MessageBox.Show(i.ToString());
                                pa.Push(i);
                                // shortest_path[i] = path[i];
                                i = path[i];
                                //count2 -= 1;
                                //if (path[i] == 0) break;
                                //if (i == 0) break;
                                // count2 -= count2;
                            }

                            // MessageBox.Show("Ang laog:" + pa.Count.ToString());

                            shortest_path = new int[pa.Count];
                            int c = 0;
                            for (int i = Vertices.Count - 1; i >= 0; )
                            {
                                if (i == Vertices.Count - 1)
                                {
                                    // MessageBox.Show(i.ToString());
                                    shortest_path[c] = i;
                                    i = path[i];
                                    c += 1;
                                    // continue;
                                }
                                //MessageBox.Show(i.ToString());
                                shortest_path[c] = i;
                                // shortest_path[i] = path[i];
                                i = path[i];
                                c += 1;
                            }

                        }
                        /* Prints the shortest distances on the nodes */
                      /*  for (int i = 1; i < dist.Length; i++)
                        {
                            Graphics g = panMap.CreateGraphics();
                            Vertex p = Vertices[i];
                            // StringFormat distFormat = new StringFormat();
                            // distFormat.Alignment = StringAlignment.Center;
                            // g.DrawString(dist[i].ToString(), new Font("Verdana", 11), new SolidBrush(Color.White), p.p.X, p.p.Y - 7, distFormat);
                            g.FillEllipse(new SolidBrush(Color.Red), p.p.X - 25, p.p.Y - 25, 50, 50);
                            for (int q = 0; q < 100000000; q++) ;
                        } */
                       // print_Report(dist, path);
                       // count_of_nodes = 1;
                      //  btnstepf.Enabled = true;
                        //  for (int a = 0; a < dist.Length; a++)
                        //{
                        //  MessageBox.Show( dist[a].ToString());
                        //}
                    }
                    catch (ArgumentException err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                if (this.label4.Text == "Floyd-Warshall Algorithm")
                {
                    /* Runs floyd-warshall */
                    try
                    {
                        FloydWarshall floyd = new FloydWarshall(Edges, Vertices);
                        fdist = floyd.w;
                        fpath = floyd.p;
                     
                        count = 0;
                        count_of_nodes = 0;

                        timer1.Enabled = true;

                        this.btnRun.Enabled = false;
                        if (fdist[0,Vertices.Count - 1] != Double.PositiveInfinity)
                        {
                            BinaryPriorityQueue pa = new BinaryPriorityQueue();

                            //int count2 = path.Length-1;
                            // shortest_path = new int[count2];
                            //shortest_path[count2 - 1] = Vertices.Count - 1;
                            // int i = path.Length - 1;
                            // pa.Push(Vertices.Count - 1);
                            // count2 -= 2;
                            for (int i = Vertices.Count - 1; i > -1; )
                            {
                                if (i == Vertices.Count - 1)
                                {
                                    // MessageBox.Show(i.ToString());
                                    pa.Push(i);
                                    i = fpath[0,i];
                                    // continue;
                                }
                                //MessageBox.Show(i.ToString());
                                pa.Push(i);
                                // shortest_path[i] = path[i];
                                i = fpath[0,i];
                                //count2 -= 1;
                                //if (path[i] == 0) break;
                                //if (i == 0) break;
                                // count2 -= count2;
                            }

                            // MessageBox.Show("Ang laog:" + pa.Count.ToString());

                            shortest_path = new int[pa.Count];
                            int c = 0;
                            for (int i = Vertices.Count - 1; i >= 0; )
                            {
                                if (i == Vertices.Count - 1)
                                {
                                    // MessageBox.Show(i.ToString());
                                    shortest_path[c] = i;
                                    i = fpath[0,i];
                                    c += 1;
                                    // continue;
                                }
                                //MessageBox.Show(i.ToString());
                                shortest_path[c] = i;
                                // shortest_path[i] = path[i];
                                i = fpath[0,i];
                                c += 1;
                            }

                        }
                        //MessageBox.Show(floyd.path(0,3));
                        // this.richTextBox1.AppendText(floyd.path(0,(int)Convert.ToInt32(cmbDest.SelectedItem))); 
                        /* Prints the shortest distances on the nodes */
                        // for (int i = 0; i < G.Length; i++)
                        // {
                        //Graphics g = panMap.CreateGraphics();
                        // = floyd.path();
                        // Vertex p = Vertices[i];
                        // StringFormat distFormat = new StringFormat();
                        //distFormat.Alignment = StringAlignment.Center;
                        // g.DrawString(dist[i].ToString(), new Font("Verdana", 11), new SolidBrush(Color.White), p.p.X, p.p.Y - 7, distFormat);

                        // }
                        // print_Report(dist, path, G);
                        //  for (int a = 0; a < dist.Length; a++)
                        //{
                        //  MessageBox.Show( dist[a].ToString());
                        //}
                    }
                    catch (ArgumentException err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
        
      private void print(double[,]d,int[,] p)
        {
          
          this.richTextBox1.Clear();
          this.richTextBox1.ResetText();
          this.richTextBox1.AppendText("      Report\n");
          this.richTextBox1.AppendText("      From\n");
          this.richTextBox1.AppendText("            ");
          for (int i = 0; i < d.GetLength(0); i++)
          {
              if (i == 0) { this.richTextBox1.AppendText(ReturnChar(i) + "      "); i++; }
              this.richTextBox1.AppendText(ReturnChar(i) + "      ");
          }
          this.richTextBox1.AppendText("\n");

        for (int i = 0; i < d.GetLength(0) ;i++)
        {
            this.richTextBox1.AppendText(ReturnChar(i)+"           ");

            for (int j = 0; j < d.GetLength(0); j++)
            {
                
                if (d[i, j] == Double.PositiveInfinity)
                {
                    this.richTextBox1.AppendText(Format("∞"));
                }
                else
                {
                    this.richTextBox1.AppendText(Format(ReturnChar(j) + ":" + d[i, j].ToString()));
                    //this.richTextBox1.AppendText("                      ");
                    //this.richTextBox1.AppendText(" " + d[i, j].ToString() + "  ");
                }  
               
            }
            this.richTextBox1.AppendText("\n");
        }
        this.richTextBox1.AppendText("\n\n");
        if (d[0, Vertices.Count - 1] != Double.PositiveInfinity)
        {
            for (int s = shortest_path.Length - 1; s >= 0; s--)
            {

                this.richTextBox1.AppendText(ReturnChar(shortest_path[s]));
                if (s != 0) this.richTextBox1.AppendText(" → ");
            }
        }
        else this.richTextBox1.AppendText("Unfound Shortest Path!");
        }
        private void print_Report(double[] d, int[] p)
        {

            int i, y, a;
            this.richTextBox1.Clear();
            this.richTextBox1.ResetText();
            this.richTextBox1.AppendText("     Report\n");
            this.richTextBox1.AppendText("     From\n");
            this.richTextBox1.AppendText("          ");
            for (i = 0; i < d.Length; i++)
            {
                if (i == 0) { this.richTextBox1.AppendText(ReturnChar(i) + "→  "); i++; }
                this.richTextBox1.AppendText(ReturnChar(i) + "      ");
            }
            this.richTextBox1.AppendText("\n");
            for (y = 0; y < d.Length; y++)
            {
                if (d[y] != Double.PositiveInfinity)
                {
               
                this.richTextBox1.AppendText(ReturnChar(y));
                this.richTextBox1.AppendText("             ");
                a = y;
               
                    for (i = 0; i < d.Length; i++)
                    {
                        if (i == 0)
                        {
                           // do nothing
                        }
                        
                        else if (p[i] == a && d[i] != Double.PositiveInfinity)
                        {
                           // this.richTextBox1.AppendText(" " + ReturnChar(a) + ":" + d[i] + "  ");
                            this.richTextBox1.AppendText(Format(ReturnChar(a) + ":" + d[i]));

                        }
                        //else if (i == a) { this.richTextBox1.AppendText(" " + ReturnChar(p[i]) + ":" + d[i] + "  "); }
                        else if (i == a) { this.richTextBox1.AppendText(Format(ReturnChar(p[i]) + ":" + d[i])); }
                        else if (p[i] != a && d[i] != Double.PositiveInfinity)
                        {
                            //check the source if it is a neighbor from it;
                            if (p[i] == 0)
                            {
                                //this.richTextBox1.AppendText(" " + ReturnChar(0) + ":" + d[i] + "  ");
                                this.richTextBox1.AppendText(Format(ReturnChar(0) + ":" + d[i]));
                                
                            }
                            //if not then unreachable, it probably infinite;
                            else { 
                                //this.richTextBox1.AppendText("  ∞  ");
                               
                               this.richTextBox1.AppendText(Format("∞")); 
                            }
                  
                        }
                       
                        else if (d[i] == Double.PositiveInfinity)
                        {
                            //this.richTextBox1.AppendText("  ∞ ");
                            this.richTextBox1.AppendText(Format("∞"));
                        }
                    }
                }
                else continue;
                this.richTextBox1.AppendText("\n");
            }
            this.richTextBox1.AppendText("\n\n");
            if (d[Vertices.Count - 1] != Double.PositiveInfinity)
            {
                for (int s = shortest_path.Length - 1; s >= 0; s--)
                {

                    this.richTextBox1.AppendText(ReturnChar(shortest_path[s]));
                    if (s != 0) this.richTextBox1.AppendText(" → ");
                }
            }
            else this.richTextBox1.AppendText("Unfound Shortest Path!");
        }
        /* Resets everything */
        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //Clear rich text box
            richTextBox1.Text = " ";
            richTextBox2.Undo();
            btnstepf.Enabled = false;
            btnstepb.Enabled = false;
            btnRun.Enabled = true;
            /* Clear the map panel */
            Graphics g = panMap.CreateGraphics();
            g.Clear(DefaultBackColor);

            /* Removes all nodes in Vertices */
            Vertices.RemoveAll(delegate(Vertex v)
            {
                return true;
            });

            /* Removes all edges in Edges */
            Edges.RemoveAll(delegate(Edge edge)
            {
                return true;
            });

            /* Resets controls */
            cmbFrom.Items.Clear();
            cmbFrom.ResetText();

        
            cmbTo.Items.Clear();
            cmbTo.ResetText();
            txtWeight.ResetText();

            /* Resets vertex counter */
            numV = 0;

        }




        private void panMap_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GraphCreator_Load(object sender, EventArgs e)
        {
            richTextBox2.Undo();
           // count_of_nodes = 0;
          
            if (label4.Text == "Floyd-Warshall Algorithm")
            {
                token = new String[8];
                richTextBox3.Text = "Since we begin with shortestPath(i,j,0) = edgeCost(i,j) and\n" +
                "compute the sequence of n matrices shortestPath(i,j,1), shortestPath(i,j,2), …, shortestPath(i,j,n)";
                richTextBox2.Text = "procedure Floyd-Warshall()\n" +
                    "for (i=0; i<n; i++) { \n" +
                    "   for (j=0; j<n; j++) {\n" +
                    "   d[i][j] = w[i][j];\n" +
                    "   p[i][j] = i;\n"+
                    "   }\n"+
                    "}\n\n"+
                    "for (i=0; i<n; i++) {\n"+
                    "   d[i][i] = 0;\n"+
                    "}\n\n" + 
                    "for k := 1 to n\n" +
                    "    for i := 1 to n\n" +
                    "        for j := 1 to n\n" +
                    "            if path[i][k] + path[k][j] < path[i][j] then {\n" +
                    "               path[i][j] := path[i][k] + path[k][j];\n" +
                    "               next[i][j] := k; }";
                token[0] = "for (i=0; i<n; i++) { \n" +
                    "   for (j=0; j<n; j++) {\n" +
                    "   d[i][j] = w[i][j];\n" +
                    "   p[i][j] = i;\n" +
                    "   }\n" +
                    "}\n\n";
                token[1] = "for (i=0; i<n; i++) {\n" +
                    "   d[i][i] = 0;\n" +
                    "}\n\n";
                token[2] = "for k := 1 to n";
                token[3] = "    for i := 1 to n";
                token[4] = "        for j := 1 to n";
                token[5] = "            if path[i][k] + path[k][j] < path[i][j] then {";
                token[6] = "               path[i][j] := path[i][k] + path[k][j];";
                token[7] = "               next[i][j] := k; }";
            }
            if (label4.Text == "A* (A Star) Algorithm")
            {
             
                token = new String[15];
                richTextBox2.Text = "function A*(start,goal)\n" +
                    "closedset := the empty set    // The set of nodes already evaluated.\n" +
                    "openset := {start}    // The set of tentative nodes to be evaluated, initially containing the start node\n" +
                    " came_from := the empty map    // The map of navigated nodes.\n\n" +
                    " g_score[start] := 0    // Cost from start along best known path.\n" +
                    "// Estimated total cost from start to goal through y.\n" +
                    " f_score[start] := g_score[start] + heuristic_cost_estimate(start, goal)\n\n" +
                    "while openset is not empty \n" +
                    "  current := the node in openset having the lowest f_score[] value\n" +
                    "  remove current from openset\n" +
                    "  add current to closedset\n" +
                    "  for each neighbor in neighbor_nodes(current)\n" +
                    "      if neighbor in closedset\n" +
                    "            continue\n" +
                    "      tentative_g_score := g_score[current] + dist_between(current,neighbor)\n\n" +
                    "      if neighbor not in openset or tentative_g_score <= g_score[neighbor]\n" +
                    "       came_from[neighbor] := current\n" +
                    "       g_score[neighbor] := tentative_g_score\n" +
                    "       f_score[neighbor] := g_score[neighbor] + heuristic_cost_estimate(neighbor, goal)\n" +
                    "       if neighbor not in openset\n" +
                    "       add neighbor to openset\n";
                token[0] = "closedset := the empty set    // The set of nodes already evaluated.\n" +
                    "openset := {start}    // The set of tentative nodes to be evaluated, initially containing the start node\n" +
                    " came_from := the empty map    // The map of navigated nodes.\n\n" +
                    " g_score[start] := 0    // Cost from start along best known path.\n" +
                    "// Estimated total cost from start to goal through y.\n" +
                    " f_score[start] := g_score[start] + heuristic_cost_estimate(start, goal)";
                token[1] = "while openset is not empty \n";
                token[2] = "  current := the node in openset having the lowest f_score[] value";
                token[3] = "  remove current from openset";
                token[4] = "  add current to closedset";
                token[5] = "  for each neighbor in neighbor_nodes(current)";
                token[6] = "      if neighbor in closedset";
                token[7] = "            continue";
                token[8] = "      tentative_g_score := g_score[current] + dist_between(current,neighbor)";
                token[9] = "      if neighbor not in openset or tentative_g_score <= g_score[neighbor]";
                token[10] = "       came_from[neighbor] := current";
                token[11] = "       g_score[neighbor] := tentative_g_score";
                token[12] = "       f_score[neighbor] := g_score[neighbor] + heuristic_cost_estimate(neighbor, goal)";
                token[13] = "       if neighbor not in openset";
                token[14] = "       add neighbor to openset";
            }
            if (label4.Text == "Dijkstra Algorithm")
            {
                token = new String[13];
              
                richTextBox3.Text = "For each arc connecting a solved and unsolved, calculate the candidate distance.\n Candidate distance = distance to the solved node + length of arc";
                richTextBox2.Text = "function Dijkstra(Graph, source)\n" +
                    "    //initialize\n" +
                    "    for each vertex v in Graph:\n" +
                    "          dist[v] := infinity;\n" +
                    "          previous[v] := undefined;\n" +
                    "    end for\n" +
                    "\n   dist[source] := 0;\n" +
                    "     Q := the set of all nodes in Graph;\n" +
                    "\n    // the main loop run through all the set nodes\n" +
                    "     while Q is not empty:\n" +
                    "          u := vertex in Q with smallest distance in dist[];\n" +
                    "          remove u from Q;\n" +
                    "\n        for each neighbor v of u:\n" +
                    "              alt := dist[u] + dist_between(u,v)\n" +
                    "              if alt < dist[v]:\n" +
                    "                  dist[v] := alt;\n" +
                    "                  previous[v] := u;\n" +
                    "                  decrease-key v in Q;\n" +
                    "              end if\n" +
                    "          end for\n" +
                    "      end while\n" +
                    "return dist;";
                token[0] = "    //initialize\n" +
                    "    for each vertex v in Graph:\n" +
                    "          dist[v] := infinity;\n" +
                    "          previous[v] := undefined;\n" +
                    "    end for\n" +
                    "\n   dist[source] := 0;\n" +
                    "     Q := the set of all nodes in Graph;\n";
                token[1] = "     while Q is not empty:";
                token[2] = "          u := vertex in Q with smallest distance in dist[];";
                token[3] = "          remove u from Q;";
                token[4] = "        for each neighbor v of u:";
                token[5] = "              alt := dist[u] + dist_between(u,v)";
                token[6] = "              if alt < dist[v]:";
                token[7] = "                  dist[v] := alt;";
                token[8] = "                  previous[v] := u;";
                token[9] = "                  decrease-key v in Q;";
                token[10] = "              end if";
                token[11] = "          end for";
                token[12] = "      end while";
                
            }
            if (label4.Text == "Bellman-Ford Algorithm")
            {
              
                token = new string[15];
                richTextBox3.Text = "For each arc connecting, calculate the candidate distance.\n Candidate distance = distance to the solved node + length of arc";
                richTextBox2.Text = "procedure BellmanFord(list vertices, list edge, vertex source\n//This implementation takes in a graph, represented as lists of vertices\n" +
                    "//and edges, and modifies the vertices so that their distance and\n" +
                    "//predecessor attributes store the shortest paths.\n" +
                    "\n//Step 1: Initialize graph\n" +
                    "for each vertex v in vertices:\n" +
                    "  if v is the source then v.distance := 0\n" +
                    "  else v.distance := infinity\n" +
                    "  v.predecessor := null\n" +
                    "\n//Step 2: relax edges repeatedly\n" +
                    "for i from 1 to size(vertices) - 1:\n" +
                    "   for each edge uv in edges: //uv is the edge from u to v\n" +
                    "        u := uv.source\n" +
                    "        v := uv.destination\n" +
                    "        if u.distance + uv.weight < v.distance:\n" +
                    "             v.distance := u.distance + uv.weight\n" +
                    "             v.predecessor := u\n" +
                    "\n//Step 3: Check for negative - weight cycles\n" +
                    "for each edge uv in edges:\n" +
                    "     'u := uv.source\n" +
                    "     'v := uv.destination\n" +
                    "     'if u.distance + uv.weight < v.distance:\n" +
                    "           error (Graph contains a negative-weight cycle)";
                token[0] = "//Step 1: Initialize graph\n" +
                    "for each vertex v in vertices:\n" +
                    "  if v is the source then v.distance := 0\n" +
                    "  else v.distance := infinity\n" +
                    "  v.predecessor := null";
                token[1] = "//Step 2: relax edges repeatedly";
                token[2] = "for i from 1 to size(vertices) - 1:";
                token[3] = "   for each edge uv in edges: //uv is the edge from u to v";
                token[4] = "        u := uv.source";
                token[5] = "        v := uv.destination";
                token[6] = "     if u.distance + uv.weight < v.distance:";
                token[7] = "             v.distance := u.distance + uv.weight";
                token[8] = "             v.predecessor := u";
                token[9] = "//Step 3: Check for negative - weight cycles";
                token[10] = "for each edge uv in edges:\n";
                token[11] = "     'u := uv.source";
                token[12] = "     'v := uv.destination";
                token[13] = "     'if u.distance + uv.weight < v.distance:";
                token[14] = "           error (Graph contains a negative-weight cycle)";

            }
        }
        private void btnstepf_Click(object sender, EventArgs e)
        {
            /* Create the array containing the adjacency matrix */
            double[,] G = new double[Vertices.Count, Vertices.Count];
            //int dest = Int32.Parse(cmbDest.SelectedItem.ToString());
            /* Set the connections and weights based on each edge in the collection */
            foreach (Edge edge in Edges)
            {
                G[edge.from, edge.to] = edge.weight;
            }
            if (label4.Text == "A* (A Star) Algorithm")
            { 
                /* Runs astar */
                try
                {
                    //  Dijkstra dijk = new Dijkstra(G, 0);
                    //  dist = dijk.dist;
                    // path = dijk.path;
                    btnstepb.Enabled = true;
                    Graphics g = panMap.CreateGraphics();
                    //MessageBox.Show(nodes.Length.ToString()+" Ngek="+ngek.ToString());
                    if (ngek != 1)
                    {
                        int i;
                        for ( i = 0; i < dist.Length; i++)
                        {
                            //MessageBox.Show(nodes[i].ToString());
                            Vertex p = Vertices[i];
                            g.FillEllipse(new SolidBrush(Color.Black), p.p.X - 15, p.p.Y - 15, 30, 30);
                            if (i != 0)
                            {
                                DrawEdge2(path[i], i, Color.Black);

                            }
                        }
                        ngek = 1;
                    }
                    if (count_of_nodes == dist.Length)
                    {
                        btnstepf.Enabled = false;
                        ngek = 0;
                        //count_of_nodes = 0;
                        if (dist[Vertices.Count - 1] != Double.PositiveInfinity)
                        {
                            for (int i = Vertices.Count - 1; i > 0; )
                            {
                                if (i == Vertices.Count - 1)
                                {
                                    // MessageBox.Show(i.ToString());
                                    DrawEdge2(path[i], i, Color.Blue);
                                    i = path[i];
                                    // c += 1;

                                    continue;
                                }
                                //MessageBox.Show(i.ToString());
                                DrawEdge2(path[i], i, Color.Blue);
                                // shortest_path[i] = path[i];
                                i = path[i];
                                //c += 1;
                            }
                        }
                   
                       
                        return;
                    }
                    btnstepb.Enabled = true;
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);

                    if (count == 11)
                    {
                        if (count_of_nodes != 0 && dist[count_of_nodes] != Double.PositiveInfinity)
                        {
                            DrawEdge2(path[count_of_nodes], count_of_nodes, Color.Aquamarine);

                        }
                        /* Prints the shortest distances on the nodes */
                        Vertex a = Vertices[count_of_nodes];

                        // StringFormat distFormat = new StringFormat();
                        //distFormat.Alignment = StringAlignment.Center;
                        // g.DrawString(dist[d].ToString(), new Font("Verdana", 11), new SolidBrush(Color.White), p.p.X, p.p.Y - 7, distFormat);
                        g.FillEllipse(new SolidBrush(Color.Red), a.p.X - 15, a.p.Y - 15, 30, 30);
                        //MessageBox.Show(nodes.GetLength(0).ToString());
                        if (count_of_nodes < dist.Length) count_of_nodes += 1;
                        //else { btnstepf.Enabled = false; ngek = 0; count_of_nodes = 0; }
                        count = 1;
                    }
                    count += 1;
                  
                }
                catch (ArgumentException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            if (this.label4.Text == "Dijkstra Algorithm")
            {
                /* Runs dijkstra */
                try
                {
                  //  Dijkstra dijk = new Dijkstra(G, 0);
                   //  dist = dijk.dist;
                    // path = dijk.path;
                    btnstepb.Enabled = true;
                    Graphics g = panMap.CreateGraphics();
                    //MessageBox.Show(nodes.Length.ToString()+" Ngek="+ngek.ToString());
                    if (ngek != 1)
                    {
                        int i;
                        for ( i = 0; i < dist.Length; i++)
                        {
                            //MessageBox.Show(nodes[i].ToString());
                            Vertex p = Vertices[i];
                            g.FillEllipse(new SolidBrush(Color.Black), p.p.X - 15, p.p.Y - 15, 30, 30);
                            if (i != 0)
                            {
                                DrawEdge2(path[i], i, Color.Black);

                            }
                        }
                        ngek = 1;
                    }
                    if (count_of_nodes == dist.Length)
                    {
                        btnstepf.Enabled = false; 
                        ngek = 0; 
                        //count_of_nodes = 0;
                        if (dist[Vertices.Count - 1] != Double.PositiveInfinity)
                        {
                            for (int i = Vertices.Count - 1; i > 0; )
                            {
                                if (i == Vertices.Count - 1)
                                {
                                    // MessageBox.Show(i.ToString());
                                    DrawEdge2(path[i], i, Color.Blue);
                                    i = path[i];
                                    // c += 1;

                                    continue;
                                }
                                //MessageBox.Show(i.ToString());
                                DrawEdge2(path[i], i, Color.Blue);
                                // shortest_path[i] = path[i];
                                i = path[i];
                                //c += 1;
                            }
                        }
                   
                        
                        return;
                    }
                    btnstepb.Enabled = true;
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    
                    if (count == 7)
                    {
                        if (count_of_nodes != 0 && dist[count_of_nodes] != Double.PositiveInfinity)
                        {
                            DrawEdge2(path[count_of_nodes], count_of_nodes, Color.Aquamarine);

                        }
                        /* Prints the shortest distances on the nodes */
                        Vertex a = Vertices[count_of_nodes];

                        // StringFormat distFormat = new StringFormat();
                        //distFormat.Alignment = StringAlignment.Center;
                        // g.DrawString(dist[d].ToString(), new Font("Verdana", 11), new SolidBrush(Color.White), p.p.X, p.p.Y - 7, distFormat);
                        g.FillEllipse(new SolidBrush(Color.Red), a.p.X - 15, a.p.Y - 15, 30, 30);
                        //MessageBox.Show(nodes.GetLength(0).ToString());
                        if (count_of_nodes < dist.Length) count_of_nodes += 1;
                        //else { btnstepf.Enabled = false; ngek = 0; count_of_nodes = 0; }
                        count = 1;
                    }
                    count += 1;
                   // print_Report(dist, path);
                  //  btnstepb.Enabled = true;
                    //  for (int a = 0; a < dist.Length; a++)
                    //{
                    //  MessageBox.Show( dist[a].ToString());
                    //}
                }
                catch (ArgumentException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            if (this.label4.Text == "Floyd-Warshall Algorithm")
            {
                   try
                {
                  //  Dijkstra dijk = new Dijkstra(G, 0);
                   //  dist = dijk.dist;
                    // path = dijk.path;
                    btnstepb.Enabled = true;
                    Graphics g = panMap.CreateGraphics();
                    //MessageBox.Show(nodes.Length.ToString()+" Ngek="+ngek.ToString());
                    if (ngek != 1)
                    {
                        for (int i = 0; i < fdist.GetLength(0); i++)
                        {
                            //MessageBox.Show(nodes[i].ToString());
                            Vertex p = Vertices[i];
                            g.FillEllipse(new SolidBrush(Color.Black), p.p.X - 15, p.p.Y - 15, 30, 30);
                            if (i != 0)
                            {
                                DrawEdge2(fpath[0,i], i, Color.Black);

                            }
                        }
                        ngek = 1;
                    }
                    if (count_of_nodes == fdist.GetLength(0))
                    {
                        btnstepf.Enabled = false; 
                        ngek = 0; 
                        //count_of_nodes = 0;
                        if (fdist[0,Vertices.Count - 1] != Double.PositiveInfinity)
                        {
                            for (int i = Vertices.Count - 1; i > 0; )
                            {
                                if (i == Vertices.Count - 1)
                                {
                                    // MessageBox.Show(i.ToString());
                                    DrawEdge2(fpath[0,i], i, Color.Blue);
                                    i = fpath[0,i];
                                    // c += 1;

                                    continue;
                                }
                                //MessageBox.Show(i.ToString());
                                DrawEdge2(fpath[0,i], i, Color.Blue);
                                // shortest_path[i] = path[i];
                                i = fpath[0,i];
                                //c += 1;
                            }
                        }
                   
                       
                        return;
                    }
                    btnstepb.Enabled = true;
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    
                    if (count == 7)
                    {
                        if (count_of_nodes != 0 && fdist[0,count_of_nodes] != Double.PositiveInfinity)
                        {
                            DrawEdge2(fpath[0,count_of_nodes], count_of_nodes, Color.Aquamarine);

                        }
                        /* Prints the shortest distances on the nodes */
                        Vertex a = Vertices[count_of_nodes];

                        // StringFormat distFormat = new StringFormat();
                        //distFormat.Alignment = StringAlignment.Center;
                        // g.DrawString(dist[d].ToString(), new Font("Verdana", 11), new SolidBrush(Color.White), p.p.X, p.p.Y - 7, distFormat);
                        g.FillEllipse(new SolidBrush(Color.Red), a.p.X - 15, a.p.Y - 15, 30, 30);
                        //MessageBox.Show(nodes.GetLength(0).ToString());
                        if (count_of_nodes < fdist.GetLength(0)) count_of_nodes += 1;
                        //else { btnstepf.Enabled = false; ngek = 0; count_of_nodes = 0; }
                        count = 1;
                    }
                    count += 1;
                  
                }
                  catch (ArgumentException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            if (this.label4.Text == "Bellman-Ford Algorithm")
            {
                /* Runs dijkstra */
                try
                {

                    Graphics g = panMap.CreateGraphics();
                
                    if (ngek != 1)
                    {int i;
                        for (i = 0; i < dist.Length; i++)
                        {
                            Vertex p = Vertices[i];
                            g.FillEllipse(new SolidBrush(Color.Black), p.p.X - 15, p.p.Y - 15, 30, 30);
                            if (i != 0)
                            {
                                DrawEdge2(path[i], i, Color.Black);

                            }
                        }
                        ngek = 1;
                    }
                    if (count_of_nodes == dist.Length)
                    {
                        btnstepf.Enabled = false;
                        ngek = 0;
                        //count_of_nodes = 0;
                        if (dist[Vertices.Count - 1] != Double.PositiveInfinity)
                        {
                            for (int i = Vertices.Count - 1; i > 0; )
                            {
                                if (i == Vertices.Count - 1)
                                {
                                    // MessageBox.Show(i.ToString());
                                    DrawEdge2(path[i], i, Color.Blue);
                                    i = path[i];
                                    // c += 1;

                                    continue;
                                }
                                //MessageBox.Show(i.ToString());
                                DrawEdge2(path[i], i, Color.Blue);
                                // shortest_path[i] = path[i];
                                i = path[i];
                                //c += 1;
                            }
                        }
                   
                        
                        return;
                    }
                    btnstepb.Enabled = true;
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    
                    /* Prints the shortest distances on the nodes */

                    if (count == 7)
                    {
                        if (count_of_nodes != 0 && dist[count_of_nodes] != Double.PositiveInfinity)
                        {
                            DrawEdge2(path[count_of_nodes], count_of_nodes, Color.Aquamarine);

                        }
                    Vertex a = Vertices[count_of_nodes];

                    // StringFormat distFormat = new StringFormat();
                    //distFormat.Alignment = StringAlignment.Center;
                    // g.DrawString(dist[d].ToString(), new Font("Verdana", 11), new SolidBrush(Color.White), p.p.X, p.p.Y - 7, distFormat);
                    g.FillEllipse(new SolidBrush(Color.Red), a.p.X - 15, a.p.Y - 15, 30, 30);
                    if (count_of_nodes < dist.Length) count_of_nodes += 1;
                   // print_Report(dist, path);
                   // btnstepb.Enabled = true;
                    count = 1;
                    }
                    count += 1;
                }
                catch (ArgumentException err)
                {
                    MessageBox.Show(err.Message);
                }
            }

        }
        private String Format(string num)
        { 
            if (num.Length == 1) return num + "      ";
            if (num.Length == 3) return num + "    ";
            if (num.Length == 4) return num + "   ";
            return "";
        }
   
        private void btnstepb_Click(object sender, EventArgs e)
        {
            /* Create the array containing the adjacency matrix */
           double[,] G = new double[Vertices.Count, Vertices.Count];
           // int dest = Int32.Parse(cmbDest.SelectedItem.ToString());
            /* Set the connections and weights based on each edge in the collection */
          foreach (Edge edge in Edges)
            {
                G[edge.from, edge.to] = edge.weight;
            }
          if (label4.Text == "A* (A Star) Algorithm")
          { 
              /* Runs astar */
              try
              {
                  btnstepf.Enabled = true;


                  if (count_of_nodes == 0 && count == 1)
                  {
                    
                      ngek = 0;
                      //count_of_nodes = 0;
                      btnstepb.Enabled = false;
                      return;
                  }
                  if (count == 1)
                  {
                      count = 14;
                  }
                  btnstepf.Enabled = true;
                  richTextBox2.Undo();
                  HighlightText(token[count - 1], Color.Red);
                  if (count == 11)
                  {
                     
                      /* Prints the shortest distances on the nodes */
                      Graphics g = panMap.CreateGraphics();
                      Vertex p = Vertices[count_of_nodes - 1];
                      g.FillEllipse(new SolidBrush(Color.Black), p.p.X - 15, p.p.Y - 15, 30, 30);
                      // d = Int32.Parse(pqueue.Pop().ToString());
                      // MessageBox.Show(d.ToString());
                      // p = Vertices[nodes[count_of_nodes]];
                      //StringFormat distFormat = new StringFormat();
                      //  distFormat.Alignment = StringAlignment.Center;
                      // g.DrawString(dist[d].ToString(), new Font("Verdana", 11), new SolidBrush(Color.White), p.p.X, p.p.Y - 7, distFormat);
                      //g.FillEllipse(new SolidBrush(Color.Red), p.p.X - 25, p.p.Y - 25, 50, 50);
                      //  count_of_nodes -= 1;
                      count_of_nodes = count_of_nodes - 1;
                      if (count_of_nodes != 0 && dist[count_of_nodes] != Double.PositiveInfinity)
                      {
                          DrawEdge2(path[count_of_nodes], count_of_nodes, Color.Black);

                      }
                  }
                  count -= 1;


              }
              catch (ArgumentException err)
              {
                  MessageBox.Show(err.Message);
              }
          }
            if (this.label4.Text == "Dijkstra Algorithm")
            {
                /* Runs dijkstra */
                try
                {
                    btnstepf.Enabled = true;
                 //   if (count_of_nodes == dist.Length)
                   // {
                    //    btnstepb.Enabled = false;
                    //}
                    if (count_of_nodes == 0 && count == 1)
                    {
                       
                        ngek = 0;
                        //count_of_nodes = 0;
                        btnstepb.Enabled = false;
                        return;
                    }
                    if (count == 1)
                    {
                        count = 11;
                    }
                    btnstepf.Enabled = true;
                    richTextBox2.Undo();
                    HighlightText(token[count - 1], Color.Red);
                    if (count == 10)
                    {
                      
                        /* Prints the shortest distances on the nodes */
                        Graphics g = panMap.CreateGraphics();
                        Vertex p = Vertices[count_of_nodes - 1];
                        g.FillEllipse(new SolidBrush(Color.Black), p.p.X - 15, p.p.Y - 15, 30, 30);
                        // d = Int32.Parse(pqueue.Pop().ToString());
                        // MessageBox.Show(d.ToString());
                        // p = Vertices[nodes[count_of_nodes]];
                        //StringFormat distFormat = new StringFormat();
                        //  distFormat.Alignment = StringAlignment.Center;
                        // g.DrawString(dist[d].ToString(), new Font("Verdana", 11), new SolidBrush(Color.White), p.p.X, p.p.Y - 7, distFormat);
                        //g.FillEllipse(new SolidBrush(Color.Red), p.p.X - 25, p.p.Y - 25, 50, 50);
                        //  count_of_nodes -= 1;
                        count_of_nodes = count_of_nodes - 1;
                        if (count_of_nodes != 0 && dist[count_of_nodes] != Double.PositiveInfinity)
                        {
                            DrawEdge2(path[count_of_nodes], count_of_nodes, Color.Black);

                        }
                    }
                    count -= 1;
                      
                       // if (count_of_nodes < 1) { btnstepb.Enabled = false; btnstepf.Enabled = true; }
                  // print_Report(dist, path);
                    //  for (int a = 0; a < dist.Length; a++)
                    //{
                    //  MessageBox.Show( dist[a].ToString());
                    //}
                }
                catch (ArgumentException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            if (this.label4.Text == "Floyd-Warshall Algorithm")
            {
                /* Runs Floyd-Warshall */
                try
                {
                    btnstepf.Enabled = true;
              
                   
                    if (count_of_nodes == 0 && count == 2)
                    {
                       
                        ngek = 0;
                        //count_of_nodes = 0;
                        btnstepb.Enabled = false;
                        return;
                    }
                    if (count == 2)
                    {
                        count = 7;
                    }
                    btnstepf.Enabled = true;
                    richTextBox2.Undo();
                    HighlightText(token[count - 1], Color.Red);
                    if (count == 7)
                    {
                         
                        /* Prints the shortest distances on the nodes */
                        Graphics g = panMap.CreateGraphics();
                        Vertex p = Vertices[count_of_nodes - 1];
                        g.FillEllipse(new SolidBrush(Color.Black), p.p.X - 15, p.p.Y - 15, 30, 30);
                        // d = Int32.Parse(pqueue.Pop().ToString());
                        // MessageBox.Show(d.ToString());
                        // p = Vertices[nodes[count_of_nodes]];
                        //StringFormat distFormat = new StringFormat();
                        //  distFormat.Alignment = StringAlignment.Center;
                        // g.DrawString(dist[d].ToString(), new Font("Verdana", 11), new SolidBrush(Color.White), p.p.X, p.p.Y - 7, distFormat);
                        //g.FillEllipse(new SolidBrush(Color.Red), p.p.X - 25, p.p.Y - 25, 50, 50);
                        //  count_of_nodes -= 1;
                        count_of_nodes = count_of_nodes - 1;
                       if (count_of_nodes != 0 && fdist[0,count_of_nodes] != Double.PositiveInfinity)
                        {
                            DrawEdge2(fpath[0,count_of_nodes], count_of_nodes, Color.Black);

                        }
                    }
                    count -= 1;

              
                }
                catch (ArgumentException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            if (this.label4.Text == "Bellman-Ford Algorithm")
            {
                /* Runs bellman-ford */
                try
                {
                    if (count_of_nodes == 0 && count == 2)
                    {
                       
                        ngek = 0;
                        //count_of_nodes = 0;
                        btnstepb.Enabled = false;
                        return;
                    }
                    if (count == 2)
                    {
                        count = 8;
                    }
                    btnstepf.Enabled = true;
                    richTextBox2.Undo();
                    HighlightText(token[count - 1], Color.Red);

                    
                
                    /* Prints the shortest distances on the nodes */

                    if (count == 7)
                    {
                       
                        Graphics g = panMap.CreateGraphics();
                        Vertex a = Vertices[count_of_nodes - 1];

                        // StringFormat distFormat = new StringFormat();
                        //distFormat.Alignment = StringAlignment.Center;
                        // g.DrawString(dist[d].ToString(), new Font("Verdana", 11), new SolidBrush(Color.White), p.p.X, p.p.Y - 7, distFormat);
                        g.FillEllipse(new SolidBrush(Color.Black), a.p.X - 15, a.p.Y - 15, 30, 30);
                        //MessageBox.Show(nodes.GetLength(0).ToString());
                        count_of_nodes = count_of_nodes - 1;
                        if (count_of_nodes != 0 && dist[count_of_nodes] != Double.PositiveInfinity)
                        {
                            DrawEdge2(path[count_of_nodes], count_of_nodes, Color.Black);

                        }
                        //if (count_of_nodes < 1) { btnstepb.Enabled = false; btnstepf.Enabled = true; }
                    }
                    count -= 1;
                   // print_Report(dist, path);
                    //btnstepb.Enabled = true;
                    //  for (int a = 0; a < dist.Length; a++)
                    //{
                    //  MessageBox.Show( dist[a].ToString());
                    //}
                }
                catch (ArgumentException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label4.Text == "A* (A Star) Algorithm")
            {
                if (count_of_nodes == dist.Length)
                {
                    richTextBox2.Undo();
                    // HighlightText(token[12], Color.Red);
                    print_Report(dist, path);
                    btnstepf.Enabled = true;
                    btnRun.Enabled = true;
                    timer1.Enabled = false;// timer1.Stop();
                    if (dist[Vertices.Count - 1] != Double.PositiveInfinity)
                    {
                        for (int i = Vertices.Count - 1; i > 0; )
                        {
                            if (i == Vertices.Count - 1)
                            {
                                // MessageBox.Show(i.ToString());
                                DrawEdge2( path[i],i, Color.Blue);
                                i = path[i];
                               // c += 1;
                               
                                continue;
                            }
                            //MessageBox.Show(i.ToString());
                            DrawEdge2( path[i],i, Color.Blue);
                            // shortest_path[i] = path[i];
                            i = path[i];
                            //c += 1;
                        }
                    }
                   
                    count_of_nodes = 0;
                    count = 0;
                }
                if (count == 0)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 1)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 2)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 3)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 4)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 5)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 6)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 7)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 8)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 9)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 10)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 11)
                {
                    if (count_of_nodes != 0 && dist[count_of_nodes] != Double.PositiveInfinity)
                    {
                        DrawEdge2(path[count_of_nodes], count_of_nodes,Color.Aquamarine);

                    }
                    Graphics g = panMap.CreateGraphics();

                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);

                    Vertex p = Vertices[count_of_nodes];
                    g.FillEllipse(new SolidBrush(Color.Red), p.p.X - 15, p.p.Y - 15, 30, 30);
                    count = count + 1;

                    count_of_nodes += 1;
                    return;
                }
                if (count == 12)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 13)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 14)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = 1;
                    return;
                }
            }
            if (this.label4.Text == "Floyd-Warshall Algorithm")
            {
                if (count_of_nodes == fdist.GetLength(0))
                {
                    richTextBox2.Undo();
                    // HighlightText(token[12], Color.Red);
                    print(fdist, fpath);
                    btnstepf.Enabled = true;
                    btnRun.Enabled = true;
                    timer1.Enabled = false;// timer1.Stop();
                    if (fdist[0,Vertices.Count - 1] != Double.PositiveInfinity)
                    {
                        for (int i = Vertices.Count - 1; i > 0; )
                        {
                            if (i == Vertices.Count - 1)
                            {
                                // MessageBox.Show(i.ToString());
                                DrawEdge2(fpath[0,i], i, Color.Blue);
                                i = fpath[0,i];
                                // c += 1;

                                continue;
                            }
                            //MessageBox.Show(i.ToString());
                            DrawEdge2(fpath[0,i], i, Color.Blue);
                            // shortest_path[i] = path[i];
                            i = fpath[0,i];
                            //c += 1;
                        }
                    }
                    count_of_nodes = 0;
                    count = 0;
                }
                if (count == 0)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 1)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 2)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 3)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 4)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 5)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 6)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 7)
                {
                    if (count_of_nodes != 0 && fdist[0,count_of_nodes] != Double.PositiveInfinity)
                    {
                        DrawEdge2(fpath[0,count_of_nodes], count_of_nodes, Color.Aquamarine);

                    }
                    Graphics g = panMap.CreateGraphics();

                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);

                    Vertex p = Vertices[count_of_nodes];
                    g.FillEllipse(new SolidBrush(Color.Red), p.p.X - 15, p.p.Y - 15, 30, 30);
                    count = 2;

                    count_of_nodes += 1;
                    return;
                }

            }
            if (this.label4.Text == "Dijkstra Algorithm")
            {//ecount == Edges.Count - 1 &&
                if ( count_of_nodes == dist.Length)
                {
                    richTextBox2.Undo();
                   // HighlightText(token[12], Color.Red);
                    print_Report(dist, path);
                    btnstepf.Enabled = true;
                    btnRun.Enabled = true;
                    timer1.Enabled = false;// timer1.Stop();
                    if (dist[Vertices.Count - 1] != Double.PositiveInfinity)
                    {
                        for (int i = Vertices.Count - 1; i > 0; )
                        {
                            if (i == Vertices.Count - 1)
                            {
                                // MessageBox.Show(i.ToString());
                                DrawEdge2(path[i], i, Color.Blue);
                                i = path[i];
                                // c += 1;

                                continue;
                            }
                            //MessageBox.Show(i.ToString());
                            DrawEdge2(path[i], i, Color.Blue);
                            // shortest_path[i] = path[i];
                            i = path[i];
                            //c += 1;
                        }
                    }
                    count_of_nodes = 0;
                    count = 0;
                }
                if (count == 0)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 1)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);

                    count += 1;
                    //timer1.Stop();

                    return;
                }
                if (count == 2)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 3)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 4)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 5)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 6)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 7)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 8)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 9)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 10)
                {

                    if (count_of_nodes != 0 && dist[count_of_nodes] != Double.PositiveInfinity)
                    {
                        DrawEdge2(path[count_of_nodes],count_of_nodes, Color.Aquamarine );
                        
                    }
                    Graphics g = panMap.CreateGraphics();

                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);

                    Vertex p = Vertices[count_of_nodes];
                    g.FillEllipse(new SolidBrush(Color.Red), p.p.X - 15, p.p.Y - 15, 30, 30);
                    count += 1;
                    
                    count_of_nodes += 1;
                    return;
                }
                if (count == 11)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = 1;
                    return;
                }
              
            }
            if (this.label4.Text == "Bellman-Ford Algorithm")
            {
                if (count_of_nodes == dist.Length)
                {
                    richTextBox2.Undo();
                   // HighlightText(token[12], Color.Red);
                    print_Report(dist, path);
                    btnRun.Enabled = true;
                    btnstepf.Enabled = true;
                    timer1.Enabled = false;// timer1.Stop();
                    if (dist[Vertices.Count - 1] != Double.PositiveInfinity)
                    {
                        for (int i = Vertices.Count - 1; i > 0; )
                        {
                            if (i == Vertices.Count - 1)
                            {
                                // MessageBox.Show(i.ToString());
                                DrawEdge2(path[i], i, Color.Blue);
                                i = path[i];
                                // c += 1;

                                continue;
                            }
                            //MessageBox.Show(i.ToString());
                            DrawEdge2(path[i], i, Color.Blue);
                            // shortest_path[i] = path[i];
                            i = path[i];
                            //c += 1;
                        }
                    }
                    count_of_nodes = 0;
                    count = 0;
                }
                if (count == 0)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = count + 1;
                    return;
                }
                if (count == 1)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);

                    count += 1;
                    return;
                }
                if (count == 2)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 3)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 4)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 5)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 6)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 7)
                {
                    if (count_of_nodes != 0 && dist[count_of_nodes] != Double.PositiveInfinity)
                    {
                        DrawEdge2(path[count_of_nodes], count_of_nodes, Color.Aquamarine);

                    }
                    Graphics g = panMap.CreateGraphics();

                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);

                    Vertex p = Vertices[count_of_nodes];
                    g.FillEllipse(new SolidBrush(Color.Red), p.p.X - 15, p.p.Y - 15, 30, 30);
                    count += 1;
                    count_of_nodes += 1;
                    return;
                }
                if (count == 8)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = 2;
                    return;
                }
                if (count == 9)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count += 1;
                    return;
                }
                if (count == 10)
                {

                    Graphics g = panMap.CreateGraphics();

                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);

                    Vertex p = Vertices[count_of_nodes];
                    g.FillEllipse(new SolidBrush(Color.Red), p.p.X - 15, p.p.Y - 15, 30, 30);
                    count += 1;
                    count_of_nodes += 1;
                    return;
                }
                if (count == 11)
                {
                    richTextBox2.Undo();
                    HighlightText(token[count], Color.Red);
                    count = 1;
                    return;
                }
              

            }
               
        }


       
    }
}