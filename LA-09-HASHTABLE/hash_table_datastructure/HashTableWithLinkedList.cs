using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash_table_datastructure
{
    public class HashTableWithLinkedList<K, T> : HashTable<K, T>
    {
        class HashItem
        {
            public K key;
            public T value; // value or content
            public HashItem next;
        }

        HashItem[] A;

        public HashTableWithLinkedList(int m) : base(m)
        {
            A = new HashItem[m];
        }

        public override void Insert(K key, T value)
        {
            HashItem newItem = new HashItem();
            newItem.key = key;
            newItem.value = value;

            newItem.next = A[h(key)];

            A[h(key)] = newItem;
        }

        public override T Search(K kulcs)
        {
            HashItem p = A[h(kulcs)];

            while (p != null && !p.key.Equals(kulcs))
                p = p.next;

            if (p != null)
                return p.value;
            else
                throw new NoSuchKeyHashingException("No such key exists.");
        }

        public override void Delete(K kulcs)
        {
            HashItem p = A[h(kulcs)];
            HashItem e = null;
            while (p != null && !p.key.Equals(kulcs))
            {
                e = p;
                p = p.next;
            }

            if (p != null)
                if (e == null)
                    A[h(kulcs)] = p.next;
                else
                    e.next = p.next;
            else
                throw new NoSuchKeyHashingException("No such key exists.");
        }
    }
}
