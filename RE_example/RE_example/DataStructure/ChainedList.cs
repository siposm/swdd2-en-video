using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example.DataStructure
{
    public class ChainedList<T> : IEnumerator, IEnumerable where T : IComparable
    {
        private ListItem head;
        private ListItem head_pointer;
        class ListItem
        {
            public T content;
            public ListItem next;
        }

        public delegate void TraversalHandler(T content);

        // -----------------------------
        
        #region CUSTOM INDEXER

        public T this[int i]
        {
            get { return SearchItem(i); }
            set { ModItem(i, value); }
        }

        private T SearchItem(int index)
        {
            ListItem p = head;
            int count = 0;
            while (p != null && count < index)
            {
                p = p.next;
                count++;
            }

            if (p != null && count == index)
                return p.content;
            else
                throw new NoSuchItemException("no item was found");
        }
        private void ModItem(int index, T newValue)
        {
            ListItem p = head;
            int count = 0;
            while (p != null && count < index)
            {
                p = p.next;
                count++;
            }

            if (p != null && count == index)
                p.content = newValue;
            else
                throw new NoSuchItemException("no item was found");
        }

        #endregion
        
        // -----------------------------

        #region METHODS

        public void InsertToFront(T newContent)
        {
            ListItem newItem = new ListItem();
            newItem.content = newContent;
            newItem.next = head; // !!!!
            head = newItem;
        }

        public void InsertToBack(T newContent)
        {
            ListItem newItem = new ListItem();
            newItem.content = newContent;
            newItem.next = null;

            if (head == null)
                head = newItem;
            else
            {
                ListItem p = head;
                while (p.next != null) p = p.next;
                p.next = newItem;
            }
        }

        public void Traverse(TraversalHandler processingMethod)
        {
            ListItem p = head;
            while (p != null)
            {
                processingMethod(p.content);
                p = p.next;
            }
        }

        // -----------------------------

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

        #endregion

        // -----------------------------

        #region ENUMERATION METHODS

        public object Current
        {
            get { return head_pointer.content; }
        }

        public bool MoveNext()
        {
            if (head_pointer == null)
            {
                // first call
                head_pointer = head;
                return true;
            }
            else if (head_pointer.next != null)
            {
                // n'th call
                head_pointer = head_pointer.next;
                return true;
            }
            else
            {
                // last call (end of the list)
                this.Reset();
                return false;
            }
        }

        public void Reset()
        {
            head_pointer = null;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        #endregion

    }
}
