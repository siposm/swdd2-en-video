using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_datastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> g = new Graph<string>();

            g.AddNode("Joseph");
            g.AddNode("Stew");
            g.AddNode("Marge");
            g.AddNode("Gerald");
            g.AddNode("Zack");
            g.AddNode("Peter");
            g.AddNode("Janet");

            g.AddEdge("Joseph", "Stew");
            g.AddEdge("Joseph", "Marge");
            g.AddEdge("Marge", "Stew");

            g.AddEdge("Joseph", "Zack");
            g.AddEdge("Gerald", "Zack");
            g.AddEdge("Joseph", "Gerald");

            g.AddEdge("Peter", "Zack");
            g.AddEdge("Peter", "Janet");

            Console.WriteLine("\n>> DFS\n");
            g.DFS("Janet");

            Console.WriteLine("\n>> BFS\n");
            g.BFS("Janet");
        }
    }
}
