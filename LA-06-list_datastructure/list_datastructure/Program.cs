using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_datastructure
{
    class Person
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ChainedList<Person> personList =
                new ChainedList<Person>();

            personList.Insert2Front(new Person()
            {
                Name = "Test Person 1"
            });
            personList.Insert2Front(new Person()
            {
                Name = "Test Person 2"
            });
            personList.Insert2Front(new Person()
            {
                Name = "Test Person 3"
            });

            personList.Traversal();

            foreach (var item in personList.CopyToArray())
            {
                Console.WriteLine(">>> " + item);
            }

            // ---------------------

            ChainedList<int> intList =
                new ChainedList<int>();

            intList.Insert2Front(20);
            intList.Insert2Front(200);
            intList.Insert2Front(34);

            intList.Traversal();

            // ---------------------

            ChainedList<string> stringList
                = new ChainedList<string>();

            stringList.Insert2Front("first item");
            stringList.Insert2Front("second item");
            stringList.Insert2Front("third item");

            stringList.Traversal();

            foreach (var item in stringList.CopyToArray())
            {
                Console.WriteLine("---> " + item);
            }
        }
    }
}
