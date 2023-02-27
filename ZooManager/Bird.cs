using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    // Improve Feature: (b) Add a new subclass Bird, which is a subclass of animal
    public class Bird : Animal
    {
        /// <summary>
        /// Attack when detect prey
        /// </summary>
        /// <param name="prey">Prey list of the animal</param>
        protected virtual void CatchPrey(List<string> prey)
        {
            if (Seek(location.x, location.y, Direction.up, prey[0]))
            {
                Attack(this, Direction.up);
            }
            else if (Seek(location.x, location.y, Direction.down, prey[0]))
            {
                Attack(this, Direction.down);
            }
            else if (Seek(location.x, location.y, Direction.left, prey[0]))
            {
                Attack(this, Direction.left);
            }
            else if (Seek(location.x, location.y, Direction.right, prey[0]))
            {
                Attack(this, Direction.right);
            }
        }

        /// <summary>
        /// Search the hunter from up, down, left and right, if find the hunter, then run to the opposite direction of hunter
        /// </summary>
        /// <param name="hunter">The bird's predator</param>
        protected virtual void BirdFlee(string hunter)
        {
            if (Seek(location.x, location.y, Direction.up, hunter))
            {
                if (Retreat(this, Direction.down)) return;
            }
            if (Seek(location.x, location.y, Direction.down, hunter))
            {
                if (Retreat(this, Direction.up)) return;
            }
            if (Seek(location.x, location.y, Direction.left, hunter))
            {
                if (Retreat(this, Direction.right)) return;
            }
            if (Seek(location.x, location.y, Direction.right, hunter))
            {
                if (Retreat(this, Direction.left)) return;
            }
        }

    }
}
