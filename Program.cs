﻿using System;
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
            var registry = new AnimalRegistry();
            registry.Open();

            Console.ReadLine();
        }
    }
}
