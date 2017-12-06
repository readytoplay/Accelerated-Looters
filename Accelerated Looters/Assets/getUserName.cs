using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getUserName : MonoBehaviour
{

	public InputField UserName;
	// Use this for initialization
	void Start()
	{
		UserName.text = PlayerPrefs.GetString("PlayerName");
	}

	public void SetName()
	{
		PlayerPrefs.SetString("PlayerName", UserName.text);
	}

}