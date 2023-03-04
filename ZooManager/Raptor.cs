using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    // Improve Feature: (a) Add a new subclass Raptor
    public class Raptor : Bird // Improve Feature: (b) Make Raptor a subclass of Bird
    {
        // private List<string> prey = new List<string>() { "cat", "mouse" }; // Add a list to store the prey of Raptor and keep it readonly
        public override List<string> Prey { get { return new List<string>() { "cat", "mouse" }; } }

        private int turnsNotEat = 0; // Improve Feature: (p) Set up a variable to remember how many turns the animal does not eat
        public override int TurnsNotEat { get { return turnsNotEat; } set { turnsNotEat = value; } } 

        public Raptor(string name)
        {
            emoji = "🦅";
            species = "raptor";
            this.name = name;
            reactionTime = 1;
        }

        public override void Activate()
        {
            if (TurnsNotEat > 3) // Improve Feature: (p) If the turnsNotEat more than 3. The Raptor will starve to death and become a corpse
            {
                emoji = "☠";
                species = "";
                name = "Corpse";
            }
            else // not starve to death
            {
                base.Activate();
                Console.WriteLine("I am a raptor. I'm hungry!");

                /*CatchPrey("cat");
                CatchPrey("mouse");*/

                Console.WriteLine("Turns not eat" + TurnsNotEat);
                Hunt(Prey); // Improve Feature: (d) The Raptor will hunt both Cat and Mouse.
                
            }
            
        }

        /// <summary>
        /// Attack when detect prey
        /// </summary>
        /// <param name="prey">Prey list of the Raptor</param>
        /// Is called by Activate method
        public override void Hunt(List<string> prey)
        {
            if (Seek(location.x, location.y, Direction.up, prey[0]) || Seek(location.x, location.y, Direction.up, prey[1]))
            {
                Attack(this, Direction.up);
                TurnsNotEat = 0;
            }else if (Seek(location.x, location.y, Direction.down, prey[0]) || Seek(location.x, location.y, Direction.down, prey[1]))
            {
                Attack(this, Direction.down);
                TurnsNotEat = 0;
            }else if (Seek(location.x, location.y, Direction.left, prey[0]) || Seek(location.x, location.y, Direction.left, prey[1]))
            {
                Attack(this, Direction.left);
                TurnsNotEat = 0;
            }
            else if (Seek(location.x, location.y, Direction.right, prey[0]) || Seek(location.x, location.y, Direction.right, prey[1]))
            {
                Attack(this, Direction.right);
                TurnsNotEat = 0;
            }
            else
            {
                TurnsNotEat++;
            }   
        }

    }
}
