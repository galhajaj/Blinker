using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TeleportDevice : MonoBehaviour 
{
    public SpaceshipData Data;
    public GameObject Core;

    private Queue<TeleportCore> _cores = new Queue<TeleportCore>();
    // =================================================================================================
    void Start()
    {
        for (int i = 0; i < Data.TeleportCoresNumber; ++i)
        {
            addCore();
        }
    }
    // =================================================================================================
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            teleport();
        }
    }
    // =================================================================================================
    private void addCore()
    {
        GameObject coreObject = Instantiate(Core, this.transform) as GameObject;
        TeleportCore coreScript = coreObject.GetComponent<TeleportCore>();
        _cores.Enqueue( coreScript );
    }
    // =================================================================================================
    private void teleport()
    {
        if (_cores.Peek().IsReady) // check if next core is ready
        {
            // add cooldown to used core
            _cores.Peek().AddCooldown(Data.TeleportCooldownDuration);

            // cycle used core to beginning of queue
            _cores.Enqueue(_cores.Dequeue());

            // move spaceship to mouse position
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition = new Vector3(newPosition.x, newPosition.y, 0.0F); // Z to 0
            transform.position = newPosition;
        }
    }
    // =================================================================================================

}


