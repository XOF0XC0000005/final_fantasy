using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_fantasy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(Counter counter = new Counter())
            {
                var registry = new AnimalRegistry(counter);
                registry.Open();
            }

            Console.ReadLine();
        }
    }
}
