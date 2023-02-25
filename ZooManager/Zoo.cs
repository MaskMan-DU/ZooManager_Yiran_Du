using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    // Adjust: Move ActivateAnimals method from Game to Zoo object. Because this method manages Zone information and changes 
    public static class Zoo
    {
        static int reactionTimeNow = 0; // Remember animal Activate time.
        public static void ActivateAnimals()
        {
            
            for (var r = 1; r < 11; r++) // reaction times from 1 to 10
            {
                
                for (var y = 0; y < Game.numCellsY; y++)
                {
                    for (var x = 0; x < Game.numCellsX; x++)
                    {
                        var zone = Game.animalZones[y][x];

                        if (zone.occupant != null && zone.occupant.reactionTime == r) 
                        {
                            if (reactionTimeNow < r) // Improve Feature: (o) reset the isActivated if the animal move to up or right. When the animal move to up or right, it will can not use NotActivated method to reset the isActivated value.
                            {
                                zone.occupant.isActivated = false;
                            }

                            if (zone.occupant.NotActivated()) // Improve Feature: (o)Add a check condition.Check if this animal has moved.If it has moved, change the variable isMoved to false and stop activate this animal again.
                            {
                                zone.occupant.isActivated = true; // Improve Feature: (o) If the animal has moved, remember it. 
                                // isMoved must change first, otherwise there will be errors. Because after Activate() this location will lose the reference.
                                zone.occupant.Activate();
                            }

                            reactionTimeNow++;

                        }
                    }
                }
                
            }
            reactionTimeNow = 0; // Reset the variable
        }
    }
}
