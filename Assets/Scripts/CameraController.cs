using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    private Camera _camera;
    private float defaultCameraHeight;
    protected CircleCollider2D target;
    private Vector3 defaultCameraPosition;
	private Vector3 lastPlayerPosition;
	private float DistanceToMove;

	public GameObject player;


	void Start ()
	{
	    _camera = GetComponent<Camera>();
		player = GameObject.FindGameObjectWithTag ("Player");
		lastPlayerPosition = player.transform.position; //the initial position at start, and the position on the last frame

	    defaultCameraPosition = _camera.transform.position;
	    defaultCameraHeight = 4 * _camera.orthographicSize;
	}



    void OrthoZoom(Vector2 center, float regionHeight)
    {
        _camera.transform.position = new Vector3(center.x, center.y, defaultCameraPosition.z);
        _camera.orthographicSize = regionHeight / 2f;
    }

    CircleCollider2D GetTarget()
    {

        target = player.GetComponent<CircleCollider2D>();
        return target;
    }

 	public void FixedUpdate () 
	{
		DistanceToMove = player.transform.position.x  - lastPlayerPosition.x;
		transform.position = new Vector3 (transform.position.x + DistanceToMove, transform.position.y, transform.position.z);
		lastPlayerPosition = player.transform.position;
	}

}
