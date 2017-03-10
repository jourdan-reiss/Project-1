 using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private Vector2 pointerPosition;
	public GameObject wavePrefab;
	public GameObject thing;


	private Wave currentWave;

	
	void Update () 
	{
		pointerPosition = Input.mousePosition;

		if (Input.GetButtonDown ("Fire1"))
			WavePrepare ();
		if (Input.GetButton ("Fire1")) 
		{
			currentWave.transform.position = WorldPosition ();
			currentWave.transform.position = new Vector3 (currentWave.transform.position.x, 0f, currentWave.transform.position.z);
		}
		if (Input.GetButtonUp ("Fire1"))
			currentWave.SetSolid ();
	}

	Vector3 WorldPosition ()
	{
		return Camera.main.ScreenToWorldPoint (new Vector3 (pointerPosition.x,pointerPosition.y , 10f));
	}

	void WavePrepare ()
	{
		
		GameObject prep = Instantiate (wavePrefab, WorldPosition (), Quaternion.identity) as GameObject;
		currentWave = prep.GetComponent <Wave> (); 
		currentWave.SetOutline ();
	}
}
