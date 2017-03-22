using UnityEngine;
using System.Collections;

public class HazardGenerator : MonoBehaviour
{

    /*
        This class is responsible for spawning all 'hazards'.
        Initially, the method is called outside of the class, so that the sequence of events is as follows:
        Line is instatiated; 'WhatAreWeSpawning' makes a decision based on a RNG; if it returns a gameobject,
         then instantiate an object to spawn at a set position.
    */

    public GameObject[] listOfObstacles; //an array of gameobjects. There will be four; three hazards that are only aesthetically different, with one collectible
    public GameObject Obstacles;
    private float _hazardSpawnSeed;




    public GameObject WhatAreWeSpawning()
    {
        //RNG method which returns either nothing or a set object from the array.

        GameObject newObstacle = null;
        _hazardSpawnSeed = Random.value;
        if (0f <= _hazardSpawnSeed && _hazardSpawnSeed <= 0.4f)
        {
             newObstacle = null;
        }
        else if (_hazardSpawnSeed <= 0.65f)
        {
            newObstacle = listOfObstacles[0];
        }
        else if (_hazardSpawnSeed > 0.65f)
        {
            newObstacle = listOfObstacles[1];
        }
         return newObstacle;
    }

    public GameObject Spawning(Vector2 SpawnPosition)
    {

        GameObject preTarget = WhatAreWeSpawning();

        if (preTarget != null)
        {
            GameObject target = Instantiate(preTarget, SpawnPosition, Quaternion.identity) as GameObject;
            return target;
        }
        else
            return null;
    }
}
