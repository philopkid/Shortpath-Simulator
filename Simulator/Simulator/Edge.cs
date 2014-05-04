using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulator
{
   public class Edge
    {
        public int from 
        { 
            get; 
           private set; 
        }
        public int to 
        { get; 
            private set; 
        }
        public Double weight 
        { get; 
            private set; 
        }

        public Edge(int from, int to, Double weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }
    }
}
