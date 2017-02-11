using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByTime : MonoBehaviour {

	private float lifetimeForVel1 = 20f;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		float lifetime = -rb2d.velocity.x;
		if (lifetime != 0) {
			lifetime = lifetimeForVel1 / lifetime;
		}
		Destroy (gameObject, lifetime);
	}
}
