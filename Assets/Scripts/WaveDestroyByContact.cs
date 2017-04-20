using UnityEngine;
using System.Collections;

public class WaveDestroyByContact : MonoBehaviour
{
    private InteractiveObjects _objects;


    void Awake()
    {
        _objects = FindObjectOfType<InteractiveObjects>();
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        ContactPoint2D pointOfContact = coll.contacts[0];
        Debug.Log("Something hit us! It was" + pointOfContact.otherCollider.gameObject + ".");

        if (pointOfContact.otherCollider.gameObject == _objects)
        {
            _objects.DestroySelf();
        }
    }
}
