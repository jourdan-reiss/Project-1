using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	//-----THIS IS A MOVEMEMENT SCRIPT FOR THE LINES--------//

	public float speed;
	private Rigidbody2D rb2D;



	void Start () 
	{
		rb2D = GetComponent <Rigidbody2D> ();
	}
		
	void FixedUpdate () 
	{
		rb2D.MovePosition (rb2D.position + Vector2.left * speed * Time.fixedDeltaTime); //we access the rigidbody component of the line, and then immediately move its position 
																						// by some value to the left, which is multiplied by a constant and time scalar, fixedDetaTime.
	}
}