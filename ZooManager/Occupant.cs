using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    // Adjust#3: Creat a new class, make it be the top Class of Animal and Alien
    public class Occupant
    {
        public string emoji;
        public string species;

        public Point location;

        public bool isActivated = false; // Improve Feature: (o) Add a new variable to remember is this occupant activatied

        public void ReportLocation()
        {
            Console.WriteLine($"I am at {location.x},{location.y}");
        }

        // Improve Feature: (o) Add a method to check if the occupant has activated
        /// <summary>
        /// check if the occupant has activated
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

        // Improve Feature: (g) Wirte a new method Move that use 3 pieces of information: an Occupant(Animal is the subclass of Occupant), a Direction, and a Distance. The specified Occupant will move in the specified direction 1 square at a time, but will only into an empty square. If the next square in that direction is not empty, the animal will not move.
        /// <summary>
        /// Let the runner move in a random direction other than hunterDirecton, and the maximum number of steps to move is determined by Distance.
        /// </summary>
        /// <param name="runner">The Occupant wants to move</param>
        /// <param name="hunterDirecton">Direction of Occupant to avoid</param>
        /// <returns>The actual number of steps the Occupant moves</returns>
        /// Is called by Mouse object
        protected virtual int Move(Occupant runner, Direction hunterDirecton, int Distance)
        {
            // The following code is to disrupt the direction list after removing the hunterDirection.
            List<Direction> allDirection = new List<Direction> { Direction.down, Direction.up, Direction.left, Direction.right }; // Add a new list which contain 4 direction
            allDirection.Remove(hunterDirecton); // Remove th hunt direction in the list
            Random random = new Random();
            List<Direction> moveDirection = new List<Direction>(); // Build a new list to store posible move direction
            // Disrupt the moveDirection list
            foreach (Direction direction in allDirection)
            {
                moveDirection.Insert(random.Next(moveDirection.Count + 1), direction);
            }

            int x = runner.location.x;
            int y = runner.location.y;

            int distance = 0; // the vairable to record the actual move distance 
            bool canMove = false; // Add a bool value to remember whether the Occupant can move

            // use for loop to check all direction in the moveDirection list
            for (int i = 0; i < 3; i++)
            {
                if (moveDirection[i] == Direction.up) // direction is up
                {
                    // use for loop to make the Occupant move the distance given by Distance.
                    for (int d = 0; d < Distance; d++)
                    {
                        if (y - d > 0 && x >= 0 && x <= Game.numCellsX - 1 && Game.animalZones[y - (d + 1)][x].occupant == null) // The Occupant is not out of range in the x-direction and the coordinate y - d remains within the range in the y-direction, while the zone on (y - d, x) is empty.
                        {
                            Game.animalZones[y - (d + 1)][x].occupant = runner;
                            Game.animalZones[y - d][x].occupant = null;
                            distance++;
                            canMove = true;
                        }
                        else // When a failure is determined, the loop is directly jumped out to prevent errors. Error example: The first move fails, but the second move succeeds.
                        {
                            break;
                        }
                    }

                    if (canMove) // Only a successful move will return distance and jump out of the whole loop.
                    {
                        return distance;
                    }
                }
                else if (moveDirection[i] == Direction.down) // direction is down
                {
                    for (int d = 0; d < Distance; d++)
                    {
                        if (y + d < Game.numCellsY - 1 && x >= 0 && x <= Game.numCellsX - 1 && Game.animalZones[y + (d + 1)][x].occupant == null) // The Occupant is not out of range in the x-direction and the coordinate y + d remains within the range in the y-direction, while the zone on (y + d, x) is empty.
                        {
                            Game.animalZones[y + (d + 1)][x].occupant = runner;
                            Game.animalZones[y + d][x].occupant = null;
                            distance++;
                            canMove = true;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (canMove)
                    {
                        return distance;
                    }

                }
                else if (moveDirection[i] == Direction.left) // direction is left
                {
                    for (int d = 0; d < Distance; d++)
                    {
                        if (x - d > 0 && y >= 0 && y <= Game.numCellsY - 1 && Game.animalZones[y][x - (d + 1)].occupant == null) // The Occupant is not out of range in the y-direction and the coordinate x - d remains within the range in the x-direction, while the zone on (y, x - d) is empty.
                        {
                            Game.animalZones[y][x - (d + 1)].occupant = runner;
                            Game.animalZones[y][x - d].occupant = null;
                            distance++;
                            canMove = true;
                        }
                        else
                        {
                            break;
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
                        if (x + d < Game.numCellsX - 1 && y >= 0 && y <= Game.numCellsY - 1 && Game.animalZones[y][x + (d + 1)].occupant == null) // The Occupant is not out of range in the y-direction and the coordinate x + d remains within the range in the x-direction, while the zone on (y, x + d) is empty.
                        {
                            Game.animalZones[y][x + (d + 1)].occupant = runner;
                            Game.animalZones[y][x + d].occupant = null;
                            distance++;
                            canMove = true;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (canMove)
                    {
                        return distance;
                    }
                }
            }

            return distance; // Returns distance if all the directions in moveDirection cannot be moved, and distance is then 0.
        }


        // Adjust#3: Move Seek method from Animal to Occupant. In this way, Alien as a subclass of Occupant can use this method.
        // Encapsulation: Make it protected, because only the class inherited from the Occupant will use this method. Make it virtual, becauce this method might be change in the class which is inherited from Occupant
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
            if (Game.animalZones[y][x].occupant.species == target)
            {
                return true;
            }
            return false;
        }



        // Adjust#3: Move Attack method from Animal to Occupant. In this way, Alien as a subclass of Occupant can use this method.
        // Encapsulation: Make it protected, because only the class inherited from the Occupant will use this method. Make it virtual, becauce this method might be change in the class which is inherited from Occupant
        protected virtual void Attack(Occupant attacker, Direction d)
        {
            if (attacker as Animal != null) // The attacker belongs to Animal Class
            {
                Console.WriteLine($"{((Animal)attacker).name} is attacking {d.ToString()}");
            }
            else if (attacker as Alien != null) // The attacker belongs to Alien Class
            {
                Console.WriteLine($"{((Alien)attacker).name} is attacking {d.ToString()}");
            }

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

        // Adjust#3: Move Retreat method from Animal to Occupant. In this way, Alien as a subclass of Occupant can use this method.
        // Adjust: Make it protected, because only the class inherited from the Occupant will use this method. Make it virtual, becauce this method might be change in the class which is inherited from Occupant
        protected virtual bool Retreat(Occupant runner, Direction d)
        {
            if (runner as Animal != null) // The runner belongs to Animal Class
            {
                Console.WriteLine($"{((Animal)runner).name} is attacking {d.ToString()}");
            }
            else if (runner as Alien != null) // The runner belongs to Alien Class
            {
                Console.WriteLine($"{((Alien)runner).name} is attacking {d.ToString()}");
            }
            
            int x = runner.location.x;
            int y = runner.location.y;

            switch (d)
            {
                case Direction.up:
                    if (y > 0 && Game.animalZones[y - 1][x].occupant == null)
                    {
                        Game.animalZones[y - 1][x].occupant = runner;
                        Game.animalZones[y][x].occupant = null;
                        return true; // retreat was successful
                    }
                    return false; // retreat was not successful
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
