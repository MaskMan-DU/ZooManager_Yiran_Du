using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    // Improve Feature: (c) Add a new subclass of bird, Chick. It will flee from Cat.
    public class Chick : Bird
    {
        public Chick(string name)
        {
            emoji = "🐥";
            species = "chick";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(6, 11); // reaction time of 6 to 10 (slow)
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a chick. Chirp.");
            BirdFlee("cat");
        }


    }
}
