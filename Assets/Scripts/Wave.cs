using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	public GameObject wave;
	public GameObject outline; 


	public void SetOutline ()
	{
		wave.SetActive (false);
		outline.SetActive (true);
	}

	public void SetSolid ()
	{
		wave.SetActive (true);
		outline.SetActive (false);
	}

	public void Attach ()
	{
	}
}
