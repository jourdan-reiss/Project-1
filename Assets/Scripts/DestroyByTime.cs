using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
    /*
        This is a basic class which will be attached to any gameobject which has a finite lifetime.
        The time from it beign instantiated to death will be set in the inspector.
        As far as certain objects needing specific statements and methods ran on it after destroytimer is called,
        We can have children classes which inherit from DestroyByTime.
    */

    public float timeToDestroy;
    private bool _shallWeDestroy; //starts false, coroutine waits for a specified amount of time and sets it to true.



    void Awake()

    {
        StartCoroutine(DestroyTimer());
    }

    private void Update()
    {
        if (_shallWeDestroy)
            Destroy(gameObject);
    }

    public IEnumerator DestroyTimer()
    {
        _shallWeDestroy = false;
        yield return new WaitForSeconds(timeToDestroy);
        _shallWeDestroy = true;

    }
}
