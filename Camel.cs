﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_fantasy
{
    internal class Camel : PackAnimal
    {
        public Camel(string name, string type, DateTime dateOfBirth, List<string> command) : base(name, type, dateOfBirth, command)
        {
        }
    }
}