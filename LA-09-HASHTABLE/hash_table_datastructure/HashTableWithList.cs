using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash_table_datastructure
{
    class HashTableWithList<K, T> : HashTable<K, T>
    {
        class HashItem
        {
            public K key;
            public T value;
            public List<T> nextValues;
        }

        HashItem[] A;

        public HashTableWithList(int m) : base(m)
        {
            A = new HashItem[m];
        }


        public override void Delete(K key)
        {
            if (A[h(key)] == null)
                throw new NoSuchKeyHashingException("No such key exists.");
            else
            {
                HashItem x = A[h(key)];
                if (x.nextValues.Count > 0)
                    x.nextValues.RemoveAt(x.nextValues.Count - 1);
                else
                    A[h(key)] = null;
            }
        }

        public override void Insert(K key, T value)
        {
            if(A[h(key)] != null)
            {
                // item already exists with this KEY
                A[h(key)].nextValues.Add(value); // add to end (!) of the list
            }
            else
            {
                // first item
                HashItem hi = new HashItem();
                hi.key = key;
                hi.value = value;
                hi.nextValues = new List<T>();

                A[h(key)] = hi;
            }
        }

        public override T Search(K key)
        {
            if (A[h(key)] == null)
                throw new NoSuchKeyHashingException("No such key exists.");
            else
            {
                HashItem x = A[h(key)];
                if (x.nextValues.Count > 0)
                    return x.nextValues.Last();
                else
                    return x.value;
            }
        }
    }
}
