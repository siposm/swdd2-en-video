using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bstree
{
    class Person
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BST<Person, int> bst =
                new BST<Person, int>();

            bst.Insert(new Person()
            {
                Name = "Test Pilot"
            }, 10);

            bst.Insert(new Person()
            {
                Name = "Steve Jobs"
            }, 20);

            bst.Insert(new Person()
            {
                Name = "Thanos"
            }, 1);

            bst.Traverse(TraversalTypes.PreOrder);

            Console.WriteLine("\n---\n");

            bst.Traverse(TraversalTypes.InOrder);

            Console.WriteLine("\n---\n");

            bst.Traverse(TraversalTypes.PostOrder);
        }
    }
}
