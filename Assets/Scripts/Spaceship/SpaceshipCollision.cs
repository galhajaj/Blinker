using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipCollision : MonoBehaviour 
{
	void Start () 
    {
		
	}
	
	void Update () 
    {
		
	}

    void OnCollisionEnter2D(Collision2D coll) 
    {
        // hit obstacle
        if (coll.gameObject.tag == "Obstacle")
        {
            GameControl.instance.gameOver = true;
            SceneManager.LoadScene ("mainScene");
        }
        // hit orb
        else if (coll.gameObject.tag == "Orb")
        {
            Destroy(coll.gameObject);
        }
    }
}
