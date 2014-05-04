using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulator
{
    class BellmanFord
    {
        /* Takes adjacency matrix in the following format, for a directed graph (2-D array)
       * Ex. node 1 to 3 is accessible at a cost of 4
       *        0  1  2  3  4 
       *   0  { 0, 2, 5, 0, 0},
       *   1  { 0, 0, 0, 4, 0},
       *   2  { 0, 6, 0, 0, 8},
       *   3  { 0, 0, 0, 0, 9},
       *   4  { 0, 0, 0, 0, 0}
       */

        /* Resulting arrays with distances to nodes and how to get there */
       public double[] dist { get; private set; }
        public int[] path { get; private set; }
       
        
        /* Holds queue for the nodes to be evaluated */
        private int queue;

        /* Sets up initial settings */
        private void Initialize(int s, int len)
        {
            dist = new double[len];
            path = new int[len];

            /* Set distance to all nodes to infinity - alternatively use Int.MaxValue for use of Int type instead */
        for (int i = 0; i < len; i++)
            {
                dist[i] = Double.PositiveInfinity;
            }
            queue = len;
            /* Set distance to 0 for starting point and the previous node to null (-1) */
            dist[s] = 0;
            path[s] = -1;
        } 



        /* Takes a graph as input an adjacency matrix (see top for details) and a starting node */
        public BellmanFord(Double[,] G,List<Edge> edge, int s)
        {
            int u, v;
            /* Check graph format and that the graph actually contains something */
           if (G.GetLength(0) < 1 || G.GetLength(0) != G.GetLength(1))
            { 
                throw new ArgumentException("Graph error, wrong format or no nodes to compute");
            }
            
            int len = G.GetLength(0);
          /*  foreach(Vertex v in vertices)
            {
                if (v.ident == s) v.dist = 0;
                else {v.dist = int.MaxValue; v.pre = null;}
            } */
            Initialize(s, len);

          // for (i = 1; i <= sizeof(vertices) - 1; i++);

            while (queue > 0)
            {
                queue = queue - 1; 
                
                /* Find the nodes that u connects to and perform relax */
               foreach (Edge uv in edge)
                {   u = uv.from;
                    v = uv.to;
                    /* Edge exists, relax the edge */
                    if (dist[u] + G[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + G[u, v];
                        path[v] = u;
                    }
                  
                }
                
            }
            
            /* Checks for edges with negative weight */
            foreach (Edge vu in edge)
            {
                u = vu.from;
                v = vu.to;
                if (G[u,v] < 0) throw new ArgumentException("Graph contains negative edge(s)");
               // if (dist[u] + G[u, v] < dist[v]) throw new ArgumentException("Graph contains negative edge(s)");
            }
        } 
    }
}
