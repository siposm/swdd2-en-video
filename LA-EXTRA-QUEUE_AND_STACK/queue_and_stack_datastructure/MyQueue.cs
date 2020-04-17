using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue_and_stack_datastructure
{
    class MyQueue<T>
    {
        T[] items;
        int count;

        public delegate void TraversalHandler(T content);

        public MyQueue(int size)
        {
            items = new T[size];
            count = -1;
        }

        public T Peek()
        {
            if (count >= 0)
                return items[0];
            throw new Exception("Queue is empty.");
        }

        public void Enqueue(T newItem)
        {
            if ( count < items.Length )
                items[++count] = newItem;
            else
                throw new Exception("Queue is full.");
        }

        public T Dequeue()
        {
            if (count >= 0)
            {
                T toReturn = items[0];

                Shift();

                items[count] = default;
                count--;

                return toReturn;
            }
            throw new Exception("Queue is empty.");
        }

        public void Traverse(TraversalHandler method)
        {
            for (int i = 0; i <= count; i++)
                method(items[i]);
        }

        private void Shift()
        {
            for (int i = 1; i <= count; i++)
                items[i - 1] = items[i];
        }
    }
}
