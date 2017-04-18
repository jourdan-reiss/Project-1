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

    public float LeftDistanceFromMiddle()
    {
        return Mathf.Sqrt(
            (Midpoint().x - leftPoint.transform.position.x) * (Midpoint().x - leftPoint.transform.position.x) +
            (Midpoint().y - leftPoint.transform.position.y) * (Midpoint().y - leftPoint.transform.position.y));
    }

    public float RightDistanceFromMiddle()
    {
        return Mathf.Sqrt(
            (rightPoint.transform.position.x - Midpoint().x) * (rightPoint.transform.position.x - Midpoint().x) +
            (rightPoint.transform.position.y - Midpoint().y) * (rightPoint.transform.position.y - Midpoint().y));
    }

    public Vector2 LeftEndpointPosition()
    {
        return leftPoint.position;
    }

    public Vector2 RightEndpointPosition()
    {
        return rightPoint.position;
    }
}
