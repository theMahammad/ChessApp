using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass test = new();
            List < TestClass > list = new();
            list.Add((TestClass)test.Clone());
            test.name = "Mehemmed";
            Console.WriteLine(list[0].name);
            

        }
    }
}
