using System;
using UnityEngine;
using System.Collections;


    public class Collectables : InteractiveObjects
    {

        private GameManager gameManager;

        void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        protected override void OnCollisionEnter2D(Collision2D coll)

        {
            base.OnCollisionEnter2D(coll);
            if (coll.gameObject.CompareTag("Player"))
            {
                Debug.Log("Picked up by player");
                gameManager.ScoreCount();
            }
        }
    }
