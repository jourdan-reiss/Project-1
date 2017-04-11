using UnityEngine;
using System.Collections.Generic;//needed for generic classes such as Lists

namespace _Passive
{
    public class LineManager : MonoBehaviour
    {

        private List<GameObject> Lines; //create a list of my lines (more versatile than arrays),
                                        //angled brackets denote type of list.

        public int maxLines;
        public float initialSpawnTimer = 2f;
        public GameObject RegularLine;
        public GameObject BiggerLine;

        private Coroutine hazardcoroutine;
        private HazardGenerator _upcomingHazard;
        private float _hazardSpawnSeed;
        private bool GameOver;
        private GameObject lastLine;


        void Start()
        {
            _upcomingHazard = GetComponent<HazardGenerator>();

            Lines = new List<GameObject>();
            GameObject firstLine = Instantiate(BiggerLine); //makes sure that there is always a large line at start.
            Lines.Add(firstLine); //adds it immediately to the list of lines.
            lastLine = firstLine;
        }

        private float GetRandomInterval()
        {
            return Random.Range(1f, 5f); //this is a random time interval which we will use to create a loop via coroutine.
                                         //below, you can see the coroutine it will be used in.
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            Vector3 Endpoint = other.transform.position + (Vector3) other.offset; //determines the right edge of the current line
            GameObject nextLine = RandomLineSpawn(Endpoint);
            Lines.Add(nextLine); //adds a reference of that new line to our list
            Management(); //immediately calls management method to check number of elements in list
            _upcomingHazard.WhatAreWeSpawning();
            _upcomingHazard.Spawning(nextLine.GetComponent<Line>().Midpoint());
        }

        GameObject RandomLineSpawn(Vector3 spawnPosition) //Here, our method returns a game object at a specific position in 3D space, called SpawnPosition. This is so we can
                                                          //instantiate our game object at a position specified above in our OnTriggerEnter2D method.
        {
            GameObject lineToSpawn;
            float spawnSeed = Random.value;
            if (spawnSeed < 0.5f)
                lineToSpawn = BiggerLine;
            else
                lineToSpawn = RegularLine;

            lastLine = Instantiate(lineToSpawn, spawnPosition, Quaternion.identity) as GameObject; //see below;
            return lastLine; // makes sure to instantate the next line explicitly as a gameobject

        }

        void Management()
        {
            int difference = Lines.Count - maxLines;

            if (Lines.Count >= maxLines)
            {
                for (int i = 0; i < difference; i++)
                {
                    Destroy(
                        Lines[
                            i]); //starts a recursive algorithm which solely destroys indexed gameobjects on the list, from the oldest to a set number.
                }
                Lines.RemoveRange(0, difference); //removes references to destroyed lines from list.
            }
        }
    }
}