using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;


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

/*
        public enum GameStates
        {
            playerDiesOften = 5,
            scoreThreshold = 20,
            distanceThreshold = 100
        };*/


      /*  private int isScoreMultipleof20 = GameManager.score;
        private int isDistanceMultipleof100 = (int)GameManager.distanceTravelled;
        private int comparePlayerDeath = GameManager.playerDeathCount;*/


        public int maxObjects;
        private List<GameObject> objects;


        void Awake()
        {
            objects = new List<GameObject>();
        }


        public GameObject WhatAreWeSpawning()
        {
            //RNG method which returns either nothing or a set object from the array.

            GameObject newObstacle = null;
            _hazardSpawnSeed = Random.value;

            /*GameStates scoreMultiplier = GameStates.scoreThreshold;
            GameStates playerDeaths = GameStates.playerDiesOften;
            GameStates distanceMultiplier = GameStates.distanceThreshold;*/

//            int increasingFactor = GameManager.difficultyAdditive;


            /*if (comparePlayerDeath >= (int) playerDeaths)
            {
                if (0f <= _hazardSpawnSeed && _hazardSpawnSeed <= 0.3f)
                {
                    newObstacle = null;
                }
                else if (_hazardSpawnSeed <= 0.7f)
                {
                    newObstacle = listOfObstacles[0];
                }
                else if (_hazardSpawnSeed > 0.7f)
                {
                    newObstacle = listOfObstacles[1];
                }
                Debug.Log(newObstacle);
                objects.Add(newObstacle);
            }

            if (isScoreMultipleof20 > 20 && isDistanceMultipleof100 > 100)
            {
                if (isScoreMultipleof20 % (int) scoreMultiplier == 0 ||
                    isDistanceMultipleof100 % (int) distanceMultiplier == 0)
                {
                    if (0f <= _hazardSpawnSeed && _hazardSpawnSeed <= 0.4f - increasingFactor / 100)
                    {
                        newObstacle = null;
                    }
                    else if (_hazardSpawnSeed <= 0.65f + increasingFactor / 100)
                    {
                        newObstacle = listOfObstacles[0];
                    }
                    else if (_hazardSpawnSeed > 0.65f + increasingFactor / 100)
                    {
                        newObstacle = listOfObstacles[1];
                    }

                    Debug.Log(newObstacle);
                    objects.Add(newObstacle);


                }
            }


            }*/

            if (objects.Count < maxObjects)

            {
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
                    Debug.Log(newObstacle);
                    objects.Add(newObstacle);

            }

            else if (objects.Count == maxObjects)
            {
                Debug.Log("We now have " + maxObjects + " objects in our scene.");

                if(objects.GetRange(0, 3).Contains(null))
                {
                    if (_hazardSpawnSeed <= 0.4f)
                    {
                        newObstacle = listOfObstacles[0];
                    }
                    else if (_hazardSpawnSeed > 0.4f)
                    {
                        newObstacle = listOfObstacles[1];
                    }
                    Debug.Log(newObstacle);

                    objects.Add(newObstacle);
                }
                else if (objects.GetRange(0, 3).Contains(listOfObstacles[0]))
                {
                    if (_hazardSpawnSeed <= 0.4f)
                    {
                        newObstacle = null;
                    }
                    else if (_hazardSpawnSeed > 0.4f)
                    {
                        newObstacle = listOfObstacles[1];
                    }
                    Debug.Log(newObstacle);

                    objects.Add(newObstacle);
                }
                else if (objects.GetRange(0, 3).Contains(listOfObstacles[1]))
                {
                    if (_hazardSpawnSeed <= 0.4f)
                    {
                        newObstacle = null;
                    }
                    else if (_hazardSpawnSeed > 0.4f)
                    {
                        newObstacle = listOfObstacles[0];
                    }
                    Debug.Log(newObstacle);

                    objects.Add(newObstacle);
                }
            }


            Management();
            return newObstacle;

        }


        private void Management()
        {
            int difference = objects.Count - maxObjects;

            if (objects.Count >= maxObjects)
            {

                objects.RemoveRange(0, difference);
            }
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