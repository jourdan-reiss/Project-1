using UnityEngine;
using System.Collections;

public class Hazards : MonoBehaviour
{
/* In this class, I want to:
-handle collision with the player
-handle collision with the instantiated waves
-destroy itself on contact

This will eventually inherit from a general class called "Interactables"
 */
    private Collider2D _hazardCollider;

    private Player player;
    private GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {

            player.KnockedOff();

            gameManager.PlayerHasBeenHit();

           Destroy(this.gameObject);

        }
    }
}
