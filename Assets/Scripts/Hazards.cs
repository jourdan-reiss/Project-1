using UnityEngine;
using System.Collections;

public class Hazards : InteractiveObjects
{
/* In this class, I want to:
-handle collision with the player
-handle collision with the instantiated waves
-destroy itself on contact

This will eventually inherit from a general class called "Interactables"
 */

//------------------Code-------------------------------//

   /* private Player player;
    private GameManager gameManager;
    private Rigidbody2D hazardRigidbody;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        hazardRigidbody = GetComponent<Rigidbody2D>();
    }



    private void OnCollisionEnter2D(Collision2D coll)
    {


        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log(coll.gameObject);

            player = coll.gameObject.GetComponent<Player>();

            player.KnockedOff();


           Destroy(gameObject);

        }

    }*/
    private Player player;

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        player = coll.gameObject.GetComponent<Player>();
        player.KnockedOff();
    }
}
