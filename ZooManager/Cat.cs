using System;

namespace ZooManager
{
    public class Cat : Animal
    {
        public Cat(string name)
        {
            emoji = "🐱";
            species = "cat";
            this.name = name;
            reactionTime = new Random().Next(1, 6); // reaction time 1 (fast) to 5 (medium)
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a cat. Meow.");
            if (!FleeAwayHunter("raptor"))
            {
                Hunt();
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
        private void Hunt()
        {
            if (Seek(location.x, location.y, Direction.up, "mouse") || Seek(location.x, location.y, Direction.up, "chick"))
            {
                Attack(this, Direction.up);
            }
            else if (Seek(location.x, location.y, Direction.down, "mouse") || Seek(location.x, location.y, Direction.down, "chick"))
            {
                Attack(this, Direction.down);
            }
            else if (Seek(location.x, location.y, Direction.left, "mouse") || Seek(location.x, location.y, Direction.left, "chick"))
            {
                Attack(this, Direction.left);
            }
            else if (Seek(location.x, location.y, Direction.right, "mouse") || Seek(location.x, location.y, Direction.right, "chick"))
            {
                Attack(this, Direction.right);
            }
        }

        private bool FleeAwayHunter(string hunter)
        {
            if (Seek(location.x, location.y, Direction.up, hunter))
            {
                if (Retreat(this, Direction.down)) return true;
            }
            if (Seek(location.x, location.y, Direction.down, hunter))
            {
                if (Retreat(this, Direction.up)) return true;
            }
            if (Seek(location.x, location.y, Direction.left, hunter))
            {
                if (Retreat(this, Direction.right)) return true;
            }
            if (Seek(location.x, location.y, Direction.right, hunter))
            {
                if (Retreat(this, Direction.left)) return true;
            }
            return false;
        }
    }
}

