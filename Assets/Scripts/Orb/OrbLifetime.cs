using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbLifetime : MonoBehaviour 
{
    public float FadeFactor = 1.0F;
    public float FadingSize = 0.001F;
	void Start () 
    {
		
	}
	
	void Update () 
    {
        float shrinkingSize = Time.deltaTime * FadeFactor;
        this.transform.localScale -= new Vector3(shrinkingSize, shrinkingSize);

        if (this.transform.localScale.x <= FadingSize) // check only one side, it's symetrical...
            Destroy(this.gameObject);
	}
}
