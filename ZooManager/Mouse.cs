using System;
namespace ZooManager
{
    public class Mouse : Animal, IPrey
    {
        public string Predator { get { return "cat"; } } // Adjust#2: Override the Predator property of IPrey interface.
        public Mouse(string name)
        {
            emoji = "🐭";
            species = "mouse";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(1, 4); // reaction time of 1 (fast) to 3
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a mouse. Squeak.");
            Flee(Predator);
        }


        public bool Flee(string hunter)
        {
            int runDistance;
            if (Seek(location.x, location.y, Direction.up, hunter))
            {
                runDistance = Move(this, Direction.up, 2);
                if (runDistance == 0)
                {
                    return true;
                }
                else if (runDistance == 1)
                {
                    Console.WriteLine("The mouse run from up cat for 1 square!");
                    return true;
                }
                else if (runDistance == 2)
                {
                    Console.WriteLine("The mouse run from up cat for 2 squares!");
                    return true;
                }
            }
            if (Seek(location.x, location.y, Direction.down, hunter))
            {
                runDistance = Move(this, Direction.down, 2);
                if (runDistance == 0)
                {
                    return true;
                }
                else if (runDistance == 1)
                {
                    Console.WriteLine("The mouse run from down cat for 1 square!");
                    return true;
                }
                else if (runDistance == 2)
                {
                    Console.WriteLine("The mouse run from doiwn cat for 2 squares!");
                    return true;
                }
            }
            if (Seek(location.x, location.y, Direction.left, "cat"))
            {
                runDistance = Move(this, Direction.left, 2);
                if (runDistance == 0)
                {
                    return true;
                }
                else if (runDistance == 1)
                {
                    Console.WriteLine("The mouse run from left cat for 1 square!");
                    return true;
                }
                else if (runDistance == 2)
                {
                    Console.WriteLine("The mouse run from left cat for 2 squares!");
                    return true;
                }
            }
            if (Seek(location.x, location.y, Direction.right, hunter))
            {
                runDistance = Move(this, Direction.right, 2);
                if (runDistance == 0)
                {
                    return true;
                }
                else if (runDistance == 1)
                {
                    Console.WriteLine("The mouse run from right cat for 1 square!");
                    return true;
                }
                else if (runDistance == 2)
                {
                    Console.WriteLine("The mouse run from right cat for 2 squares!");
                    return true;
                }
            }
            return false;
        }
    }
}

