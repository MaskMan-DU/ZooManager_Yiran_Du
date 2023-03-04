using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    public class Alien : Occupant, IPredator
    {
        public string name;
        public int reactionTime; 

        protected int liveTime = 1; // Improve Feature: (m) Add a variable to remember the Alien's live time

        private int turnsNotEat = 0; // Improve Feature: (p) Set up a variable to remember how many turns the Alien does not eat
        public int TurnsNotEat { get { return turnsNotEat; } set { turnsNotEat = value; } }
        public List<string> Prey { get { return new List<string>() { "mouse", "chick", "cat", "raptor" }; } }

        public Alien (string name)
        {
            this.name = name;
            species = "alien";
            emoji = "👽";
            reactionTime = new Random().Next(1, 11); // default reaction time for aliens (1 - 10)
        }

        virtual public void Activate()
        {
            if (TurnsNotEat > 3) // Improve Feature: (p) If the turnsNotEat more than 3. The Alien will starve to death and become a corpse
            {
                emoji = "☠";
                species = "";
                name = "Corpse";
            }
            else
            {
                Console.WriteLine($"Alien {name} at {location.x},{location.y} activated");
                Console.WriteLine($"Alien {name} has lived for {liveTime} turns");
                liveTime++;

                Console.WriteLine("I am a alien! I will eat you all!");
                Hunt(Prey);
            }            
        }

        // Adjust#3: First, use Hunt method in IPredator interface. Then change it to make Alien hunt all animals.
        /// <summary>
        /// Hunt all animals in the game
        /// </summary>
        /// <param name="prey">The list of all Animals</param>
        /// Is called by Activated() in Alien object
        public void Hunt(List<string> prey)
        {
            if (Seek(location.x, location.y, Direction.up, prey[0]) || Seek(location.x, location.y, Direction.up, prey[1]) || Seek(location.x, location.y, Direction.up, prey[2]) || Seek(location.x, location.y, Direction.up, prey[3])) // "Up" square, is prey
            {
                Attack(this, Direction.up);
                TurnsNotEat = 0;
            }
            else if (Seek(location.x, location.y, Direction.down, prey[0]) || Seek(location.x, location.y, Direction.down, prey[1]) || Seek(location.x, location.y, Direction.down, prey[2]) || Seek(location.x, location.y, Direction.down, prey[3])) // "Down" square, is prey
            {
                Attack(this, Direction.down);
                TurnsNotEat = 0;
            }
            else if (Seek(location.x, location.y, Direction.left, prey[0]) || Seek(location.x, location.y, Direction.left, prey[1]) || Seek(location.x, location.y, Direction.left, prey[2]) || Seek(location.x, location.y, Direction.left, prey[3])) // "Left" square, is mouse or chick
            {
                Attack(this, Direction.left);
                TurnsNotEat = 0;
            }
            else if (Seek(location.x, location.y, Direction.right, prey[0]) || Seek(location.x, location.y, Direction.right, prey[1]) || Seek(location.x, location.y, Direction.right, prey[2]) || Seek(location.x, location.y, Direction.right, prey[3])) // "Right" square, is mouse or chick
            {
                Attack(this, Direction.right);
                TurnsNotEat = 0;
            }
            else // no mouse or chick nearby 
            {
                TurnsNotEat++;
            }
        }
    }
}
