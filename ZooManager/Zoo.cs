using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    // Adjust: Move ActivateAnimals method from Game to Zoo object. Because this method manages Zone information and changes 
    public class Zoo
    {
        public void ActivateAnimals()
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
                            zone.occupant.Activate();
                        }
                    }
                }
            }
        }
    }
}
