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

    public float speed;

    private Player player;
    private GameManager gameManager;
    private Rigidbody2D hazardRigidbody;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        hazardRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
         hazardRigidbody.AddForce(Vector2.left*speed);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {


        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log(coll.gameObject);

            player = coll.gameObject.GetComponent<Player>();

            player.KnockedOff();

            gameManager.PlayerHasBeenHit();

           Destroy(gameObject);

        }

    }
}
