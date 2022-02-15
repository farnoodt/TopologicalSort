using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologicalSort
{
    class Graph
    {
        public List<List<int>> adj = new List<List<int>>();
        public int Nodes;

        public Graph(int V)
        {
            this.Nodes = V;
            for (int i = 0; i < V; i++)
                adj.Add(new List<int>());
        }

        public void AddEdge(int Source, int Destination)
        {
            adj[Source].Add(Destination);
        }

        public void Sort()
        {
            bool[] Visited = new bool[Nodes];
            Stack<int> S = new Stack<int>();

            for(int i = 0; i< Nodes; i++)
            {
                if (!Visited[i])
                    SortUtil(i, Visited, S);
            }

            Console.WriteLine(string.Join(" , ", S));
            Console.ReadLine();
        }

        public void SortUtil(int startNode, bool[] Visited, Stack<int> S)
        {
            Visited[startNode] = true;
            List<int> node = new List<int>();
            node = adj[startNode]; 

            foreach(var child in node)
            {
                if (!Visited[child])
                {
                    SortUtil(child, Visited, S);
                    
                }
            }
            S.Push(startNode);
        }
    }
}
