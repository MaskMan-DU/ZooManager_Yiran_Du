using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    // Adjust#2: Create a IPrey interface, all prey will implement this interface
    interface IPrey
    {
        string Predator { get; } // Preys need to know their predator
        bool Flee(string hunter); // All preys need have Flee ability
    }
}
