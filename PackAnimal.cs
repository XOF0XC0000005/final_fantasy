using System;
using System.Collections.Generic;

namespace final_fantasy
{
    internal class PackAnimal : Animal
    {
        public PackAnimal(string name, string type, DateTime dateOfBirth, List<string> command) : base(name, type, dateOfBirth, command) { }
    }
}
