using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    interface IPredator
    {
        List<string> Prey { get; } // Predators need to know their preys
        int TurnsNotEat { get; set; } // Because I have improve the featrue (p), so the predator has a hungry time.
        void Hunt(List<string> prey); // All predators need have Hunt ability
    }
}
