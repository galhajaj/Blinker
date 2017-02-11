using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsGenerator : MonoBehaviour {

	public GameObject asteroid;

	private float initialDelay = 1f;
	private float minDelay = 0f;
	private float maxDelay = 2f;

	private float xPos = 10f;
	private float minYPos = -5f;
	private float maxYPos = 5f;

	// Use this for initialization
	void Start () {
		StartCoroutine(StartAsteroidsWaves());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator StartAsteroidsWaves()
	{
		yield return new WaitForSeconds(initialDelay);
		while (GameControl.instance.gameOver == false) {
			ConstructAsteroid ();
			yield return new WaitForSeconds (Random.Range (minDelay, maxDelay));
		}
	}

	void ConstructAsteroid()
	{
		Instantiate (asteroid).transform.position = new Vector2 (xPos,Random.Range(minYPos,maxYPos));
	}


}
