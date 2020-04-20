using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

            // :::::::::::::::::::::::::::::::::::::::::
            //  QUEUE DATA STRUCTURE - EXAMPLE 2
            // :::::::::::::::::::::::::::::::::::::::::

            HR();

            MyQueue<SomeDelegate> methodQueue = new MyQueue<SomeDelegate>(5);

            methodQueue.Enqueue(CalculateNumber);
            methodQueue.Enqueue(MultiplyNumber);
            methodQueue.Enqueue(AddingRandomBitsToNumber);
            methodQueue.Enqueue(WriteOutNumber);

            int _number = 0;

            int limit = methodQueue.Count; // .Count changes as we take items out...
            for (int i = 0; i <= limit; i++)
                methodQueue.Dequeue()?.Invoke(ref _number);

            HR();
        }

        public delegate void SomeDelegate(ref int _number);

        static void CalculateNumber(ref int _number)
        {
            H1("... calculating the number ...");
            _number = 230;
            Console.WriteLine("\tNUMBER: " + _number);
        }
        static void MultiplyNumber(ref int _number)
        {
            H1("... multiplying the number ...");
            _number *= 3;
            Console.WriteLine("\tNUMBER: " + _number);
        }
        static void AddingRandomBitsToNumber(ref int _number)
        {
            H1("... adding random bits ...");
            _number += new Random().Next(1, 15);
            Console.WriteLine("\tNUMBER: " + _number);
        }
        static void WriteOutNumber(ref int _number)
        {
            H1("... writing out to file ...");
            File.WriteAllLines("_OUTPUT.txt", new[] { _number.ToString() });
            Console.WriteLine("\tDONE");
        }
    }
}
