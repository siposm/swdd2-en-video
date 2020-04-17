using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue_and_stack_datastructure
{
    class Program
    {
        static void TraversalMethod(string input)
        {
            Console.WriteLine("\t>> " + input);
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

            Console.WriteLine("QUEUE ITEMS:");
            mq.Traverse(TraversalMethod);
            Console.WriteLine();

            Console.WriteLine("PEEK 1: " + mq.Peek()); // should return "apple 1"

            Console.WriteLine("TAKE 1: " + mq.Dequeue()); // should return "apple 1"
            Console.WriteLine("TAKE 2: " + mq.Dequeue()); // should return "apple 2"

            Console.WriteLine("PEEK 2: " + mq.Peek()); // should return "apple 3"
        }

        static void Main(string[] args)
        {
            // :::::::::::::::::::::::::::::::::::::::::
            //  QUEUE DATA STRUCTURE - EXAMPLE
            // :::::::::::::::::::::::::::::::::::::::::

            QueueTesting();
            

            // :::::::::::::::::::::::::::::::::::::::::
            //  STACK DATA STRUCTURE - EXAMPLE
            // :::::::::::::::::::::::::::::::::::::::::
        }
    }
}
