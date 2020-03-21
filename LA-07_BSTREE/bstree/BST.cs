using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bstree
{
    enum TraversalTypes
    {
        PreOrder, InOrder, PostOrder
    }

    // T = content (Person)
    // K = key (int)
    class BST<T,K> where K : IComparable
    {
        private TreeItem root;
        class TreeItem
        {
            public T content;
            public K key;
            public TreeItem left;
            public TreeItem right;

            public TreeItem(T content, K key)
            {
                this.key = key; this.content = content;
            }

            public override string ToString()
            {
                return $"{key.ToString()} - {content.ToString()}";
            }
        }
        public BST()
        {
            this.root = null;
        }

        public void Insert(T content, K key)
        {
            Insert(ref this.root, content, key);
        }
        private void Insert(ref TreeItem p, T content, K key)
        {
            if (p == null)
                p = new TreeItem(content, key);

            else if (p.key.CompareTo(key) < 0)
                Insert(ref p.right, content, key);

            else if (p.key.CompareTo(key) > 0)
                Insert(ref p.left, content, key);

            else
                throw new KeyExistsException("Item with the given key already exists.");
        }

        #region TRAVERSALS

        public void Traverse(TraversalTypes type)
        {
            if (type == TraversalTypes.PreOrder)
                PreOrder(this.root);

            else if (type == TraversalTypes.InOrder)
                InOrder(this.root);

            else if (type == TraversalTypes.PostOrder)
                PostOrder(this.root);
        }

        private void PreOrder(TreeItem p)
        {
            if(p != null)
            {
                Console.WriteLine(p);
                PreOrder(p.left);
                PreOrder(p.right);
            }
        }

        private void InOrder(TreeItem p)
        {
            if (p != null)
            {
                PreOrder(p.left);
                Console.WriteLine(p);
                PreOrder(p.right);
            }
        }

        private void PostOrder(TreeItem p)
        {
            if (p != null)
            {
                PreOrder(p.left);
                PreOrder(p.right);
                Console.WriteLine(p);
            }
        }

        #endregion
    }
}
