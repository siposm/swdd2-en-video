using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_datastructure
{
    class Graph<T>
    {
        List<List<T>> adjacencyList = new List<List<T>>();
        List<T> content = new List<T>();

        public void AddNode(T node)
        {
            content.Add(node);
            adjacencyList.Add(new List<T>());
        }

        public void AddEdge(T from, T to)
        {
            int indexFrom = content.IndexOf(from);
            int indexTo = content.IndexOf(to);

            adjacencyList[indexFrom].Add(content[indexTo]);
            adjacencyList[indexTo].Add(content[indexFrom]);
        }

        public bool HasEdge(T from, T to)
        {
            int indexFrom = content.IndexOf(from);
            int indexTo = content.IndexOf(to);

            return adjacencyList[indexFrom].Contains(content[indexTo]);
        }

        public List<T> Neighbors(T whichNode)
        {
            int index = content.IndexOf(whichNode);
            return adjacencyList[index];
        }

        public void DFS(T startNode)
        {
            List<T> F = new List<T>();
            DFS(startNode, F);
        }

        private void DFS(T k, List<T> F)
        {
            F.Add(k);
            Console.WriteLine(k.ToString()); // !!! 

            foreach (T x in Neighbors(k))
                if (!F.Contains(x))
                    DFS( x, F );
        }

        public void BFS(T startNode)
        {
            Queue<T> S = new Queue<T>();
            List<T> F = new List<T>();

            S.Enqueue(startNode);
            F.Add(startNode);

            T k;

            while ( S.Count != 0 )
            {
                k = S.Dequeue();
                Console.WriteLine(k.ToString());
                foreach (T x in Neighbors(k))
                {
                    if ( ! F.Contains(x) )
                    {
                        S.Enqueue(x);
                        F.Add(x);
                    }
                }
            }
        }
    }
}
