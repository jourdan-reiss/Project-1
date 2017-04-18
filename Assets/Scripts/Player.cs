using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
/* In this class, I aim to:

-communicate with the game manager if the player is still alive
-play set animations (Phase II)

*/
    public float speed;

    public Rigidbody2D _playerRigidbody;
    private GameManager gameManager;

//    private int _damage = 1;
    private bool _isThePlayerStillAlive = true;


    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        _playerRigidbody.AddForce(transform.right*speed);
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
