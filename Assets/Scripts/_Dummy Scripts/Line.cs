using UnityEngine;
using System.Collections;

public class Line: MonoBehaviour
{

    public Transform leftPoint;
    public Transform rightPoint;

    public Vector2 Midpoint()
    {
      return (rightPoint.transform.position + leftPoint.transform.position) / 2f ;


    }
}
