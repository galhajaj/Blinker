using UnityEngine;
using System.Collections;

public class CheckEscapeKey : MonoBehaviour 
{
	void Start () 
    {
	
	}
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
