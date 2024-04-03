﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_fantasy
{
    internal class Animal
    {
        public string Name { get; }
        public string Type { get; }
        public DateTime DateOfBirth { get; }
        public List<string> Commands { get; set; }

        public Animal(string name, string type, DateTime dateOfBirth, List<string> commands)
        {
            Name = name;
            Type = type;
            DateOfBirth = dateOfBirth;
            Commands = commands;
        }
    }
}
