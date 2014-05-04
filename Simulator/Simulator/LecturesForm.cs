using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Simulator
{
    public partial class LecturesForm : Form
    {
        
        public LecturesForm()
        {
            InitializeComponent();
        }
        public LecturesForm(String algo)
        {
            InitializeComponent();
            label1.Text = algo;
        }

        private void LecturesForm_Load(object sender, EventArgs e)
        {
           
            if (label1.Text == "Djikstra")
            {
                richTextBox1.Text = "In the following algorithm, the code u := vertex in Q with smallest dist[]," +
                   "searches for the vertex u in the vertex set Q that has the least dist[u] value." +
                   "That vertex is removed from the set Q and returned to the user." +
                   "dist_between(u, v) calculates the length between the two neighbor-nodes u and v. " +
                   "The variable alt on lines 20 & 22 is the length of the path from the root node to the " +
                   "neighbor node v if it were to go through u. If this path is shorter than the current shortest path recorded for v, " +
                   "that current path is replaced with this alt path. The previous array is populated with a pointer to the \"next-hop\" node on the source graph to get the shortest route to the source.\n" +

        "\n  function Dijkstra(Graph, source):\n" +
        "      for each vertex v in Graph:                                // Initializations\n" +
        "          dist[v] := infinity ;                                  // Unknown distance function from\n" +
        "                                                                 // source to v\n" +
        "          previous[v] := undefined ;                             // Previous node in optimal path\n" +
        "      end for                                                    // from source\n" +
        "      dist[source] := 0 ;                                        // Distance from source to source\n" +
        "      Q := the set of all nodes in Graph ;                       // All nodes in the graph are\n" +
        "                                                                 // unoptimized - thus are in Q\n" +
        "      while Q is not empty:                                      // The main loop\n" +
        "          u := vertex in Q with smallest distance in dist[] ;    // Start node in first case\n" +
        "          remove u from Q ;\n" +
        "          if dist[u] = infinity:\n" +
        "              break ;                                            // all remaining vertices are\n" +
        "          end if                                                 // inaccessible from source\n\n" +
        "          for each neighbor v of u:                              // where v has not yet been\n" +
        "                                                                 // removed from Q.\n" +
        "              alt := dist[u] + dist_between(u, v) ;\n" +
        "              if alt < dist[v]:                                  // Relax (u,v,a)\n" +
        "                  dist[v] := alt ;\n" +
        "                  previous[v] := u ;\n" +
        "                  decrease-key v in Q;                           // Reorder v in the Queue\n" +
        "              end if\n" +
        "          end for\n" +
        "      end while\n" +
        "  return dist;\n";
                
            }
            if (label1.Text == "Bellman-Ford")
            {
               richTextBox1.Text = " The Bellman–Ford algorithm computes single-source shortest paths in a weighted digraph. For graphs with only non-negative edge weights, the faster Dijkstra's algorithm also solves the problem. Thus, Bellman–Ford is used primarily for graphs with negative edge weights. The algorithm is named after its developers, Richard Bellman and Lester Ford, Jr.\n" +
               "Negative edge weights are found in various applications of graphs, hence the usefulness of this algorithm.[2] However, if a graph contains a \"negative cycle\", i.e., a cycle whose edges sum to a negative value, then walks of arbitrarily low weight can be constructed by repeatedly following the cycle, so there may not be a shortest path. In such a case, the Bellman-Ford algorithm can detect negative cycles and report their existence, but it cannot produce a correct \"shortest path\" answer if a negative cycle is reachable from the source.";

            }
            if (label1.Text == "Floyd-Warshall")
            {
                richTextBox1.Text = "  In computer science, the Floyd–Warshall algorithm (also known as Floyd's algorithm, Roy–Warshall algorithm, Roy–Floyd algorithm, or the WFI algorithm) is a graph analysis algorithm for finding shortest paths in a weighted graph (with positive or negative edge weights) and also for finding transitive closure of a relation R. A single execution of the algorithm will find the lengths (summed weights) of the shortest paths between all pairs of vertices, though it does not return details of the paths themselves. The algorithm is an example of dynamic programming. It was published in its currently recognized form by Robert Floyd in 1962. However, it is essentially the same as algorithms previously published by Bernard Roy in 1959 and also by Stephen Warshall in 1962 for finding the transitive closure of a graph. The modern formulation of Warshall's algorithm as three nested for-loops was first described by Peter Ingerman, also in 1962.";
            }
            if (label1.Text == "A* Star")
            {
                richTextBox1.Text = "function A*(start,goal)\n" +
                "  closedset := the empty set    // The set of nodes already evaluated.\n" +
                "  openset := {start}    // The set of tentative nodes to be evaluated, initially containing the start node\n" +
                "  came_from := the empty map    // The map of navigated nodes.\n" +
                "\ng_score[start] := 0    // Cost from start along best known path.\n" +
                "// Estimated total cost from start to goal through y.\n" +
                "f_score[start] := g_score[start] + heuristic_cost_estimate(start, goal)\n" +
                "\nwhile openset is not empty\n" +
                "   current := the node in openset having the lowest f_score[] value\n" +
                "   if current = goal\n" +
                "   return reconstruct_path(came_from, goal)\n" +
                "\n remove current from openset\n " +
                " add current to closedset\n" +
                "for each neighbor in neighbor_nodes(current)\n" +
                "  if neighbor in closedset\n" +
                "  continue\n" +
                "  tentative_g_score := g_score[current] + dist_between(current,neighbor)\n" +
                "\nif neighbor not in openset or tentative_g_score <= g_score[neighbor] \n" +
                "came_from[neighbor] := current\n" +
                "g_score[neighbor] := tentative_g_score\n" +
                "f_score[neighbor] := g_score[neighbor] + heuristic_cost_estimate(neighbor, goal)\n" +
                "if neighbor not in openset\n" +
                "     add neighbor to openset\n" +
                "\nreturn failure\n" +
                "\nfunction reconstruct_path(came_from, current_node)\n" +
                "if came_from[current_node] in set\n" +
                "p := reconstruct_path(came_from, came_from[current_node])\n" +
                "return (p + current_node)\n" +
                "else\n" +
                "return current_node";
            }
       }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Djikstra")
            {
                richTextBox1.Text = "  Dijkstra's Algorithm solves the single-source shortest-paths problem on weighted directed graph G = (V, E) for the case in which all edge weights are nonnegative. In this case, therefore, we assume that w(u,v) >= 0for each edge (u,v) element. As we shall see, with a good implementation, the running time of Dijkstra's algorithm is lower than that of the Bellman-Ford algorithm.\n" +
              "Dijkstra's alogorithm maintain a set S of vertices whose final shortest-path weights from the source s have been determined. The algorithm repeatedly selects the vertex u Element V-S wtih the minimum shortest-path estimate, adds u to S, and relaxes all edges leaving u. In the following implementation, we use a min-priority queue Q of vertices, keyed by their d values.\n" +

              "\nDIJKSTRA (G,w,s)\n" +
              "1. INITIALIZE-SINGLE-SOURCE(G,s)\n" +
              "2. S = /0\n" +
              "3. Q = G.V\n" +
              " while Q not equal  /0\n" +
              "5.        u = EXTRACT-MIN\n" +
              "6.        S = S U {u}\n" +
              "7.        for each vertex v ELEMENT G.Adj[u]\n" +
              "8.              RELAX(u,v,w)\n" +

              "\nLine 1 initializews the d and pie values in the usual way, and line 2 initializes the set S to the empty set. The algorithm maintains the invariant that Q = V - S at the start of ecah iterationof the while loopof lines -8.Line 3 initializes the min-priority queue Q to contain all the vertices in V; since S = /0 at that time, the variant  is true after line 3. Each time through the while loop of lines 4-8, line 5 extract a vertex u from Q = V - S and line 6 adds it to set S, thereby maintaning the invariant . (The first time through this loop, u = s.) Vertex u,therfore has the smallest shortest-path estimate of any vertex in V - S. Then,lines 7-8 relax each edges (u,v) leaving u thus updating the estimate v.d and the predeccessor v.pie if we cam improve the shortest path to v found so far by going through u. Observe that the algorithm never inserts vertices into Q after line 3 and that each vertex is extracted from Q and added to S exactly once, so that the while loop of lines 4-8 iterates exactly [V] times.\n" +
              "Because Dijkstra's algorithm always chooses the \"lightest\" or \"closest\" vertex in V - S to add to set S, we say that it uses a greedy strategy.\n" +

              "\nDijkstra's algorithm, conceived by Dutch computer scientist Edsger Dijkstra in 1956 and published in 1959, is a graph search algorithm that solves the single-source shortest path problem for a graph with nonnegative edge path costs, producing a shortest path tree. This algorithm is often used in routing and as a subroutine in other graph algorithms.\n" +
              "For a given source vertex (node) in the graph, the algorithm finds the path with lowest cost (i.e. the shortest path) between that vertex and every other vertex. It can also be used for finding costs of shortest paths from a single vertex to a single destination vertex by stopping the algorithm once the shortest path to the destination vertex has been determined. For example, if the vertices of the graph represent cities and edge path costs represent driving distances between pairs of cities connected by a direct road, Dijkstra's algorithm can be used to find the shortest route between one city and all other cities. As a result, the shortest path first is widely used in network routing protocols, most notably IS-IS and OSPF (Open Shortest Path First).\n" +
              "Dijkstra's original algorithm does not use a min-priority queue and runs in O(|V|^2). The idea of this algorithm is also given in (Leyzorek et al. 1957). The implementation based on a min-priority queue implemented by a Fibonacci heap and running in 0(|E| + |V| log |V| is due to (Fredman & Tarjan 1984). This is asymptotically the fastest known single-source shortest-path algorithm for arbitrary directed graphs with unbounded nonnegative weights.\n" +


     "\n\nAlgorithm\n" +


         "\n\n     Let the node at which we are starting be called the initial node. Let the distance of node Y be the distance from the initial node to Y. Dijkstra's algorithm will assign some initial distance values and will try to improve them step by step.\n" +

     "\n1. Assign to every node a tentative distance value: set it to zero for our initial node and to infinity for all other nodes.\n" +
     "2. Mark all nodes unvisited. Set the initial node as current. Create a set of the unvisited nodes called the unvisited set consisting of all the nodes except the initial node.\n" +
     "3. For the current node, consider all of its unvisited neighbors and calculate their tentative distances. For example, if the current node A is marked with a tentative distance of 6, and the edge connecting it with a neighbor B has length 2, then the distance to B (through A) will be 6+2=8. If this distance is less than the previously recorded tentative distance of B, then overwrite that distance. Even though a neighbor has been examined, it is not marked as \"visited\" at this time, and it remains in the unvisited set.\n" +
     "4. When we are done considering all of the neighbors of the current node, mark the current node as visited and remove it from the unvisited set. A visited node will never be checked again; its distance recorded now is final and minimal.\n" +
     "5. If the destination node has been marked visited (when planning a route between two specific nodes) or if the smallest tentative distance among the nodes in the unvisited set is infinity (when planning a complete traversal), then stop. The algorithm has finished.\n" +
     "6. Set the unvisited node marked with the smallest tentative distance as the next \"current node\" and go back to step 3.\n";
            }
            if (label1.Text == "Bellman-Ford")
            {
                richTextBox1.Text = " The Bellman–Ford algorithm computes single-source shortest paths in a weighted digraph. For graphs with only non-negative edge weights, the faster Dijkstra's algorithm also solves the problem. Thus, Bellman–Ford is used primarily for graphs with negative edge weights. The algorithm is named after its developers, Richard Bellman and Lester Ford, Jr.\n" +
               "Negative edge weights are found in various applications of graphs, hence the usefulness of this algorithm.[2] However, if a graph contains a \"negative cycle\", i.e., a cycle whose edges sum to a negative value, then walks of arbitrarily low weight can be constructed by repeatedly following the cycle, so there may not be a shortest path. In such a case, the Bellman-Ford algorithm can detect negative cycles and report their existence, but it cannot produce a correct \"shortest path\" answer if a negative cycle is reachable from the source.";

            }
            if (label1.Text == "Floyd-Warshall")
            {
                richTextBox1.Text = "  In computer science, the Floyd–Warshall algorithm (also known as Floyd's algorithm, Roy–Warshall algorithm, Roy–Floyd algorithm, or the WFI algorithm) is a graph analysis algorithm for finding shortest paths in a weighted graph (with positive or negative edge weights) and also for finding transitive closure of a relation R. A single execution of the algorithm will find the lengths (summed weights) of the shortest paths between all pairs of vertices, though it does not return details of the paths themselves. The algorithm is an example of dynamic programming. It was published in its currently recognized form by Robert Floyd in 1962. However, it is essentially the same as algorithms previously published by Bernard Roy in 1959 and also by Stephen Warshall in 1962 for finding the transitive closure of a graph. The modern formulation of Warshall's algorithm as three nested for-loops was first described by Peter Ingerman, also in 1962.";
            }
            if (label1.Text == "A* Star")
            {
                richTextBox1.Text = "   In computer science, A* (pronounced \"A star\" is a computer algorithm that is widely used in pathfinding and graph traversal, the process of plotting an efficiently traversable path between points, called nodes. Noted for its performance and accuracy, it enjoys widespread use.\n" +
                                    "Peter Hart, Nils Nilsson and Bertram Raphael of Stanford Research Institute (now SRI International) first described the algorithm in 1968. It is an extension of Edsger Dijkstra's 1959 algorithm. A* achieves better performance (with respect to time) by using heuristics." ;
            }
              }
        //' private void 
        //'Process.Start("http://www.google.com")  
       //' MessageBox.Show("Press here!")  
    
        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Djikstra")
            {
                richTextBox1.Text = "   Note: For ease of understanding, this discussion uses the terms intersection, road and map — however, formally these terms are vertex, edge and graph, respectively.\n" +

                "\nSuppose you want to find the shortest path between two intersections on a city map, a starting point and a destination. The order is conceptually simple: to start, mark the distance to every intersection on the map with infinity. This is done not to imply there is an infinite distance, but to note that that intersection has not yet been visited; some variants of this method simply leave the intersection unlabeled. Now, at each iteration, select a current intersection. For the first iteration the current intersection will be the starting point and the distance to it (the intersection's label) will be zero. For subsequent iterations (after the first) the current intersection will be the closest unvisited intersection to the starting point—this will be easy to find.\n" +
                "From the current intersection, update the distance to every unvisited intersection that is directly connected to it. This is done by determining the sum of the distance between an unvisited intersection and the value of the current intersection, and relabeling the unvisited intersection with this value if it is less than its current value. In effect, the intersection is relabeled if the path to it through the current intersection is shorter than the previously known paths. To facilitate shortest path identification, in pencil, mark the road with an arrow pointing to the relabeled intersection if you label/relabel it, and erase all others pointing to it. After you have updated the distances to each neighboring intersection, mark the current intersection as visited and select the unvisited intersection with lowest distance (from the starting point) -- or lowest label—as the current intersection. Nodes marked as visited are labeled with the shortest path from the starting point to it and will not be revisited or returned to.\n" +
                "Continue this process of updating the neighboring intersections with the shortest distances, then marking the current intersection as visited and moving onto the closest unvisited intersection until you have marked the destination as visited. Once you have marked the destination as visited (as is the case with any visited intersection) you have determined the shortest path to it, from the starting point, and can trace your way back, following the arrows in reverse.\n" +
                "Of note is the fact that this algorithm makes no attempt to direct \"exploration\" towards the destination as one might expect. Rather, the sole consideration in determining the next \"current\" intersection is its distance from the starting point. In some sense, this algorithm \"expands outward\" from the starting point, iteratively considering every node that is closer in terms of shortest path distance until it reaches the destination. When understood in this way, it is clear how the algorithm necessarily finds the shortest path, however it may also reveal one of the algorithm's weaknesses: its relative slowness in some topologies.\n";
            }
            if (label1.Text == "Bellman-Ford")
            {
                richTextBox1.Text = "  When a node receives distance tables from its neighbors, it calculates the shortest routes to all other nodes and updates its own table to reflect any changes.\n" +
                 "The main disadvantages of the Bellman–Ford algorithm in this setting are as follows:\n" +
                 "It does not scale well.\n" +
                 "Changes in network topology are not reflected quickly since updates are spread node-by-node.\n" +
                 "Count to infinity (if link or node failures render a node unreachable from some set of other nodes, those nodes may spend forever gradually increasing their estimates of the distance to it, and in the meantime there may be routing loops).\n";
            }
            if (label1.Text == "Floyd-Warshall")
            {
            }
            if (label1.Text == "A* Star")
            {
                richTextBox1.Text = "  A* uses a best-first search and finds a least-cost path from a given initial node to one goal node (out of one or more possible goals). As A* traverses the graph, it follows a path of the lowest known heuristic cost, keeping a sorted priority queue of alternate path segments along the way.\n" +
                "It uses a distance-plus-cost heuristic function of node  (usually denoted ) to determine the order in which the search visits nodes in the tree. The distance-plus-cost heuristic is a sum of two functions:\n" +
                "the path-cost function, which is the cost from the starting node to the current node  (usually denoted ) " +
                "n admissible \"heuristic estimate\" of the distance from  to the goal (usually denoted ). " +
                "The  part of the  function must be an admissible heuristic; that is, it must not overestimate the distance to the goal. Thus, for an application like routing,  might represent the straight-line distance to the goal, since that is physically the smallest possible distance between any two points or nodes. " +
                "If the heuristic h satisfies the additional condition  for every edge x, y of the graph (where d denotes the length of that edge), then h is called monotone, or consistent. In such a case, A* can be implemented more efficiently—roughly speaking, no node needs to be processed more than once (see closed set below)—and A* is equivalent to running Dijkstra's algorithm with the reduced cost .";
            }
        }
       /* public int FindMyText(string txtToSearch, int searchStart, int searchEnd)
        {
            // Unselect the previously searched string
            if (searchStart > 0 && searchEnd > 0 && indexOfSearchText >= 0)
            {
                rtb.Undo();
            }

            // Set the return value to -1 by default.
            int retVal = -1;

            // A valid starting index should be specified.
            // if indexOfSearchText = -1, the end of search
            if (searchStart >= 0 && indexOfSearchText >= 0)
            {
                // A valid ending index
                if (searchEnd > searchStart || searchEnd == -1)
                {
                    // Find the position of search string in RichTextBox
                    indexOfSearchText = rtb.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None);
                    // Determine whether the text was found in richTextBox1.
                    if (indexOfSearchText != -1)
                    {
                        // Return the index to the specified search text.
                        retVal = indexOfSearchText;
                    }
                }
            }
            return retVal;
        }*/
        private void button3_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Djikstra")
            {
                richTextBox1.Text = "In the following algorithm, the code u := vertex in Q with smallest dist[]," +
                     "searches for the vertex u in the vertex set Q that has the least dist[u] value." +
                     "That vertex is removed from the set Q and returned to the user." +
                     "dist_between(u, v) calculates the length between the two neighbor-nodes u and v. " +
                     "The variable alt on lines 20 & 22 is the length of the path from the root node to the " +
                     "neighbor node v if it were to go through u. If this path is shorter than the current shortest path recorded for v, " +
                     "that current path is replaced with this alt path. The previous array is populated with a pointer to the \"next-hop\" node on the source graph to get the shortest route to the source.\n" +

          "\n  function Dijkstra(Graph, source):\n" +
          "      for each vertex v in Graph:                                // Initializations\n" +
          "          dist[v] := infinity ;                                  // Unknown distance function from\n" +
          "                                                                 // source to v\n" +
          "          previous[v] := undefined ;                             // Previous node in optimal path\n" +
          "      end for                                                    // from source\n" +
          "      dist[source] := 0 ;                                        // Distance from source to source\n" +
          "      Q := the set of all nodes in Graph ;                       // All nodes in the graph are\n" +
          "                                                                 // unoptimized - thus are in Q\n" +
          "      while Q is not empty:                                      // The main loop\n" +
          "          u := vertex in Q with smallest distance in dist[] ;    // Start node in first case\n" +
          "          remove u from Q ;\n" +
          "          if dist[u] = infinity:\n" +
          "              break ;                                            // all remaining vertices are\n" +
          "          end if                                                 // inaccessible from source\n\n" +
          "          for each neighbor v of u:                              // where v has not yet been\n" +
          "                                                                 // removed from Q.\n" +
          "              alt := dist[u] + dist_between(u, v) ;\n" +
          "              if alt < dist[v]:                                  // Relax (u,v,a)\n" +
          "                  dist[v] := alt ;\n" +
          "                  previous[v] := u ;\n" +
          "                  decrease-key v in Q;                           // Reorder v in the Queue\n" +
          "              end if\n" +
          "          end for\n" +
          "      end while\n" +
          "  return dist;\n";
            }
            if (label1.Text == "Bellman-Ford")
            {
                richTextBox1.Text = "Algorithm\n\n" +
                "Bellman–Ford is based on dynamic programming approach. In its basic structure it is similar to Dijkstra's Algorithm, but instead of greedily selecting the minimum-weight node not yet processed to relax, it simply relaxes all the edges, and does this |V | − 1 times, where |V | is the number of vertices in the graph. The repetitions allow minimum distances to propagate accurately throughout the graph, since, in the absence of negative cycles, the shortest path can visit each node at most only once. Unlike the greedy approach, which depends on certain structural assumptions derived from positive weights, this straightforward approach extends to the general case.\n" +
                "Bellman–Ford runs in O(|V|·|E|) time, where |V| and |E| are the number of vertices and edges respectively.\n" +
                "\nprocedure BellmanFord(list vertices, list edges, vertex source)\n" +
                "// This implementation takes in a graph, represented as lists of vertices\n" +
                "// and edges, and modifies the vertices so that their distance and\n" +
                "// predecessor attributes store the shortest paths.\n" +

                "\n// Step 1: initialize graph\n" +
                "for each vertex v in vertices:\n" +
                "if v is source then v.distance := 0\n" +
                "else v.distance := infinity\n" +
                "v.predecessor := null\n" +

                "\n// Step 2: relax edges repeatedly\n" +
                "for i from 1 to size(vertices)-1:\n" +
                "for each edge uv in edges: // uv is the edge from u to v\n" +
                "    u := uv.source\n" +
                "    v := uv.destination\n" +
                "if u.distance + uv.weight < v.distance:\n" +
                "    v.distance := u.distance + uv.weight\n" +
                "    v.predecessor := u\n" +

                "\n// Step 3: check for negative-weight cycles\n" +
                "for each edge uv in edges:\n" +
                "u := uv.source\n" +
                "v := uv.destination\n" +
                "if u.distance + uv.weight < v.distance:\n" +
                "   error \"Graph contains a negative-weight cycle\"\n";
            }
            if (label1.Text == "Floyd-Warshall")
            {
               richTextBox1.Text =" The Floyd–Warshall algorithm typically only provides the lengths of the paths between all pairs of vertices. With simple modifications, it is possible to create a method to reconstruct the actual path between any two endpoint vertices. While one may be inclined to store the actual path from each vertex to each other vertex, this is not necessary, and in fact, is very costly in terms of memory. For each vertex, one need only store the information about the highest index intermediate vertex one must pass through if one wishes to arrive at any given vertex. Therefore, information to reconstruct all paths can be stored in a single N×N matrix next where next[i][j] represents the highest index vertex one must travel through if one intends to take the shortest path from i to j. Implementing such a scheme is trivial; when a new shortest path is found between two vertices, the matrix containing the paths is updated. The next matrix is updated along with the path matrix, so at completion both tables are complete and accurate, and any entries which are infinite in the path table will be null in the next table. The path from i to j is the path from i to next[i][j], followed by the path from next[i][j] to j. These two shorter paths are determined recursively. This modified algorithm runs with the same time and space complexity as the unmodified algorithm.\n" +

                "\n procedure FloydWarshallWithPathReconstruction ()\n" +
                "    for k := 1 to n\n" +
                "       for i := 1 to n\n" +
                "          for j := 1 to n\n" +
                "             if path[i][k] + path[k][j] < path[i][j] then {\n" +
                "                path[i][j] := path[i][k]+path[k][j];\n" +
                "                next[i][j] := next[i][k]; }\n" +
                "\n function Path (i,j)\n" +
                "    if path[i][j] equals infinity then\n" +
                "      return \"no path\";\n" +
                "    int intermediate := next[i][j];\n" +
                "    if intermediate equals 'null' then\n" +
                "      return \" \";   /* there is an edge from i to j, with no vertices between */\n" +
                "    else\n" +
                "      return Path(i,intermediate) + intermediate + Path(intermediate,j);\n";
            }
            if (label1.Text == "A* Star")
            {
                richTextBox1.Text = "function A*(start,goal)\n" +
               "  closedset := the empty set    // The set of nodes already evaluated.\n" +
               "  openset := {start}    // The set of tentative nodes to be evaluated, initially containing the start node\n" +
               "  came_from := the empty map    // The map of navigated nodes.\n" +
               "\ng_score[start] := 0    // Cost from start along best known path.\n" +
               "// Estimated total cost from start to goal through y.\n" +
               "f_score[start] := g_score[start] + heuristic_cost_estimate(start, goal)\n" +
               "\nwhile openset is not empty\n" +
               "   current := the node in openset having the lowest f_score[] value\n" +
               "   if current = goal\n" +
               "   return reconstruct_path(came_from, goal)\n" +
               "\n remove current from openset\n " +
               " add current to closedset\n" +
               "for each neighbor in neighbor_nodes(current)\n" +
               "  if neighbor in closedset\n" +
               "  continue\n" +
               "  tentative_g_score := g_score[current] + dist_between(current,neighbor)\n" +
               "\nif neighbor not in openset or tentative_g_score <= g_score[neighbor] \n" +
               "came_from[neighbor] := current\n" +
               "g_score[neighbor] := tentative_g_score\n" +
               "f_score[neighbor] := g_score[neighbor] + heuristic_cost_estimate(neighbor, goal)\n" +
               "if neighbor not in openset\n" +
               "     add neighbor to openset\n" +
               "\nreturn failure\n" +
               "\nfunction reconstruct_path(came_from, current_node)\n" +
               "if came_from[current_node] in set\n" +
               "p := reconstruct_path(came_from, came_from[current_node])\n" +
               "return (p + current_node)\n" +
               "else\n" +
               "return current_node";
            }
        }
    }
}