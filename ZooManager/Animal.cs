using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Animal: Occupant
    {
        public string name; 
        public int reactionTime = 5; // default reaction time for animals (1 - 10)

        protected int liveTime = 1; // Improve Feature: (m) Add a new variable to remember the animal's live time // Encapsulation: make it "protected" because it should be use in other class except subclass of Animal 


        public virtual void Activate()
        {
            Console.WriteLine($"Animal {name} at {location.x},{location.y} activated");
            Console.WriteLine($"Animal {name} has lived for {liveTime} turns");
            liveTime++;   
        }    
    }
}
