using System;
using UnityEngine;
using System.Collections;


    public class Collectables : InteractiveObjects
    {

        protected override void OnCollisionEnter2D(Collision2D coll)

        {
            Debug.Log("Picked up by player");
            base.OnCollisionEnter2D(coll);
        }
    }
