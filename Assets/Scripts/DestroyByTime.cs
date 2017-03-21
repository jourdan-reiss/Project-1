using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
    public float timeToDestroy;
    private bool _shallWeDestroy = false;
    private Coroutine destroyTimer;



    void Awake()

    {
        destroyTimer = StartCoroutine(DestroyTimer());
    }

    private void Update()
    {
        if (_shallWeDestroy == true)
            Destroy(this);
    }

    public IEnumerator DestroyTimer()
    {
        _shallWeDestroy = false;
        yield return new WaitForSeconds(timeToDestroy);
        _shallWeDestroy = true;
    }
}
