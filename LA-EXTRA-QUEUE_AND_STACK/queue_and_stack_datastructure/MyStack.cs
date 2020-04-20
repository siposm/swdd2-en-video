using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue_and_stack_datastructure
{
    class MyStack<T>
    {
        T[] items;
        int count;

        public delegate void TraversalHandler(T content);

        public MyStack(int size)
        {
            items = new T[size];
            count = -1;
        }

        public void Push(T newitem)
        {
            if (count < items.Length - 1)
                items[++count] = newitem;
            else
                throw new Exception("Stack is full.");
        }

        public T Pop()
        {
            if(count >= 0)
                return items[count--];
            throw new Exception("Stack is empty.");
        }

        public T Peek()
        {
            if (count >= 0)
                return items[count];
            throw new Exception("Stack is empty.");
        }

        public void Traverse(TraversalHandler method)
        {
            //for (int i = 0; i <= count; i++) // bad order
            for (int i = count; i >= 0; i--)
                method(items[i]);
        }
    }
}
