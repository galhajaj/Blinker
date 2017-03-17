using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGenerator : MonoBehaviour 
{
    public GameObject OrbObject;

    public float FirstCreationDelay = 3.0F;
    public float CreationIntervalMin = 6.0F;
    public float CreationIntervalMax = 15.0F;
    private float _timeToCreate;

    public float PosXMin = -3.0F;
    public float PosXMax = 3.0F;
    public float PosYMin = -3.0F;
    public float PosYMax = 3.0F;

    public float MaxSize = 2.0F;
    public float MinSize = 0.25F;

    void Start () 
    {
        _timeToCreate = FirstCreationDelay;
	}
	
	void Update () 
    {
        _timeToCreate -= Time.deltaTime;
        if (_timeToCreate <= 0.0F)
        {
            _timeToCreate = Random.Range(CreationIntervalMin, CreationIntervalMax);

            Vector3 orbPosition = new Vector3(Random.Range(PosXMin, PosXMax), Random.Range(PosYMin, PosYMax));
            GameObject orb = Instantiate(OrbObject, orbPosition, Quaternion.identity) as GameObject;
            orb.transform.localScale *= Random.Range(MinSize, MaxSize); // orb size
            orb.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1.0F, 1.0F), Random.Range(-1.0F, 1.0F)); // velocity
        }
	}
}
