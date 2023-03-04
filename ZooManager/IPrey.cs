using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    interface IPrey
    {
        string Predator { get; } // Preys need to know their predator
        bool Flee(string hunter); // All preys need have Flee ability
    }
}
