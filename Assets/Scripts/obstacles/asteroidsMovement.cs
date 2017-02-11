using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidsMovement : MonoBehaviour {

	private Rigidbody2D rb2d;

	private float minVel = -3f;
	private float maxVel = -0.1f;

	private float minAngVel = -90;
	private float maxAngVel = 90;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.angularVelocity = Random.Range (minAngVel, maxAngVel);
		rb2d.velocity = new Vector2(Random.Range(minVel,maxVel),0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
