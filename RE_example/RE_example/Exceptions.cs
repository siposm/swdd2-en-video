using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example.DataStructure
{
    class NoSuchItemException : Exception
    {
        public NoSuchItemException(string msg) : base(msg) { }
    }
}
