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

    public LayerMask colliderMask;

    private bool grounded = true;
    private Rigidbody2D _playerRigidbody;
    private GameManager gameManager;


    private CameraController cameraController;

    private bool _isThePlayerStillAlive = true;


    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        cameraController = FindObjectOfType<CameraController>();


    }

    void OnCollisionExit2D(Collision2D other)
    {

        if (other.collider.gameObject.GetComponent<Wave>())
        {
            Debug.Log("Player has just jumped off" + other.gameObject.name);
            grounded = false;
            PlayerJump();
        }
    }

    void PlayerJump()
    {
        if (!grounded)
        {
            Debug.Log("Jump!");
            _playerRigidbody.AddForce(transform.up * thrust);
            grounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Hazards>())
        {
           cameraController.ActivateZoomMethod();
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Hazards>())
        {
            cameraController.DeactivateZoomMethod();


            if (_isThePlayerStillAlive)
            {
                Debug.Log("Our hero lives on!");
            }

        }
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
            cameraController.DeactivateZoomMethod();
        }
    }
}
