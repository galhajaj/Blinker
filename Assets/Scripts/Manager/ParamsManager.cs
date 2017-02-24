using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class ParamsManager : MonoBehaviour 
{
    public bool ResetParamsInReg = false;
    public bool SetParamsFromFile = false;

    // dictionary of param and their init values
    private Dictionary<string, float> _params = new Dictionary<string, float>();    

    // =================================================================================================
    void Awake()
    {
        if (ResetParamsInReg)
        {
            PlayerPrefs.DeleteAll();
            Debug.LogWarning("Reset Registry Params - should be false in release!!!!");
        }

        if (SetParamsFromFile)
        {
            Debug.LogWarning("Set Params From File - should be false in release!!!! + The upgrades will not work!!!!");
        }

        updateDictionaryFromConfigFile();

        if (!isRegistryContainAllParams() || SetParamsFromFile)
        {
            updateRegistryFromDictionary();
        }
        else
        {
            updateDictionaryFromRegistry();
        }
    }
    // =================================================================================================
    void Start () 
    {
        
	}
    // =================================================================================================
    public float GetFloatParam(string name)
    {
        if (!_params.ContainsKey(name))
            Debug.LogError("Param " + name + "doesn't exist!");

        return _params[name];
    }
    // =================================================================================================
    public int GetIntParam(string name)
    {
        if (!_params.ContainsKey(name))
            Debug.LogError("Param " + name + "doesn't exist!");

        return Mathf.RoundToInt(_params[name]);
    }
    // =================================================================================================
    private void updateDictionaryFromConfigFile()
    {
        Debug.Log("updateDictionaryFromConfigFile");
        TextAsset textAsset = Resources.Load("SpaceshipParams") as TextAsset;
        var listToReturn = new List<string>();
        var arrayString = textAsset.text.Split('\n');
        foreach (var line in arrayString)
        {
            string paramName = line.Split(',')[0];
            float paramValue = (float)Convert.ToDouble(line.Split(',')[1]);
            _params.Add(paramName, paramValue);
        }
    }
    // =================================================================================================
    private void updateRegistryFromDictionary()
    {
        Debug.Log("updateRegistryFromDictionary");
        foreach (var key in _params.Keys.ToList())
        {
            PlayerPrefs.SetFloat(key, _params[key]);
        }
    }
    // =================================================================================================
    private void updateDictionaryFromRegistry()
    {
        Debug.Log("updateDictionaryFromRegistry");
        foreach (var key in _params.Keys.ToList())
        {
            if (!PlayerPrefs.HasKey(key))
                Debug.LogError("Param " + key + "doesn't exist in registry!");

            _params[key] = PlayerPrefs.GetFloat(key);
        }
    }
    // =================================================================================================
    private bool isRegistryContainAllParams()
    {
        foreach (var key in _params.Keys.ToList())
        {
            if (!PlayerPrefs.HasKey(key))
                return false;
        }

        return true;
    }
    // =================================================================================================
}
