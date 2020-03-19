using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS
{
    class Person
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return (obj as Person).Name.Equals(this.Name);
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
