using System;
using UnityEngine;
using System.Collections;

public class ObjectMovement : Movement
{

    private float maxSpeed;

    protected override void FixedUpdate()
    {
        for (float _speed = base.speed; _speed < maxSpeed; _speed = (float) _speed + 0.1f)
        {
            base.FixedUpdate();
        }

    }
}
