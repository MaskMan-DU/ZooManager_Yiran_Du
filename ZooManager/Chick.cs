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
            if (liveTime >= 3) // When the chick live in the zone for three or more than three turns
            {
                Mature();        
            }
            else // less than three turns
            {
                base.Activate();
                Console.WriteLine("I am a chick. Chirp.");
                BirdFlee("cat");
            }       
        }

        // Improve Feature: (n) Add a new method to make the chick become raptor.
        /// <summary>
        /// Change all content of chick. Tranfer Chick to Raptor
        /// </summary>
        /// Is called by Activate()
        private void Mature()
        {
            emoji = "🦅";
            species = "raptor";
            this.name = "Haughty";
            reactionTime = 1;
            List<string> prey = new List<string>() { "cat", "mouse" };

            base.Activate();
            Console.WriteLine("I am a raptor. I'm hungry!");

            if (Seek(location.x, location.y, Direction.up, prey[0]) || Seek(location.x, location.y, Direction.up, prey[1]))
            {
                Attack(this, Direction.up);
            }
            else if (Seek(location.x, location.y, Direction.down, prey[0]) || Seek(location.x, location.y, Direction.down, prey[1]))
            {
                Attack(this, Direction.down);
            }
            else if (Seek(location.x, location.y, Direction.left, prey[0]) || Seek(location.x, location.y, Direction.left, prey[1]))
            {
                Attack(this, Direction.left);
            }
            else if (Seek(location.x, location.y, Direction.right, prey[0]) || Seek(location.x, location.y, Direction.right, prey[1]))
            {
                Attack(this, Direction.right);
            }
        }
    }
}
