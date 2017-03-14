using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	public GameObject wave;
	public GameObject outline; 
	public LayerMask lineMask;


	public void SetOutline ()
	{
		wave.SetActive (false);
		outline.SetActive (true);
	}

	//Turns the outline and solid wave objects on and off. Both cannot be on at the same time.

	public void SetSolid ()
	{
		wave.SetActive (true);
		outline.SetActive (false);
	}

	public void Attach ()
	{
		RaycastHit2D checkIfWaveHit = Physics2D.Raycast (wave.transform.position, Vector2.down, Mathf.Infinity, lineMask);
		 //showots a ray directly downwards from the wave object to check if it hits a line.
		if (checkIfWaveHit.collider != null)
		{
			Debug.Log (checkIfWaveHit.collider.gameObject.name); 
			transform.SetParent (checkIfWaveHit.collider.transform); //the wave then becomes a child of the line.
		}
	}
}
