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
        private int turnsNotEat = 0; // Improve Feature: (p) Set up a variable to remember how many turns the animal does not eat

        public Raptor(string name)
        {
            emoji = "🦅";
            species = "raptor";
            this.name = name;
            reactionTime = 1;
        }

        public override void Activate()
        {
            if (turnsNotEat > 3) // Improve Feature: (p) If the turnsNotEat more than 3. The Raptor will starve to death and become a corpse
            {
                emoji = "☠";
                species = "";
                name = "Corpse";
                reactionTime = 0;
            }
            else
            {
                base.Activate();
                Console.WriteLine("I am a raptor. I'm hungry!");

                /*CatchPrey("cat");
                CatchPrey("mouse");*/

                RaptorHunt(prey); // Improve Feature: (d) The Raptor will hunt both Cat and Mouse.
            }
            
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
                turnsNotEat = 0;
            }else if (Seek(location.x, location.y, Direction.down, prey[0]) || Seek(location.x, location.y, Direction.down, prey[1]))
            {
                Attack(this, Direction.down);
                turnsNotEat = 0;
            }else if (Seek(location.x, location.y, Direction.left, prey[0]) || Seek(location.x, location.y, Direction.left, prey[1]))
            {
                Attack(this, Direction.left);
                turnsNotEat = 0;
            }
            else if (Seek(location.x, location.y, Direction.right, prey[0]) || Seek(location.x, location.y, Direction.right, prey[1]))
            {
                Attack(this, Direction.right);
                turnsNotEat = 0;
            }
            else
            {
                turnsNotEat++;
            }   
        }

    }
}
