using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulator
{
    class A_star
    {
        //private ArrayList closedset = new ArrayList();
        private List<int> openset = new List<int>();
       //private List<int> closedset = new List<int>();
        //int end;
        double[] di;
        public int[] came_from { get; private set; }
       public double[] g_score { get; private set; }
       public double[] f_score { get; private set; }
        private void Initialize(int s, int g, double[,] G)
        {

            int len = G.GetLength(0);
            f_score = new double[len];
            came_from = new int[len];
            g_score = new double[len];
            
            /* Set distance to all nodes to infinity - alternatively use Int.MaxValue for use of Int type instead */
            for (int i = 0; i < len; i++)
            {
               f_score[i] = Heuristic(G, s, g);
                g_score[i] = Double.PositiveInfinity;
                openset.Add(i);
            }
           //openset.Add(0);
            
            /* Set distance to 0 for starting point and the previous node to null (-1) */
            g_score[s] = 0;
            f_score[s] = g_score[s] + Heuristic(G,s,g);
            came_from[s] = -1;
        }
    private int GetNextVertex()
    {
        double min = f_score[0];
        double min2 = Double.PositiveInfinity;
        int Vertex = -1;
        //throw new ArgumentException(min2.ToString());
        /* Search through queue to find the next node having the smallest distance */
        foreach (int j in openset)
        {
            if (g_score[j] <= min2)
            {
               
                min = f_score[j];
                min2 = g_score[j];
                Vertex = j;
            }
      
        }
        //remove current from openset
        openset.Remove(Vertex);
        
        return Vertex;

    }
    public A_star(double[,] G, int start)
    {
       
        if (G.GetLength(0) < 1 || G.GetLength(0) != G.GetLength(1))
        {
            throw new ArgumentException("Graph error, wrong format or no nodes to compute");
        }

            int len = G.GetLength(0);
            int end = len - 1;
            Initialize(start,end,G);
            

         while (openset.Count > 0)
         {
             //current := the node in openset having the lowest f_score[] value
             int current = GetNextVertex();
             
                 for (int v = 0; v < len; v++)
                 {
                     if (G[current, v] > 0)
                     {
                     if (g_score[v] > g_score[current] + G[current, v])
                     {
                         g_score[v] = g_score[current] + G[current, v];
                         f_score[v] = g_score[v]  +  Heuristic(G, v, end);
                         came_from[v] = current;
                     }
                     }
                }
         }   
    }
    
   private Double Heuristic(double[,] G, int start, int end)
    {
        double cost;
        if (start == 0) return Find_G_Cost(G, end);
        cost = Find_G_Cost(G, start) - Find_G_Cost(G, end);

        return cost;
        //return (Math.Abs(Math.Abs());
        //return (Math.Abs(Find_G_Cost(G,start) - Find_G_Cost(G,end)) + Math.Abs(Find_G_Cost(G,start) - Find_G_Cost(G,end)));
           //return (Math.Abs(newNode.X - end.X) + Math.Abs(newNode.Y - end.Y));
            //return Math.Sqrt((start.X - end.X) * (start.X - end.X) + (start.Y - end.Y) * (start.Y - end.Y));
        }
    private double Find_G_Cost(double[,] G, int n)
    {
        //double[]  di;
        int[] p;
        int i, len, u ,v;
        len = G.GetLength(0);
        di = new double[len];
        p = new int[len];
        //double cost;
        for (i = 0; i < len; i++)
        {
            di[i] = Double.PositiveInfinity;
        }

       // queue = len;
        /* Set distance to 0 for starting point and the previous node to null (-1) */
        di[0] = 0;
        p[0] = -1;

     //   while (queue > 0)
       // {
         //   queue = queue - 1;
        

            /* Find the nodes that u connects to and perform relax */
            for (u = 0; u < len; u++)
            {
                for (v = 0; v < n; v++)
                    /* Edge exists, relax the edge */
                    if (di[u] + G[u, v] < di[v])
                    {
                        di[v] = di[u] + G[u, v];
                        p[v] = u;
                    }

            }
        //cost = di[n] - di[g];
        //}
           return  di[n];
        //return cost;
       
    }
    }
}
