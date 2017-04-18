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
        if (coll.gameObject.GetComponent<Collider2D>().CompareTag("Player"))
        {
            Debug.Log(coll.gameObject);
            Destroy(gameObject);
        }
        else if (coll.gameObject.GetComponent<Collider2D>().CompareTag("Waves"))
        {
            Debug.Log(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
