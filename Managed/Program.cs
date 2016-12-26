using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managed
{
    class Program
    {
        static void Main(string[] args)
        {
            var sumValue = UnmanagedProxy.Add(1, 2);


            Console.Read();
        }
    }
}
