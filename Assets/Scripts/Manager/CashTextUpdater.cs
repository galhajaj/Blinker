using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashTextUpdater : MonoBehaviour 
{
    public Text CashText;

	void Start () 
    {
		
	}
	
	void Update () 
    {
        int cash = PlayerPrefs.GetInt("Cash");
        CashText.GetComponent<Text>().text = cash.ToString() + " $";
	}
}
