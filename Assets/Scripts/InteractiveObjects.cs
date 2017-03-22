using UnityEngine;
using System.Collections;

public class InteractiveObjects : MonoBehaviour
{
    protected Rigidbody2D rb2D;

    public virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
