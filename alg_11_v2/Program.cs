using System;
using System.Collections.Generic;

namespace alg_11_v2
{
    class Edge
    {
        public int Node { get; set; }
    
        public double weight { get; set; }

        public int CompareTo(Edge other)
        {
            return weight.CompareTo(other.weight);
        }
    }

    class Graph
    {

        public Dictionary<int, List<Edge>> Edges = new Dictionary<int, List<Edge>>();

        public void AddDirectedEdge(int source, int destination, double weight)
        {
            if (!Edges.ContainsKey(source))
            {
                Edges.Add(source, new List<Edge>());
            }
            if (!Edges.ContainsKey(destination))
            {
                Edges.Add(destination, new List<Edge>());

            }
            Edges[source].Add(new Edge() { Node = destination, weight = weight });
        }

        public void AddundiectedEdge(int source, int destination, double weight)
        {
            AddDirectedEdge(source, destination, weight);
            AddDirectedEdge(destination, source, weight);
        }

        public void BFTraversal(int start, Action<int> action)
        {
            Queue<int> queue = new Queue<int>();
            ISet<int> visited = new HashSet<int>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                if (visited.Contains(node))
                {
                    continue;
                }
                action.Invoke(node);
                visited.Add(node);
                List<Edge> childrem = Edges[node];
                foreach (Edge child in childrem)
                {
                    queue.Enqueue(child.Node);
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.AddDirectedEdge(1, 2, 3);
            graph.AddDirectedEdge(1, 3, 2);
            graph.AddDirectedEdge(1, 4, 6);
            graph.AddDirectedEdge(2, 5, 3);
            graph.AddDirectedEdge(3, 6, 7);
            graph.AddDirectedEdge(4, 6, 5);
            graph.AddDirectedEdge(5, 6, 8);
            graph.BFTraversal(5, n => Console.Write(n + " "));
        }
    }
    
}
