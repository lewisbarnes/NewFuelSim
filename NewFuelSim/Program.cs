using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFuelSim
{
    class Program
    {
        static void Main(string[] args)
        {
            // New simcontroller with x number of pumps where x % 3 = 0
            var sc = new SimController(9);
            sc.StartLoop();
            Console.ReadKey();
        }
    }
}
