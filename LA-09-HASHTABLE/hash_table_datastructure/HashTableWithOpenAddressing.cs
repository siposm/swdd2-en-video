using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash_table_datastructure
{
    public class HashTableWithOpenAddressing<K, T> : HashTable<K, T>
    {
        class HashItem
        {
            public K key;
            public T value;
            public bool deleted = false;
        }

        HashItem[] A;

        public HashTableWithOpenAddressing(int m) : base(m)
        {
            A = new HashItem[m];
            for (int i = 0; i < m; i++)
                A[i] = new HashItem();
        }

        protected virtual int h(K key, int j)
        {
            return (base.h(key) + j * 31) % m;
        }

        public override void Insert(K kulcs, T ertek)
        {
            int j = 0;
            while (j < m && A[h(kulcs, j)].key != null && !A[h(kulcs, j)].deleted) j++;

            if (j < m)
            {
                A[h(kulcs, j)].key = kulcs;
                A[h(kulcs, j)].value = ertek;
                A[h(kulcs, j)].deleted = false;
            }
            else throw new NoSpaceHashingException("No free space to insert.");
        }

        public override T Search(K kulcs)
        {
            int j = 0;
            while (j < m && A[h(kulcs, j)].key != null && !(A[h(kulcs, j)].key.Equals(kulcs) && !A[h(kulcs, j)].deleted)) j++;

            if (j < m && A[h(kulcs, j)].key != null)
                return A[h(kulcs, j)].value;
            else
                throw new NoSuchKeyHashingException("No such key exists.");
        }

        public override void Delete(K kulcs)
        {
            int j = 0;
            while (j < m && A[h(kulcs, j)].key != null && !(A[h(kulcs, j)].key.Equals(kulcs) && !A[h(kulcs, j)].deleted)) j++;

            if (j < m && A[h(kulcs, j)].key != null)
                A[h(kulcs, j)].deleted = true;
            else
                throw new NoSuchKeyHashingException("No such key exists.");
        }
    }
}
