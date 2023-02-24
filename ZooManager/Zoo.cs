using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    // Adjust: Move ActivateAnimals method from Game to Zoo object. Because this method manages Zone information and changes 
    public static class Zoo
    {
        /*public static int reactionTimeNow = 1;*/
        public static void ActivateAnimals()
        {
            
            for (var r = 1; r < 11; r++) // reaction times from 1 to 10
            {
                for (var y = 0; y < Game.numCellsY; y++)
                {
                    for (var x = 0; x < Game.numCellsX; x++)
                    {
                        var zone = Game.animalZones[y][x];

                        /*if (r < reactionTimeNow && zone.occupant != null)
                        {
                            zone.occupant.isMoved = false;
                        }*/

                        if (zone.occupant != null && zone.occupant.reactionTime == r) // Improve Feature: (o) Add a check condition. Check if this animal has moved. If it has moved, change the variable isMoved to false and stop activate this animal again.
                        {
                            /*if (zone.occupant.NotMoved()) // If not moved
                            {
                                zone.occupant.Activate();
                                zone.occupant.isMoved = true; // Improve Feature: (o) If the animal has moved, remember it.
                            }*/
                            zone.occupant.Activate();

                            /*reactionTimeNow = r;*/
                        }
                    }
                }
                
            }
        }
    }
}
