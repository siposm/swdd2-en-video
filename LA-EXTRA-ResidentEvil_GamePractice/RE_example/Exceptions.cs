using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example.DataStructure
{
    // used in ChainedList
    class NoSuchItemException : Exception
    {
        public NoSuchItemException(string msg) : base(msg) { }
    }

    // used in BSTree
    class KeyExistsException : Exception
    {
        public KeyExistsException(string msg) : base(msg) { }
    }
}
