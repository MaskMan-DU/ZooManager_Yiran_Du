using System;
namespace ZooManager
{
    public class Mouse : Animal
    {
        public Mouse(string name)
        {
            emoji = "🐭";
            species = "mouse";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(1, 4); // reaction time of 1 (fast) to 3
            /* Note that Mouse reactionTime range is smaller than Cat reactionTime,
             * so mice are more likely to react to their surroundings faster than cats!
             */
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a mouse. Squeak.");
            Flee();
        }

        /* Note that our mouse is (so far) a teeny bit more strategic than our cat.
         * The mouse looks for cats and tries to run in the opposite direction to
         * an empty spot, but if it finds that it can't go that way, it looks around
         * some more. However, the mouse currently still has a major weakness! He
         * will ONLY run in the OPPOSITE direction from a cat! The mouse won't (yet)
         * consider running to the side to escape! However, we have laid out a better
         * foundation here for intelligence, since we actually check whether our escape
         * was succcesful -- unlike our cats, who just assume they'll get their prey!
         */

        // Adjust: Keep this method private, because it only be used in Mouse object.
        private void Flee()
        {
            int runDistance;
            if (Seek(location.x, location.y, Direction.up, "cat"))
            {
                runDistance = Move(this, Direction.up, 2);
                if (runDistance == 0)
                {
                    return;
                }
                else if (runDistance == 1)
                {
                    Console.WriteLine("The mouse run from up cat for 1 square!");
                    return;
                }
                else if (runDistance == 2)
                {
                    Console.WriteLine("The mouse run from up cat for 2 squares!");
                    return;
                }
            }
            if (Seek(location.x, location.y, Direction.down, "cat"))
            {
                runDistance = Move(this, Direction.down, 2);
                if (runDistance == 0)
                {
                    return;
                }
                else if (runDistance == 1)
                {
                    Console.WriteLine("The mouse run from down cat for 1 square!");
                    return;
                }
                else if (runDistance == 2)
                {
                    Console.WriteLine("The mouse run from doiwn cat for 2 squares!");
                    return;
                }
            }
            if (Seek(location.x, location.y, Direction.left, "cat"))
            {
                runDistance = Move(this, Direction.left, 2);
                if (runDistance == 0)
                {
                    return;
                }
                else if (runDistance == 1)
                {
                    Console.WriteLine("The mouse run from left cat for 1 square!");
                    return;
                }
                else if (runDistance == 2)
                {
                    Console.WriteLine("The mouse run from left cat for 2 squares!");
                    return;
                }
            }
            if (Seek(location.x, location.y, Direction.right, "cat"))
            {
                runDistance = Move(this, Direction.right, 2);
                if (runDistance == 0)
                {
                    return;
                }
                else if (runDistance == 1)
                {
                    Console.WriteLine("The mouse run from right cat for 1 square!");
                    return;
                }
                else if (runDistance == 2)
                {
                    Console.WriteLine("The mouse run from right cat for 2 squares!");
                    return;
                }
            }
        }
    }
}

