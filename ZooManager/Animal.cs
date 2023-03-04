using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Animal: Occupant
    {
        public string name; // Adjust: Change it from public to protected, because this variable only be used in animal class and class inherited from animal class
        public int reactionTime = 5; // default reaction time for animals (1 - 10)

        protected int liveTime = 1; // Improve Feature: (m) Add a new variable to remember the animal's live time

        virtual public void Activate()
        {
            Console.WriteLine($"Animal {name} at {location.x},{location.y} activated");
            Console.WriteLine($"Animal {name} has lived for {liveTime} turns");
            liveTime++;   
        }    
    }
}
