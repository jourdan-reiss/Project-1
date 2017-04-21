using UnityEngine;
using System.Collections;

public class FloatingObjects : InteractiveObjects
{

    private Rigidbody2D rb2D;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

//    void OnCollisionEnter2D(Collision2D coll)
//    {
//        if (coll.gameObject.CompareTag("Wave"))
//        {
//
//        }
//    }
}
