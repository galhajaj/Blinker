using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour 
{

    void Start () 
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition = new Vector3(newPosition.x, newPosition.y, 0.0F); // Z to 0
            transform.position = newPosition;
        }
    }
}
