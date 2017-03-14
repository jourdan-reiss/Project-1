using UnityEngine;
using System.Collections;

public class HazardGenerator : MonoBehaviour
{
    public GameObject Obstacles;
    private float _hazardSpawnSeed;


    GameObject Spawning(Vector3 hazardSpawnPosition)
    {

        GameObject hazardToSpawn;
        _hazardSpawnSeed = Random.value;
        if (_hazardSpawnSeed > 0.4f)
            hazardToSpawn = Obstacles;
        else
            hazardToSpawn = null;

            return Instantiate(hazardToSpawn, hazardSpawnPosition, Quaternion.identity) as GameObject;
    }




}
