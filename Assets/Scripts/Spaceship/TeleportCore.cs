using UnityEngine;
using System.Collections;

public class TeleportCore : MonoBehaviour 
{
    private float _cooldownDuration = 0.0F;

    // =================================================================================================
    void Start()
    {

    }
    // =================================================================================================
    void Update()
    {
        if (_cooldownDuration > 0.0F)
            _cooldownDuration -= Time.deltaTime;
    }
    // =================================================================================================
    public bool IsReady
    {
        get { return _cooldownDuration <= 0.0F; }
    }
    // =================================================================================================
    public void AddCooldown(float duration)
    {
        _cooldownDuration = duration;
    }
    // =================================================================================================
}

