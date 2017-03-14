using UnityEngine;
using System.Collections;

public class HazardGenerator : MonoBehaviour
{
    public GameObject Obstacles;
    private float _hazardSpawnSeed;


    public GameObject Spawning(Vector2 hazardSpawnPosition)
    {
        GameObject newObstacle = Instantiate(Obstacles, hazardSpawnPosition, Quaternion.identity) as GameObject;
        return newObstacle;
    }
}
