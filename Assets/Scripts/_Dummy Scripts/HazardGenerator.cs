using UnityEngine;
using System.Collections;

public class HazardGenerator : MonoBehaviour
{
    public GameObject[] listOfObstacles;
    public GameObject Obstacles;
    private float _hazardSpawnSeed;




    public GameObject WhatAreWeSpawning()
    {
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
