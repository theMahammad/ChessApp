using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class TestClass:ICloneable
    {
        public string name { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
