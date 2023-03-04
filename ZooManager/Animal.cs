using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Animal
    {
        public string emoji;
        public string species; 
        protected string name; // Adjust: Change it from public to protected, because this variable only be used in animal class and class inherited from animal class
        public int reactionTime = 5; // default reaction time for animals (1 - 10)
        
        public Point location;

        public bool isActivated = false; // Improve Feature: (o) Add a new variable to remember is this animal moved

        protected int liveTime = 1; // Improve Feature: (m) Add a new variable to remember the animal's live time

        public void ReportLocation()
        {
            Console.WriteLine($"I am at {location.x},{location.y}");
        }

        virtual public void Activate()
        {
            Console.WriteLine($"Animal {name} at {location.x},{location.y} activated");
            Console.WriteLine($"Animal {name} has lived for {liveTime} turns");
            liveTime++;   
        }

        // Improve Feature: (o) Add a method to check if the animal has activated
        /// <summary>
        /// check if the animal has activated
        /// </summary>
        /// <returns>If has activated, return true. Otherwise, return false</returns>
        /// Is called by Zoo object
        public bool NotActivated()
        {
            if (isActivated == true)
            {
                return isActivated = false;
            }
            return isActivated = true;
        }

        // Improve Feature: ()
        /// <summary>
        /// Let the runner move in a random direction other than hunterDirecton, and the maximum number of steps to move is determined by Distance.
        /// </summary>
        /// <param name="runner">The animal needs to move</param>
        /// <param name="hunterDirecton">Direction of animal to avoid</param>
        /// <returns>The number of steps the animal moves</returns>
        /// Is called by Mouse object
        protected virtual int Move(Animal runner, Direction hunterDirecton, int Distance)
        {
            List<Direction> allDirection = new List<Direction> { Direction.down, Direction.up, Direction.left, Direction.right};
            allDirection.Remove(hunterDirecton);
            Random random = new Random();
            List<Direction> moveDirection = new List<Direction>();
            foreach (Direction direction in allDirection)
            {
                moveDirection.Insert(random.Next(moveDirection.Count + 1), direction);
            }

            int x = runner.location.x;
            int y = runner.location.y;

            int distance = 0;
            bool canMove = false;

            for(int i = 0; i < 3; i++)
            {
                if (moveDirection[i] == Direction.up) // direction is up
                {
                    for (int d = 0; d < Distance; d++)
                    {
                        if (y - d > 0 && x >= 0 && x <= Game.numCellsX - 1 && Game.animalZones[y - (d + 1)][x].occupant == null)
                        {
                            Game.animalZones[y - (d + 1)][x].occupant = runner;
                            Game.animalZones[y - d][x].occupant = null;
                            distance++;
                            canMove = true;
                        }
                    }

                    if (canMove)
                    {
                        return distance;
                    }
                }
                else if (moveDirection[i] == Direction.down)
                {
                    for (int d = 0; d < Distance; d++)
                    {
                        if (y + d < Game.numCellsY - 1 && x >= 0 && x <= Game.numCellsX - 1 && Game.animalZones[y + (d + 1)][x].occupant == null)
                        {
                            Game.animalZones[y + (d + 1)][x].occupant = runner;
                            Game.animalZones[y + d][x].occupant = null;
                            distance++;
                            canMove = true;
                        }                     
                    }

                    if (canMove)
                    {
                        return distance;
                    }
                    
                }
                else if (moveDirection[i] == Direction.left)
                {
                    for (int d = 0; d < Distance; d++)
                    {
                        if (x - d > 0 && y >= 0 && y <= Game.numCellsY -1 && Game.animalZones[y][x - (d + 1)].occupant == null)
                        {
                            Game.animalZones[y][x - (d + 1)].occupant = runner;
                            Game.animalZones[y][x - d].occupant = null;
                            distance++;
                            canMove = true;
                        }
                    }

                    if (canMove)
                    {
                        return distance;
                    }
                    
                }
                else if (moveDirection[i] == Direction.right)
                {
                    for (int d = 0; d < Distance; d++)
                    {
                        if (x + d < Game.numCellsX - 1 && y >= 0 && y <= Game.numCellsY - 1 && Game.animalZones[y][x + (d + 1)].occupant == null)
                        {
                            Game.animalZones[y][x + (d + 1)].occupant = runner;
                            Game.animalZones[y][x + d].occupant = null;
                            distance++;
                            canMove = true;
                        }
                    }

                    if (canMove)
                    {
                        return distance;
                    }      
                }
            }

            return distance;
        } 


        // Adjust: Move Seek method to Animal. Seek is a behavior that animal can do, it makes sence to put it in the animal class
        // Adjust: Make it protected, because only the class inherited from the animal will use this method
        // Adjust: Make it virtual, becauce this method might be change in the class which is inherited from animal

        protected virtual bool Seek(int x, int y, Direction d, string target)
        {
            switch (d)
            {
                case Direction.up:
                    y--;
                    break;
                case Direction.down:
                    y++;
                    break;
                case Direction.left:
                    x--;
                    break;
                case Direction.right:
                    x++;
                    break;
            }
            if (y < 0 || x < 0 || y > Game.numCellsY - 1 || x > Game.numCellsX - 1) return false;
            if (Game.animalZones[y][x].occupant == null) return false;
            if (Game.animalZones [y][x].occupant.species == target)
            {
                return true;
            }
            return false;
        }

        /* This method currently assumes that the attacker has determined there is prey
         * in the target direction. In addition to bug-proofing our program, can you think
         * of creative ways that NOT just assuming the attack is on the correct target (or
         * successful for that matter) could be used?
         */

        // Adjust: Move Attack method to Animal. Attack is a behavior that animal can do, it makes sence to put it in the animal class
        // Adjust: Make it protected, because only the class inherited from the animal will use this method
        // Adjust: Make it virtual, becauce this method might be change in the class which is inherited from animal

        protected virtual void Attack(Animal attacker, Direction d)
        {
            Console.WriteLine($"{attacker.name} is attacking {d.ToString()}");
            int x = attacker.location.x;
            int y = attacker.location.y;

            switch (d)
            {
                case Direction.up:
                    Game.animalZones[y - 1][x].occupant = attacker;
                    break;
                case Direction.down:
                    Game.animalZones[y + 1][x].occupant = attacker;
                    break;
                case Direction.left:
                    Game.animalZones[y][x - 1].occupant = attacker;
                    break;
                case Direction.right:
                    Game.animalZones[y][x + 1].occupant = attacker;
                    break;
            }
            Game.animalZones[y][x].occupant = null;
        }

        /* We can't make the same assumptions with this method that we do with Attack, since
         * the animal here runs AWAY from where they spotted their target (using the Seek method
         * to find a predator in this case). So, we need to figure out if the direction that the
         * retreating animal wants to move is valid. Is movement in that direction still on the board?
         * Is it just going to send them into another animal? With our cat & mouse setup, one is the
         * predator and the other is prey, but what happens when we have an animal who is both? The animal
         * would want to run away from their predators but towards their prey, right? Perhaps we can generalize
         * this code (and the Attack and Seek code) to help our animals strategize more...
         */

        // Adjust: Move Retreat method to Animal. Retreat is a behavior that animal can do, it makes sence to put it in the animal class
        // Adjust: Make it protected, because only the class inherited from the animal will use this method
        // Adjust: Make it virtual, becauce this method might be change in the class which is inherited from animal

        protected virtual bool Retreat(Animal runner, Direction d)
        {
            Console.WriteLine($"{runner.name} is retreating {d.ToString()}");
            int x = runner.location.x;
            int y = runner.location.y;

            switch (d)
            {
                case Direction.up:
                    /* The logic below uses the "short circuit" property of Boolean &&.
                     * If we were to check our list using an out-of-range index, we would
                     * get an error, but since we first check if the direction that we're modifying is
                     * within the ranges of our lists, if that check is false, then the second half of
                     * the && is not evaluated, thus saving us from any exceptions being thrown.
                     */
                    if (y > 0 && Game.animalZones[y - 1][x].occupant == null)
                    {
                        Game.animalZones[y - 1][x].occupant = runner;
                        Game.animalZones[y][x].occupant = null;
                        return true; // retreat was successful
                    }
                    return false; // retreat was not successful
                /* Note that in these four cases, in our conditional logic we check
                 * for the animal having one square between itself and the edge that it is
                 * trying to run to. For example,in the above case, we check that y is greater
                 * than 0, even though 0 is a valid spot on the list. This is because when moving
                 * up, the animal would need to go from row 1 to row 0. Attempting to go from row 0
                 * to row -1 would cause a runtime error. This is a slightly different way of testing
                 * if 
                 */
                case Direction.down:
                    if (y < Game.numCellsY - 1 && Game.animalZones[y + 1][x].occupant == null)
                    {
                        Game.animalZones[y + 1][x].occupant = runner;
                        Game.animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
                case Direction.left:
                    if (x > 0 && Game.animalZones[y][x - 1].occupant == null)
                    {
                        Game.animalZones[y][x - 1].occupant = runner;
                        Game.animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
                case Direction.right:
                    if (x < Game.numCellsX - 1 && Game.animalZones[y][x + 1].occupant == null)
                    {
                        Game.animalZones[y][x + 1].occupant = runner;
                        Game.animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
            }
            return false; // fallback
        }
    }
}
