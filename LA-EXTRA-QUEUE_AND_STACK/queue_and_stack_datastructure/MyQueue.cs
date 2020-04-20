using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue_and_stack_datastructure
{
    class MyQueue<T>
    {
        private T[] items;
        public int Count { get; private set; }

        public delegate void TraversalHandler(T content);

        public MyQueue(int size)
        {
            items = new T[size];
            Count = -1;
        }

        public T Peek()
        {
            if (Count >= 0)
                return items[0];
            throw new Exception("Queue is empty.");
        }

        public void Enqueue(T newItem)
        {
            if ( Count < items.Length )
                items[++Count] = newItem;
            else
                throw new Exception("Queue is full.");
        }

        public T Dequeue()
        {
            if (Count >= 0)
            {
                T toReturn = items[0];

                Shift();

                items[Count--] = default;

                return toReturn;
            }
            throw new Exception("Queue is empty.");
        }

        public void Traverse(TraversalHandler method)
        {
            for (int i = 0; i <= Count; i++)
                method(items[i]);
        }

        private void Shift()
        {
            for (int i = 1; i <= Count; i++)
                items[i - 1] = items[i];
        }
    }
}
