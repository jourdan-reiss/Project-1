using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Vector3 lastPlayerPosition;
	private float DistanceToMove;

	public GameObject player;


	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		lastPlayerPosition = player.transform.position; //the initial position at start, and the position on the last frame
	}
	
 	public void FixedUpdate () 
	{
		transform.position = new Vector3 (transform.position.x + DistanceToMove, transform.position.y, transform.position.z);

		DistanceToMove = player.transform.position.x  - lastPlayerPosition.x;

		lastPlayerPosition = player.transform.position;
	}

}
