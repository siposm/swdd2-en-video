using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_datastructure
{
    class ChainedList < T >
    {
        private ListItem head;

        class ListItem
        {
            public T content;
            public ListItem next;
        }

        // -----------------------------

        public void Insert2Front(T newContent)
        {
            ListItem newItem = new ListItem();
            newItem.content = newContent;
            newItem.next = head; // !!!!
            head = newItem;
        }

        public void Traversal()
        {
            ListItem p = head;
            while (p != null)
            {
                Process(p);
                p = p.next;
            }
        }

        private void Process(ListItem p)
        {
            Console.WriteLine(p.content);
        }

        // --------------------

        public int Count()
        {
            int count = 0;
            ListItem p = head;
            while (p != null)
            {
                count++;
                p = p.next;
            }
            return count;
        }

        public T[] CopyToArray()
        {
            T[] arrayToReturn = new T[Count()];
            int i = 0;

            ListItem p = head;
            while (p != null)
            {
                arrayToReturn[i++] = p.content;
                p = p.next;
            }

            return arrayToReturn;
        }
    }
}
