using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulator
{
    class FloydWarshall
    {
        //private double[,] d;
        public int[,] p;
        public double[,] w;

        private void Initialize(int l)
        {
            // int i, j;

            // w = new double[l, l];
            // d = new double[l, l];
            //  p = new int[l, l];
            //throw new ArgumentException(l.ToString());
            /* for (i = 0; i < l; i++)
             {
                 for (j = 0; j < l; j++)
                 {
                     w[i, j] = Double.PositiveInfinity;
                     p[i, j] = -1;
                 }
             }

             for (i = 0; i < l; i++) w[i, i] = 0; */
            /* for (i = 1; i <= n; i++)
                 d[i][i] = 0;
             for (i = 1; i <= n; i++)
             {
                 for (j = 1; j <= n; j++)
                 {
                     p[i][j] = i;
                 }
             } */

        }

        public FloydWarshall(List<Edge> E, List<Vertex> V)
        {
            int i, j, k;
            // int ii;
            int u, v;

            int len = V.Count;
            // Initialize(V.Count);

            w = new double[len, len];
            // d = new double[V.Count, V.Count];
            p = new int[len, len];
            //throw new ArgumentException(l.ToString());
            for (i = 0; i < len; i++)
            {
                for (j = 0; j < len; j++)
                {
                    w[i, j] = Double.PositiveInfinity;
                    p[i, j] = -1;
                }
            }

            for (i = 0; i < len; i++) w[i, i] = 0;

            foreach (Edge e in E)
            {
                u = e.from;
                v = e.to;
                w[u, v] = e.weight;
                p[u, v] = u;
            }




            for (k = 0; k < len; k++)
            {
                for (i = 0; i < len; i++)
                    for (j = 0; j < len; j++)
                    {
                        if (w[i, k] + w[k, j] < w[i, j])
                        {
                            w[i, j] = w[i, k] + w[k, j];
                            p[i, j] = p[k, j];
                        }

                    }
            }
        }
        public void path(int i, int j)
        {
           // if (w[i, j] == double.PositiveInfinity) return "no path";
          //  int intermediate = p[i, j];
           // if (intermediate == -1) return "there is an edge from i to j, with no vertices between";   /* there is an edge from i to j, with no vertices between */
           if(i != j)// else
            {
               path(i, p[i, j]);
            }
           // j;
            // else return path(i,(int)Convert.ToInt32(path(intermediate,(int)Convert.ToInt32(path(intermediate,j)))));
            //else return path(i, intermediate) +" "+ intermediate.ToString() +" "+ path(intermediate,j);
            //}

        }
    }
}
