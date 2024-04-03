using System;
using System.Collections.Generic;

namespace final_fantasy
{
    internal class Hamster : Pet
    {
        public Hamster(string name, string type, DateTime dateOfBirth, List<string> command) : base(name, type, dateOfBirth, command)
        {
        }
    }
}
