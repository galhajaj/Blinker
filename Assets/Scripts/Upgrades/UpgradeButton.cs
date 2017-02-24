using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour 
{
    public enum UpgradeVariableType
    {
        INT_PARAM,
        FLOAT_PARAM
    }

    public string Title;
    public string ParamName;
    public UpgradeVariableType ParamType;
    public float Addition;
    public float Percentage;
    public int Cost;

    private Text _text;
    private Button _button;

    // =================================================================================================
	void Start() 
    {
        _text = transform.Find("Text").gameObject.GetComponent<Text>();

        _button = this.GetComponent<Button>();
        _button.onClick.AddListener(TaskOnClick);
	}
    // =================================================================================================
	void Update() 
    {
        updateButtonText();
	}
    // =================================================================================================
    private void updateButtonText()
    {
        string valueStr = "";
        if (ParamType == UpgradeVariableType.INT_PARAM)
        {
            valueStr = Mathf.RoundToInt(PlayerPrefs.GetFloat(ParamName)).ToString();
        }
        else if (ParamType == UpgradeVariableType.FLOAT_PARAM)
        {
            valueStr = PlayerPrefs.GetFloat(ParamName).ToString("F");
        }

        string bonus = "";
        if (ParamType == UpgradeVariableType.INT_PARAM)
        {
            bonus = Addition.ToString();
            if (Addition > 0)
                bonus = "+" + bonus; 
        }
        else if (ParamType == UpgradeVariableType.FLOAT_PARAM)
        {
            bonus = Percentage.ToString("F") + "%";
            if (Percentage > 0)
                bonus = "+" + bonus;
        }

        _text.text = Title + ", " + valueStr + ", " + bonus;
    }
    // =================================================================================================
    void TaskOnClick()
    {
        if (ParamType == UpgradeVariableType.INT_PARAM)
        {
            float value = PlayerPrefs.GetFloat(ParamName) + Addition;
            PlayerPrefs.SetFloat(ParamName, value);
        }
        else if (ParamType == UpgradeVariableType.FLOAT_PARAM)
        {
            float value = PlayerPrefs.GetFloat(ParamName);
            PlayerPrefs.SetFloat(ParamName, value + value * Percentage / 100);
        }
    }
    // =================================================================================================
}
