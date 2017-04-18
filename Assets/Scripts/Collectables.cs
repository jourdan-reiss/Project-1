using System;
using UnityEngine;
using System.Collections;


    public class Collectables : InteractiveObjects
    {

        protected override void OnCollisionEnter2D(Collision2D coll)

        {
            base.OnCollisionEnter2D(coll);
            if (coll.gameObject.CompareTag("Player"))
            {
                Debug.Log("Picked up by player");
            }
        }
    }
