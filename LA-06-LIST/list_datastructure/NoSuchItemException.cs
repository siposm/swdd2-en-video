using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_datastructure
{
    class NoSuchItemException : Exception
    {
        public NoSuchItemException(string msg)
            : base(msg)
        {

        }
    }
}
