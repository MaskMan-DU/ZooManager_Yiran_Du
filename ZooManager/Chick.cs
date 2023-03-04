using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    // Improve Feature: (c) Add a new subclass of bird, Chick. It will flee from Cat.
    public class Chick : Bird
    {
        public override string Predator { get { return "Cat"; } }
        public Chick(string name)
        {
            emoji = "🐥";
            species = "chick";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(6, 11); // reaction time of 6 to 10 (slow)
        }

        public override void Activate()
        {
             Mature();        
             base.Activate();
             Console.WriteLine("I am a chick. Chirp.");
             Flee(Predator);     
        }

        // Improve Feature: (n) Add a new method to make the chick become raptor. After 3 turns
        /// <summary>
        /// Change all content of chick. Tranfer Chick to Raptor
        /// </summary>
        /// Is called by Activate()
        private void Mature()
        {
            if (liveTime >= 3) // When the chick has lived for more than 3 turns
            {
                Game.animalZones[location.y][location.x].occupant = new Raptor("Youthful Raptor"); // transfer the chick to raptor
            }      
        }
    }
}
