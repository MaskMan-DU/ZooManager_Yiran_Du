using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    // Adjust: Move ActivateAnimals method from Game to Zoo object. Because this method manages Zone information

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

                        // Adjust#3: When Occupant be created, errors will appear, Fix here.
                        if ((zone.occupant as Animal != null || zone.occupant as Alien != null) && reactionTimeNow < r) // Improve Feature: (o) reset the isActivated if the animal move to up or right. When the animal move to up or right, it will can not use NotActivated method to reset the isActivated value.
                        {
                            zone.occupant.isActivated = false;
                        }

                        if (zone.occupant as Animal != null && ((Animal)zone.occupant).reactionTime == r) 
                        {
                            if (zone.occupant.NotActivated()) // Improve Feature: (o) Add a check condition.Check if this animal has moved.If it has moved, change the variable isMoved to false and stop activate this animal again.
                            {
                                ((Animal)zone.occupant).Activate();
                            }

                            reactionTimeNow++;

                        }

                        if (zone.occupant as Alien != null && ((Alien)zone.occupant).reactionTime == r)
                        {
                            if (zone.occupant.NotActivated()) // Improve Feature: (o) Add a check condition.Check if this animal has moved.If it has moved, change the variable isMoved to false and stop activate this animal again.
                            {
                                ((Alien)zone.occupant).Activate();
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
