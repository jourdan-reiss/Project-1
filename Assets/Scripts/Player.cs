using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
/* In this class, I aim to:

-communicate with the game manager if the player is still alive
-play set animations (Phase II)

*/
    public float speed;
    public float thrust;

    private bool grounded = true;
    private Rigidbody2D _playerRigidbody;
    private GameManager gameManager;


    private bool _isThePlayerStillAlive = true;

    public delegate void TriggerEnterEvent();

    public static event TriggerEnterEvent TriggerEntered;


    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();


    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Waves"))
        {
            Debug.Log("Player has just jumped off" + other.gameObject.name);
            grounded = false;
            if (!grounded)
            {
                Debug.Log("Jump!");
                _playerRigidbody.AddForce(transform.up * thrust);
            }
            grounded = true;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {


    }

    void OnTriggerStay2D(Collider2D other)
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {

    }

    void FixedUpdate()
    {
        _playerRigidbody.AddForce(transform.right * speed);
    }

    public void KnockedOff()
    {
        _isThePlayerStillAlive = false;
        if (!_isThePlayerStillAlive)
        {
            Debug.Log("Player should be knocked off, we'll play an animation.");
            gameManager.PlayerHasBeenHit();
        }
    }
}
