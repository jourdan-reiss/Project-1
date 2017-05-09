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
        public GameObject SmallLine;
        public GameObject RegularLine;
        public GameObject LargeLine;


//        private bool hasANewLineBeenSpawned = false;

        private Coroutine hazardcoroutine;
        private HazardGenerator _upcomingHazard;
        private float _hazardSpawnSeed;
        private bool GameOver;
        private GameObject lastLine;


        void Start()
        {
            _upcomingHazard = GetComponent<HazardGenerator>();

            Lines = new List<GameObject>();
            GameObject firstLine = Instantiate(LargeLine); //makes sure that there is always a large line at start.
            Lines.Add(firstLine); //adds it immediately to the list of lines.
            lastLine = firstLine;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
                Vector3 Endpoint = (Vector3) lastLine.GetComponent<Line>().Midpoint() + (Vector3) other.offset; //determines the right edge of the current line
                GameObject nextLine = RandomLineSpawn(Endpoint);



                nextLine.transform.position = new Vector3

                (nextLine.transform.position.x + nextLine.GetComponent<Line>().LeftDistanceFromMiddle(),
                nextLine.transform.position.y, nextLine.transform.position.z);

                Lines.Add(nextLine); //adds a reference of that new line to our list
                Management(); //immediately calls management method to check number of elements in list.
                _upcomingHazard.Spawning(nextLine.GetComponent<Line>().Midpoint());
                Debug.Log("we have instantiated a new line!");

        }

        /*void OnTriggerExit2D(Collider2D other)
        {
            if (!hasANewLineBeenSpawned)
            {
                Debug.Log("A line did not spawn");
                Vector3 Endpoint = (Vector3) lastLine.GetComponent<Line>().Midpoint() + (Vector3) other.offset; //determines the right edge of the current line
                GameObject nextLine = RandomLineSpawn(Endpoint);

                hasANewLineBeenSpawned = true;

                nextLine.transform.position = new Vector3

                (nextLine.transform.position.x + nextLine.GetComponent<Line>().LeftDistanceFromMiddle(),
                    nextLine.transform.position.y, nextLine.transform.position.z);

                Lines.Add(nextLine); //adds a reference of that new line to our list
                Management(); //immediately calls management method to check number of elements in list
                _upcomingHazard.WhatAreWeSpawning();
                _upcomingHazard.Spawning(nextLine.GetComponent<Line>().Midpoint());
            }
            else
            {
                hasANewLineBeenSpawned = false;
            }
        }*/

        GameObject RandomLineSpawn(Vector3 spawnPosition) //Here, our method returns a game object at a specific position in 3D space, called SpawnPosition. This is so we can
                                                          //instantiate our game object at a position specified above in our OnTriggerEnter2D method.
        {
            GameObject lineToSpawn;
            float spawnSeed = Random.value;
            if (spawnSeed <= 0.8f)
            {
                lineToSpawn = SmallLine;
            }

            else
            {
                lineToSpawn = RegularLine;
            }

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