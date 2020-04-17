using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue_and_stack_datastructure
{
    class Program
    {
        static void HR()
        {
            Console.WriteLine("\n\n--------------------------------\n\n");
        }

        static void H1(string x)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  :: " + x);
            Console.ResetColor();
        }

        static void TraversalMethod(string input)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t>> " + input);
            Console.ResetColor();
        }

        static void QueueTesting()
        {
            MyQueue<string> mq = new MyQueue<string>(7);

            try
            {
                mq.Peek();
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERR] : " + e.Message);
            }

            mq.Enqueue("apple 1");
            mq.Enqueue("apple 2");
            mq.Enqueue("apple 3");
            mq.Enqueue("apple 4");

            H1("QUEUE ITEMS:");
            mq.Traverse(TraversalMethod);
            Console.WriteLine();

            Console.WriteLine("PEEK 1: " + mq.Peek()); // should return "apple 1"

            Console.WriteLine("TAKE 1: " + mq.Dequeue()); // should return "apple 1"
            Console.WriteLine("TAKE 2: " + mq.Dequeue()); // should return "apple 2"

            Console.WriteLine("PEEK 2: " + mq.Peek()); // should return "apple 3"
        }

        static void StackTesting()
        {
            MyStack<string> ms = new MyStack<string>(5);

            ms.Push("peach 1");
            ms.Push("peach 2");
            ms.Push("peach 3");

            Console.WriteLine("PEEK 1:" + ms.Peek()); // should return "peach 3"

            Console.WriteLine("POP 1:" + ms.Pop()); // should return "peach 3"
            Console.WriteLine("POP 2:" + ms.Pop()); // should return "peach 2"

            ms.Push("peach 4");
            Console.WriteLine("PEEK 2:" + ms.Peek()); // should return "peach 4"

            H1("STACK ITEMS:");
            ms.Traverse(TraversalMethod);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // :::::::::::::::::::::::::::::::::::::::::
            //  QUEUE DATA STRUCTURE - EXAMPLE
            // :::::::::::::::::::::::::::::::::::::::::

            QueueTesting();

            HR();

            // :::::::::::::::::::::::::::::::::::::::::
            //  STACK DATA STRUCTURE - EXAMPLE
            // :::::::::::::::::::::::::::::::::::::::::

            StackTesting();
        }
    }
}
