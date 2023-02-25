using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    // Improve Feature: (a) Add a new subclass Raptor
    public class Raptor : Bird // Improve Feature: (b) Make Raptor a subclass of Bird
    {
        private List<string> prey = new List<string>() { "cat", "mouse" }; // Add a list to store the prey of Raptor and keep it readonly
        public Raptor(string name)
        {
            emoji = "🦅";
            species = "raptor";
            this.name = name;
            reactionTime = 1;
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a raptor. I'm hungry!");

            /*CatchPrey("cat");
            CatchPrey("mouse");*/

            RaptorHunt(prey); // Improve Feature: (d) The Raptor will hunt both Cat and Mouse.
        }

        /// <summary>
        /// Attack when detect prey
        /// </summary>
        /// <param name="prey">Prey list of the Raptor</param>
        /// Is called by Activate method
        private void RaptorHunt(List<string> prey)
        {
            if (Seek(location.x, location.y, Direction.up, prey[0]) || Seek(location.x, location.y, Direction.up, prey[1]))
            {
                Attack(this, Direction.up);
            }else if (Seek(location.x, location.y, Direction.down, prey[0]) || Seek(location.x, location.y, Direction.down, prey[1]))
            {
                Attack(this, Direction.down);
            }else if (Seek(location.x, location.y, Direction.left, prey[0]) || Seek(location.x, location.y, Direction.left, prey[1]))
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
