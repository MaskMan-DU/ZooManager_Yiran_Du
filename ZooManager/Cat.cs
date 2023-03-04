using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Cat : Animal, IPredator, IPrey
    {
        private int turnsNotEat = 0; // Improve Feature: (p) Set up a variable to remember how many turns the animal does not eat
        public int TurnsNotEat { get { return turnsNotEat; } set { turnsNotEat = value; } }

        public string Predator { get { return "raptor"; } }
        public List<string> Prey { get { return new List<string>() { "mouse", "chick" }; } }

        public Cat(string name)
        {
            emoji = "🐱";
            species = "cat";
            this.name = name;
            reactionTime = new Random().Next(1, 6); // reaction time 1 (fast) to 5 (medium)
        }

        public override void Activate()
        {
            if (TurnsNotEat > 3) // Improve Feature: (p) If the turnsNotEat more than 3. The Cat will starve to death and become a corpse
            {
                emoji = "☠";
                species = "";
                name = "Corpse";
            }
            else // not hungry
            {
                base.Activate();
                Console.WriteLine("I am a cat. Meow.");
                if (!Flee(Predator)) // no raptor nearby
                {
                    Hunt(Prey);
                }
            }
                
        }

        /* Note that our cat is currently not very clever about its hunting.
         * It will always try to attack "up" and will only seek "down" if there
         * is no mouse above it. This does not affect the cat's effectiveness
         * very much, since the overall logic here is "look around for a mouse and
         * attack the first one you see." This logic might be less sound once the
         * cat also has a predator to avoid, since the cat may not want to run in
         * to a square that sets it up to be attacked!
         */

        // Adjust: Keep this method private, because it only be used in Cat object.
        // Improve Featrue: (e) Make cat can hunt mouse and chick
        public void Hunt(List<string> prey)
        {
            if (Seek(location.x, location.y, Direction.up, prey[0]) || Seek(location.x, location.y, Direction.up, prey[1])) // "Up" square, is mouse or chick
            {
                Attack(this, Direction.up);
                TurnsNotEat = 0;
            }
            else if (Seek(location.x, location.y, Direction.down, prey[0]) || Seek(location.x, location.y, Direction.down, prey[1])) // "Down" square, is mouse or chick
            {
                Attack(this, Direction.down);
                TurnsNotEat = 0;
            }
            else if (Seek(location.x, location.y, Direction.left, prey[0]) || Seek(location.x, location.y, Direction.left, prey[1])) // "Left" square, is mouse or chick
            {
                Attack(this, Direction.left);
                TurnsNotEat = 0;
            }
            else if (Seek(location.x, location.y, Direction.right, prey[0]) || Seek(location.x, location.y, Direction.right, prey[1])) // "Right" square, is mouse or chick
            {
                Attack(this, Direction.right);
                TurnsNotEat = 0;
            }
            else // no mouse or chick nearby 
            {
                TurnsNotEat++;
            }

        }

        // Improve Feature: (e) Make Cat flee from his predator, raptor
        /*private bool FleeAwayHunter(string hunter)*/
        public bool Flee(string hunter)
        {
            if (Seek(location.x, location.y, Direction.up, hunter)) // "Up" square, is the predator of Cat
            {
                if (Retreat(this, Direction.down)) return true; // Escapes Down and returns " true"
            }
            if (Seek(location.x, location.y, Direction.down, hunter)) // "Down" square, is the predator of Cat
            {
                if (Retreat(this, Direction.up)) return true; // Escapes Up and returns " true"
            }
            if (Seek(location.x, location.y, Direction.left, hunter)) // "Left" square, is the predator of Cat
            {
                if (Retreat(this, Direction.right)) return true; // Escapes Right and returns " true"
            }
            if (Seek(location.x, location.y, Direction.right, hunter)) // "Right" square, is the predator of Cat
            {
                if (Retreat(this, Direction.left)) return true; // Escapes Left and returns " true"
            }
            return false; // no predator nearby, return "false"
        }

    }
}

