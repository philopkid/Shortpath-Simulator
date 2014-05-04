using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Simulator
{
   public class Vertex
    {
        public Point p { get; private set; }
        public int ident { get; private set; }
        public int dist { get; set; }
        public int pre { get; set; }
        public Vertex(Point p, int ident)
        { 
            this.p = p;
            this.ident = ident;
        }
    }
}
